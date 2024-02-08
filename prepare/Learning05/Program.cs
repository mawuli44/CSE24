using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold shapes
        List<Shape> shapes = new List<Shape>();

        // Addind  square, rectangle, and circle to the list
        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4, 6));
        shapes.Add(new Circle("Green", 3));

        // Iterating through the list of shapes
        foreach (Shape shape in shapes)
        {
            // Display color and area of each shape
            Console.WriteLine($"Color: {shape.Color}, Area: {shape.GetArea()}");
        }
    }
}