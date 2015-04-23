import processing.core.*; 
import processing.data.*; 
import processing.event.*; 
import processing.opengl.*; 

import java.util.HashMap; 
import java.util.ArrayList; 
import java.io.File; 
import java.io.BufferedReader; 
import java.io.PrintWriter; 
import java.io.InputStream; 
import java.io.OutputStream; 
import java.io.IOException; 

public class sketch_150424b extends PApplet {

//GLOBALS
int winW = 1024;
int winH = 1024;

int bgColor = 0;
int circleCount=0;

public void setup() {
  size(winW, winH);
  background(bgColor);
}

public void draw() {
  drawGreyCircles(200,200,300,5);
  //noLoop();
}


public void drawGreyCircles(int xLoc, int yLoc, int size, int num) {
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

  static public void main(String[] passedArgs) {
    String[] appletArgs = new String[] { "--full-screen", "--bgcolor=#666666", "--stop-color=#cccccc", "sketch_150424b" };
    if (passedArgs != null) {
      PApplet.main(concat(appletArgs, passedArgs));
    } else {
      PApplet.main(appletArgs);
    }
  }
}
