public class ExtendedMaxHeap {
	private HeapElement[] heapArray;
	private int maxSize; // size of array
	private int currentSize; // number of nodes in array

	public ExtendedMaxHeap(int capacity) {
		this.maxSize = capacity;
		this.currentSize = 0;
		this.heapArray = new HeapElement[capacity]; // create array
	}

	public ExtendedMaxHeap(HeapElement[] elementsArray, int capacity) {

	}

	public void insert(HeapElement e) {

	}

	public HeapElement deleteMax() throws HeapException {

	}

	public long getKeysAverage() {

	}

	public HeapElement getElementWithMinKey() {

	}

	// custom methods
	public boolean isEmpty() {
		return this.currentSize == 0;
	}
}