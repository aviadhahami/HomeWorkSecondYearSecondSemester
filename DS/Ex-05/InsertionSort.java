public class InsertionSort implements Sort {

	public int[] sort(int[] ar) {

		int temp = 0; // Stores the examined value
		int i; // Holds the index of the current compared value

		// Goes through each value of the array, starting from the second one
		for (int j = 1; j < ar.length; j++) {

			temp = ar[j];
			i = j - 1;

			// Compares each value with its previous,
			// including all previous examined values
			while (i >= 0 && ar[i] > temp) {
				ar[i + 1] = ar[i];
				i--;
			}

			// Locates the examined value in its place
			ar[i + 1] = temp;
		}
		return ar;
	}
}