#!/usr/bin/python3
import time
from iothub_client import IoTHubClient, IoTHubTransportProvider, IoTHubMessage

channel = 2
address = 0x04

i2c = smbus.SMBus(channel)
i2c.read_byte(0x14)

def writeNumber(value):
    bus.write_byte(address, value)
    return -1
