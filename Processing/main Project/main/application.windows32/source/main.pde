boolean TRUE = true;
boolean FALSE = false;
boolean DEBUG = TRUE;

//MAIN PROGRAM GLOBALS
int windowWidth, windowHeight;


int bgColor = 0;

void setup() {
  this.windowWidth = displayWidth;
  this.windowHeight = displayHeight;
  size(windowWidth, windowHeight); //GOING FULL SCREEN BABY ! 
  //setting main window bg

  background(bgColor);


  //everything is dead after this
  noLoop();
}

void draw() {
  baseWheel base = new baseWheel(windowWidth/2, windowHeight/2, windowWidth/5, windowWidth/5);
  base.generate();
}

