import processing.core.*; 
import processing.data.*; 
import processing.event.*; 
import processing.opengl.*; 

import java.util.*; 

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

LinkedList<Person> people;
LinkedList<Task> tasks;
BaseWheel base;
TopWheel top;

int statusFlag; //can be -1 for waiting, 0 for pick task, 1 for task picked

public void setup() {
  this.windowWidth = displayWidth;
  this.windowHeight = displayHeight;
  size(windowWidth, windowHeight); //GOING FULL SCREEN BABY ! 
  //setting main window bg

  background(bgColorR, bgColorG, bgColorB);  
  //instansiate people
  Person david = new Person("David", new PersonColor(65, 191, 191));
  Person anna = new Person("Anna", new PersonColor(80, 191, 65));
  Person raziel = new Person("Raziel", new PersonColor(204, 73, 102));
  people = new LinkedList();
  david.increaseAmountOfTasks();
  david.increaseAmountOfTasks();
  anna.increaseAmountOfTasks();
  raziel.increaseAmountOfTasks();
  people.add(david);
  people.add(anna);
  people.add(raziel);
  LinkedList<Task> myList = new LinkedList();
  //instansiate tasks

  tasks = new LinkedList();
  tasks.add( new Task("Laundry", "laundry.png", 1));
  tasks.add( new Task("Laundry", "laundry.png", 1));
  tasks.add( new Task("Laundry", "laundry.png", 1));
  tasks.add( new Task("Brooming", "broom.png", 1));
  tasks.add( new Task("Brooming", "broom.png", 1));
  tasks.add( new Task("Dishes", "plate.png", 1));
  tasks.add( new Task("Dishes", "plate.png", 1));
  tasks.add( new Task("Dishes", "plate.png", 1));
  tasks.add( new Task("Dishes", "plate.png", 1));
  tasks.add( new Task("Trash", "trash.png", 1));
  tasks.add( new Task("Trash", "trash.png", 1));
  tasks.add( new Task("Trash", "trash.png", 1));
  tasks.add( new Task("Trash", "trash.png", 1));
  tasks.add( new Task("Trash", "trash.png", 1));

  int BaseWheelSize = windowWidth/2;
  int tasksNumber;
  statusFlag = -1;
  base = new BaseWheel(windowWidth/2, windowHeight/2, BaseWheelSize, BaseWheelSize, people, tasks.size());
  base.generate();
  top = new TopWheel(windowWidth/2, windowHeight/2, BaseWheelSize, BaseWheelSize, tasks, raziel);
  top.generateWaitingPosition();


  //everything is dead after this
  //noLoop();
}

//mouse click listener
public void mousePressed() {
  if (top.overCircle(windowWidth/2, windowHeight/2, 500)) {
    switch(statusFlag) {
      case(-1):
      {
        System.out.println("User clicked, showing tasks");
        top.generateTaskChooser();
        statusFlag = 0;
        break;
      }
      case(0):
      {
        
        System.out.println("Task picked, showing status");
        //need to initiate scrolling wheel
        //need to retrieve what the user clicked on
        top.generateTaskAmountChooser();
        statusFlag = 1;
        break;
      }
      case(1):
      {
        System.out.println("Task amount picked, moving to waiting");

        top.generateWaitingPosition();
        statusFlag = -1;
        break;
      }
    }
  }
}

//key up listener
public void keyReleased() {
  if (key == CODED) {
    if (keyCode == 39) {
      //right key
      if (statusFlag ==0) {
        top.generateTaskChooser();
      } else if (statusFlag == 1) {
        top.generateTaskAmountChooser();
      }
    } else if (keyCode == 37) {
      //left key
      if (statusFlag ==0) {
        top.generateTaskChooser();
      } else if (statusFlag == 1) {
        top.generateTaskAmountChooser();
      }
    }
  }
}

public void draw() {
  this.top.listen();
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

class TaskDots {
  float xLoc, yLoc,containerWidth;
  Person person;
  public TaskDots(float xLoc, float yLoc,float containerWidth, Person p) {
    this.xLoc = xLoc;
    this.yLoc = yLoc;
    this.person = p;
    this.containerWidth = containerWidth;
  } 
  public void generateDot() {
    PersonColor c = person.getColor();
    fill(c.getR(), c.getG(), c.getB());
    ellipse(xLoc, yLoc, 50, 50);
    increaseAmount();
  }
  public void generateDots(int n){
    for(int i=0;i<n;i++){
      generateDot();
    }
  }
  public void increaseAmount(){
    this.xLoc = this.xLoc + 60;
  }
    public void decreaseAmount(){
    this.xLoc = this.xLoc - 60;
  }
}

class TopWheel {

  final static String PLACEHOLDER = "System is waiting...";

  float iconWidth, iconHeight;
  float iconX, iconY;

  int wheelColor = 255;
  int xPos, yPos;
  float cWidth, cHeight;
  LinkedList<Task> tasks;

  int currentItemInTasksArray;

  String currentTaskName;
  int currentTaskAmout;
  PImage currentTaskIcon;
  int currentTaskOriginAmount;

  Person activePerson;

  TaskDots activePersonDots;

  public TopWheel(int xPos, int yPos, int cWidth, int cHeight, LinkedList<Task> tasks, Person person) {
    this.xPos = xPos;
    this.yPos = yPos;
    this.cWidth = cWidth/1.2f;
    this.cHeight = cHeight/1.2f;
    this.tasks = tasks;


    this.iconWidth = this.cWidth/4;
    this.iconHeight = this.cHeight/4;

    this.iconX = this.xPos - this.iconWidth/2;
    this.iconY = this.yPos - this.cWidth/2 + 50;

    this.currentItemInTasksArray = 0;


    this.activePerson = person;
  }

  //listenenes to mouse hover
  public void listen() {
    if (overCircle(0, 0, 100) ) {
      //System.out.println("hover");
    } else {
      //System.out.println("====");
    }
  }

  public void generateWaitingPosition() {
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

  public void generateTaskChooser() {
    drawBase(255);
    int fontSize = 35;
    initText(fontSize, 73, 137, 204);
    //mapping the tasks to hash and to task names array for easy iterating
    Hashtable<String, Integer> tasksNamesAndAmount = mapTasksToHash();
    Hashtable<String, PImage> tasksToIconsHash = mapTasksToIcons();
    String[] taskNames = getTaskNamesArray();
    this.activePersonDots = new TaskDots(this.cWidth, this.cHeight, this.cWidth, activePerson);
    switch(keyCode) {
      //clicked left
      case(37):
      { 
        //System.out.println("left");
        currentItemInTasksArray = currentItemInTasksArray == 0 ? 0 : --currentItemInTasksArray;
        image(tasksToIconsHash.get(taskNames[currentItemInTasksArray]), iconX, iconY, iconWidth, iconHeight);
        text(taskNames[currentItemInTasksArray], xPos - fontSize*2, yPos);
        activePersonDots.generateDots(tasksNamesAndAmount.get (taskNames[currentItemInTasksArray]));
        //update current task
        updateCurrentTask(taskNames[currentItemInTasksArray], tasksNamesAndAmount.get (taskNames[currentItemInTasksArray]), tasksToIconsHash.get(taskNames[currentItemInTasksArray]));
        this.currentTaskOriginAmount = tasksNamesAndAmount.get(taskNames[currentItemInTasksArray]);
        break;
      }
      //clicked right
      case(39):
      {
        //System.out.println("right");
        currentItemInTasksArray = currentItemInTasksArray == taskNames.length-1 ? taskNames.length-1 : ++currentItemInTasksArray;
        image(tasksToIconsHash.get(taskNames[currentItemInTasksArray]), iconX, iconY, iconWidth, iconHeight);
        text(taskNames[currentItemInTasksArray], xPos - fontSize*2, yPos);
        activePersonDots.generateDots(tasksNamesAndAmount.get (taskNames[currentItemInTasksArray]));
        //update current task
        updateCurrentTask(taskNames[currentItemInTasksArray], tasksNamesAndAmount.get (taskNames[currentItemInTasksArray]), tasksToIconsHash.get(taskNames[currentItemInTasksArray]));
        this.currentTaskOriginAmount = tasksNamesAndAmount.get(taskNames[currentItemInTasksArray]);
        break;
      }
      //first run
      case(0):
      {
        System.out.println("first time");
        image(tasksToIconsHash.get(taskNames[currentItemInTasksArray]), iconX, iconY, iconWidth, iconHeight);
        text(taskNames[currentItemInTasksArray], xPos - fontSize*2, yPos);
        activePersonDots.generateDots(tasksNamesAndAmount.get (taskNames[currentItemInTasksArray]));
        //update current task
        updateCurrentTask(taskNames[currentItemInTasksArray], tasksNamesAndAmount.get(taskNames[currentItemInTasksArray]), tasksToIconsHash.get(taskNames[currentItemInTasksArray]));
        this.currentTaskOriginAmount = tasksNamesAndAmount.get(taskNames[currentItemInTasksArray]);

        break;
      }
    }
  }
  public void updateCurrentTask(String name, int amount, PImage icon) {
    this.currentTaskName = name;
    this.currentTaskAmout = amount;
    this.currentTaskIcon=icon;
  }

  //shows the amount of options per task
  public void generateTaskAmountChooser() {
    this.activePersonDots = new TaskDots(this.cWidth, this.cHeight, this.cWidth, activePerson);
    //init stuff
    drawBase(255);
    int fontSize = 35;
    initText(fontSize, 73, 137, 204);


    switch(keyCode) {
      //clicked left
      case(37):
      { 
        //System.out.println("left");
        this.currentTaskAmout =  this.currentTaskAmout == 0 ? 0 : --this.currentTaskAmout;
        break;
      }
      //clicked right
      case(39):
      {
        //System.out.println("right");
        this.currentTaskAmout =this.currentTaskAmout == this.currentTaskOriginAmount ? this.currentTaskOriginAmount : ++this.currentTaskAmout;
        break;
      }
      //first run
      case(0):
      {
        System.out.println("first time");
        break;
      }
    }
    
    //display icons
    image(this.currentTaskIcon, iconX, iconY, iconWidth, iconHeight);
    text(this.currentTaskName, xPos - fontSize*2, yPos);
    activePersonDots.generateDots(this.currentTaskAmout);
  }
  //iterating all tasks in the tasks list, returns an array with all the names
  public Hashtable<String, Integer> mapTasksToHash() {
    Hashtable<String, Integer> table = new Hashtable();
    for (Task t : tasks) {
      if (! table.containsKey(t.getName())) {
        table.put(t.getName(), 1);
      } else {
        table.put(t.getName(), table.get(t.getName()) + 1 );
      }
    }
    return table;
  }
  //maping each task to his proper icon
  public Hashtable<String, PImage> mapTasksToIcons() {
    Hashtable<String, PImage> table = new Hashtable();
    for (Task t : tasks) {
      if (! table.containsKey(t.getName())) {
        table.put(t.getName(), t.getIcon());
      }
    }

    return table;
  }
  public String[] getTaskNamesArray() {
    LinkedList<String> list = new LinkedList();
    for (Task t : tasks) {
      if (! list.contains(t.getName())) {
        list.add(t.getName());
      }
    }
    return list.toArray(new String[list.size()]);
  }
  public void drawBase(int c) {
    noStroke();
    fill(c);
    ellipse(xPos, yPos, cWidth, cWidth);
  }
  public void initText(int fSize, int r, int g, int b) {
    textFont(createFont("Arial", fSize));
    fill(r, g, b);
  }

  public void showTask(Task t) {
    int fontSize=32;
    initText(fontSize, 0, 0, 0);
    text(t.getName(), xPos - fontSize*4, yPos);
    image(t.getIcon(), this.iconX, this.iconY, iconWidth, iconHeight);
  }



  //mouse hover listener
  public boolean overCircle(int x, int y, int diameter) {
    float disX = x - mouseX;
    float disY = y - mouseY;
    if (sqrt(sq(disX) + sq(disY)) < diameter/2 ) {
      return true;
    } else {
      return false;
    }
  }
}

//BUGS:
//We override other tasks if we get more tasks than places on the wheel
//fuck im tired
class BaseWheel {
  int wheelColor = 255;
  int xPos, yPos, cWidth, cHeight;
  float currentAngel;
  LinkedList<Person> people;
  int amountOfTasks;
  public BaseWheel(int xPos, int yPos, int cWidth, int cHeight, LinkedList<Person> people, int amountOfTasks) {
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
    fill(216, 223, 234);
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
    return (this.r + this.g + this.b)/3;
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
