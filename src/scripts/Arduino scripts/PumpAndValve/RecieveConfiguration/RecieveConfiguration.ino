#include <Wire.h>

byte own_address = 0x15;
int pump;
bool teller = false;

int pump_val;
bool valve_val;

void setup() {
  Wire.begin(own_address);                // join i2c bus with address #15
  Wire.onReceive(receiveEvent); // register event
  Serial.begin(9600);           // start serial for output
  Serial.print("Setup completed");
}

void loop() {
  delay(1000);  
}

// function that executes whenever data is received from master

void receiveEvent(int howMany) {
  int x = Wire.read();    // receive byte as an integer
  if(x == 0 | x == 1){
    valve_val = x;
    Serial.println("Valve: " + String(valve_val));
  }
  else{
    pump_val = x;
    Serial.println("Pump: " + String(pump_val));
  }
}
