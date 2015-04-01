public class ExtendedMaxHeap {

	private long keysAvg;
	private HeapElement[] heap;
	private HeapElement minKey;

	public ExtendedMaxHeap(int capacity) {
		// empty array with no data
		this.heap = new HeapElement[capacity];
		this.keysAvg = 0;
		this.minKey = null;
	}

	public ExtendedMaxHeap(HeapElement[] elementsArray, int capacity) {
		this.heap = elementsArray;
		/* forcing a minimal element --> will get sorted on the go */
		this.minKey = this.heap[0]; 
		buildMaxHeap();
		this.keysAvg = this.keysAvg / this.heap.length;
	}

	private void buildMaxHeap() {
		int heapSize = this.heap.length;
		for (int i = heapSize / 2; i > 1; i--) {
			MaxHeapify(i);
		}
	}

	private void MaxHeapify(int i) {
		int left = 2 * i;
		int right = 2 * i + 1;
		int bigger = i;
		if (left <= this.heap.length && this.heap[left].getKey() > this.heap[bigger].getKey()) {
			bigger = left;
			this.minKey = this.minKey.getKey() < this.heap[left].getKey() ? this.minKey : this.heap[left];
		}
		if (right <= this.heap.length && this.heap[right].getKey() > this.heap[bigger].getKey()) {
			bigger = right;
			this.minKey = this.minKey.getKey() < this.heap[right].getKey() ? this.minKey : this.heap[right];
		}
		if (bigger != i) {
			swap(i, bigger);
			MaxHeapify(bigger);
		}

	}

	private void swap(int i, int bigger) {
		HeapElement temp = this.heap[i];
		this.heap[i] = this.heap[bigger];
		this.heap[bigger] = temp;
	}

	public void insert(HeapElement e) {

	}

	public HeapElement deleteMax() throws HeapException {
		return null;

	}

	public long getKeysAverage() {
		return this.keysAvg;
	}

	public HeapElement getElementWithMinKey() {
		return null;

	}

}