# Setting up a ready-to-use raspberry pi for iothub


## Setup development environment on the rapsberry pi
For this project we use the azure-iothub-device-client SDK with the MQTT protocol to connect to the IoT hub. We are using python3 so make sure you setup the environment accordingly.
Check your current python3 version with: `python3 --version` and make sure your version is 3.5.X or higher.


## Installing python modules
Type the following command in the command prompt: `pip install azure-iothub-device-client` to download the right python modules for installing the SDK on your raspberry pi.


## Building the SDK
### Installs needed to compile the SDKs for Python
1. Clone the Azure IoT Python SDK Repository

    ```
    git clone --recursive https://github.com/Azure/azure-iot-sdk-python.git
    ```

2. For Ubuntu, you can use apt-get to install the right packages:

    ```
    sudo apt-get update
    sudo apt-get install -y git cmake build-essential curl libcurl4-openssl-dev libssl-dev uuid-dev
    ```

3. Verify that CMake is at least version **2.8.12**:

    ```
    cmake --version
    ```

4. Verify that gcc is at least version **4.4.7**:

    ```
    gcc --version
    ```

### Compile the Python modules
1. Clone the Azure IoT Python SDK Repository

    ```
    git clone --recursive https://github.com/Azure/azure-iot-sdk-python.git
    ```

2. Navigate to the folder **build_all/linux** in your local copy of the repository.
3. Run the `./setup.sh` script to install the prerequisite packages and the dependent libraries.
    * Setup will default to python 2.7
    * To setup dependencies for python version greater than 3, run `./setup.sh --python-version X.Y` where "X.Y" is the python version (3.5 or 3.6)
5. Run the `./build.sh` script.
    * The build will be default to python 2.7 aswell, so run `./build.sh --build-python X.Y`
6. After a successful build, the `iothub_client.so` Python extension module is copied to the [**device/samples**][device-samples] and [**service/samples**][service-samples] folders. Visit these folders for instructions on how to run the samples.


### Sample applications

This repository contains various Python sample applications that illustrate how to use the Microsoft Azure IoT SDKs for Python.
* [Samples showing how to use the Azure IoT Hub device client][device-samples]

#### Bron:
https://github.com/Azure/azure-iot-sdk-python/blob/master/doc/python-devbox-setup.md