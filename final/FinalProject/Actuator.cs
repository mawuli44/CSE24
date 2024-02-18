using System;

public abstract class Actuator
{
    public abstract void ExecuteAction();
}

public class Relay : Actuator
{
    public override void ExecuteAction()
    {
        // Execute action using relay
    }
}

public class ServoMotor : Actuator
{
    public override void ExecuteAction()
    {
        // Execute action using servo motor
    }
}