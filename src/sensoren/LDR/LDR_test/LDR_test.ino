#include <Wire.h>

int sensorPin = 7; // select the input pin for LDR
int sensorValue = 0; // variable to store the value coming from the sensor

void setup() {
  Wire.begin(0x14);
  Wire.onRequest(requestEvent);
}

void loop() {
delay(100);
}

void requestEvent() {
  sensorValue = analogRead(sensorPin);
  Wire.write(sensorValue);
}
