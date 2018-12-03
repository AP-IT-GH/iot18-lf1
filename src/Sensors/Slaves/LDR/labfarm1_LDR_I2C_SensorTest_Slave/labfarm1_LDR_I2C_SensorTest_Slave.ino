#include <TinyWire.h>

byte own_address = 0x14;

//Global Sensor
int sensorPin = A2; 
int sensorValue = 0; 

void setup() 
{
  pinMode(sensorPin, INPUT);
  TinyWire.begin(own_address);      // join i2c bus with address #2
  TinyWire.onRequest(requestEvent); // register event
}

void loop() {
  sensorValue = analogRead(sensorPin); // read the value from the sensor
}

void requestEvent()
{
  TinyWire.send(sensorValue); //send data [1 byte]
}

