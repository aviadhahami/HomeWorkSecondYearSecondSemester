class TopWheel {

  final static String PLACEHOLDER = "System is waiting...";
  final static float DEVISION_CONSTANT = 1.2;

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

  int amountOfTasks;

  Person activePerson;

  TaskDots activePersonDots;

  LinkedList<Person> people;

  public TopWheel(int xPos, int yPos, int cWidth, int cHeight, LinkedList<Task> tasks, LinkedList<Person> people, Person person) {
    this.xPos = xPos;
    this.yPos = yPos;
    this.cWidth = cWidth/DEVISION_CONSTANT;
    this.cHeight = cHeight/DEVISION_CONSTANT;
    this.tasks = tasks;


    this.iconWidth = this.cWidth/4;
    this.iconHeight = this.cHeight/4;

    this.iconX = this.xPos - this.iconWidth/2;
    this.iconY = this.yPos - this.cWidth/2 + 50;

    this.currentItemInTasksArray = 0;

    this.activePerson = person;

    this.amountOfTasks = tasks.size();

    this.people = people;
  }

  //listenenes to mouse hover
  void listen() {
    if (overCircle(0, 0, 100) ) {
      //System.out.println("hover");
    } else {
      //System.out.println("====");
    }
  }

  void generateWaitingPosition() {
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

  void generateTaskChooser() {
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
  void updateCurrentTask(String name, int amount, PImage icon) {
    this.currentTaskName = name;
    this.currentTaskAmout = amount;
    this.currentTaskIcon=icon;
  }

  //shows the amount of options per task
  void generateTaskAmountChooser() {
    this.activePersonDots = new TaskDots(this.cWidth, this.cHeight, this.cWidth, activePerson);
    //init stuff

    //update amount of current tasks for a given key press
    switch(keyCode) {
      //clicked left
      case(37):
      { 
        //System.out.println("left");
        this.currentTaskAmout =  this.currentTaskAmout == 0 ? 0 : --this.currentTaskAmout;
        //increase active person tasks
        updateActivePersonTasks(true);
        break;
      }
      //clicked right
      case(39):
      {
        //System.out.println("right");
        this.currentTaskAmout =this.currentTaskAmout == this.currentTaskOriginAmount ? this.currentTaskOriginAmount : ++this.currentTaskAmout;
        //decrease active person tasks
        updateActivePersonTasks(false);
        break;
      }
      //first run
      case(0):
      {
        System.out.println("first time");
        //don't ask me about the following line.
        this.currentTaskAmout = this.currentTaskAmout;
        break;
      }
    }
    //draw bottom wheel
    //moving from float to int
    int ellipseRad = Math.round(cWidth*DEVISION_CONSTANT);
    //generate new base wheel
    BaseWheel updatedBase = new BaseWheel(xPos, yPos, ellipseRad, ellipseRad, people, amountOfTasks);
    updatedBase.generate();
    //draw upper wheel
    drawBase(255);
    int fontSize = 35;
    initText(fontSize, 73, 137, 204);
    //display icons
    image(this.currentTaskIcon, iconX, iconY, iconWidth, iconHeight);
    text(this.currentTaskName, xPos - fontSize*2, yPos);
    activePersonDots.generateDots(this.currentTaskAmout);
  }

  void updateActivePersonTasks(boolean actionFlag) {
    //true means we increase
    LinkedList<Person> newList = new LinkedList<Person>();
    for (Person p : people) {
      if (p.getName() == activePerson.getName()) {
        if (actionFlag) {
          if (! (p.getAmountOfTasks()+1 > currentTaskOriginAmount)) {
            p.increaseAmountOfTasks();
          }
        } else {
          if (! (p.getAmountOfTasks() -1 < 0)) {
            p.decreaseAmountOfTasks();
          }
        }
      }
      newList.add(p);
      // System.out.println(p.getAmountOfTasks());
    }
    this.people = newList;
  }
  //iterating all tasks in the tasks list, returns an array with all the names
  Hashtable<String, Integer> mapTasksToHash() {
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
  Hashtable<String, PImage> mapTasksToIcons() {
    Hashtable<String, PImage> table = new Hashtable(); 
    for (Task t : tasks) {
      if (! table.containsKey(t.getName())) {
        table.put(t.getName(), t.getIcon());
      }
    }

    return table;
  }
  String[] getTaskNamesArray() {
    LinkedList<String> list = new LinkedList(); 
    for (Task t : tasks) {
      if (! list.contains(t.getName())) {
        list.add(t.getName());
      }
    }
    return list.toArray(new String[list.size()]);
  }
  void drawBase(int c) {
    noStroke(); 
    fill(c); 
    ellipse(xPos, yPos, cWidth, cWidth);
  }
  void initText(int fSize, int r, int g, int b) {
    textFont(createFont("Arial", fSize)); 
    fill(r, g, b);
  }

  void showTask(Task t) {
    int fontSize=32; 
    initText(fontSize, 0, 0, 0); 
    text(t.getName(), xPos - fontSize*4, yPos); 
    image(t.getIcon(), this.iconX, this.iconY, iconWidth, iconHeight);
  }



  //mouse hover listener
  boolean overCircle(int x, int y, int diameter) {
    float disX = x - mouseX; 
    float disY = y - mouseY; 
    if (sqrt(sq(disX) + sq(disY)) < diameter/2 ) {
      return true;
    } else {
      return false;
    }
  }
}

