using System;
using System.Collections.Generic;

// Tool that lets users generate and track stories based on their titles
// Inherits from WritingTool overriding the Run() method
class StoryTracker : WritingTool
{
    // Override the Run() method
    public override void Run(Dictionary<string, Dictionary<string, List<string>>> sessionData)
    {
        // Prompt the user to enter the title of the story being tracked
        Console.Write("Enter the title of your story: ");
        string title = Console.ReadLine();

        // Check if the "Stories" category exists
        if (!sessionData.ContainsKey("Stories"))
        {
            // If the category does not exist, creates a dictionary with an empty "Stories" list
            sessionData["Stories"] = new Dictionary<string, List<string>>();
        }
        if (!sessionData["Stories"].ContainsKey(title))
        {
            sessionData["Stories"][title] = new List<string>();
        }
        // Tells the user that their story is being tracked
        // This way they know that any character or worldbuilding data will be added under this story
        Console.WriteLine($"Story '{title}' is now being tracked.");
    }
}
