public class InsertionSort implements Sort {

	public int[] sort(int[] i_InputArray) {

		int i_TempInteger = 0; // Stores the examined value
		int i; // Holds the index of the current compared value

		// Goes through each value of the array, starting from the second one
		for (int j = 1; j < i_InputArray.length; j++) {

			i_TempInteger = i_InputArray[j];
			i = j - 1;

			// Compares each value with its previous,
			// including all previous examined values
			while (i >= 0 && i_InputArray[i] > i_TempInteger) {
				i_InputArray[i + 1] = i_InputArray[i];
				i--;
			}

			// Locates the examined value in its place
			i_InputArray[i + 1] = i_TempInteger;
		}
		return i_InputArray;
	}
}