using System;
using System.Collections.Generic;
using System.Threading;

// Base class for activities
public class Activity
{
    protected string name;
    protected string description;
    protected int duration;

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {name} activity...");
        Console.WriteLine(description);
        Console.WriteLine("Please set the duration of the activity (in seconds): ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Congratulations! You have completed the {name} activity.");
        Console.WriteLine($"Activity duration: {duration} seconds");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("-");
            Thread.Sleep(1000); // Pause for 1 second
        }
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i >= 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000); // Pause for 1 second
        }
    }
}

// Derived class for Breathing Activity
public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Starting breathing exercise...");
        Console.WriteLine("Get ready to breathe in...");
        ShowSpinner(duration);
        Console.WriteLine("\nGreat job! You've completed the breathing exercise.");
        DisplayEndingMessage();
    }
}

// Derived class for Reflection Activity
public class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Starting reflection activity...");
        Random rand = new Random();

        // Select random prompt
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);

        // Ask reflection questions
        foreach (string question in questions)
        {
            Console.WriteLine(question);
            ShowSpinner(duration / questions.Count);
        }

        Console.WriteLine("\nGreat job! You've completed the reflection activity.");
        DisplayEndingMessage();
    }
}

// Derived class for Listing Activity
public class ListingActivity : Activity
{
    private List<string> prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Starting listing activity...");
        
        Random rand = new Random();

        // Select random prompt
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);

        Console.WriteLine("You have a few seconds to start listing...");

        // Pause for a few seconds before starting listing
        Thread.Sleep(5000); // Pause for 5 seconds

        // Ask user to list items
        Console.WriteLine("Enter as many items as you can:");
        string input;
        int count = 0;
        do
        {
            input = Console.ReadLine();
            count++;
        } while (!string.IsNullOrEmpty(input));

        Console.WriteLine($"You've listed {count - 1} items.");
        DisplayEndingMessage();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Mindfulness Activities:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            Console.WriteLine("Choose an activity:");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    break;
                case 2:
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.Run();
                    break;
                case 3:
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    break;
                case 4:
                    Console.WriteLine("Exiting program...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}