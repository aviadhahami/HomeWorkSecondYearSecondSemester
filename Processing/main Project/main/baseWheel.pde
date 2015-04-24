
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
    this.currentAngel = PI*1.5; // head of cicrle  

    this.amountOfTasks = amountOfTasks;
  }

  //generates the first wheel
  void generate() {
    //initiate base white circle
    drawBase();
    //noStroke();
    stroke(150);
    for (Person p : people) {
      for (int i=0; i<p.getAmountOfTasks (); i++) {
        int r = p.getColor().getR();
        int g = p.getColor().getG();
        int b  =p.getColor().getB();
        fill(r, g, b);
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
    currentAngel = currentAngel > 2*PI*amountOfTasks ? 2*PI*amountOfTasks : currentAngel;
  }
  void decreaseCurrentAngel() {
    currentAngel -= getArcSpan();
    currentAngel = currentAngel < 0 ? 0 : currentAngel;
  }
}

