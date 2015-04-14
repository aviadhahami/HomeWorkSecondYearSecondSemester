public class MatrixMultThread implements Runnable {

	private static final int n = 1024; // n is the matrix size

	@Override
	public void run() {
		// TODO Auto-generated method stub

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

		return null;
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
		float[][] matrix_A = new float[n][n];
		float[][] matrix_B = new float[n][n];

		for (int i = 0; i < matrix_A.length; i++) {
			for (int j = 0; j < matrix_A.length; j++) {
				matrix_A[i][j] = (float) Math.random();
			}
		}
		for (int i = 0; i < matrix_B.length; i++) {
			for (int j = 0; j < matrix_B.length; j++) {
				matrix_A[i][j] = (float) Math.random();
			}
		}

	}
}
