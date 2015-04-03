public class ExtendedMaxHeap {

	private long keysAvg;
	private HeapElement minKeyElement;
	private HeapElement[] heap;
	private int heapSize = this.heap.length;

	private static final int ROOT = 1;

	public ExtendedMaxHeap(int capacity) {

	}

	public ExtendedMaxHeap(HeapElement[] elementsArray, int capacity) {

	}

	public void insert(HeapElement e) {
		this.heap[++this.heapSize] = e;
		int currentPos = this.heapSize;

		while (this.heap[currentPos].getKey() > this.heap[parent(currentPos)].getKey()) {
			swap(currentPos, parent(currentPos));
			currentPos = parent(currentPos);
		}
	}

	private void swap(int currentPos, int parent) {
		HeapElement temp;
		temp = this.heap[currentPos];
		this.heap[currentPos] = this.heap[parent];
		this.heap[parent] = temp;

	}

	public HeapElement deleteMax() throws HeapException {
		if (this.heap[ROOT] == null)
			throw new HeapException("Empty queue, can't delete nothing");
		HeapElement maxElement = this.heap[ROOT];
		this.heap[ROOT] = this.heap[this.heapSize--];
		maxHeapify(ROOT);
		return maxElement;
	}

	private void maxHeapify(int loc) {
		// TODO Auto-generated method stub

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

	private boolean isLeaf(int loc) {
		return (loc >= (this.heapSize / 2) && loc <= this.heapSize) ? true : false;
	}

}