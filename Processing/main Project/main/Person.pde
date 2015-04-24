class Person {
  String name;
  PersonColor c;
  int amountOfTasks;

  public Person(String name, PersonColor c) {
    this.name = name;
    this.c = c;
    this.amountOfTasks = 0;
  }
  PersonColor getColor() {
    return this.c;
  }
  String getName() {
    return this.name;
  }
  int getAmountOfTasks() {
    return this.amountOfTasks;
  }
  void setAmountOfTasks(int n) {
    this.amountOfTasks = n;
  }
  void increaseAmountOfTasks() {
    this.amountOfTasks++;
  }
  void decreaseAmountOfTasks() {
    if (!( this.amountOfTasks == 0)) {
      this.amountOfTasks--;
    }
  }
}

