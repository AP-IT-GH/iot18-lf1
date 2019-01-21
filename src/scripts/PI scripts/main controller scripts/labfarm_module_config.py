#get labfarm config
labfarm_id = "2"
CONFIG_URL = "http://labfarmwebapp.azurewebsites.net/api/v1/labfarm/"+labfarm_id + "/configuration"

#send pulse config
camera_pin_1 = 17
camera_pin_2 = 27
camera_pin_3 = 22 

#read sensor values
CONNECTION_STRING = "HostName=labfarm-iot-hub-v3.azure-devices.net;DeviceId=rpi-master;SharedAccessKey=DpPQwQdPOMxTiKC3stO4Nu/SjvqZGLKc9+UqAibsN6Y="
ldr_sensor_id = 2
temp_sensor_id = 4
conduct_sensor_id = 3
dust_sensor_id = 1
