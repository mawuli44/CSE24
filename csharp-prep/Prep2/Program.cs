using System;

class Program
{
    static void Main(string[] args)
    {
       Console.Write("what is your grade percentage?");
       string answer = Console.Readline();
      
       int percent = int.parse(answer);
       
       string letter = "";

        if (grade Percentage >= 90)
        {
            letter = "A";
        }
        else if (grade Percentage >= 80)
        {
            letter = "B";
        }
        else if (grade Percentage >= 70)
        {
            letter = "C";
        }
        else if (grade Percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
            Console.WriteLine($"Your letter grade is: {letter}");
           
           if (grade Percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Better luck next time. Keep working hard!");
    }
         // Stretch Challenge: 
        int lastDigit = (int)grade Percentage % 10;
        string sign = "";

        if (letter != "F")
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        

        // Print the letter grade along with the sign
        if (sign != "")
        {
            Console.WriteLine($"Your detailed grade is: {letter}{sign}");
        }
    }
}