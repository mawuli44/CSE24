using System;
using System.Collections.Generic;
using System.IO;

// Base class for all types of goals
public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    // Constructor
    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    // Abstract methods
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}

// Derived class for simple goals
public class SimpleGoal : Goal
{
    protected bool _isComplete;

    // Constructor
    public SimpleGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
        _isComplete = false; // Initialize as incomplete
    }

    // Override methods from base class
    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Recorded event for {_shortName}. You earned {_points} points!");
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        return $"{_shortName} - {_description} [{(_isComplete ? "Complete" : "Incomplete")}]";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isComplete}";
    }
}

// Derived class for eternal goals
public class EternalGoal : Goal
{
    // Constructor
    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
        // No additional attributes needed for eternal goals
    }

    // Override methods from base class
    public override void RecordEvent()
    {
        Console.WriteLine($"Recorded event for {_shortName}. You earned {_points} points!");
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals are never complete
    }

    public override string GetDetailsString()
    {
        return $"{_shortName} - {_description} [Eternal]";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{_shortName}|{_description}|{_points}";
    }
}

// Derived class for checklist goals
public class ChecklistGoal : Goal
{
    protected int _amountCompleted;
    protected int _target;
    protected int _bonus;

    // Constructor
    public ChecklistGoal(string shortName, string description, int points, int target, int bonus)
        : base(shortName, description, points)
    {
        _amountCompleted = 0; // Initialize completed amount
        _target = target;
        _bonus = bonus;
    }

    // Override methods from base class
    public override void RecordEvent()
    {
        _amountCompleted++;
        Console.WriteLine($"Recorded event for {_shortName}. You earned {_points} points!");

        if (_amountCompleted >= _target)
        {
            _points += _bonus;
            Console.WriteLine($"Congratulations! {_shortName} completed with bonus points. Total points: {_points}");
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"{_shortName} - {_description} [Completed {_amountCompleted}/{_target}]";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_amountCompleted}|{_target}|{_bonus}";
    }
}

// Class responsible for managing goals
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    // Constructor
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // Method to create a new goal of any type
    public void CreateGoal(string goalType, string shortName, string description, int points, int target = 0, int bonus = 0)
    {
        Goal newGoal;
        switch (goalType)
        {
            case "SimpleGoal":
                newGoal = new SimpleGoal(shortName, description, points);
                break;
            case "EternalGoal":
                newGoal = new EternalGoal(shortName, description, points);
                break;
            case "ChecklistGoal":
                newGoal = new ChecklistGoal(shortName, description, points, target, bonus);
                break;
            default:
                throw new ArgumentException("Invalid goal type.");
        }
        _goals.Add(newGoal);
        Console.WriteLine($"New {goalType} created: {shortName}");
    }

    // Method to record an event for a goal
    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            _goals[goalIndex].RecordEvent();
            _score += _goals[goalIndex]._points;
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    // Method to display all goals and their status
    public void DisplayGoals()
    {
        Console.WriteLine("Current Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.WriteLine($"Total Score: {_score}");
    }

    // Method to save goals and score to a file
    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
            writer.WriteLine($"Score|{_score}");
        }
        Console.WriteLine("Goals and score saved to file.");
    }

    // Method to load goals and score from a file
    public void LoadGoals(string filename)
    {
        _goals.Clear();
        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts[0] == "SimpleGoal")
                    {
                        _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])) { _isComplete = bool.Parse(parts[4]) });
                    }
                    else if (parts[0] == "EternalGoal")
                    {
                        _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    }
                    else if (parts[0] == "ChecklistGoal")
                    {
                        _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[6])) { _amountCompleted = int.Parse(parts[4]) });
                    }
                    else if (parts[0] == "Score")
                    {
                        _score = int.Parse(parts[1]);
                    }
                }
                Console.WriteLine("Goals and score loaded from file.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading goals: {e.Message}");
        }
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        // Create sample goals
        manager.CreateGoal("SimpleGoal", "Run a Marathon", "Complete a full marathon", 1000);
        manager.CreateGoal("EternalGoal", "Read Scriptures", "Read scriptures daily", 100);
        manager.CreateGoal("ChecklistGoal", "Attend Temple", "Visit the temple", 50, 10, 500);

        // Display initial goals
        manager.DisplayGoals();

        // Record events
        manager.RecordEvent(0); // Record event for "Run a Marathon"
        manager.RecordEvent(1); // Record event for "Read Scriptures"
        manager.RecordEvent(2); // Record event for "Attend Temple"

        // Display updated goals
        manager.DisplayGoals();

        // Save goals to file
        manager.SaveGoals("goals.txt");

        // Create new manager to test loading from file
        GoalManager newManager = new GoalManager();
        newManager.LoadGoals("goals.txt");

        // Display loaded goals
        newManager.DisplayGoals();
    }
}