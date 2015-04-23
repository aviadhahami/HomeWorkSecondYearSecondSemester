
class baseWheel {
  int wheelColor = 255;
  int xPos, yPos, cWidth, cHeight;
  float currentAngel;
  Person[] people;
  int amountOfTasks;
  public baseWheel(int xPos, int yPos, int cWidth, int cHeight, Person[] people, int amountOfTasks) {
    this.xPos = xPos;
    this.yPos = yPos;
    this.cWidth = cWidth;
    this.cHeight = cHeight;

    this.people = people;
    this.currentAngel = PI*1.5;

    this.amountOfTasks = amountOfTasks;
  }

  //generates the first wheel
  void generate() {
    //initiate base white circle
    drawBase();
    noStroke();
    for (Person p : people) {
      for (int i=0; i<p.getAmountOfTasks (); i++) {
        fill(p.getColor().getGrayScale());
        arc(xPos, yPos, cWidth, cHeight, currentAngel, currentAngel + getArcSpan(), PIE); 

        increaseCurrentAngel();
      }
    }
  }
  //return the size of each cake slice in the big pie..
  float getArcSpan() {
    return 2*PI/this.amountOfTasks;
  }
  void drawBase() {
    fill(wheelColor);
    ellipse(xPos, yPos, cWidth, cWidth);
  }
  void increaseCurrentAngel() {
    currentAngel += getArcSpan();
    currentAngel = currentAngel > 2*PI ? 2*PI : currentAngel;
  }
  void decreaseCurrentAngel() {
    currentAngel -= getArcSpan();
    currentAngel = currentAngel < 0 ? 0 : currentAngel;
  }
}
