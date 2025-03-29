using System;

class ProgressTracker : WritingTool
{
    private int _wordCount = 0;
    private int _dailyStreak = 0;
    private int _goal = 50000;

    public override void DisplayMenu()
    {
        Console.WriteLine("\n--- Progress Tracker ---");
        Console.WriteLine($"Total Words: {_wordCount} | Streak: {_dailyStreak} days | Goal: {_goal} words");

        Console.Write("Enter words written today: ");
        if (int.TryParse(Console.ReadLine(), out int words) && words > 0)
        {
            _wordCount += words;
            _dailyStreak++;
            Console.WriteLine($"You've written {words} words today!");
        }
    }

    public override string ExportData() => $"{_wordCount},{_dailyStreak},{_goal}";
    public override void ImportData(string data)
    {
        string[] parts = data.Split(',');
        int.TryParse(parts[0], out _wordCount);
        int.TryParse(parts[1], out _dailyStreak);
        int.TryParse(parts[2], out _goal);
    }
}
