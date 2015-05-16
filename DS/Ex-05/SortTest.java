
public class SortTest {
	public static void main(String[] args) {
		int inputArrayCopy1[] = { 9, 0, 15, 17, 0, 13, 13, 14, 14, 6, 17, 5, 4, 18, 4, 18, 19, 11, 7, 7 };
		int inputArrayCopy2[] = { 9, 0, 15, 17, 0, 13, 13, 14, 14, 6, 17, 5, 4, 18, 4, 18, 19, 11, 7, 7 };
		int inputArrayCopy3[] = { 9, 0, 15, 17, 0, 13, 13, 14, 14, 6, 17, 5, 4, 18, 4, 18, 19, 11, 7, 7 };
		int inputArrayCopy4[] = { 9, 0, 15, 17, 0, 13, 13, 14, 14, 6, 17, 5, 4, 18, 4, 18, 19, 11, 7, 7 };

		MergeSort mergeSort = new MergeSort();
		MergeSortModified mergeSortModified = new MergeSortModified();
		BucketSort bucketSort = new BucketSort();
		CountingSort countingSort = new CountingSort();

		testSort(mergeSort, "MergeSort", inputArrayCopy1);
		testSort(mergeSortModified, "MergeSortModified", inputArrayCopy2);
		testSort(bucketSort, "BucketSort", inputArrayCopy3);
		testSort(countingSort, "CountingSort", inputArrayCopy4);

	}

	private static void testSort(Sort sort, String sortName, int[] array) {
		System.out.println(sortName + " test-");
		System.out.println("Input:");
		ArrayFactory.printArray(array);
		System.out.println("Ouput:");
		ArrayFactory.printArray(sort.sort(array));
	}

}
