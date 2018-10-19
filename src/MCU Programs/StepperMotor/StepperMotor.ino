//////////////////////////////////////////////////////////////////
//©2011 bildr
//Released under the MIT License – Please reuse change and share
//Using the easy stepper with your arduino
//use rotate and/or rotateDeg to controll stepper motor
//spd is any number from .01 -> 1 with 1 being fastest –
//Slower spd == Stronger movement
/////////////////////////////////////////////////////////////////
//modified by Steven De Keuster
/////////////////////////////////////////////////////////////////

int DIR_PINS[] = {2, 2, 2};
int STEP_PINS[] = {3, 3, 3};

int motor1 = 0;
int motor2 = 1;
int motor3 = 2;


void setup() {
  pinMode(DIR_PINS, OUTPUT);
  pinMode(STEP_PINS, OUTPUT);
}

void loop(){

  //rotate a specific number of degrees
  rotateDeg(motor1, 360, 1);
  delay(1000);

  rotateDeg(motor1, -360, .1); //reverse
  delay(1000);

  //rotate a specific number of microsteps (8 microsteps per step)
  //a 200 step stepper would take 1600 micro steps for one full revolution
  rotate(motor1, 1600, .5);
  delay(1000);

  rotate(motor1, -1600, .25); //reverse
  delay(1000);
}



void rotate(int motor, int steps, float spd){
  //rotate a specific number of microsteps (8 microsteps per step) – (negitive for reverse movement)
  //spd is any number from .01 -> 1 with 1 being fastest – Slower is stronger
  int dir = (steps > 0)? HIGH:LOW;
  steps = abs(steps);

  digitalWrite(DIR_PINS[motor],dir);

  float usDelay = (1/spd) * 70;

  for(int i=0; i < steps; i++){
    digitalWrite(STEP_PINS[motor], HIGH);
    delayMicroseconds(usDelay);
    digitalWrite(STEP_PINS[motor], LOW);
    delayMicroseconds(usDelay);
  }
}


void rotateDeg(int motor, float deg, float spd){
  //rotate a specific number of degrees (negitive for reverse movement)
  //spd is any number from .01 -> 1 with 1 being fastest – Slower is stronger
  int dir = (deg > 0)? HIGH:LOW;
  digitalWrite(DIR_PINS[motor],dir);

  int steps = abs(deg)*(1/0.225);
  float usDelay = (1/spd) * 70;

  for(int i=0; i < steps; i++){
    digitalWrite(STEP_PINS[motor], HIGH);
    delayMicroseconds(usDelay);
    digitalWrite(STEP_PINS[motor], LOW);
    delayMicroseconds(usDelay);
  }
}
