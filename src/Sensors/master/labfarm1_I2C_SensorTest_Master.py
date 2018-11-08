#!/usr/bin/python3
#Made by: Team LabFarm 1
#Subject: I2C - LDR_Sensor_Test

import smbus
import time
import paho.mqtt.client as mqtt

#Global Variables
stop = False
i2c = smbus.SMBus(1) #Channel 1
n = 0
ud = " "
databyte = 0
databyte2 = 0

#Methods
def sendData():
   
   global ud
   global databyte
   global databyte2
 
   ud = "LDR: " + str(databyte)
   print("Sending databyte")
   client.publish("testtopic/ap/smartPlantenbak", ud,  qos=1)
   time.sleep(5)
   ud = "Temperature: " + str(databyte2) 
   print("Sending databyte2")
   client.publish("testtopic/ap/smartPlantenbak", ud, qos=1)
   time.sleep(5)

def on_connect(client, userdata, flags, rc):
   print("Connected with result code " + str(rc))

def on_publish(client, userdata, msg):
   print("mid: " + str(msg))



#MQTT Client (public)
client = mqtt.Client(client_id="clientId-8geZihk3K0",clean_session=True)
client.connect("broker.mqttdashboard.com")
client.on_connect = on_connect
client.on_publish = on_publish
client.loop_start()


#Loop
while not stop:
   n += 1 
   databyte = i2c.read_byte(0x14)
   databyte2  = i2c.read_byte(0x13)
   sendData()
   #print("Sensor Data - LDR " + str(n) + ": " + str(databyte))
   #print("Sensor Data - MCP " + str(n) + ": " + str(databyte2))
   if n == 10:
      stop = True
   time.sleep(2)
   
