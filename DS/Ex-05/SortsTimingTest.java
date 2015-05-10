import java.io.IOException;
import java.lang.Math;


public class SortsTimingTest {

	public static void main(String[] args) throws IOException {
		MergeSort mergeSort = new MergeSort();
		MergeSortModified mergeSortModified = new MergeSortModified();
		BucketSort bucketSort = new BucketSort();
		CountingSort countingSort = new CountingSort();
		
		int n1 = 500000;
		int n2 = 1000000;
		double span1;
		double span2;
		
		System.out.println("MergeSort test:");
		span1 = calculateAverageSortTime(n1,mergeSort);
		span2 = calculateAverageSortTime(n2,mergeSort);
		printTimeSpans(n1, span1, n2, span2);
		
		System.out.println("MergeSortModified test:");
		span1 = calculateAverageSortTime(n1,mergeSortModified);
		span2 = calculateAverageSortTime(n2,mergeSortModified);
		printTimeSpans(n1, span1, n2, span2);
		
		System.out.println("Bucketsort test:");
		span1 = calculateAverageSortTime(n1,bucketSort);
		span2 = calculateAverageSortTime(n2,bucketSort);
		printTimeSpans(n1, span1, n2, span2);
		
		System.out.println("Countingsort test:");
		span1 = calculateAverageSortTime(n1,countingSort);
		span2 = calculateAverageSortTime(n2,countingSort);
		printTimeSpans(n1, span1, n2, span2);

		
	}
	
	public static void printTimeSpans(int size1, double span1, int size2, double span2) {
		System.out.println("For size " + size1 +" we got time: " + span1);
		System.out.println("For size " + size2 +" we got time: " + span2);
	}
	
	
	public static double calculateAverageSortTime(int size, Sort sort) {
		int numOfSamples = 	100;
		long total = 0;
		for (int i=0; i<numOfSamples; i++) {
			int [] ar = ArrayFactory.generateRandomArray(size);
			long start = System.nanoTime();
			sort.sort(ar);
			long end = System.nanoTime();
			total += end - start;
		}
		return (total / (numOfSamples*Math.pow(10, 9))); //calculate the average, and change units from nano-seconds to seconds
	}
}