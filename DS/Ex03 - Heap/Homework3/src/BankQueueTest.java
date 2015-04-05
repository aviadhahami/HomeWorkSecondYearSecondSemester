public class BankQueueTest {
	public static void main(String [] args)
	{
		
		PersonWithMoney p1 = new PersonWithMoney("Moshe", 10);
		PersonWithMoney p2 = new PersonWithMoney("David", 20);
		PersonWithMoney p3 = new PersonWithMoney("Menahem", 30);
		PersonWithMoney p4 = new PersonWithMoney("Shoshi", 40);
		PersonWithMoney p5 = new PersonWithMoney("Mush", 60);
		PersonWithMoney p6 = new PersonWithMoney("Avi", 7000);
		PersonWithMoney p7 = new PersonWithMoney("Moshe1", 10);
		PersonWithMoney p8 = new PersonWithMoney("Moshe2", 10);
		PersonWithMoney p9 = new PersonWithMoney("Moshe3", 10);
		PersonWithMoney p10 = new PersonWithMoney("Moshe4", 10);
		

		//Test1
		PersonWithMoney [] peopleQueue1 = {p3,p2,p1,p4};
		BankQueue bq1 = new BankQueue(peopleQueue1, 10); 
		for(int i=0;i<4;i++)
		{
			System.out.println(bq1.dequeue());
		}
		printSeparator();
		
		//Test2
		PersonWithMoney [] peopleQueue2 = {p7,p8,p9,p10};
		BankQueue bq2 = new BankQueue(peopleQueue2, 10); 
		for(int i=0;i<4;i++)
		{
			System.out.println(bq2.dequeue());
		}
		printSeparator();
		
		//Test3
		BankQueue bq3 = new BankQueue(10);
		bq3.enqueue(p1);
		System.out.println(bq3.getAverageMoneyInQueue());
		bq3.enqueue(p2);
		System.out.println(bq3.getAverageMoneyInQueue());
		bq3.dequeue();
		System.out.println(bq3.getAverageMoneyInQueue());
		System.out.println(bq3.dequeue());
		try {
			bq3.dequeue();
		} catch (Exception e) {
			System.out.println("Caught exception - " + e.getMessage());
		}
		printSeparator();
		
		//Test4
		BankQueue bq4 = new BankQueue(10);
		bq4.enqueue(p5);
		bq4.enqueue(p1);
		bq4.enqueue(p2);
		System.out.println(bq4.getPoorestPerson());
		bq4.stealFromFirstInQueue(55);
		System.out.println(bq4.getPoorestPerson());
		System.out.println(bq4.dequeue());
		System.out.println(bq4.dequeue());
		System.out.println(bq4.dequeue());
		try {
			System.out.println(bq4.getAverageMoneyInQueue());
		} catch (Exception e) {
			System.out.println("Caught exception - " + e.getMessage());
		}
		printSeparator();
		
		//Test5
		BankQueue bq5 = new BankQueue(2);
		for(int i=0;i<1000000;i++)
		{
			bq5.enqueue(p7);
			bq5.dequeue();
		}
		try {
			System.out.println(bq5.getAverageMoneyInQueue());
		} catch (Exception e) {
			System.out.println("Caught exception - " + e.getMessage());
		}
		printSeparator();
		
		//Test6
		BankQueue bq6 = new BankQueue(101);
		for(int i=1;i<101;i++)
		{
			bq6.enqueue(new PersonWithMoney("JohnDoe", i));
		}
		System.out.println(bq6.getAverageMoneyInQueue());
		bq6.enqueue(p6);
		System.out.println(bq6.getAverageMoneyInQueue());
		

	}
	
	private static void printSeparator()
	{
		System.out.println("--------------------------------");
	}
}
