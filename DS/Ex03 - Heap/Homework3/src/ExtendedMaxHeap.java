public class ExtendedMaxHeap {
	private HeapElement[] heapArray;
	private int maxSize; // size of array
	private int currentSize; // number of nodes in array
	private HeapElement minElement;

	public ExtendedMaxHeap(int capacity) {
		this.maxSize = capacity;
		this.currentSize = 0;
		this.heapArray = new HeapElement[capacity]; // create array
	}

	public ExtendedMaxHeap(HeapElement[] elementsArray, int capacity) {

	}

	public void insert(HeapElement e) {
		if (this.currentSize != maxSize) {
			// minelement init
			minElement = minElement == null ? e : (minElement.getKey() > e.getKey() ? e : minElement);

			HeapElement newElement = new HeapElement(e.getKey(), e.getData());
			this.heapArray[this.currentSize] = newElement;
			trickleUp(this.currentSize++);
		}
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
		HeapElement root = heapArray[0];
		heapArray[0] = heapArray[--currentSize];
		trickleDown(0);
		return root;
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

	}

	public HeapElement getElementWithMinKey() {

	}

	// custom methods
	public boolean isEmpty() {
		return this.currentSize == 0;
	}
}