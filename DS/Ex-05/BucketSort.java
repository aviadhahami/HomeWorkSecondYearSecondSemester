/**
 * @author Aviad Hahami && Hila Ben Hamo
 *
 */

import java.util.ArrayList;
import java.util.LinkedList;

public class BucketSort implements Sort {

	public int[] sort(int[] io_InputArray) {

		int i_ArrayMinimalValue = io_InputArray[0];
		int i_ArrayMaximalValue = io_InputArray[0];

		//find range
		for (int i_CurrentNumberFromInput : io_InputArray) {
			i_ArrayMinimalValue = Math.min(i_ArrayMinimalValue, i_CurrentNumberFromInput);
			i_ArrayMaximalValue = Math.max(i_ArrayMaximalValue, i_CurrentNumberFromInput);
		}


		ArrayList<LinkedList<Integer>> i_Buckets = new ArrayList<LinkedList<Integer>>();

		// Creates new ar.length buckets
		for (int i = 0; i < io_InputArray.length + 1; i++) {
			i_Buckets.add(new LinkedList<Integer>());
		}

		// Sorts each value to its destined bucket
		double i_PositionFormula;
		int i_ArraySize = io_InputArray.length;
		int i_MinMaxDiferential = i_ArrayMaximalValue - i_ArrayMinimalValue;
		for (int i = 0; i < io_InputArray.length; i++) {
			i_PositionFormula = (io_InputArray[i] - i_ArrayMinimalValue);
			i_PositionFormula /= i_MinMaxDiferential;
			i_PositionFormula *= i_ArraySize;
			Math.floor(i_PositionFormula);
			i_Buckets.get((int) i_PositionFormula).add(io_InputArray[i]);
		}

		// Sorts each bucket, using Insertion Sort
		InsertionSort i_insertionSort = new InsertionSort();
		int i_currentBucket = 0;

		for (int i = 0; i < i_Buckets.size(); i++) {

			// Copies each bucket from a LinkedList form to an array form
			int[] i_TempBucket = new int[i_Buckets.get(i).size()];

			for (int j = 0; j < i_TempBucket.length; j++) {
				i_TempBucket[j] = i_Buckets.get(i).get(j);
			}

			// Sorts the bucket
			i_insertionSort.sort(i_TempBucket);

			// Concatenates the buckets into one array
			System.arraycopy(i_TempBucket, 0, io_InputArray, i_currentBucket, i_Buckets.get(i).size());
			i_currentBucket += i_Buckets.get(i).size();
		}
		return io_InputArray;
	}
}
