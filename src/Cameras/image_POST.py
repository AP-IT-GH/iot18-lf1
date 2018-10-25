#!/usr/bin/python3
from PIL import Image
import io
import json
import base64
import requests

#open image file
img = Image.open("image1.jpg")
#print some image data (optional)
print(img.bits, img.size, img.format)
#convert: .jpg -> byte arary -> UTF-8 string
buffered = io.BytesIO()
img.save(buffered, format= "JPEG")
img_str = base64.b64encode(buffered.getvalue()).decode('UTF-8')
#API POST request, new picture object
r = requests.post("http://localhost:5000/api/picture", json={"content": img_str, "timeStamp": "0001-01-01T00:00:00", "cameraId": 1})
#print status code of POST request
print(r.status_code)





