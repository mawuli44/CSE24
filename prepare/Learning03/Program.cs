using System;

class Program
{
    static void Main(string[] args)
    {
    
    {
        // Creating instances using different constructors
        Fraction fraction1 = new Fraction();      // 1/1
        Fraction fraction2 = new Fraction(6);    // 6/1
        Fraction fraction3 = new Fraction(6, 7);  // 6/7

        // Displaying initial fractions
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());

        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());

        // Modifying fractions using setters
        fraction1.SetNumerator(5);
        fraction2.SetDenominator(3);

        // Displaying modified fractions
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());
    }
} 