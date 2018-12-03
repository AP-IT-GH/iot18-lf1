#!/usr/bin/python3
#Made by: Team LabFarm 1
#Subject: I2C - LDR_Sensor_Test

import smbus
import time
from iothub_client import IoTHubClient, IoTHubTransportProvider, IoTHubMessage
import json

CONNECTION_STRING = "HostName=labfarm-iot-hub-v2.azure-devices.net;DeviceId=rpi-master;SharedAccessKey=CVya/T3XD5pO9UfpPw/xX2g4JhUrdmtq15O1MmqoQWA="
PROTOCOL = IoTHubTransportProvider.MQTT

#Global Variables
stop = False
i2c = smbus.SMBus(1) #Channel 1
n = 0
ud = " "
databyte = 0
databyte2 = 0
databyte3 = 0
databyte4 = 0
delay = 30
amount_of_values = 5
canCalculateAvg = False

ldrValues = [0] * amount_of_values
tempValues = [0] * amount_of_values
dustValues = [0] * amount_of_values

#Methods

def send_confirmation_callback(message, result, user_context):
    print("Confirmation received for message with result = %s" % (result))

def Average(list):
    return sum(list) / len(list)

#Main Program
if __name__ == '__main__':
    client = IoTHubClient(CONNECTION_STRING, PROTOCOL)
    
    #Loop
    while not stop:

       #Calculate previous average
       if n == amount_of_values:
          ldrAvg = Average(ldrValues)
          tempAvg = Average(tempValues)
          dustAvg = Average(dustValues)
          print(" ")
          print("---- PREVIOUS AVERAGE ----")
          print("LDR Average:" + str(round(ldrAvg,2)))
          print("Temp Average:" + str(round(tempAvg,2)))
          print("Dust Average:" + str(round(dustAvg,2)))
          print(" ---- ---- ---- ---- ----  ")
      
       #Reset n to 0
       n = 0

       while n < amount_of_values:
  
          #Read Data
          databyte = i2c.read_byte(0x14)
          databyte2 = i2c.read_byte(0x13)
          #databyte3 = i2c.read_byte(0x12)
          databyte4 = i2c.read_byte(0x11)
       
          if databyte4 is not 0:
             
             #Place data in list
             ldrValues[n] = databyte
             tempValues[n] = databyte2
             dustValues[n] = databyte4
            
             n += 1

             #Convert data to Json
             ldrData_Json = {
                "SensorId": 9,
                "SensorValue": databyte
             }

             temperatureData_Json = {
                "SensorId": 11,
                "SensorValue": databyte2
             }

             #conductivityData_Json = {
             #   "SensorId": 3,
             #   "SensorValue": databyte3
             #}

             dustData_Json = {
                "SensorId": 8,
                "SensorValue": databyte4
             }

             ldrData = json.dumps(ldrData_Json)
             temperatureData = json.dumps(temperatureData_Json)
             #conductivityData = json.dumps(conductivityData_Json)
             dustData = json.dumps(dustData_Json)

             print("---- JSON ----")
             print("LDR: " + str(ldrData))
             print("TEMP: " + str(temperatureData))
             print("DUST: " + str(dustData))
             print("---- LISTS ----")
             print(ldrValues)
             print(tempValues)
             print(dustValues)
             print("---- END DATA [" + str(n) + "] ----")
             print(" ")

             #Wait exactly 30 seconds by waiting a certain amount of seconds at each sensor
             time.sleep(delay / amount_of_values)

             #Send to IoT Hub

             message = IoTHubMessage(ldrData)
             client.send_event_async(message, send_confirmation_callback, None)
             message2 = IoTHubMessage(temperatureData)
             client.send_event_async(message2, send_confirmation_callback, None)
             #message3 = IoTHubMessage(conductivityData)
             #client.send_event_async(message3, send_confirmation_callback, None)
             message4 = IoTHubMessage(dustData)
             client.send_event_async(message4, send_confirmation_callback, None)

             print("Messages transmitted to IoT Hub")


   
