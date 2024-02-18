using System;

public class CentralControlHub
{
    private List<Device> Devices { get; set; }
    private List<Sensor> Sensors { get; set; }
    private List<Actuator> Actuators { get; set; }

    public CentralControlHub()
    {
        Devices = new List<Device>();
        Sensors = new List<Sensor>();
        Actuators = new List<Actuator>();
    }

    public void AddDevice(Device device)
    {
        Devices.Add(device);
    }

    public void AddSensor(Sensor sensor)
    {
        Sensors.Add(sensor);
    }

    public void AddActuator(Actuator actuator)
    {
        Actuators.Add(actuator);
    }

    // Methods for user interface, automation, etc.
}