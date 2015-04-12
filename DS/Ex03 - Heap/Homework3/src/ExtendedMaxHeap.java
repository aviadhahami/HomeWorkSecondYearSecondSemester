public class ExtendedMaxHeap {
	private HeapElement[] heapArray;
	private int heapCapacity; // size of array
	private int currentHeapSize; // number of nodes in array
	private HeapElement minElement;
	private long keysAvg;
	private int keysSum;

	public ExtendedMaxHeap(int capacity) {
		this.heapCapacity = capacity;
		this.currentHeapSize = 0;
		this.heapArray = new HeapElement[capacity];
		this.keysAvg = 0;
		this.keysSum = 0;
	}

	public ExtendedMaxHeap(HeapElement[] elementsArray, int capacity) {
		this.heapCapacity = capacity;
		this.currentHeapSize = 0;
		this.heapArray = new HeapElement[capacity];
		this.keysAvg = 0;
		this.keysSum = 0;

		for (HeapElement currentElement : elementsArray) {
			insert(currentElement);
		}

	}

	public void insert(HeapElement e) throws HeapException {
		if (this.currentHeapSize != heapCapacity) {
			// minElement setting
			// if the min elem is null -> set it to the current element
			// else -> if the value of the curr element is smaller -> replace
			minElement = minElement == null ? e : (minElement.getKey() > e.getKey() ? e : minElement);

			HeapElement newElement = new HeapElement(e.getKey(), e.getData());
			this.heapArray[this.currentHeapSize] = newElement;

			percUp(this.currentHeapSize++);
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
		this.keysAvg = this.currentHeapSize == 0 ? 0 : this.keysSum / this.currentHeapSize;
	}

	public void percUp(int index) {
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
		if (this.currentHeapSize == 0) {
			throw new HeapException("heap is empty, can't delete");
		} else {
			HeapElement root = heapArray[0];
			heapArray[0] = heapArray[--currentHeapSize];
			percDown(0);

			updateSum(root.getKey(), false);
			updateAvg();

			return root;
		}
	}

	public void percDown(int index) {
		int biggestChild;
		HeapElement top = heapArray[index]; // save root
		// while node has at-least one child
		while (index < currentHeapSize / 2) {
			int leftChild = 2 * index + 1;
			int rightChild = leftChild + 1;
			// find larger child
			if (rightChild < currentHeapSize && // (rightChild exists?)
					heapArray[leftChild].getKey() < heapArray[rightChild].getKey())
				biggestChild = rightChild;
			else
				biggestChild = leftChild;
			// top >= largerChild?
			if (top.getKey() >= heapArray[biggestChild].getKey())
				break;
			// perc child up
			heapArray[index] = heapArray[biggestChild];
			index = biggestChild; // go down
		}
		heapArray[index] = top; // root to index
	}

	public long getKeysAverage() {
		if (this.currentHeapSize == 0)
			throw new HeapException("no keys -> avg is zero");
		return this.keysAvg;
	}

	public HeapElement getElementWithMinKey() throws HeapException {
		if (this.currentHeapSize == 0) {
			throw new HeapException("Heap is empty!, no min element boy");
		} else {
			return this.minElement;
		}
	}

	public boolean isEmpty() {
		return this.currentHeapSize == 0;
	}
}