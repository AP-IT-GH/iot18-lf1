#!/usr/bin/python3
#Made by: Team LabFarm 1
#Subject: I2C - LDR_Sensor_Test

import smbus
import time

stop = False
i2c = smbus.SMBus(1) #Channel 1
n = 0

while not stop:
   n += 1
   databyte = i2c.read_byte(0x14)
   print("Sensor Data " + str(n) + ": " + str(databyte))
   if n == 10:
      stop = True
   time.sleep(2)
   
