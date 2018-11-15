#!/usr/bin/python3
from picamera import PiCamera
from time import sleep
from PIL import Image
import io
import base64
import requests
import os

#random file name
random_name = "plant_picture.jpg"

camera = PiCamera()
camera.start_preview()
sleep(2)
camera.capture('/home/pi/IoT/Camera/Pictures/'+random_name)
camera.stop_preview()

image_name = random_name
labfarm_id = "1"
plant_name = "Test plant 1"

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


