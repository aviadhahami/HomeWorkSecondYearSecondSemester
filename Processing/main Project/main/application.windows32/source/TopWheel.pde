class TopWheel {
  int wheelColor = 255;
  int xPos, yPos;
  float cWidth, cHeight;

  public TopWheel(int xPos, int yPos, int cWidth, int cHeight) {
    this.xPos = xPos;
    this.yPos = yPos;
    this.cWidth = cWidth/1.2;
    this.cHeight = cHeight/1.2;
  }


  void generate() {
    drawBase();
    String placeHolder = "System is waiting...";
  }
  void drawBase() {
    noStroke();
    fill(255);
    ellipse(xPos, yPos, cWidth, cWidth);
  }
}

