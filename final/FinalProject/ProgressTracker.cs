using System;
using System.Collections.Generic;

// Tracks word count progress for the designated story
// Future itterations could track further progress such as goals, chapters, etc.
// Inherits from WritingTool overriding the Run() method
class ProgressTracker : WritingTool
{
    // Override the Run() method
    public override void Run(Dictionary<string, Dictionary<string, List<string>>> sessionData)
    {
        // Prompt the user to enter the title of the story being tracked
        Console.Write("Enter the story title you want to track progress for: ");
        string title = Console.ReadLine();

        // Prompt user to enter the number of words they wrote
        Console.Write("Enter the number of words written today: ");
        string wordCount = Console.ReadLine();

        // Checks that the "Progress" category exists
        // If not, it creates a new entry for the story title
        if (!sessionData.ContainsKey("Progress"))
        {
            sessionData["Progress"] = new Dictionary<string, List<string>>();
        }
        if (!sessionData["Progress"].ContainsKey(title))
        {
            sessionData["Progress"][title] = new List<string>();
        }

        // Add the word count entry to the progress data for the given story title
        sessionData["Progress"][title].Add($"Words Written: {wordCount}");

        // This message confirms that the progress was recorded
        Console.WriteLine($"Progress recorded: {wordCount} words for '{title}'.");
    }
}
