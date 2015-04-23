

//rect(x,y,w,h);
//rect(90,0,10,20);


//ellipse(x,y,w,h)
//ellipse(20,20,20,20); 

/* for(int i=0;i<10;i++){
 
 rect(0+i,+i,Math.abs(-20)+i,20+i);
 }
 */
//background(23, 213, 23);
//stroke(255, 0, 0);
//fill(0,0,255);
//rect(0,0,200,200);
//globals

//SETUP -> onstart initiation
void setup() {
  int w = 500;
  int h = 500;
  size(w, h);
}

void draw() {
  background(0);

  ellipse(eX, eY, 100, 100);
}

