#include <TinyWire.h>
#include <Adafruit_NeoPixel.h>
#ifdef __AVR__
  #include <avr/power.h>
#endif

#define LEDS                       60    // Amount of LEDs in a strip
#define PIN                           0     // Data pin connected to the strip
#define DELAY_MILLIS        5     // Number of milliseconds to wait between a pixel update

int red = 0;                                  
int green = 0;
int blue = 0;
int brightness = 128;

// I2C address
byte own_address = 0x15;            // Might need to edit this address

Adafruit_NeoPixel ledstrip = Adafruit_NeoPixel(LEDS, PIN, NEO_GRB + NEO_KHZ800);            // Create a new Adafruit NeoPixel LED object


void setup() 
{
  ledstrip.begin();

  TinyWire.begin(own_address);                  // join i2c bus with address #2
  TinyWire.onRequest(requestEvent);         // register request event
  TinyWire.onReceive(receiveEvent);         // register receive event

  setColor(100, 60, 180);
  setBrightness(200);
  delay(2000);
  setBrightness(128);
  setColor(0, 0, 0);

  
}


void loop() 
{
  
}


// Set the color of the LED strip
void setColor(int r, int g, int b)
{
  red = r;
  green = g;
  blue = b;

  showLedstrip();
}


// Set the brightness of the LED strip
void setBrightness(int b) 
{
  brightness = b;
  showLedstrip();
}


// Turn on all the lights in the LED strip
void showLedstrip() 
{
   for(int i = 0; i < LEDS; i++) {
      ledstrip.setPixelColor(i, red ,green, blue, brightness);
      ledstrip.show();
      delay(DELAY_MILLIS);
    }
}


void requestEvent() 
{
  
}

void receiveEvent(int b)
{
  while (1 < Wire.available()) {      // loop through all but the last
    char c = Wire.read();               // receive byte as a character
  }
  int x = Wire.read();                    // receive byte as an integer
  setBrightness(x);                       // setBrightness x or b ?
}
