public class ExtendedMaxHeap {

	private long keysAvg;
	private HeapElement[] heap;

	public ExtendedMaxHeap(int capacity) {
		// empty array with no data
		this.heap = new HeapElement[capacity];
		maxHeapify();
	}

	private void maxHeapify() {
		// TODO Auto-generated method stub
		
	}

	public ExtendedMaxHeap(HeapElement[] elementsArray, int capacity) {
		this.heap = elementsArray;
		maxHeapify();

	}

	public void insert(HeapElement e) {

	}

	public HeapElement deleteMax() throws HeapException {

	}

	public long getKeysAverage() {
		return this.keysAvg;
	}

	public HeapElement getElementWithMinKey() {

	}

}