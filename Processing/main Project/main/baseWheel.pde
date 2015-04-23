
class baseWheel {
  int wheelColor = 255;
  int xPos, yPos, cWidth, cHeight;
  int currentAngel;
  Person[] people;
  public baseWheel(int xPos, int yPos, int cWidth, int cHeight, Person[] people) {
    this.xPos = xPos;
    this.yPos = yPos;
    this.cWidth = cWidth;
    this.cHeight = cHeight;

    this.people = people;
    this.currentAngel = 0;
  }

  //generates the first wheel
  void generate() {
    noStroke();
    fill(wheelColor);
    // ellipse(xPos, yPos, cWidth, cHeight);
    arc(xPos, yPos, cWidth, cHeight, currentAngel, currentAngel + getArcSpan(), PIE);
    currentAngel += getArcSpan();
    arc(xPos, yPos, cWidth, cHeight, currentAngel, ( currentAngel + getArcSpan()), PIE);
  }
  //return the size of each cake slice in the big pie..
  int getArcSpan() {
    return 2*PIE/this.people.length;
  }
}


/*
void draw() {
 background(100);
 pieChart(300, angles);
 }
 
 void pieChart(float diameter, int[] data) {
 float lastAngle = 0;
 for (int i = 0; i < data.length; i++) {
 float gray = map(i, 0, data.length, 0, 255);
 fill(gray);
 arc(width/2, height/2, diameter, diameter, lastAngle, lastAngle+radians(angles[i]));
 lastAngle += radians(angles[i]);
 }*/
