public class Node {
	private Node leftChild;
	private Node rightChild;
	private int data;

	public Node(Node leftChild, Node rightChild, int data) {
		this.leftChild = leftChild;
		this.rightChild = rightChild;
		this.data = data;
	}

	// Getters
	public Node getRightChild() {
		return this.rightChild;
	}

	public Node getLeftChild() {
		return this.leftChild;
	}

	public int getData() {
		return this.data;
	}

	// Setters

	public void setRightChild(Node node) {
		this.rightChild = node;
	}

	public void setLeftChild(Node node) {
		this.leftChild = node;
	}

	public void setData(int data) {
		this.data = data;
	}
}
