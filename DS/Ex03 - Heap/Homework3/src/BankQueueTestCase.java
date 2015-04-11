import static org.junit.Assert.*;

import org.junit.Rule;
import org.junit.Test;
import org.junit.rules.ExpectedException;

public class BankQueueTestCase {

	@Test
	public void regularInitTest() {
		PersonWithMoney p1 = new PersonWithMoney("Moshe", 10);
		PersonWithMoney p2 = new PersonWithMoney("David", 20);
		PersonWithMoney p3 = new PersonWithMoney("Menahem", 30);
		PersonWithMoney p4 = new PersonWithMoney("Shoshi", 40);
		PersonWithMoney[] peopleQueue1 = { p3, p2, p1, p4 };
		BankQueue bq1 = new BankQueue(peopleQueue1, 10);

		PersonWithMoney[] expecteds = { p4, p3, p2, p1 };
		PersonWithMoney[] actuals = new PersonWithMoney[4];

		for (int i = 0; i < peopleQueue1.length; i++) {
			actuals[i] = bq1.dequeue();
		}
		assertArrayEquals(expecteds, actuals);
	}

	@Test
	public void sameElementsTest() {
		PersonWithMoney p7 = new PersonWithMoney("Moshe1", 10);
		PersonWithMoney p8 = new PersonWithMoney("Moshe2", 10);
		PersonWithMoney p9 = new PersonWithMoney("Moshe3", 10);
		PersonWithMoney p10 = new PersonWithMoney("Moshe4", 10);

		PersonWithMoney[] peopleQueue2 = { p7, p8, p9, p10 };

		BankQueue bq2 = new BankQueue(peopleQueue2, 10);

		PersonWithMoney[] expecteds = { p7, p10, p9, p8 };
		PersonWithMoney[] actuals = new PersonWithMoney[4];

		for (int i = 0; i < peopleQueue2.length; i++) {
			actuals[i] = bq2.dequeue();
		}
		assertArrayEquals(expecteds, actuals);
	}

	@Rule
	public ExpectedException exception = ExpectedException.none();

	@Test
	public void averageMoneyTest() {
		PersonWithMoney p1 = new PersonWithMoney("Moshe", 10);
		PersonWithMoney p2 = new PersonWithMoney("David", 20);
		BankQueue bq3 = new BankQueue(10);
		bq3.enqueue(p1);
		assertEquals(10, bq3.getAverageMoneyInQueue());
		bq3.enqueue(p2);
		assertEquals(15, bq3.getAverageMoneyInQueue());
		bq3.dequeue();
		assertEquals(10, bq3.getAverageMoneyInQueue());
		assertEquals(p1, bq3.dequeue());
		exception.expect(HeapException.class);
		(new BankQueue(10)).dequeue();
	}

	@Test
	public void poorestPersonTest() {
		PersonWithMoney p1 = new PersonWithMoney("Moshe", 10);
		PersonWithMoney p2 = new PersonWithMoney("David", 20);
		PersonWithMoney p5 = new PersonWithMoney("Mush", 60);

		BankQueue bq4 = new BankQueue(10);
		bq4.enqueue(p5);
		bq4.enqueue(p1);
		bq4.enqueue(p2);
		assertEquals(p1, bq4.getPoorestPerson());
		bq4.stealFromFirstInQueue(55);
		assertEquals(p5, bq4.getPoorestPerson());
		assertEquals(p2, bq4.dequeue());
		assertEquals(p1, bq4.dequeue());
		assertEquals(p5, bq4.dequeue());
		exception.expect(HeapException.class);
		bq4.getAverageMoneyInQueue();

	}

	@Test
	public void enqueueDequeueTest() {
		PersonWithMoney p7 = new PersonWithMoney("Moshe1", 10);

		BankQueue bq5 = new BankQueue(2);
		for (int i = 0; i < 1000000; i++) {
			bq5.enqueue(p7);
			bq5.dequeue();
		}
		exception.expect(HeapException.class);
		bq5.getAverageMoneyInQueue();

	}

	@Test
	public void hundredPeopleTest() {
		PersonWithMoney p6 = new PersonWithMoney("Avi", 7000);

		BankQueue bq6 = new BankQueue(101);
		for (int i = 1; i < 101; i++) {
			bq6.enqueue(new PersonWithMoney("JohnDoe", i));
		}
		assertEquals(50, bq6.getAverageMoneyInQueue());
		bq6.enqueue(p6);
		assertEquals(119, bq6.getAverageMoneyInQueue());
	}
}