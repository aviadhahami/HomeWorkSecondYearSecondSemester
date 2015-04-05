public class PersonWithMoney {
	private String name;
	private int money;
	
	
	public PersonWithMoney(String name, int money) {
		this.name = name;
		this.money = money;
	}


	public String getName() {
		return name;
	}


	public int getMoney() {
		return money;
	}
	
	public void setMoney(int money) {
		this.money = money;
	}


	@Override
	public String toString() {
		return "PersonWithMoney [name=" + name + ", money=" + money + "]";
	}
	
	
	
}
