/****************************************************************************** 
SparkFun Easy Driver Basic Demo
Toni Klopfenstein @ SparkFun Electronics
March 2015
https://github.com/sparkfun/Easy_Driver

Simple demo sketch to demonstrate how 5 digital pins can drive a bipolar stepper motor,
using the Easy Driver (https://www.sparkfun.com/products/12779). Also shows the ability to change
microstep size, and direction of motor movement.

Development environment specifics:
Written in Arduino 1.6.0

This code is beerware; if you see me (or any other SparkFun employee) at the local, and you've found our code helpful, please buy us a round!
Distributed as-is; no warranty is given.

Example based off of demos by Brian Schmalz (designer of the Easy Driver).
http://www.schmalzhaus.com/EasyDriver/Examples/EasyDriverExamples.html
******************************************************************************/
#include <Wire.h>

#define stp 2
#define dir 3
#define MS1 4
#define MS2 5
#define EN  6

//Declare variables for functions
byte I2c_address;

int received;

void setup() {
  pinMode(stp, OUTPUT);
  pinMode(dir, OUTPUT);
  pinMode(MS1, OUTPUT);
  pinMode(MS2, OUTPUT);
  pinMode(EN, OUTPUT);
  //reset pins
  digitalWrite(stp, LOW);
  digitalWrite(dir, LOW);
  digitalWrite(MS1, LOW);
  digitalWrite(MS2, LOW);
  digitalWrite(EN, HIGH);

  Wire.begin(I2c_address);                // join i2c bus with address #8
  Wire.onReceive(receiveEvent); // register event
  
  Serial.begin(9600); //Open Serial connection for debugging
}

//Main loop
void loop() {
if(1 < Wire.available()(
receiveEvent(1);
MoveInCm(received);
received = 0;
}
}
void receiveEvent(int howmany ) {
  /* while (1 < Wire.available()) { 
    char c = Wire.read(); // receive byte as a character
    Serial.print(c);         
  }*/
  received = Wire.read();    // receive byte as an integer
  Serial.println(x);
}

// dir = 1 => forward
void MoveInCm(float cm){ // 10 => 10cm vooruit | -10 => 10cm achteruit
  //Pull enable pin low to allow motor control
  digitalWrite(EN, LOW); 
  //change direction
  if(cm > 0){
     digitalWrite(dir, LOW); 
  }
  else{
     digitalWrite(dir, HIGH);
  }
  cm = abs(cm);
  //Pull MS1, and MS2 high to set logic to 1/8th microstep resolution
  digitalWrite(MS1, HIGH);
  digitalWrite(MS2, LOW);
  // 0.9° rotation for one step => 400 steps = 360°
  // 10cm => 25 steps with half step mode
  cm /= 10;
  cm *= 25;
  cm *= 400;
  int steps = round(cm);
  for(int x= 0; x<steps; x++){
    // give pulse
    digitalWrite(stp,HIGH);
    delay(1);
    digitalWrite(stp,LOW); 
    delay(1);
  }
  //reset pins
  digitalWrite(stp, LOW);
  digitalWrite(dir, LOW);
  digitalWrite(MS1, LOW);
  digitalWrite(MS2, LOW);
  digitalWrite(EN, HIGH);
}

