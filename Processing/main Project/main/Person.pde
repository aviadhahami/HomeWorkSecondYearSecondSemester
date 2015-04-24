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
  int getAmountOfTasks(){
    return this.amountOfTasks;
  }
  void increaseAmountOfTasks(){
    this.amountOfTasks++;
  }
  void decreaseAmountOfTasks(){
    this.amountOfTasks--;
  }
}

