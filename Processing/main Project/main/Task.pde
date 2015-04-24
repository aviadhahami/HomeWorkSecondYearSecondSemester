class Task {
  String name;
  PImage icon;
  int worth;
  public Task(String name, PImage icon, int worth) {
    this.name = name;
    this.icon = icon;
    this.worth = worth;
  }
  PImage getIcon() {
    return this.icon;
  }
  String getName() {
    return this.name;
  }
  int getWorth() {
    return this.worth;
  }
}

