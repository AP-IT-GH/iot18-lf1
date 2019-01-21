#import labfarm configuration
from labfarm_module_config import * 
import RPi.GPIO as GPIO
import time
import requests
import json
from iothub_client import IoTHubClient, IoTHubTransportProvider, IoTHubMessage
import smbus

#state machine classes
class State(object):

	def __init__(self,active_pins = [],inactive_pins = []):
		print('Switching to state: '+ str(self))
		self.active_components = active_pins
		self.inactive_components = inactive_pins
		self.set_active()
		self.set_inactive()
		if len(self.active_components) == 0 and len(self.inactive_components) == 0:
			print('No pins changed')
		elif len(self.active_components) == 0 and len(self.inactive_components) != 0:
			print('Set pins ' + str(self.inactive_components)[1:-1] + ' inactive')
		elif len(self.active_components) != 0 and len(self.inactive_components) == 0:
			print('Set pins ' + str(self.active_components)[1:-1] + ' active')
		elif len(self.active_components) != 0 and len(self.inactive_components) != 0:
			print('Set pins ' + str(self.active_components)[1:-1] + ' active, '+ str(self.inactive_components)[1:-1] + ' inactive')		
		
	def __repr__(self):
		return self.__str__()

	def __str__(self):
		return self.__class__.__name__

	def set_active(self):
		for x in range(0,len(self.active_components)):
			GPIO.output(self.active_components[x],True)     

	def set_inactive(self):
		for x in range(0,len(self.inactive_components)):
			GPIO.output(self.inactive_components[x],False)  

	def go_read_webconfig_state():
		return ReadWebConfigState()

	def go_sensor_values_state():
		return SendSensorValuesState()

	def go_take_picture_state():
		return TakePictures()

	def go_idle():
		return IdleState()

 
# overbodig? inlezen config file? imports? pin configuration
class StartupState(State):
	def __init__(self):
		GPIO.setmode(GPIO.BCM)
		self.output_pins = [camera_pin_1,camera_pin_2,camera_pin_3]
		self.input_pins = []
		self.set_output()
		self.set_input()
		active_pins = []
		inactive_pins = []
		State.__init__(self,active_pins,inactive_pins)
		print(str(self)+' loaded')
		State.go_idle()

	def set_output(self):
			for x in range(0,len(self.output_pins)):
				GPIO.setup(self.output_pins[x],GPIO.OUT)

	def set_input(self):
			for x in range(0,len(self.input_pins)):
				GPIO.setup(self.input_pins[x],GPIO.IN)

# idle state reads sensor values
class IdleState(State):
	def __init__(self):
		active_pins = []
		inactive_pins = []
		State.__init__(self,active_pins,inactive_pins)
		i2c = smbus.SMBus(1) # channel 1
		data_byte_1 = 0.0
		data_byte_2 = 0.0
		data_byte_3 = 0.0
		data_byte_4 = 0.0
		self.ldr_values = []
		self.temp_values = []
		self.dust_values = []
		self.conductivity_values = []
				
		while True:
			#Read Data
			data_byte_1 = i2c.read_byte(0x14)
			data_byte_2 = i2c.read_byte(0x13)
			data_byte_3 = i2c.read_byte(0x12)
			data_byte_4 = i2c.read_byte(0x11)

			#read data till b 4 bytes != 0
			if data_byte_4 is not 0.0:
				#TODO: variable id's
				ldr_values.append(data_byte_1)
				temp_values.append(data_byte_2)
				conductivity_values.append(data_byte_3)
				dust_values.append(data_byte_4)
				# clear data
				data_byte_1 = 0.0
				data_byte_2 = 0.0
				data_byte_3 = 0.0
				data_byte_4 = 0.0


class ReadWebConfigState(State):

	def __init__(self):
		active_pins = []
		inactive_pins = []
		State.__init__(self,active_pins,inactive_pins)        
		self.active_components = []
		self.inactive_components = []
		r = requests.get(CONFIG_URL)
		obj = r.json()
		print("Valve : "+ str(obj['valve']))
		print("Pump : "+ str(obj['pump']))
		print("Done reading webconfig and configuring pump/valve.")
		Self.go_idle()
		
class SendSensorValuesState(State):
	def __init__(self,ldr = [],temp = [],dust = [],conduct = []):
		active_pins = []
		inactive_pins = []
		State.__init__(self,active_pins,inactive_pins)       
		PROTOCOL = IoTHubTransportProvider.MQTT
		#remove last item from list, to prevent incorrect data when exiting idle state middle in reading data
		ldr = ldr[:-1]
		temp = temp[:-1]
		dust = dust[:-1]
		conduct = conduct[:-1]
		ldr_values = ldr
		temp_values = temp
		dust_values = dust
		conductivity_values = conduct
		#calculate average
		ldr_average = average(ldr_values)
		temp_average = average(temp_values)
		dust_average = average(dust_values)
		conductivity_average = average(conductivity_values)
		print(" ")
		print("---- AVERAGE SENSOR VALUES ----")
		print("LDR :" + str(round(ldr_average,2)))
		print("Temp :" + str(round(temp_average,2)))
		print("Dust :" + str(round(dust_average,2)))
		print("Con :" + str(round(conductivity_average,2)))
		print(" ---- ---- ---- ---- ----  ")
		#TODO: variable id's
		ldr_data = json.dumps(data_to_json(ldr_sensor_id,ldr_average))
		temp_data = json.dumps(data_to_json(temp_sensor_id,temp_average))
		conduct_data = json.dumps(data_to_json(conduct_sensor_id,conductivity_average))
		dust_data = json.dumps(data_to_json(dust_sensor_id,dust_average))
		#send to IoT hub
		client = IoTHubClient(CONNECTION_STRING, PROTOCOL)

		ldr_message = IoTHubMessage(ldr_data)
		temp_message = IoTHubMessage(temp_data)
		conduct_message = IoTHubMessage(conduct_data)
		dust_message = IoTHubMessage(dust_data)

		client.send_event_async(ldr_message, send_confirmation_callback, None)
		client.send_event_async(temp_message, send_confirmation_callback, None)
		client.send_event_async(conduct_message, send_confirmation_callback, None)
		client.send_event_async(dust_message, send_confirmation_callback, None)
		print("Messages transmitted to IoT Hub")
		State.go_idle()

	def send_confirmation_callback(message, result, user_context):
		print("Confirmation received for message with result = %s" % (result))

	def calculate_average(list):
		return sum(list) / len(list)
	
	def data_to_json(sensor_id,data_byte):
		obj = {
			"SensorId": sensor_id,
			"SensorValue": data_byte
		}
		return obj


class TakePictures(State):
	def __init__(self):
		active_pins = []
		inactive_pins = []
		State.__init__(self,active_pins,inactive_pins)
		# 3 Atmega steppenmotor controllers
		GPIO.output(camera_pin_1,True)
		GPIO.output(camera_pin_2,True)
		GPIO.output(camera_pin_3,True)
		time.sleep(1)
		GPIO.output(camera_pin_1,False)
		GPIO.output(camera_pin_2,False)
		GPIO.output(camera_pin_3,False)
		
		print("Pulse send to PI camera controllers")
		State.go_idle()
		
