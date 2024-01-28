using System;

public class Fraction
{
    // Private attributes for the numerator and denominator
    private int numerator;
    private int denominator;

    // Constructors
    public Fraction()
    {
        // Default fraction to 1/1
        numerator = 1;
        denominator = 1;
    }

    public Fraction(int top)
    {
        // one parameter  to turn on numerator and denominator
        numerator = top;
        denominator = 1;
    }

    public Fraction(int top, int bottom)
    {
        // two parameters to set off both numerator and denominator
        if (bottom == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }

        numerator = top;
        denominator = bottom;
    }

    // Getters and Setters
    public int GetNumerator()
    {
        return numerator;
    }

    public void SetNumerator(int top)
    {
        numerator = top;
    }

    public int GetDenominator()
    {
        return denominator;
    }

    public void SetDenominator(int bottom)
    {
        if (bottom == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }

        denominator = bottom;
    }

    // Methods to return representations
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}