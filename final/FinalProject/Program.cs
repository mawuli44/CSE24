using System;
using System.Collections.Generic;

// Interface for devices
public interface IDevice
{
    void TurnOn();
    void TurnOff();
    void Control();
}

// Base class for devices
public abstract class Device : IDevice
{
    private bool isOn;

    public Device()
    {
        isOn = false; // By default, devices are turned off
    }

    public bool IsOn
    {
        get { return isOn; }
    }

    public void TurnOn()
    {
        isOn = true;
        Console.WriteLine("Device turned on.");
    }

    public void TurnOff()
    {
        isOn = false;
        Console.WriteLine("Device turned off.");
    }

    // Abstract method for controlling the device
    public abstract void Control();
}

// Derived class for Lights
public class Light : Device
{
    public override void Control()
    {
        if (IsOn)
        {
            Console.WriteLine("Adjusting brightness of light.");
        }
        else
        {
            Console.WriteLine("Cannot adjust brightness. Light is turned off.");
        }
    }
}

// Derived class for Thermostats
public class Thermostat : Device
{
    private int temperature;

    public override void Control()
    {
        if (IsOn)
        {
            Console.WriteLine("Setting temperature to " + temperature + " degrees.");
        }
        else
        {
            Console.WriteLine("Cannot set temperature. Thermostat is turned off.");
        }
    }

    public void SetTemperature(int temp)
    {
        temperature = temp;
    }
}

// Derived class for Security Cameras
public class SecurityCamera : Device
{
    public override void Control()
    {
        if (IsOn)
        {
            Console.WriteLine("Viewing live feed from security camera.");
        }
        else
        {
            Console.WriteLine("Cannot view feed. Security camera is turned off.");
        }
    }

    public void Record()
    {
        Console.WriteLine("Recording footage from security camera.");
    }
}

// Interface for sensors
public interface ISensor
{
    void Read();
}

// Base class for sensors
public abstract class Sensor : ISensor
{
    public abstract void Read();
}

// Derived class for Motion Sensors
public class MotionSensor : Sensor
{
    public override void Read()
    {
        Console.WriteLine("Motion detected.");
    }
}

// Derived class for Temperature Sensors
public class TemperatureSensor : Sensor
{
    public override void Read()
    {
        Console.WriteLine("Temperature reading obtained.");
    }
}

// Central Control Hub
public class CentralControlHub
{
    private List<IDevice> devices;
    private List<ISensor> sensors;

    public CentralControlHub()
    {
        devices = new List<IDevice>();
        sensors = new List<ISensor>();
    }

    // Method to add devices
    public void AddDevice(IDevice device)
    {
        devices.Add(device);
    }

    // Method to add sensors
    public void AddSensor(ISensor sensor)
    {
        sensors.Add(sensor);
    }

    // Method to control all devices
    public void ControlDevices()
    {
        foreach (IDevice device in devices)
        {
            device.Control();
        }
    }

    // Method to read all sensors
    public void ReadSensors()
    {
        foreach (ISensor sensor in sensors)
        {
            sensor.Read();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create central control hub
        CentralControlHub controlHub = new CentralControlHub();

        // Add devices
        Light light = new Light();
        Thermostat thermostat = new Thermostat();
        SecurityCamera camera = new SecurityCamera();
        controlHub.AddDevice(light);
        controlHub.AddDevice(thermostat);
        controlHub.AddDevice(camera);

        // Add sensors
        MotionSensor motionSensor = new MotionSensor();
        TemperatureSensor temperatureSensor = new TemperatureSensor();
        controlHub.AddSensor(motionSensor);
        controlHub.AddSensor(temperatureSensor);

        // Turn on devices
        foreach (IDevice device in controlHub.Devices)
        {
            device.TurnOn();
        }

        // Control devices
        controlHub.ControlDevices();

        // Read sensors
        controlHub.ReadSensors();
    }
}