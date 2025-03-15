using System;

// Abstract base class for all types of goals
abstract class Goal
{
    protected int _points; // Points earned for completing the goal
    protected string _name; // Name of the goal
    protected string _description; // Description of the goal

    public Goal(int points, string name, string description)
    {
        _points = points;
        _name = name;
        _description = description;
    }

    // Abstract method to be implemented by subclasses for recording goal progress
    public abstract void RecordEvent();

    // Display goal progress (can be overridden by subclasses)
    public virtual void DisplayProgress()
    {
        Console.WriteLine($"{_name}: {_description}");
    }

    // Save goal data as a formatted string
    public virtual string SaveData()
    {
        return $"{GetType().Name},{_name},{_description},{_points}";
    }
}
