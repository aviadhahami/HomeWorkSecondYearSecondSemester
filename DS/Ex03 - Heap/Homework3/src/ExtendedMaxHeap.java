public class ExtendedMaxHeap {

	private HeapElement minKeyElement;
	private HeapElement[] heap;
	private int heapSize;
	private int capacity;
	private int keysSum;
	private long keysAvg;

	private static final boolean debug = true;
	private static final int ROOT = 1;

	public ExtendedMaxHeap(int capacity) {
		this.capacity = capacity;
		this.heapSize = 0;
		this.keysAvg = 0;
		this.keysSum = 0;
		this.heap = new HeapElement[this.capacity + 1];
		// init the head
		this.heap[0] = new HeapElement(Integer.MAX_VALUE, null);
		this.minKeyElement = null;
	}

	public ExtendedMaxHeap(HeapElement[] elementsArray, int capacity) {
		boolean exceptionFlag = false;
		// flagging the needed checks according to the Ex instructions
		exceptionFlag = elementsArray == null || elementsArray.length == 0 || capacity < elementsArray.length ? true : false;
		if (exceptionFlag) {
			// means we have something wrong
			throw new HeapException("failed to initialize a heap. check capacity & initial array");
		} else {
			this.keysSum = 0; // must init
			this.minKeyElement = elementsArray[0];
			this.capacity = capacity + 1;
			this.heapSize = elementsArray.length;
			this.heap = new HeapElement[this.capacity + 1];
			this.heap[0] = new HeapElement(Integer.MAX_VALUE, null);
			int localKeysSum = 0;
			int j = 0;
			for (int i = ROOT; i < elementsArray.length; i++) {
				this.heap[i] = elementsArray[j];
				this.minKeyElement = this.minKeyElement.getKey() > this.heap[i].getKey() ? this.heap[i] : this.minKeyElement;
				localKeysSum += elementsArray[j].getKey();
				j++;
			}
			updateAvg(localKeysSum, true); // true for increase
			buildMaxHeap();
		}

	}

	private void buildMaxHeap() {
		for (int loc = (this.heapSize / 2); loc >= 1; loc--) {
			maxHeapify(loc);
		}

	}

	public void insert(HeapElement e) {
		if (this.heapSize + 1 > this.capacity) {
			throw new HeapException("Overload on insert! Capacity is " + this.capacity + " and the current size is " + this.heapSize);
		} else {

			this.heap[++this.heapSize] = e;
			updateAvg(e.getKey(), true);
			int currentPos = this.heapSize;

			// updating minimal key element if necessary
			this.minKeyElement = this.minKeyElement == null ? e : this.minKeyElement.getKey() > e.getKey() ? e : this.minKeyElement;
			while (this.heap[currentPos].getKey() > this.heap[parent(currentPos)].getKey()) {
				swap(currentPos, parent(currentPos));
				currentPos = parent(currentPos);
			}
		}

	}

	private void updateAvg(int key, boolean avgFlag) {
		// if @avgFlag is true -> we should increase the avg
		// reduce it otherwise.

		this.keysSum = avgFlag ? this.keysSum + key : this.keysSum - key;
		this.keysAvg = this.keysSum / this.heapSize;

	}

	private void swap(int currentPos, int parent) {
		HeapElement temp;
		temp = this.heap[currentPos];
		this.heap[currentPos] = this.heap[parent];
		this.heap[parent] = temp;

	}

	public HeapElement deleteMax() throws HeapException {
		if (this.heap[ROOT] == null) {
			throw new HeapException("Empty queue, can't delete nothing");
		} else {
			HeapElement maxElement = this.heap[ROOT];
			this.heap[ROOT] = this.heap[this.heapSize--];
			updateAvg(maxElement.getKey(), false);
			maxHeapify(ROOT);
			return maxElement;
		}
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
		// isLeaf checks whether the location is legit and if it's within our
		// limits
		return (loc >= (this.heapSize / 2) && loc <= this.heapSize) ? true : false;
	}

	public void print() {
		for (int i = 1; i < this.heapSize / 2; i++) {
			System.out.print(" PARENT : " + this.heap[i].getKey() + " LEFT CHILD : " + this.heap[2 * i].getKey() + " RIGHT CHILD :"
					+ this.heap[2 * i + 1].getKey());
			System.out.println();
		}
	}

	public static void main(String... arg) {

		ExtendedMaxHeap maxHeap = new ExtendedMaxHeap(20);
		int[] numArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
		int sum = 0;
		for (int e : numArray) {
			maxHeap.insert(new HeapElement(e, null));
			sum += e;
		}
		maxHeap.buildMaxHeap();
		if (debug) {
			System.out.println("The Max Heap is ");
			maxHeap.print();
			System.out.println("The max val is " + maxHeap.deleteMax().getKey() + " The min key is " + maxHeap.getElementWithMinKey().getKey());
			System.out.println("# of elements in heap : " + maxHeap.heapSize + ", keys sum is : " + maxHeap.keysSum);
			System.out.println("The avg is " + maxHeap.getKeysAverage() + " and should be " + (sum - 11) / (numArray.length - 1));

		}
	}
}