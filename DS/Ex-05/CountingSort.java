public class CountingSort implements Sort {

	public int[] sort(int[] input) {
		int io_MaxValueInArray = input[0];
		// find the range
		for (int i_CurrentItemFromInput : input) {
			io_MaxValueInArray = Math.max(io_MaxValueInArray, i_CurrentItemFromInput);
		}
		return coutingSort(input, io_MaxValueInArray);
	}

	private int[] coutingSort(int[] i_OriginalArray, int io_MaxValueInArray) {
		int[] io_OccourenceCounter = new int[io_MaxValueInArray];
		int[] i_SortedArray = new int[io_MaxValueInArray];

		initalizeToZero(io_OccourenceCounter);
		return null;
	}

	private void initalizeToZero(int[] io_OccourenceCounter) {
		for (int i = 0; i < io_OccourenceCounter.length; i++) {
			io_OccourenceCounter[i] = 0;
		}
	}

	//
	// CountingSort(A,B,k)
	// C = array [1..k] set to zero
	// for j = 1 to length[A]
	// do C[A[j]] = C[A[j]]+1
	// for j = 2 to length[C]
	// do C[j] = C[j]+C[j-1]
	// for j = length[A] downto 1
	// do B[C[A[j]]] = A[j]
	// C[A[j]] = C[A[j]]-1

}
