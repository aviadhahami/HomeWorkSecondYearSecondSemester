class Task {
  String name;
  String iconSrc;
  int worth;
  PImage icon;
  public Task(String name, String icon, int worth) {
    this.name = name;
    this.iconSrc = icon;
    this.worth = worth;
    try {
      this.icon = loadImage("images/"+this.iconSrc);
    }
    catch(Exception e) {
      System.out.println(e);
    }
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

