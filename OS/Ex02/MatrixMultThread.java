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
				matrix_A[i][j] = (float) Math.random() * 100;
			}
		}
		for (int i = 0; i < matrix_B.length; i++) {
			for (int j = 0; j < matrix_B.length; j++) {
				matrix_A[i][j] = (float) Math.random() * 100;
			}
		}

		double startTime = System.currentTimeMillis();
		float[][] resultMatrix = mult(matrix_A, matrix_B, classThreadCount);
		double endTime = System.currentTimeMillis();
		System.out.println("Time is : " + (endTime - startTime));
	}
}
