using System;

class Program
{
    static void Main(string[] args)
    {
       // Ask the user for the magic number
        Console.Write("What is the magic number? ");
        int magicNumber = Convert.ToInt32(Console.ReadLine());

        int guess;
        int guessCount = 0;

        // Add a loop until the user guesses the correct number
        do
        {
            //  Ask the user for a guess
            Console.Write("What is your guess? ");
            guess = Convert.ToInt32(Console.ReadLine());
            guessCount++;

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }

        } while (guess != magicNumber);

        // Inform the user of the number of guesses
        Console.WriteLine($"It took you {guessCount} guesses.");

        // Ask the user if they want to play again
        Console.Write("Do you want to play again? (yes/no): ");
        string playAgain = Console.ReadLine().ToLower();

        // Loop back and play the game again if the user says "yes"
        while (playAgain == "yes")
        {
            magicNumber = new Random().Next(1, 101);
            guessCount = 0;

            do
            {
                Console.Write("What is your guess? ");
                guess = Convert.ToInt32(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }

            } while (guess != magicNumber);

            Console.WriteLine($"It took you {guessCount} guesses.");
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().ToLower();
        }
    }
}  
        