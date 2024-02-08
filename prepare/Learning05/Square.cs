using System;

public class Square : Shape
{
    private double side;

    public double Side
    {
        get { return side; }
        set { side = value; }
    }

    public Square(string color, double side) : base(color)
    {
        this.side = side;
    }

    public override double GetArea()
    {
        return side * side; 
    }
}