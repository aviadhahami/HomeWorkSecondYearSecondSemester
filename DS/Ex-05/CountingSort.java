import java.util.Arrays;

/**
 * @author aviadh
 *
 */
public class CountingSort implements Sort {

	public int[] sort(int[] input) {
		int io_MaxValueInArray = input[0];
		int io_MinValueInArray = input[0];
		// find the range
		for (int i_CurrentItemFromInput : input) {
			io_MaxValueInArray = Math.max(io_MaxValueInArray, i_CurrentItemFromInput);
			io_MinValueInArray = Math.min(io_MinValueInArray, i_CurrentItemFromInput);
		}

		return countingSort(input, io_MinValueInArray, io_MaxValueInArray);
	}

	public int[] countingSort(int[] a, int low, int high) {
		int[] counts = new int[high - low + 1]; // this will hold all possible
												// values, from low to high
		for (int x : a)
			counts[x - low]++; // - low so the lowest possible value is always 0

		int current = 0;
		for (int i = 0; i < counts.length; i++) {
			Arrays.fill(a, current, current + counts[i], i + low); // fills
																	// counts[i]
																	// elements
																	// of value
																	// i + low
																	// in
																	// current
			current += counts[i]; // leap forward by counts[i] steps
		}
		return a;
	}

}
