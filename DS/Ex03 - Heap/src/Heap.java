public class Heap {

	private Node root;
	private int heapSize;

	public Heap() {
		this.setRoot(null);
		this.heapSize = 0;
	}

	public Heap(Node root) {
		this.setRoot(root);
		this.heapSize = 1;
	}

	public void insert(Node node) {

	}



	/* GETTERS AND SETTERS BELOW ! */

	public Node getRoot() {
		return root;
	}

	private void setRoot(Node root) {
		this.root = root;
	}

	public int getHeapSize() {
		return heapSize;
	}

}