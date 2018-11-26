#!/usr/bin/python3
import time
import requests

labfarm_id = 2
url = "http://labfarmwebapp.azurewebsites.net/api/v1/labfarm"+labfarm_id + "/configuration"

def GetConfiguration():
	r = requests.get(url)
	obj = r.json()
	print(obj)
GetConfiguration()
	
