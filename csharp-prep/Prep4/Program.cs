using System;

class Program
{
    static void Main(string[] args)
    {
        //  Ask the user for a series of numbers and append to a list
        List<double> numbers = new List<double>();
        double number;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            number = Convert.ToDouble(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }

        } while (number != 0);

        // Sum of the numbers in the list
        double sum = numbers.Sum();

        //  Average of the numbers in the list
        double average = numbers.Count > 0 ? numbers.Average() : 0;

        //Find the maximum number in the list
        double maxNumber = numbers.Count > 0 ? numbers.Max() : 0;

        // Print results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maxNumber}");

        //  The smallest positive number closest to zero
        double smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty(0).Min();
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (var num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}