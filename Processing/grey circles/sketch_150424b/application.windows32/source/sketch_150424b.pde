//GLOBALS
int winW = 1024;
int winH = 1024;

int bgColor = 0;
int circleCount=0;

void setup() {
  size(winW, winH);
  background(bgColor);
}

void draw() {
  drawGreyCircles(200,200,300,5);
  //noLoop();
}


void drawGreyCircles(int xLoc, int yLoc, int size, int num) {
  float grayVal = 255/num;
  float steps = size/num;
  if (circleCount > num) {
    circleCount = 0;
    background(bgColor);
  } else {
    circleCount++;
    fill(circleCount * grayVal);
    float currSize = size - circleCount*steps;
    ellipse(xLoc, yLoc, currSize, currSize);
  }
}

