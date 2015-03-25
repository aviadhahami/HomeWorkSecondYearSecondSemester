public class Heap {

	private Node root;

	public Heap() {
		this.setRoot(null);
	}

	public Heap(Node root) {
		this.setRoot(root);
	}

	public Node getRoot() {
		return root;
	}

	public void setRoot(Node root) {
		this.root = root;
	}
}
