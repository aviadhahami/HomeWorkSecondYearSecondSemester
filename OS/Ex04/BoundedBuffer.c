#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <pthread.h>
#include "BoundedBuffer.h"

// Create boolean type variable
typedef int bool;

// Boolean macros
#define true 1
#define false 0

// Initialization macros
#define _INIT_VALUE_ZERO 0
#define _INIT_VALUE_NULL NULL

/*
 * Initializes the buffer with the specified capacity.
 * This function should allocate the buffer, initialize its properties
 * and also initialize its mutex and condition variables.
 * It should set its finished flag to 0.
 */
void bounded_buffer_init(BoundedBuffer *buff, int capacity) {
	buff->buffer = malloc(capacity * sizeof(char*));
	buff->size = _INIT_VALUE_ZERO;
	buff->capacity = capacity;
	buff->head = _INIT_VALUE_ZERO;
	buff->tail = _INIT_VALUE_ZERO;
	pthread_mutex_init(&(buff->mutex), _INIT_VALUE_NULL);
	pthread_cond_init(&(buff->cv_empty), _INIT_VALUE_NULL);
	pthread_cond_init(&(buff->cv_full), _INIT_VALUE_NULL);
	buff->finished = _INIT_VALUE_ZERO;
}

/*
 * Enqueue a string (char pointer) to the buffer.
 * This function should add an element to the buffer. If the buffer is full,
 * it should wait until it is not full, or until it has finished.
 * If the buffer has finished (either after waiting or even before), it should
 * simply return 0.
 * If the enqueue operation was successful, it should return 1. In this case it
 * should also signal that the buffer is not empty.
 * This function should be synchronized on the buffer's mutex!
 */
int bounded_buffer_enqueue(BoundedBuffer *buff, char *data) {

	// Enter critical section
	pthread_mutex_lock(&(buff->mutex));

	// Buffer complete
	if (buff->finished) {
		pthread_mutex_unlock(&(buff->mutex));
		return 0;
	}

	bool buffSizeEqualsBuffCapacity = buff->size == buff->capacity;

	// We loop until space is freed
	while (buffSizeEqualsBuffCapacity) {
		pthread_cond_wait(&(buff->cv_empty), &(buff->mutex));

		// Check whether buffer completed
		if (buff->finished) {
			pthread_mutex_unlock(&(buff->mutex));
			return 0;
		}

		// Update the variable
		buffSizeEqualsBuffCapacity = buff->size == buff->capacity;
	}

	// Load data to buffer and signal complete
	buff->buffer[buff->tail] = data;
	buff->tail = (buff->tail + 1) % buff->capacity;
	buff->size++;
	pthread_cond_signal(&(buff->cv_full));

	// Unlock critical section
	pthread_mutex_unlock(&(buff->mutex));
	return 1;

}

/*
 * Dequeues a string (char pointer) from the buffer.
 * This function should remove the head element of the buffer and return it.
 * If the buffer is empty, it should wait until it is not empty, or until it has finished.
 * If the buffer has finished (either after waiting or even before), it should
 * simply return NULL.
 * If the dequeue operation was successful, it should signal that the buffer is not full.
 * This function should be synchronized on the buffer's mutex!
 */
char *bounded_buffer_dequeue(BoundedBuffer *buff) {
	char* data;

	// Enter critical section
	pthread_mutex_lock(&(buff->mutex));

	while (buff->size == _INIT_VALUE_ZERO) {

		// Check if buffer finished
		if (buff->finished) {
			pthread_mutex_unlock(&(buff->mutex));
			return _INIT_VALUE_NULL;
		}

		// Wait()
		pthread_cond_wait(&(buff->cv_full), &(buff->mutex));
	}

	// Save data from buffer and signal complete
	data = buff->buffer[buff->head];
	buff->head = (buff->head + 1) % buff->capacity;
	buff->size--;
	pthread_cond_signal(&(buff->cv_empty));

	// Leave critical section and unlock
	pthread_mutex_unlock(&(buff->mutex));
	return data;
}

/*
 * Sets the buffer as finished.
 * This function sets the finished flag to 1 and then wakes up all threads that are
 * waiting on the condition variables of this buffer.
 * This function should be synchronized on the buffer's mutex!
 */
void bounded_buffer_finish(BoundedBuffer *buff) {

	// Enter critical section
	pthread_mutex_lock(&(buff->mutex));

	// Set finish and notify
	buff->finished = 1;
	pthread_cond_signal(&(buff->cv_empty));
	pthread_cond_signal(&(buff->cv_full));

	// Leave critical section and unlock
	pthread_mutex_unlock(&(buff->mutex));
}

/*
 * Frees the buffer memory and destroys mutex and condition variables.
 */
void bounded_buffer_destroy(BoundedBuffer *buff) {

	// __Destruct__
	free(buff->buffer);
	pthread_mutex_destroy(&(buff->mutex));
	pthread_cond_destroy(&(buff->cv_empty));
	pthread_cond_destroy(&(buff->cv_full));
}
