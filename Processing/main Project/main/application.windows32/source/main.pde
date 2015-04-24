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

void setup() {
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

void draw() {
  int BaseWheelSize = windowWidth/2;
  int tasksNumber;
  BaseWheel base = new BaseWheel(windowWidth/2, windowHeight/2, BaseWheelSize, BaseWheelSize, people, tasks.length);
  base.generate();
  TopWheel top = new TopWheel(windowWidth/2, windowHeight/2, BaseWheelSize, BaseWheelSize);
  top.generate();
}

