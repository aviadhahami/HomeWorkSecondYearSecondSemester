import java.util.Iterator;

public class BankQueue {
	private ExtendedMaxHeap bankQueue;

	public BankQueue(int maxQueueSize) {
		this.bankQueue = new ExtendedMaxHeap(maxQueueSize);
	}

	public BankQueue(PersonWithMoney[] people, int maxQueueSize) {
		HeapElement[] elementsArray = new HeapElement[people.length];
		int i = 0;
		for (PersonWithMoney p : people) {
			elementsArray[i] = new HeapElement(p.getMoney(), p.getName());
			i++;
		}
		this.bankQueue = new ExtendedMaxHeap(elementsArray, maxQueueSize);
	}

	public void enqueue(PersonWithMoney p) {
		HeapElement e = new HeapElement(p.getMoney(), p.getName());
		bankQueue.insert(e);
	}

	public PersonWithMoney dequeue() {
		HeapElement e = bankQueue.deleteMax();
		return new PersonWithMoney((String) e.getData(), e.getKey());
	}

	public void stealFromFirstInQueue(int ammount) {
		HeapElement e = bankQueue.deleteMax();
		PersonWithMoney p = new PersonWithMoney((String) e.getData(), e.getKey() - ammount);
		enqueue(p);
	}

	public int getAverageMoneyInQueue() {
		return (int) bankQueue.getKeysAverage();

	}

	public PersonWithMoney getPoorestPerson() {
		HeapElement e = this.bankQueue.getElementWithMinKey();
		return new PersonWithMoney((String) e.getData(), e.getKey());
	}

}
