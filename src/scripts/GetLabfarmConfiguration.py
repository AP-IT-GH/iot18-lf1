#!/usr/bin/python3
import time
import requests
import json
from getlabfarmconfig import *

labfarm_id = "2"
url = "http://labfarmwebapp.azurewebsites.net/api/v1/labfarm/"+labfarm_id + "/configuration"

def GetConfiguration():
	r = requests.get(url)
	obj = r.json()
	print("Valve: "+ str(obj['valve']))
	print("Pump: "+ str(obj['pump']))

while True:
    GetConfiguration()
    time.sleep(interval_time)

