using System;

// Device base class
public abstract class Device
{
    public string Name { get; protected set; }
    public bool IsConnected { get; protected set; }

    public abstract void TurnOn();
    public abstract void TurnOff();
}