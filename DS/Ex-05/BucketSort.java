/**
 * @author aviadh
 *
 */

import java.util.ArrayList;
import java.util.LinkedList;

public class BucketSort implements Sort {

	public int[] sort(int[] ar) {

		ArrayList<LinkedList<Integer>> buckets = new ArrayList<LinkedList<Integer>>();

		// Creates new ar.length buckets
		for (int i = 0; i < ar.length; i++) {
			buckets.add(new LinkedList<Integer>());
		}

		// Sorts each value to its destined bucket
		for (int i = 0; i < ar.length; i++) {
			buckets.get((int) (ar[i] * ar.length)).add(ar[i]);
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
			System.arraycopy(tempBucket, 0, ar, cur, buckets.get(i).size());
			cur += buckets.get(i).size();
		}
		return ar;
	}

}
