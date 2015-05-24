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
	char buffer[FILE_READ_BUFFER_SIZE], time_buff[MAX_DATE_SIZE];

	// Exit if file could not counted
	if (count == -1)
		return;

	// Get time log
	dateprintf(time_buff, MAX_DATE_SIZE, DATE_FORMAT);

	// Save log line to string
	sprintf(buffer, "%s File: %s || Number of words: %d\n", time_buff,
			file_name, count);

	printf("%s File: %s || Number of words: %d\n", time_buff, file_name, count);

	// Output line to log file
	fputs(buffer, counter_data->log_file);
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
	pthread_t wordcounter, listener;
	char *pipe_file_name, *destination_log_file;
	char input_buffer[STDIN_READ_BUFF_SIZE];
	BoundedBuffer bounded_buff;
	WordCounterData counter_data;
	ListenerData listener_data;

	// Check argument count
	if (argc != 3) {
		printf(CLI_FORMAT);
		return 1;
	}

	// Get arguments
	pipe_file_name = argv[1];
	destination_log_file = argv[2];

	// Initialize bounded buffer
	bounded_buffer_init(&bounded_buff, MAX_BOUNDED_BUFF_CAPACITY);

	// Initialize word counter data
	counter_data.buff = &bounded_buff;
	counter_data.log_file = fopen(destination_log_file, "w");

	if (!counter_data.log_file) {
		printf(ERR_COULD_NOT_OPEN, destination_log_file);
		bounded_buffer_finish(&bounded_buff);
		bounded_buffer_destroy(&bounded_buff);
		return 1;
	}

	// Initialize listener data
	listener_data.buff = &bounded_buff;
	listener_data.pipe = pipe_file_name;

	printf(LOGGING_STARTED, destination_log_file);

	// Start threads
	pthread_create(&listener, NULL, run_listener, (void*) (&listener_data));
	pthread_create(&wordcounter, NULL, run_wordcounter,
			(void*) (&counter_data));

	// Read input in a loop until exit command is given
	do {
		fgets(input_buffer, STDIN_READ_BUFF_SIZE, stdin);
	} while (strcmp(input_buffer, CMD_EXIT) != 0);

	// Set buffer as finished
	bounded_buffer_finish(&bounded_buff);

	// Join threads
	pthread_join(wordcounter, NULL);
	pthread_join(listener, NULL);

	// Close log file
	fclose(counter_data.log_file);

	// Destroy buffer
	bounded_buffer_destroy(&bounded_buff);

	printf(EXIT_MSG);
	return 0;
}

