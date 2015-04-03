public class ExtendedMaxHeap {

	private long keysAvg;
	private HeapElement minKeyElement;
	private HeapElement[] heap;
	private int heapSize;
	private int capacity;

	private static final int ROOT = 1;

	public ExtendedMaxHeap(int capacity) {
		this.capacity = capacity;
		this.heapSize = 0;
		this.heap = new HeapElement[this.capacity + 1];
		// init the head
		this.heap[0] = new HeapElement(Integer.MAX_VALUE, null);
	}

	public ExtendedMaxHeap(HeapElement[] elementsArray, int capacity) {
		boolean exceptionFlag = false;
		// flagging the needed checks according to the Ex instructions
		exceptionFlag = elementsArray == null || elementsArray.length == 0 || capacity < elementsArray.length ? true : false;
		if (exceptionFlag) {
			// means we have something wrong
			throw new HeapException("failed to initialize a heap. check capacity & initial array");
		} else {
			this.capacity = capacity + 1;
			this.heapSize = elementsArray.length;
			this.heap = new HeapElement[this.capacity + 1];
			this.heap[0] = new HeapElement(Integer.MAX_VALUE, null);
			// we copy the data over. Why not pointer? not sure...
			for (int i = ROOT; i < elementsArray.length; i++) {
				this.heap[i] = elementsArray[i];
			}
			buildMaxHeap();
		}

	}

	private void buildMaxHeap() {
		for (int loc = (this.heapSize / 2); loc >= 1; loc--) {
			maxHeapify(loc);
		}

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
		if (!isLeaf(loc)) {
			// check for bigger child
			if (this.heap[loc].getKey() < this.heap[leftChild(loc)].getKey() || this.heap[loc].getKey() < this.heap[rightChild(loc)].getKey()) {
				// pick biggest child
				if (this.heap[leftChild(loc)].getKey() > this.heap[rightChild(loc)].getKey()) {
					swap(loc, leftChild(loc));
					maxHeapify(leftChild(loc));
				} else {
					swap(loc, rightChild(loc));
					maxHeapify(rightChild(loc));
				}
			}
		}

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