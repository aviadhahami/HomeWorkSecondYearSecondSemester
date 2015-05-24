#include <stdio.h>
#include <stdlib.h>
#include <fcntl.h>
#include <unistd.h>
#include <string.h>
#include <pthread.h>
#include <sys/types.h>
#include <sys/stat.h>
#include "WordCounter.h"

// Size constants
#define MAX_BOUNDED_BUFF_CAPACITY 50
#define MAX_LOG_LINE_SIZE 1024
#define MAX_LINE_SIZE 1024
#define MAX_DATE_SIZE 25

// Tokens and formats
#define DATE_FORMAT "%Y-%m-%d %H:%M:%S"
#define FILE_TOKEN_SEPARATOR "\n"

// User CLI output
#define CLI_FORMAT "Follow format : WordCounter <file_name> <destination_logging_file_name>\n"
#define EXIT_MSG "Program terminated!\n"
#define LOGGING_STARTED "Logging results to file %s\n"
#define LISTENING_MSG "Listening..\n"
#define CONNECTED_MSG "Connection established..\n"
#define COUNTING_STARTED_MSG "File words count started..\n"
#define CMD_EXIT "exit\n"

// Errors stub
#define ERR_COULD_NOT_CONNECT "Connection can not be established\n"
#define ERR_COULD_NOT_OPEN "File %s could not opened\n"
#define ERR_COULD_NOT_COUNT "File %s could not be opened for counting\n"

/*
 *
 */
void dateprintf(char *buff, int max_size, const char *format) {

	// Initializes to Jan 1st 1970 UTC
	time_t timer;
	struct tm *tm_info;
	time(&timer);

	tm_info = localtime(&timer);
	strftime(buff, max_size, format, tm_info);
}

/*
 * Returns "1" if the given char is a letter, "0" otherwise
 *
 */
int is_alphabetic(unsigned char c) {
	return ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')) ? 1 : 0;
}

/*
 * Listener thread starting point.
 * Creates a named pipe (the name should be supplied by the main function) and waits for
 * a connection on it. Once a connection has been received, reads the data from it and
 * parses the file names out of the data buffer. Each file name is copied to a new string
 * and then enqueued to the files queue.
 * If the enqueue operation fails (returns 0), it means that the application is trying to exit.
 * Therefore the Listener thread should stop. Before stopping, it should remove the pipe file and
 * free the memory of the filename it failed to enqueue.
 */
void *run_listener(void *param) {
	ListenerData *listenerData;
	BoundedBuffer *boundedBuffer;
	int currentFile, num;
	char messages[READ_BUFF_SIZE], *fileToken, *fileNameBackup;

	// Initialize variables and generate new pipe
	listenerData = (ListenerData*) param;
	boundedBuffer = listenerData->buff;
	mknod(listenerData->pipe, S_IFIFO | FILE_ACCESS_RW, 0);

	// Run while true
	while (1) {

		// Listen to pipe
		printf(LISTENING_MSG);
		currentFile = open(listenerData->pipe, O_RDONLY);
		if (currentFile <= 0) {
			printf(ERR_COULD_NOT_CONNECT);
			return NULL;
		}
		printf(CONNECTED_MSG);

		// If connection established, read from pipe
		while ((num = read(currentFile, messages, READ_BUFF_SIZE)) > 0) {

			messages[num] = '\0';

			// Parse messages into filenames via tokens
			fileToken = strtok(messages, FILE_TOKEN_SEPARATOR);
			while (fileToken != NULL) {

				// Backup the filename
				fileNameBackup = malloc((strlen(fileToken) + 1) * sizeof(char));
				strcpy(fileNameBackup, fileToken);

				// Try to enqueue, and check if the application tried to exit
				if (bounded_buffer_enqueue(boundedBuffer, fileNameBackup)
						== 0) {
					// Free file name memo,remove current file from pipe, close the file and
					// terminate the block
					free(fileNameBackup);
					remove(listenerData->pipe);
					close(currentFile);
					return NULL;
				}
				fileToken = strtok(NULL, FILE_TOKEN_SEPARATOR);
			}
		}
		// Close file
		close(currentFile);
	}
	// Free filename backup memo
	free(fileNameBackup);
	return NULL;
}

/*
 * WordCounter thread starting point.
 * The word counter reads file names from the files queue, one by one, and counts the words in them.
 * It will write the result to a log file.
 * Then it should free the memory of the dequeued file name string (it was allocated by the Listener thread).
 * If the dequeue operation fails (returns NULL), it means that the application is trying
 * to exit and therefore the thread should simply terminate.
 */
void *run_wordcounter(void *param) {
	WordCounterData *wordCounterData;
	BoundedBuffer *boundedBuffer;
	char *dequeuedFile;
	int wordCount;
	// Initialize variables
	wordCounterData = (WordCounterData*) param;
	boundedBuffer = wordCounterData->buff;

	// Pull files from queue until end of input
	while ((dequeuedFile = bounded_buffer_dequeue(boundedBuffer)) != NULL) {

		// Count and log words
		wordCount = countwords_in_file(dequeuedFile);
		log_count(wordCounterData, dequeuedFile, wordCount);

		// Free buffer
		free(dequeuedFile);
	}
	return NULL;
}

/*
 * A word-counting function. Counts the words in file_name and returns the number.
 */
int countwords_in_file(char *file_name) {
	FILE *currentFile;
	unsigned char fileReadBuffer[FILE_READ_BUFFER_SIZE];
	int i, isLetter, amountOfCharsReaded;
	int numberOfWords = 0, inWordFlag = 0;

	// Try to open file, return -1 if failed
	currentFile = fopen(file_name, "r");
	if (!currentFile) {
		printf(ERR_COULD_NOT_COUNT, file_name);
		return -1;
	}

	// If we reached here, file was opened
	printf("%s %s\n", COUNTING_STARTED_MSG, file_name);

	// Read the file until EOF
	while (fgets((char*) fileReadBuffer, FILE_READ_BUFFER_SIZE, currentFile)
			!= NULL) {
		amountOfCharsReaded = strlen((char*) fileReadBuffer);

		for (i = 0; i < amountOfCharsReaded; i++) {

			// Check if current char is letter
			isLetter = is_alphabetic(fileReadBuffer[i]);

			// If current char is letter and we're not already in it
			if (isLetter && !inWordFlag) {
				// Switch flag and increase number of words
				inWordFlag = 1;
				numberOfWords++;

				// Otherwise it's whitespace, switch flag
			} else if (!isLetter && inWordFlag) {
				inWordFlag = 0;
			}
		}
	}
	// Close current file & return number of words
	fclose(currentFile);
	return numberOfWords;
}

/*
 * logs the number of words in the file to the output log file.
 */
void log_count(WordCounterData *counter_data, char *file_name, int count) {
	char fileReadBuffer[FILE_READ_BUFFER_SIZE], timeBuffer[MAX_DATE_SIZE];

	// Exit method if file is unreachable
	if (count == -1) {
		return;
	}

	// Get current time into @timeBuffer
	dateprintf(timeBuffer, MAX_DATE_SIZE, DATE_FORMAT);

	// Stringify logged line
	sprintf(fileReadBuffer, "%s File: %s || Number of words: %d\n", timeBuffer,
			file_name, count);

	// CLI output
	printf("%s File: %s || Number of words: %d\n", timeBuffer, file_name,
			count);

	// Put @fileReadBuffer into logging file
	fputs(fileReadBuffer, counter_data->log_file);
}

/*
 * Main function.
 * Reads command line arguments in the format:
 * 		./WordCounter pipe_name destination_log_file_name
 * Where pipe_name is the name of FIFO pipe that the Listener should create and
 * destination_log_file_name is the destination file name where the log should be written.
 * This function should create the files queue and prepare the parameters to the Listener and
 * WordCounter threads. Then, it should create these threads.
 * After threads are created, this function should control them as follows:
 * it should read input from user, and if the input line is "exit" (or "exit\n"), it should
 * set the files queue as "finished". This should make the threads terminate (possibly only
 * when the next connection is received).
 * At the end the function should join the threads and exit.
 */
int main(int argc, char *argv[]) {
	BoundedBuffer boundedBuffer;
	WordCounterData wordcounterData;
	ListenerData listenerData;
	pthread_t wordcounterThread, listenerThread;
	char *pipeFileName, *loggingFileLocation;
	char inputBuffer[STDIN_READ_BUFF_SIZE];

	// Verify CLI input
	if (argc != 3) {
		printf(CLI_FORMAT);
		return 1;
	}

	// Parse arguments
	pipeFileName = argv[1];
	loggingFileLocation = argv[2];

	// Initialize bounded buffer & word counter data
	bounded_buffer_init(&boundedBuffer, MAX_BOUNDED_BUFF_CAPACITY);
	wordcounterData.buff = &boundedBuffer;
	wordcounterData.log_file = fopen(loggingFileLocation, "w");

	// Try to open file, free resources and leave if failed
	if (!wordcounterData.log_file) {
		printf(ERR_COULD_NOT_OPEN, loggingFileLocation);
		bounded_buffer_finish(&boundedBuffer);
		bounded_buffer_destroy(&boundedBuffer);
		return 1;
	}

	// Initialize listener
	listenerData.buff = &boundedBuffer;
	listenerData.pipe = pipeFileName;

	// If we reached here, print logging started
	printf(LOGGING_STARTED, loggingFileLocation);

	// Pop pthreads
	pthread_create(&listenerThread, NULL, run_listener,
			(void*) (&listenerData));
	pthread_create(&wordcounterThread, NULL, run_wordcounter,
			(void*) (&wordcounterData));

	// Read input constantly untill exit message is recieved
	do {
		fgets(inputBuffer, STDIN_READ_BUFF_SIZE, stdin);
	} while (strcmp(inputBuffer, CMD_EXIT) != 0);

	// Free buffer resources
	bounded_buffer_finish(&boundedBuffer);

	// Join and kill threads
	pthread_join(wordcounterThread, NULL);
	pthread_join(listenerThread, NULL);

	// Close logger
	fclose(wordcounterData.log_file);

	// Kill buffer
	bounded_buffer_destroy(&boundedBuffer);

	// Display bye message and exit nicely
	printf(EXIT_MSG);
	return 0;
}

