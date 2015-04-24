class TopWheel {

  final static String PLACEHOLDER = "System is waiting...";

  float iconWidth, iconHeight;
  float iconX, iconY;

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

    this.iconX = this.xPos - this.iconWidth/2;
    this.iconY = this.yPos - this.cWidth/2 + 50;
  }
  
  //listenenes to mouse hover
  void listen() {
    if (overCircle(0, 0, 100) ) {
      //System.out.println("hover");
    }else{
       //System.out.println("====");
    }
  }

  void generate() {
    drawBase(255);
    //init "waiting" text
    int fontSize = 42;
    initText(fontSize, 73, 137, 204);
    text(PLACEHOLDER, xPos - fontSize*4, yPos);

    //init waiting image
    PImage waitingIcon = new PImage();
    waitingIcon = loadImage("images/clock.png"); //loading clock image as place holder
    image(waitingIcon, iconX, iconY, iconWidth, iconHeight);
   
  }
  void drawBase(int c) {
    noStroke();
    fill(c);
    ellipse(xPos, yPos, cWidth, cWidth);
  }
  void initText(int fSize, int r, int g, int b) {
    textFont(createFont("Arial", fSize));
    fill(r, g, b);
  }

  void showTask(Task t) {
    int fontSize=32;
    initText(fontSize, 0, 0, 0);
    text(t.getName(), xPos - fontSize*4, yPos);
    image(t.getIcon(), this.iconX, this.iconY, iconWidth, iconHeight);
  }



  //mouse hover listener
  boolean overCircle(int x, int y, int diameter) {
    float disX = x - mouseX;
    float disY = y - mouseY;
    if (sqrt(sq(disX) + sq(disY)) < diameter/2 ) {
      return true;
    } else {
      return false;
    }
  }
}

