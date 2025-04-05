using System;
using System.Collections.Generic;

// Uses user data to generate and store worldbuilding information
// A more expanded version of this class could help guide users with specified categories and whatnot
// But that would quickly become a project all its own
// Inherits from WritingTool overriding the Run() method
class WorldbuildingDatabase : WritingTool
{
    // Override the Run() method
    public override void Run(Dictionary<string, Dictionary<string, List<string>>> sessionData)
    {
        // Prompt user to enter the title of the story the element belongs to
        Console.Write("Enter the story title for this world element: ");
        string title = Console.ReadLine();

        // Prompt user to enter the element with some examples of types of elements
        Console.Write("Enter the worldbuilding element (e.g., location, society, magic system): ");
        string element = Console.ReadLine();

        // Checks if the "Worldbuilding" cagegory exists
        if (!sessionData.ContainsKey("Worldbuilding"))
        {
            // If the category does not exist, creates a dictionary with an empty "Worldbuilding" list
            sessionData["Worldbuilding"] = new Dictionary<string, List<string>>();
        }
        
        // Checks if the story title exists udner "Worldbuilding"
        // If not, it creates an entry for it
        if (!sessionData["Worldbuilding"].ContainsKey(title))
        {
            sessionData["Worldbuilding"][title] = new List<string>();
        }

        // Adds the element to the list of worldbuilding elements for the specified story
        sessionData["Worldbuilding"][title].Add(element);

        // This message confirms that the element was added
        Console.WriteLine($"Worldbuilding element '{element}' added to story '{title}'.");
    }
}
