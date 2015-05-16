public class CountingSort implements Sort {

	public int[] sort(int[] input) {
		int io_MaxValueInArray = input[0];

		// find the range
		for (int i_CurrentItemFromInput : input) {
			io_MaxValueInArray = Math.max(io_MaxValueInArray, i_CurrentItemFromInput);
		}

		return coutingSort(input, io_MaxValueInArray);
	}

	/*
	 * So I took the pseudo code from class and broke it down. Only thing I
	 * changed is the order of decrementing in the last method as if I perform
	 * it as shown in class I get IndexOutOfBound
	 */
	private int[] coutingSort(int[] i_OriginalArray, int io_MaxValueInArray) {

		int[] io_OccourenceCounter = new int[io_MaxValueInArray + 1];
		int[] i_SortedArray = new int[i_OriginalArray.length];

		// C = array [1..k] set to zero
		initalizeToZero(io_OccourenceCounter);

		// for j = 1 to length[A]
		// do C[A[j]] = C[A[j]]+1
		for (int j = 0; j < i_OriginalArray.length; j++) {
			io_OccourenceCounter[i_OriginalArray[j]]++;
		}
		// for j = 2 to length[C]
		// do C[j] = C[j]+C[j-1]
		for (int j = 1; j < io_OccourenceCounter.length; j++) {
			io_OccourenceCounter[j] += io_OccourenceCounter[j - 1];
		}

		// for j = length[A] downto 1
		// do B[C[A[j]]] = A[j]
		// C[A[j]] = C[A[j]]-1

		// Error in pseudo code :)
		for (int j = io_OccourenceCounter.length - 1; j > 0; j--) {
			io_OccourenceCounter[i_OriginalArray[j]]--;
			i_SortedArray[io_OccourenceCounter[i_OriginalArray[j]]] = i_OriginalArray[j];
		}

		return i_SortedArray;
	}

	/*
	 * Just initialize
	 */
	private void initalizeToZero(int[] io_OccourenceCounter) {
		for (int i = 0; i < io_OccourenceCounter.length; i++) {
			io_OccourenceCounter[i] = 0;
		}
	}

}
