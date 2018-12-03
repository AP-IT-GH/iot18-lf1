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
  sensorValue = analogRead(sensorPin)*5/1024.0; // read the value from the sensor
  sensorValue -= 0.5; //Convert to Fahrenheit
  sensorValue = sensorValue / 0.01;
}

void requestEvent()
{
  TinyWire.send(sensorValue); //send data [1 byte]
}

