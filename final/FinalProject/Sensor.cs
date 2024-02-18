public abstract class Sensor
{
    public abstract void ReadData();
}

public class MotionSensor : Sensor
{
    public override void ReadData()
    {
        // Reading the data from motion sensor
    }
}

public class TemperatureSensor : Sensor
{
    public override void ReadData()
    {
        // Reading data from temperature sensor
    }
}