#include <TinyWire.h>

byte own_address = 0x12;

//Global Sensor
int sensorPin = PB1; 
float sensorValue = 0; 

void setup() 
{
  pinMode(sensorPin, INPUT);
  TinyWire.begin(own_address);      // join i2c bus with address #2
  TinyWire.onRequest(requestEvent); // register event
}

void loop() {
  sensorValue = analogRead(sensorPin); // read the value from the sensor
  //sensorValue = sensorValue*(5.0/1023.0); //Convert to voltage drop across the probe
}

void requestEvent()
{
  TinyWire.send(sensorValue); //send data [1 byte]
}

