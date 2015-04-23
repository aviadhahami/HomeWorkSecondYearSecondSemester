
class baseWheel {
  int wheelColor = 255;
  int xPos, yPos, cWidth, cHeight;
  Person[] people;
  public baseWheel(int xPos, int yPos, int cWidth, int cHeight,Person[] people) {
    this.xPos = xPos;
    this.yPos = yPos;
    this.cWidth = cWidth;
    this.cHeight = cHeight;
    
    this.people = people;
  }

  //generates the first wheel
  void generate() {
    noStroke();
    fill(wheelColor);
    ellipse(xPos, yPos, cWidth, cHeight);
    arc(50, 50, 80, 80, 0, PI+QUARTER_PI, PIE);
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
