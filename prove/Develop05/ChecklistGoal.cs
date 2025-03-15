using System;

// Represents a goal that must be completed multiple times before it's fully achieved
class ChecklistGoal : Goal
{
    private int _bonus; // Extra points earned when the goal is fully completed
    private int _target; // The number of times this goal must be completed
    private int _currentCount; // How many times it has been completed so far

    // Constructor: Initializes a checklist goal with target completions and bonus points
    public ChecklistGoal(int points, string name, string description, int bonus, int target, int currentCount = 0)
        : base(points, name, description)
    {
        _bonus = bonus;
        _target = target;
        _currentCount = currentCount;
    }

    // Records progress toward completing the goal
    public override void RecordEvent()
    {
        if (_currentCount < _target)
        {
            _currentCount++;
            Console.WriteLine($"Progress recorded for '{_name}'. Earned {_points} points.");

            // If the goal reaches the target, award the bonus points
            if (_currentCount == _target)
            {
                Console.WriteLine($"Checklist goal '{_name}' completed! Bonus {_bonus} points awarded.");
            }
        }
        else
        {
            Console.WriteLine($"Goal '{_name}' is already fully completed.");
        }
    }

    // Displays the goal progress, showing how many times it has been completed
    public override void DisplayProgress()
    {
        Console.WriteLine($"[{_currentCount}/{_target}] {_name}: {_description}");
    }

    // Saves the goal data, including the target and how much progress has been made
    public override string SaveData()
    {
        return base.SaveData() + $",{_bonus},{_target},{_currentCount}";
    }
}
