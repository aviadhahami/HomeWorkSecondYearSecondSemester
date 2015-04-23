//globals
int winWidth = 500;
int winHeight = 500;


int ellipseW = 100;
int ellipseH = 100;

int eX = ellipseW/2;
int eY = 200;

void setup() {

  size(winWidth, winHeight);
}

void draw() {
  background(0); //repaint in black the BG each iteration
  fill(200, 200, 200);
  stroke(255);
  ellipse(eX, eY, ellipseW, ellipseH);
  eX = eX > (winWidth+ ellipseW /2) ? 0 - (ellipseW /2) : eX+2;
}

