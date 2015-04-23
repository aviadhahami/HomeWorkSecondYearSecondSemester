boolean TRUE = true;
boolean FALSE = false;
boolean DEBUG = TRUE;

//MAIN PROGRAM GLOBALS
int windowWidth, windowHeight;
int bgColor = 0;

Person[] people;

void setup() {
  this.windowWidth = displayWidth;
  this.windowHeight = displayHeight;
  size(windowWidth, windowHeight); //GOING FULL SCREEN BABY ! 
  //setting main window bg

  background(bgColor);

  Person david = new Person("David", new personColor(0, 0, 255));
  //everything is dead after this
  noLoop();
}

void draw() {
  int baseWheelSize = windowWidth/2;
  baseWheel base = new baseWheel(windowWidth/2, windowHeight/2, baseWheelSize, baseWheelSize, people);
  base.generate();
}

