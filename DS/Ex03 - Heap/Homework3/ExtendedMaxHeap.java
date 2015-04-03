public class ExtendedMaxHeap {

	private long keysAvg;
	private HeapElement minKeyElement;
	private HeapElement[] heap;
	private int heapSize = this.heap.length;

	public ExtendedMaxHeap(int capacity) {

	}

	public ExtendedMaxHeap(HeapElement[] elementsArray, int capacity) {

	}

	public void insert(HeapElement e) {

	}

	public HeapElement deleteMax() throws HeapException {
		if (this.heap[0] == null)
			throw new HeapException("Empty queue, can't delete nothing");
		HeapElement maxElement = this.heap[0];
		// deletion logic comes here

		return maxElement;
	}

	public long getKeysAverage() {
		return this.keysAvg;
	}

	public HeapElement getElementWithMinKey() throws HeapException {
		if (this.minKeyElement == null)
			throw new HeapException("Queue is empty");
		return this.minKeyElement;
	}

	private int rightChild(int loc) {
		return (loc * 2) + 1;
	}

	private int leftChild(int loc) {
		return (loc * 2);
	}

	private int parent(int loc) {
		return loc / 2;
	}

}