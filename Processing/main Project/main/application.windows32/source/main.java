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
//blue FB
int bgColorR = 109;
int bgColorG = 132;
int bgColorB = 180;

Person[] people;
Task[] tasks;

public void setup() {
  this.windowWidth = displayWidth;
  this.windowHeight = displayHeight;
  size(windowWidth, windowHeight); //GOING FULL SCREEN BABY ! 
  //setting main window bg

  background(bgColorR,bgColorG,bgColorB);  
  //instansiate people
  Person david = new Person("David", new PersonColor(65, 191, 191));
  Person anna = new Person("Anna", new PersonColor(80, 191, 65));
  people = new Person[2];
  david.increaseAmountOfTasks();
  david.increaseAmountOfTasks();
  anna.increaseAmountOfTasks();
  people[0] = david;
  people[1] = anna;
  
  //instansiate tasks
  
  tasks = new Task[6];
  tasks[0] = new Task("Laundry","laundry.png",1);
  //everything is dead after this
  noLoop();
}

public void draw() {
  int BaseWheelSize = windowWidth/2;
  int tasksNumber;
  BaseWheel base = new BaseWheel(windowWidth/2, windowHeight/2, BaseWheelSize, BaseWheelSize, people, tasks.length);
  base.generate();
  TopWheel top = new TopWheel(windowWidth/2, windowHeight/2, BaseWheelSize, BaseWheelSize,tasks);
  top.generate();
}

class Person {
  String name;
  PersonColor c;
  int amountOfTasks;

  public Person(String name, PersonColor c) {
    this.name = name;
    this.c = c;
    this.amountOfTasks = 0;
  }
  public PersonColor getColor() {
    return this.c;
  }
  public int getAmountOfTasks(){
    return this.amountOfTasks;
  }
  public void increaseAmountOfTasks(){
    this.amountOfTasks++;
  }
  public void decreaseAmountOfTasks(){
    this.amountOfTasks--;
  }
}

class Task {
  String name;
  String iconSrc;
  int worth;
  PImage icon;
  public Task(String name, String icon, int worth) {
    this.name = name;
    this.iconSrc = icon;
    this.worth = worth;
    
    try {
      this.icon = loadImage("images/"+this.iconSrc);
    }
    catch(Exception e) {
      System.out.println(e);
    }
  }
  public PImage getIcon() {
    return this.icon;
  }
  public String getName() {
    return this.name;
  }
  public int getWorth() {
    return this.worth;
  }
}

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
    this.cWidth = cWidth/1.2f;
    this.cHeight = cHeight/1.2f;
    this.tasks = tasks;


    this.iconWidth = this.cWidth/4;
    this.iconHeight = this.cHeight/4;
  }


  public void generate() {
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
  public void drawBase() {
    noStroke();
    fill(255);
    ellipse(xPos, yPos, cWidth, cWidth);
  }
  public void initText(int fSize, int r, int g, int b) {
    textFont(createFont("Georgia", fSize));
    fill(r, g, b);
  }
}


class BaseWheel {
  int wheelColor = 255;
  int xPos, yPos, cWidth, cHeight;
  float currentAngel;
  Person[] people;
  int amountOfTasks;
  public BaseWheel(int xPos, int yPos, int cWidth, int cHeight, Person[] people, int amountOfTasks) {
    this.xPos = xPos;
    this.yPos = yPos;
    this.cWidth = cWidth;
    this.cHeight = cHeight;

    this.people = people;
    this.currentAngel = PI*1.5f; // head of cicrle  

    this.amountOfTasks = amountOfTasks;
  }

  //generates the first wheel
  public void generate() {
    float arcD = cWidth;
    //initiate base white circle
    drawBase();
    //noStroke();
    stroke(255);
    for (Person p : people) {
      for (int i=0; i<p.getAmountOfTasks (); i++) {
        int r = p.getColor().getR();
        int g = p.getColor().getG();
        int b  =p.getColor().getB();
        fill(r, g, b);
        arc(xPos, yPos, arcD, arcD, currentAngel, currentAngel + getArcSpan(), PIE); 

        increaseCurrentAngel();
      }
    }
  }
  //return the size of each cake slice in the big pie..
  public float getArcSpan() {
    return 2*PI/this.amountOfTasks;
  }
  public void drawBase() {
    noStroke();
    fill(216,223,234);
    ellipse(xPos, yPos, cWidth, cWidth);
  }
  public void increaseCurrentAngel() {
    currentAngel += getArcSpan();
    currentAngel = currentAngel > 2*PI*amountOfTasks ? 2*PI*amountOfTasks : currentAngel;
  }
  public void decreaseCurrentAngel() {
    currentAngel -= getArcSpan();
    currentAngel = currentAngel < 0 ? 0 : currentAngel;
  }
}

class PersonColor {
  int r, g, b;

  public PersonColor(int r, int g, int b) {
    this.r = r;
    this.g = g;
    this.b = b;
  }

  public int getR() {
    return this.r;
  }
  public int getG() {
    return this.g;
  }
  public int getB() {
    return this.b;
  }
  public int getGrayScale() {
    return (this.r+this.b+this.g)/3;
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
