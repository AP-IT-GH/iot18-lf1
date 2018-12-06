#!/usr/bin/python3
import RPi.GPIO as GPIO
import time
from pulseconfig import *

GPIO.setmode(GPIO.BCM)
GPIO.setup(pin1,GPIO.OUT)
GPIO.setup(pin2,GPIO.OUT)
GPIO.setup(pin3,GPIO.OUT)

while True:
	GPIO.output(pin1,True)
	GPIO.output(pin2,True)
	GPIO.output(pin3,True)
	time.sleep(1)
	GPIO.output(pin1,False)
	GPIO.output(pin2,False)
	GPIO.output(pin3,False)
	time.sleep(picture_interval)
GPIO.cleanup()