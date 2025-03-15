using System;

// Represents a simple goal that can only be completed once
class SimpleGoal : Goal
{
    private bool _isCompleted; // Tracks if the goal has been completed

    // Constructor: Initializes the goal with its details and completion status
    public SimpleGoal(int points, string name, string description, bool isCompleted = false)
        : base(points, name, description)
    {
        _isCompleted = isCompleted;
    }

    // Marks the goal as completed and awards points
    public override void RecordEvent()
    {
        if (!_isCompleted)
        {
            _isCompleted = true;
            Console.WriteLine($"Goal '{_name}' completed! Earned {_points} points.");
        }
        else
        {
            Console.WriteLine($"Goal '{_name}' was already completed.");
        }
    }

    // Displays goal progress, showing whether it's completed or not
    public override void DisplayProgress()
    {
        string status = _isCompleted ? "[X]" : "[ ]"; // [X] means completed, [ ] means not completed
        Console.WriteLine($"{status} {_name}: {_description}");
    }

    // Saves goal data, including whether it was completed or not
    public override string SaveData()
    {
        return base.SaveData() + $",{_isCompleted}";
    }
}
