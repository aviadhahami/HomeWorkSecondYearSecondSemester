import javax.management.RuntimeErrorException;

public class MatrixMultThread implements Runnable {
	// ---- final static globals --//
	private static final int n = 1024; // n is the matrix size
	private static final int classThreadCount = 5; // n is the matrix size

	// ---- end of final static globals --//

	// -- OO variables --//
	private float[][] i_Mat_A, i_Mat_B, i_ResMat;
	private int i_startRow, i_endRow;
	private Thread currentThread;

	// -- End of OO variables //
	/**
	 * 
	 * @param mat_A
	 *            - first matrix
	 * @param mat_b
	 *            - second matrix
	 * @param resultMat
	 *            -sult matrix -> post multiplication
	 * @param startPoint
	 *            - which row we start from
	 * @param endPoint
	 *            - which row we end with
	 */
	public MatrixMultThread(float[][] mat_A, float[][] mat_b, float[][] resultMat, int startPoint, int endPoint) {
		float[][] i_Mat_A = mat_A;
		float[][] i_Mat_B = mat_b;
		float[][] i_ResMat = resultMat;
		int i_startRow = startPoint;
		int i_endRow = endPoint;
	}

	@Override
	public void run() {
		// simple matrices multiplication logic following this..
		for (int i = i_startRow; i <= i_endRow; i++) {
			for (int j = 0; j < i_Mat_A.length; j++) {
				for (int k = 0; k < i_Mat_A.length; k++) {
					i_ResMat[i][j] += (i_Mat_A[i][k] * i_Mat_B[k][j]);
				}
			}
		}
	}

	private void start() {
		currentThread = currentThread == null ? new Thread(this) : currentThread;
		currentThread.start();
	}

	/**
	 * 
	 * @param a
	 *            - Left hand matrix
	 * @param b
	 *            - Right hand matrix
	 * @param threadCount
	 *            - Number of threads
	 * @return - matrices multiplication
	 */
	public static float[][] mult(float[][] a, float[][] b, int threadCount) {
		// Testing for legit matrix
		if (a[0].length != b[0].length || a[0].length != a.length || b[0].length != b.length) {
			throw new RuntimeException("Matrices are not equal or not sqaure !");
		}

		MatrixMultThread[] threadPool = new MatrixMultThread[threadCount];
		int i_startingPoint, i_endingPoint;
		int i_currentMatrixSize = a.length;
		/**
		 * amout of rows as the suggested solution
		 */
		int i_amountOfRowsNeeded = (i_currentMatrixSize / threadCount);

		float[][] finalizedMatrix = new float[i_currentMatrixSize][i_currentMatrixSize];

		for (int i = 0; i < threadCount; i++) {
			i_startingPoint = i * i_amountOfRowsNeeded;
			i_endingPoint = i_startingPoint - 1 + i_amountOfRowsNeeded;
			i_endingPoint = i_currentMatrixSize <= i_endingPoint ? i_currentMatrixSize - 1 : i_endingPoint;

			// Initialize the thread
			threadPool[i] = new MatrixMultThread(a, b, finalizedMatrix, i_startingPoint, i_endingPoint);
			// LOCKED AND LOADED ! (Tania sound)
			threadPool[i].start();
			// THREAD LUNCHED !
		}

		// now we collect the prizes :D
		for (int i = 0; i < threadCount; i++) {
			try {
				threadPool[i].currentThread.join();
			} catch (Exception e) {
				// And I pray to god we won't reach this
				e.printStackTrace();
			}
		}
		return finalizedMatrix;
	}

	/**
	 * 
	 * @param n
	 *            - size of the square matrix
	 * @return - randomized matrix
	 */
	public static float[][] randomMatrixGenerator(int n) {
		float[][] matrix = new float[n][n];
		for (int i = 0; i < matrix.length; i++) {
			for (int j = 0; j < matrix.length; j++) {
				matrix[i][j] = (float) Math.random() * 100;
			}
		}
		return matrix;
	}

	/**
	 * @Description - should implement a main method that generates two
	 *              1024x1024 matrices filled with random values. Then, it
	 *              should multiply them using the mult method described above
	 *              using at least two threads. Also, it should measure the time
	 *              in milliseconds it took to perform the multiplication and
	 *              print this time to the screen.
	 * @param args
	 *            - empty
	 */
	public static void main(String[] args) {
		// Generating matrices
		float[][] matrix_A = randomMatrixGenerator(n);
		float[][] matrix_B = randomMatrixGenerator(n);

		// GOGOGO
		double startTime = System.currentTimeMillis();
		float[][] resultMatrix = mult(matrix_A, matrix_B, classThreadCount);
		double endTime = System.currentTimeMillis();
		System.out.println("Time is : " + (endTime - startTime));
	}

}
