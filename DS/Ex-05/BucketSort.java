/**
 * @author aviadh
 *
 */

import java.util.ArrayList;
import java.util.LinkedList;

public class BucketSort implements Sort {

	public int[] sort(int[] io_InputArray) {

		int i_ArrayMinimalValue = io_InputArray[0];
		int i_ArrayMaximalValue = io_InputArray[0];

		for (int i_CurrentNumberFromInput : io_InputArray) {
			i_ArrayMinimalValue = Math.min(i_ArrayMinimalValue, i_CurrentNumberFromInput);
			i_ArrayMaximalValue = Math.max(i_ArrayMaximalValue, i_CurrentNumberFromInput);
		}

		ArrayList<LinkedList<Integer>> buckets = new ArrayList<LinkedList<Integer>>();

		// Creates new ar.length buckets
		for (int i = 0; i < io_InputArray.length; i++) {
			buckets.add(new LinkedList<Integer>());
		}

		// Sorts each value to its destined bucket
		int i_PositionFormula;
		int i_ArraySize = io_InputArray.length;

		for (int i = 0; i < io_InputArray.length; i++) {
			i_PositionFormula = ((io_InputArray[i] - i_ArrayMinimalValue) / i_ArrayMaximalValue) * i_ArraySize;
			buckets.get(i_PositionFormula).add(io_InputArray[i]);
		}

		// Sorts each bucket, using Insertion Sort

		InsertionSort insertion = new InsertionSort();
		int cur = 0;

		for (int i = 0; i < buckets.size(); i++) {

			// Copies each bucket from a LinkedList form to an array form
			int[] tempBucket = new int[buckets.get(i).size()];

			for (int j = 0; j < tempBucket.length; j++) {
				tempBucket[j] = buckets.get(i).get(j);
			}

			// Sorts the bucket
			insertion.sort(tempBucket);

			// Concatenates the buckets into one array
			System.arraycopy(tempBucket, 0, io_InputArray, cur, buckets.get(i).size());
			cur += buckets.get(i).size();
		}
		return io_InputArray;
	}
}
