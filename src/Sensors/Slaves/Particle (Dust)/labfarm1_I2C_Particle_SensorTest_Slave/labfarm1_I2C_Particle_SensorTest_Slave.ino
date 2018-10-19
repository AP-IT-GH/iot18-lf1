#include <TinyWire.h>

byte own_address = 0x11;

//Global Sensor
int sensorPin = A2; 
float sensorValue = 0; 
float dustDensity = 0;

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
  sensorValue = analogRead(sensorPin); // read the value from the sensor
  sensorValue = sensorValue*(5.0/1024.0); //Convert to voltage
  dustDensity = 0.17 * sensorValue - 0.1; //Calculate dust density
  TinyWire.send(dustDensity); //send data [1 byte]
}

