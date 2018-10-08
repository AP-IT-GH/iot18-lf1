#include <TinyWire.h>

byte own_address = 0x13;

//Global Sensor
int sensorPin = A2; 
float sensorValue = 0; 

void setup() 
{
  pinMode(sensorPin, INPUT);
  TinyWire.begin(own_address);      // join i2c bus with address #2
  TinyWire.onRequest(requestEvent); // register event
}

void loop() {
  delay(100);
}

void requestEvent()
{
  sensorValue = analogRead(sensorPin)*5/1024.0; // read the value from the sensor
  sensorValue -= 0.5;
  sensorValue = sensorValue / 0.01;
  TinyWire.send(sensorValue); //send data [1 byte]
}

