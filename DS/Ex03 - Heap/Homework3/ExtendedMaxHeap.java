public class ExtendedMaxHeap {

	private long keysAvg;
	private HeapElement minKeyElement;
	private HeapElement[] heap;

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

	public HeapElement getElementWithMinKey() {
		if (this.minKeyElement == null)
			throw new HeapException("Queue is empty");
		return this.minKeyElement;
	}

}