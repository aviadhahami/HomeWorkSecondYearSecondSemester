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

	public int[] countingSort(int[] io_InputArray, int io_MinValueInArray, int io_MaxValueInArray) {
		// this will hold all possible values, from low to high

		int[] counts = new int[io_MaxValueInArray - io_MinValueInArray + 1];

		for (int i_CurrenyArrayItem : io_InputArray)
			// - low so the lowest possible value is always 0
			counts[i_CurrenyArrayItem - io_MinValueInArray]++;

		int i_CurrentNumber = 0;
		for (int i = 0; i < counts.length; i++) {
			// fills counts[i] elements of value i + low in current
			Arrays.fill(io_InputArray, i_CurrentNumber, i_CurrentNumber + counts[i], i + io_MinValueInArray);
			i_CurrentNumber += counts[i]; // leap forward by counts[i] steps
		}
		return io_InputArray;
	}

}
