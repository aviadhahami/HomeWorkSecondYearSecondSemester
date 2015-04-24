import java.util.*;


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
LinkedList<Task> tasks;
BaseWheel base;
TopWheel top;

void setup() {
  this.windowWidth = displayWidth;
  this.windowHeight = displayHeight;
  size(windowWidth, windowHeight); //GOING FULL SCREEN BABY ! 
  //setting main window bg

  background(bgColorR, bgColorG, bgColorB);  
  //instansiate people
  Person david = new Person("David", new PersonColor(65, 191, 191));
  Person anna = new Person("Anna", new PersonColor(80, 191, 65));
  people = new Person[2];
  david.increaseAmountOfTasks();
  anna.increaseAmountOfTasks();
  people[0] = david;
  people[1] = anna;
  LinkedList<Task> myList = new LinkedList();
  //instansiate tasks

  tasks = new LinkedList();
  tasks.add( new Task("Laundry", "laundry.png", 1));
  tasks.add( new Task("Brooming", "broom.png", 1));
  tasks.add( new Task("Cooking", "food.png", 1));
  tasks.add( new Task("Trash", "trash.png", 1));

  int BaseWheelSize = windowWidth/2;
  int tasksNumber;
  base = new BaseWheel(windowWidth/2, windowHeight/2, BaseWheelSize, BaseWheelSize, people, tasks.size());
  base.generate();
  top = new TopWheel(windowWidth/2, windowHeight/2, BaseWheelSize, BaseWheelSize, tasks);
  top.generate();
  //everything is dead after this
  //noLoop();
}

//mouse click listener
void mousePressed() {
  if (top.overCircle(windowWidth/2, windowHeight/2, 500)) {
    //should start task pick sequence here
    top.drawBase(0);
    // top.generate();
  }
}

void draw() {

  this.top.listen();
}

