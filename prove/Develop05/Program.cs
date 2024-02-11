using System;
using System.Collections.Generic;
using System.IO;

// Base class for goals
abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

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
class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points) : base(shortName, description, points)
    {
        _isComplete = false;
    }

    // Override methods
    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"{_shortName} goal completed! {_points} points earned.");
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        return $"{_shortName}: {_description} [{(_isComplete ? "X" : " ")}]";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points},{(_isComplete ? "1" : "0")}";
    }
}

// Derived class for eternal goals
class EternalGoal : Goal
{
    // Constructor
    public EternalGoal(string shortName, string description, int points) : base(shortName, description, points)
    {
        // No additional attributes needed
    }

    // Override methods
    public override void RecordEvent()
    {
        Console.WriteLine($"{_shortName} event recorded! {_points} points earned.");
    }

    public override bool IsComplete()
    {
        // Eternal goals are never complete
        return false;
    }

    public override string GetDetailsString()
    {
        return $"{_shortName}: {_description}";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}

// Derived class for checklist goals
class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    // Constructor
    public ChecklistGoal(string shortName, string description, int points, int target, int bonus) : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    // Override methods
    public override void RecordEvent()
    {
        _amountCompleted++;
        Console.WriteLine($"{_shortName} event recorded! {_points} points earned.");

        if (_amountCompleted == _target)
        {
            Console.WriteLine($"Congratulations! Bonus of {_bonus} points earned for completing {_shortName} goal {_target} times!");
            _points += _bonus;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"{_shortName}: {_description} [Completed {_amountCompleted}/{_target} times]";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_amountCompleted},{_target},{_bonus}";
    }
}

// Class for managing goals
class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    // Constructor
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // Method to display player's score
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    // Method to list goal names
    public void ListGoalNames()
    {
        Console.WriteLine("Goal Names:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal._shortName);
        }
    }

    // Method to list goal details
    public void ListGoalDetails()
    {
        Console.WriteLine("Goal Details:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    // Method to create a new goal
    public void CreateGoal(string type, string shortName, string description, int points, int target = 0, int bonus = 0)
    {
        Goal newGoal;
        switch (type)
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
                Console.WriteLine("Invalid goal type.");
                return;
        }
        _goals.Add(newGoal);
        Console.WriteLine("New goal created successfully.");
    }

    // Method to record an event for a goal
    public void RecordEvent(string shortName)
    {
        foreach (Goal goal in _goals)
        {
            if (goal._shortName == shortName)
            {
                goal.RecordEvent();
                _score += goal._points;
                return;
            }
        }
        Console.WriteLine("Goal not found.");
    }

    // Method to save goals and score to a file
    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
            outputFile.WriteLine($"Score:{_score}");
        }
        Console.WriteLine("Goals and score saved successfully.");
    }

    // Method to load goals and score from a file
    public void LoadGoals(string filename)
    {
        _goals.Clear();
        using (StreamReader inputFile = new StreamReader(filename))
        {
            string line;
            while ((line = inputFile.ReadLine()) != null)
            {
                if (line.StartsWith("SimpleGoal:"))
                {
                    string[] parts = line.Split(":");
                    string[] values = parts[1].Split(",");
                    CreateGoal("SimpleGoal", values[0], values[1], int.Parse(values[2]));
                }
                else if (line.StartsWith("EternalGoal:"))
                {
                    string[] parts = line.Split(":");
                    string[] values = parts[1].Split(",");
                    CreateGoal("EternalGoal", values[0], values[1], int.Parse(values[2]));
                }
                else if (line.StartsWith("ChecklistGoal:"))
                {
                    string[] parts = line.Split(":");
                    string[] values = parts[1].Split(",");
                    CreateGoal("ChecklistGoal", values[0], values[1], int.Parse(values[2]), int.Parse(values[3]), int.Parse(values[4]));
                }
                else if (line.StartsWith("Score:"))
                {
                    string[] values = line.Split(":");
                    _score = int.Parse(values[1]);
                }
            }
        }
    }
}