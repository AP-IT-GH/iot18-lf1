# Sensor values flow
In this document we will illustrate step-by-step how the sensor values are proccesed and sent for this project.


1. The first step is ofcourse the sensor reading out the environment parameters. The sensor translates the environmental parameters into a voltage value which in turn gets converted to the correct physical quantity.

2. The sensor values are then received by the ATtiny and any mapping that might need to be done is done here. Also, if we need to change a sensor value unit, we do that here.

3. Next, the sensor values are sent to a central raspberry Pi over I²C. With the raspberry Pi being the master receiver and the ATtiny's being the slave sender.

4. We read out the sensor values for a defined period of time and take an average of 5 values. This value is then sent to the IoT hub via the iothub SDK over MQTT. We do this because a single value might not be as accurate as we want it to be. This finale average value is then finally sent in a JSON format like this:
![alt text](https://github.com/AP-Elektronica-ICT/.JPG)
Every new labfarm connected will autmatically check if it already exists. If not it will generate a new one in the database with the standard sensors.

5. IoT hub receives these values and through azure data streamer analytics job the values are put in the SQL database. A timestamp will automatically be added by the IoT hub.

6. The values are now ready to be used by our API.
