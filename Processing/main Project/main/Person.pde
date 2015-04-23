class Person {
  String name;
  personColor c;
  int amountOfTasks;

  public Person(String name, personColor c) {
    this.name = name;
    this.c = c;
    this.amountOfTasks = 0;
  }
  personColor getColor() {
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

