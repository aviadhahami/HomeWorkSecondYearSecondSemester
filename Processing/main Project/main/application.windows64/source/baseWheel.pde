
class baseWheel {
  int wheelColor = 255;
  int xPos, yPos, cWidth, cHeight;
  public baseWheel(int xPos, int yPos, int cWidth, int cHeight) {
    this.xPos = xPos;
    this.yPos = yPos;
    this.cWidth = cWidth;
    this.cHeight = cHeight;
  }

  //generates the first wheel
  void generate() {
    noStroke();
    fill(wheelColor);
    ellipse(xPos, yPos, cWidth, cHeight);
  }
}

