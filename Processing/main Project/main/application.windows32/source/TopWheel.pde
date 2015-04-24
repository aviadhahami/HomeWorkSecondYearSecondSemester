class TopWheel {

  final static String PLACEHOLDER = "System is waiting...";

  float iconWidth, iconHeight;

  int wheelColor = 255;
  int xPos, yPos;
  float cWidth, cHeight;
  Task[] tasks;

  public TopWheel(int xPos, int yPos, int cWidth, int cHeight, Task[] tasks) {
    this.xPos = xPos;
    this.yPos = yPos;
    this.cWidth = cWidth/1.2;
    this.cHeight = cHeight/1.2;
    this.tasks = tasks;


    this.iconWidth = this.cWidth/4;
    this.iconHeight = this.cHeight/4;
  }


  void generate() {
    drawBase();
    //init "waiting" text
    int fontSize = 42;
    initText(fontSize, 73, 137, 204);
    text(PLACEHOLDER, xPos - fontSize*4, yPos);

    //init waiting image
    PImage waitingIcon = new PImage();
    waitingIcon = loadImage("images/clock.png"); //loading clock image as place holder
    image(waitingIcon, xPos - iconWidth/2, yPos - cWidth/2 + 50, iconWidth, iconHeight);
  }
  void drawBase() {
    noStroke();
    fill(255);
    ellipse(xPos, yPos, cWidth, cWidth);
  }
  void initText(int fSize, int r, int g, int b) {
    textFont(createFont("Georgia", fSize));
    fill(r, g, b);
  }
}

