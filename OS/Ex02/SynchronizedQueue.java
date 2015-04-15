/**
 * A synchronized bounded-size queue for multithreaded producer-consumer
 * applications.
 * 
 * @param <T>
 *            Type of data items
 */
public class SynchronizedQueue<T> {

	private T[] buffer;
	private int producers;
	// custom private memebers
	private int i_size;
	private int i_startingPoint;
	private int i_producers;
	private int i_capacity;

	// locking synchronizer
	private Object queLocker;

	/**
	 * Constructor. Allocates a buffer (an array) with the given capacity and
	 * resets pointers and counters.
	 * 
	 * @param capacity
	 *            Buffer capacity
	 */
	@SuppressWarnings("unchecked")
	public SynchronizedQueue(int capacity) {
		// Standard constructor
		this.buffer = (T[]) (new Object[capacity]);
		i_startingPoint = 0;
		producers = 0;
		i_size = 0;
		// local object
		this.i_capacity = capacity;
		queLocker = new Object();
	}

	/**
	 * Dequeues the first item from the queue and returns it. If the queue is
	 * empty but producers are still registered to this queue, this method
	 * blocks until some item is available. If the queue is empty and no more
	 * items are planned to be added to this queue (because no producers are
	 * registered), this method returns null.
	 * 
	 * @return The first item, or null if there are no more items
	 * @see #registerProducer()
	 * @see #unregisterProducer()
	 */
	public T dequeue() {
		synchronized (queLocker) {
			while (this.i_size == 0) {
				if (producers == 0) {
					return null;
				}
				try {
					queLocker.wait();
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
			T i_item = buffer[i_startingPoint];
			i_size--;
			i_startingPoint = (i_startingPoint++) & i_capacity;
			queLocker.notifyAll();
			return i_item;
		}

	}

	/**
	 * Enqueues an item to the end of this queue. If the queue is full, this
	 * method blocks until some space becomes available.
	 * 
	 * @param item
	 *            Item to enqueue
	 */
	public void enqueue(T item) {
		synchronized (queLocker) {
			while (i_size == i_capacity) {
				try {
					queLocker.wait();
				} catch (InterruptedException e) {
					e.printStackTrace();
				}

			}
			buffer[(i_startingPoint + i_size) % i_capacity] = item;
			i_size++;
			queLocker.notifyAll();
		}
	}

	/**
	 * Returns the capacity of this queue
	 * 
	 * @return queue capacity
	 */
	public int getCapacity() {
		return i_capacity;
	}

	/**
	 * Returns the current size of the queue (number of elements in it)
	 * 
	 * @return queue size
	 */
	public int getSize() {
		return i_size;
	}

	/**
	 * Registers a producer to this queue. This method actually increases the
	 * internal producers counter of this queue by 1. This counter is used to
	 * determine whether the queue is still active and to avoid blocking of
	 * consumer threads that try to dequeue elements from an empty queue, when
	 * no producer is expected to add any more items. Every producer of this
	 * queue must call this method before starting to enqueue items, and must
	 * also call <see>{@link #unregisterProducer()}</see> when finishes to
	 * enqueue all items.
	 * 
	 * @see #dequeue()
	 * @see #unregisterProducer()
	 */
	public synchronized void registerProducer() {
		this.producers++;
	}

	/**
	 * Unregisters a producer from this queue. See <see>
	 * {@link #registerProducer()}</see>.
	 * 
	 * @see #dequeue()
	 * @see #registerProducer()
	 */
	public synchronized void unregisterProducer() {
		if (producers > 0) {
			this.producers--;
			synchronized (queLocker) {
				queLocker.notifyAll();
			}
		}

	}
}
