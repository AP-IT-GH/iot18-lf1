#include <TinyWire.h>

byte own_address = 0x11;

//Global Sensor
unsigned long duration;
unsigned long startTime;
unsigned long sampletime_ms = 30000;
unsigned long lowPulseOccupancy = 0;

float ratio = 0;
float concentration = 0;

int sensorPin = A2; 

void setup() 
{
  pinMode(sensorPin, INPUT);
  TinyWire.begin(own_address);      // join i2c bus with address #2
  TinyWire.onRequest(requestEvent); // register event
}

void loop() {
  duration = pulseIn(sensorPin, LOW);
  lowPulseOccupancy = lowPulseOccupancy + duration;
  
  if ((millis()-startTime) >= sampletime_ms) //if the sample time >= 30s
  {
    ratio = lowPulseOccupancy/(sampletime_ms*10.0);  
    concentration = 1.1*pow(ratio,3)-3.8*pow(ratio,2)+520*ratio+0.62;    
    lowPulseOccupancy = 0;
    startTime = millis();
  }
}

void requestEvent()
{
  TinyWire.send(concentration); //send data [1 byte]
}

