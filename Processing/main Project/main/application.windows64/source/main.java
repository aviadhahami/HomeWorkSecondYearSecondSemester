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

public class main extends PApplet {

boolean TRUE = true;
boolean FALSE = false;
boolean DEBUG = TRUE;

//MAIN PROGRAM GLOBALS
int windowWidth, windowHeight;


int bgColor = 0;

public void setup() {
  this.windowWidth = displayWidth;
  this.windowHeight = displayHeight;
  size(windowWidth, windowHeight); //GOING FULL SCREEN BABY ! 
  //setting main window bg

  background(bgColor);


  //everything is dead after this
  noLoop();
}

public void draw() {
  baseWheel base = new baseWheel(windowWidth/2, windowHeight/2, windowWidth/5, windowWidth/5);
  base.generate();
}


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
  public void generate() {
    noStroke();
    fill(wheelColor);
    ellipse(xPos, yPos, cWidth, cHeight);
  }
}

  static public void main(String[] passedArgs) {
    String[] appletArgs = new String[] { "--full-screen", "--bgcolor=#666666", "--stop-color=#cccccc", "main" };
    if (passedArgs != null) {
      PApplet.main(concat(appletArgs, passedArgs));
    } else {
      PApplet.main(appletArgs);
    }
  }
}
