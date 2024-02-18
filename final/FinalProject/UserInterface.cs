using System;

public class UserInterface
{
    private CentralControlHub Hub { get; set; }

    public UserInterface(CentralControlHub hub)
    {
        Hub = hub;
    }