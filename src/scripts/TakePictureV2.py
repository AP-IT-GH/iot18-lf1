#!/usr/bin/python3
from picamera import PiCamera
import time
from PIL import Image
import os

#setup camera
camera = PiCamera()
#get time for picture name
last_time = time.time()


def TakePicture():
	print("taking picture..")
	#take picture
	camera.start_preview()
	time.sleep(5)
	imageName = 'picture_' + str(time.time()) + '.jpg'
	camera.capture('/home/pi/IoT/Camera/Pictures/' + imageName)
	camera.stop_preview()

def AnalysePicture():
	image_path = '/home/pi/IoT/Camera/Pictures/'


takePicture = input("Press 'Enter' to take a picture")
TakePicture()
