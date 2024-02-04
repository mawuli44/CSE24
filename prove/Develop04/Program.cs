using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
         // Base class 
class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name} Activity:");
        Console.WriteLine(_description);
        SetDuration();
        Console.WriteLine("Prepare to begin...");
        ShowCountDown(3); // Pause for 3 seconds before starting
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Good job! You've completed the {_name} Activity for {_duration} seconds.");
        ShowCountDown(3); // Pause for 3 seconds before finishing
    }

    public void ShowSpinner(int seconds)
    {
        Console.Write("Working");
        for (int i = 0; i < seconds; i++)
        {
            Thread.Sleep(1000);
            Console.Write(".");
        }
        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    private void SetDuration()
    {
        Console.Write("Enter duration in seconds: ");
        _duration = Convert.ToInt32(Console.ReadLine());
    }
}

// BreathingActivity which was derived from Activity
class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        for (int i = 0; i < _duration; i += 2)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(2);
            Console.WriteLine("Breathe out...");
            ShowCountDown(2);
        }

        DisplayEndingMessage();
    }
}

// ReflectingActivity which was derived from Activity
class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity() : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
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
    }

    public void Run()
    {
        DisplayStartingMessage();

        foreach (var prompt in _prompts)
        {
            Console.WriteLine(prompt);
            ShowCountDown(2);

            foreach (var question in _questions)
            {
                Console.WriteLine(question);
                ShowSpinner(3); // Pause for 3 seconds with spinner
            }
        }

        DisplayEndingMessage();
    }
}

// ListingActivity that was derived from Activity
class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        foreach (var prompt in _prompts)
        {
            Console.WriteLine(prompt);
            ShowCountDown(5); // Pause for 5 seconds to think about the prompt

            Console.WriteLine("Start listing:");
            ShowCountDown(_duration); // User lists items for the specified duration
        }

        Console.WriteLine($"You listed {_duration} items.");

        DisplayEndingMessage();
    }
}

class Program
{
    static void Main()
    {
        // Menu system
        while (true)
        {
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            Console.Write("Choose an activity (1-4): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 4)
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            Activity activity;
            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ReflectingActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
            }

            activity.Run();
        }
    }
}