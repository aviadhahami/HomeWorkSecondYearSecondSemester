/*
 * Name: Aviya Sela
 * ID No: 302221403
 */

public class MatrixMultThread implements Runnable {

	private float[][] a;
	private float[][] b;
	private float[][] result;
	private int startRow;
	private int endRow;

	public MatrixMultThread(float[][] a, float[][] b, float[][] result,
			int startRow, int endRow) {
		this.a = a;
		this.b = b;
		this.result = result;
		this.startRow = startRow;
		this.endRow = endRow;
	}

	@Override
	public void run() {
		int size = a.length;

		// Multiplies the rows between startRow and endRow
		// and inserts the result into the result matrix
		for (int i = startRow; i <= endRow; i++) {
			for (int j = 0; j < size; j++) {
				for (int k = 0; k < size; k++) {
					result[i][j] += a[i][k] * b[k][j];
				}
			}
		}

	}

	/**
	 * Multiplies two given matrices using threadCount threads. 
	 * @param a - Left hand matrix
	 * @param b - Right hand matrix
	 * @param threadCount - Number of threads
	 * @return The result of a * b
	 */
	public static float[][] mult(float[][] a, float[][] b, int threadCount) {

		int size = a.length;

		// Verifies the given matrices are at the correct format
		if (a[0].length != a.length || b[0].length != b.length
				|| a.length != b.length) {
			throw new IllegalArgumentException(
					"Matrices must be square and of equal size");
		}

		// Sets an upper limit on the number of threads
		if (threadCount > size) {
			threadCount = size;
		}

		// Creates an array of threads to do the multiplication
		Thread[] threads = new Thread[threadCount];

		int rowsForThread = size / threadCount;
		float[][] result = new float[size][size];

		// Initiates and starts each of the threads as MarixMultThreads
		for (int i = 0; i < threadCount; i++) {

			// Calculates startRow and endRow of each thread
			int startRow = i * rowsForThread;
			int endRow = startRow + rowsForThread - 1;

			// Makes sure division between threads doesn't overflow last thread
			if (i == threadCount - 1) {
				endRow = size - 1;
			}
			//endRow = a.length <= endRow ? a.length-1 : endRow;

			// Initiates and starts thread i
			threads[i] = new Thread(new MatrixMultThread(a, b, result,
					startRow, endRow));
			threads[i].start();

		}

		// Waits for all running threads to finish
		for (int i = 0; i < threadCount; i++) {
			try {
				threads[i].join();
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
		}

		return result;
	}
	
	public static void main(String[] args) {

		int size = 1024;
		int numOfThreads = 1;
		
		// Generates two 1024x1024 matrices filled with random values
		float[][] a = generateRandMatrix(size);
		float[][] b = generateRandMatrix(size);

		// Multiplies matrices using mult method and measures the time it takes
		long startTime = System.currentTimeMillis();

		mult(a, b, numOfThreads);

		long endTime = System.currentTimeMillis();
		System.out.println("Total Time: " + (endTime - startTime)
				+ " Milliseconds");

	}

	// Generates a square matrix at length size and fills it with random values
	private static float[][] generateRandMatrix(int size) {

		float[][] matrix = new float[size][size];

		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				matrix[i][j] = (float) Math.random() * 100;
			}
		}

		return matrix;
	}

}
