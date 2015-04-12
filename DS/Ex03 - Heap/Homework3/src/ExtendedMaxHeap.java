public class ExtendedMaxHeap {
	private HeapElement[] heapArray;
	private int maxSize; // size of array
	private int currentSize; // number of nodes in array
	private HeapElement minElement;
	private long keysAvg;
	private int keysSum;

	public ExtendedMaxHeap(int capacity) {
		this.maxSize = capacity;
		this.currentSize = 0;
		this.heapArray = new HeapElement[capacity]; // create array
		this.keysAvg = 0;
		this.keysSum = 0;
	}

	public ExtendedMaxHeap(HeapElement[] elementsArray, int capacity) {
		this.maxSize = capacity;
		this.currentSize = 0;
		this.heapArray = new HeapElement[capacity]; // create array
		this.keysAvg = 0;
		this.keysSum = 0;

		for (HeapElement currentElement : elementsArray) {
			insert(currentElement);
		}

	}

	public void insert(HeapElement e) throws HeapException {
		if (this.currentSize != maxSize) {
			// minElement setting
			minElement = minElement == null ? e : (minElement.getKey() > e.getKey() ? e : minElement);

			HeapElement newElement = new HeapElement(e.getKey(), e.getData());
			this.heapArray[this.currentSize] = newElement;
			trickleUp(this.currentSize++);
			updateSum(e.getKey(), true);
			updateAvg();

		} else {
			throw new HeapException("Capacity reached ! ");
		}
	}

	private void updateSum(int key, boolean actionFlag) {
		// actionFalg -> if true we increase sum
		this.keysSum = actionFlag ? this.keysSum + key : this.keysSum - key;

	}

	private void updateAvg() {
		this.keysAvg = this.currentSize == 0 ? 0 : this.keysSum / this.currentSize;
	}

	public void trickleUp(int index) {
		int parent = (index - 1) / 2;
		HeapElement bottom = heapArray[index];

		while (index > 0 && heapArray[parent].getKey() < bottom.getKey()) {
			heapArray[index] = heapArray[parent]; // move it down
			index = parent;
			parent = (parent - 1) / 2;
		}
		heapArray[index] = bottom;
	}

	public HeapElement deleteMax() throws HeapException {
		if (this.currentSize == 0) {
			throw new HeapException("heap is empty, can't delete");
		} else {
			HeapElement root = heapArray[0];
			heapArray[0] = heapArray[--currentSize];
			trickleDown(0);

			updateSum(root.getKey(), false);
			updateAvg();

			return root;
		}
	}

	public void trickleDown(int index) {
		int largerChild;
		HeapElement top = heapArray[index]; // save root
		while (index < currentSize / 2) // while node has at
		{ // least one child,
			int leftChild = 2 * index + 1;
			int rightChild = leftChild + 1;
			// find larger child
			if (rightChild < currentSize && // (rightChild exists?)
					heapArray[leftChild].getKey() < heapArray[rightChild].getKey())
				largerChild = rightChild;
			else
				largerChild = leftChild;
			// top >= largerChild?
			if (top.getKey() >= heapArray[largerChild].getKey())
				break;
			// shift child up
			heapArray[index] = heapArray[largerChild];
			index = largerChild; // go down
		} // end while
		heapArray[index] = top; // root to index
	} // end trickleDown()

	public long getKeysAverage() {
		if (this.currentSize == 0 ) throw new HeapException("no keys -> avg is zero");
		return this.keysAvg;
	}

	public HeapElement getElementWithMinKey() throws HeapException {
		if (this.currentSize == 0) {
			throw new HeapException("Heap is empty!, no min element boy");
		} else {
			return this.minElement;
		}
	}

	public boolean isEmpty() {
		return this.currentSize == 0;
	}
}