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
    concentration = 1.1*pow(ratio,3)-3.8*pow(ratio,2)+520*ratio+0.62; //Concentration in pcs/0.01cf
    lowPulseOccupancy = 0;
    startTime = millis();
  }
}

void requestEvent()
{
  TinyWire.send(concentration); //send data [1 byte]
}

//0-500 pcs/0.01cf = a clear room
//500-1500 pcs/0.01cf = a “fairly” clean room
//1500-4000 pcs/0.01cf = a room in need of dusting (but not super dusty)
//4000+ pcs/0.01cf = if you have allergies you may notice the room
