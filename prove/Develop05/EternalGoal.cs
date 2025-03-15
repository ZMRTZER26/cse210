using System;

// Represents an ongoing goal that can be completed infinitely
class EternalGoal : Goal
{
    // Constructor: Initializes an eternal goal
    public EternalGoal(int points, string name, string description)
        : base(points, name, description) { }

    // This goal doesn't have a completion state; it just keeps giving points
    public override void RecordEvent()
    {
        Console.WriteLine($"Recorded progress for '{_name}'. Earned {_points} points.");
    }

    // Displays the goal with an infinity symbol to indicate ongoing completion
    public override void DisplayProgress()
    {
        Console.WriteLine($"[∞] {_name}: {_description} (Can be completed repeatedly)");
    }
}
