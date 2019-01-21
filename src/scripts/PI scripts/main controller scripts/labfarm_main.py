#!/usr/bin/python3
#Made by: Team LabFarm 1

#imports
import time
from labfarm_module import *

class StateMachine(object):

	webconfig_interval = 3600 #1u
	sensor_interval = 1800 #0.5u
	picture_interval = 3600 #1u

	start_time = time.time()
	
	def __init__(self):
		self.state = StartupState()
	
	# automatically changes back to idle
	def go_read_webconfig_state(self):
		self.state = self.state.go_read_webconfig_state()
	
	# automatically changes back to idle
	def go_sensor_values_state(self):
		self.state = self.state.go_sensor_values_state()
	
	# automatically changes back to idle
	def go_take_picture_state(self):
		self.state = self.state.go_take_picture_state()

	def go_idle_state(self):
		self.state = self.state.go_idle_state()
	
	def update(self):
		if time.time() >= self.start_time + self.webconfig_interval:
			go_read_webconfig_state()
			self.webconfig_interval += self.webconfig_interval

		if time.time() >= self.start_time + self.sensor_interval:
			go_sensor_values_state()
			self.sensor_interval += self.sensor_interval

		if time.time() >= self.start_time + self.picture_interval:
			go_take_picture_state()
			self.picture_interval += self.picture_interval

state_machine = StateMachine()

#exit with Ctrl-C
try:
	while True:
		state_machine.update()
except KeyboardInterrupt:
	pass 
