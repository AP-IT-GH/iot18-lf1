#!/usr/bin/python3
from picamera import PiCamera
import time
from PIL import Image
import io
import base64
import requests
import os
import RPi.GPIO as GPIO
from pictureconfig import *

#setup camera
camera = PiCamera()
#get time
last_time = time.time()

print("setup done")

def SendPicture(pin):
	# prevent callback function fire twice
	global last_time
	current_time = time.time()
	duration = current_time - last_time
	if duration > 6:
		print("callback called")
		print("taking picture..")
		#take picture
		camera.start_preview()
		time.sleep(2)
		camera.capture('/home/pi/IoT/Camera/Pictures/'+random_name)
		camera.stop_preview()
		print("sending picture")
		#setup url
		image_name = random_name
		url = "http://labfarmwebapp.azurewebsites.net/api/v1/labfarm/"+labfarm_id+"/plants/"+plant_name+"/pictures"

		#open image file
		img = Image.open("Pictures/"+image_name)

		#convert: .jpg -> byte array -> UTF-8 string
		buffered = io.BytesIO()
		img.save(buffered, format ="JPEG")
		img_str = base64.b64encode(buffered.getvalue()).decode('UTF-8')

		#API POST request, new picture object
		json_body={"content":img_str}

		# using json paramater will change the Content-Type to application/json
		r = requests.post(url,json=json_body)
		print(r.status_code)

		#delete picture
		os.remove("/home/pi/IoT/Camera/Pictures/"+ random_name)
		print("picture send succesfully")
		print("press any key to end script")
		#reset timer
		last_time = time.time()
#hardware pins setup
GPIO.setmode(GPIO.BCM)
GPIO.setup(pin1,GPIO.IN,pull_up_down=GPIO.PUD_DOWN)
GPIO.add_event_detect(pin1,GPIO.RISING,callback=SendPicture,bouncetime=200)

input("press any key to end script")

#cleanup
GPIO.remove_event_detect(pin1)
GPIO.cleanup()
