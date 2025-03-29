using System;
using System.Collections.Generic;

class StoryTracker : WritingTool
{
    private List<string> _stories = new List<string>();

    public override void DisplayMenu()
    {
        Console.WriteLine("\n--- Story Tracker ---");
        Console.Write("Enter story title: ");
        string title = Console.ReadLine();
        _stories.Add(title);
        Console.WriteLine($"Story '{title}' added.");
    }

    public override string ExportData() => string.Join(";", _stories);
    public override void ImportData(string data) => _stories = new List<string>(data.Split(';'));
}
