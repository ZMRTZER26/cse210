using System;
using System.Collections.Generic;

// Uses user data to generate and store character information
// Currently limited to just character names
// Inherits from WritingTool overriding the Run() method
class CharacterDatabase : WritingTool
{
    // Override the Run() method
    public override void Run(Dictionary<string, Dictionary<string, List<string>>> sessionData)
    {
        // Prompt user to enter the title of the story the character belongs to
        Console.Write("Enter the story title for this character: ");
        string title = Console.ReadLine();

        // Prompt user to enter the name of the character
        Console.Write("Enter the character's name: ");
        string name = Console.ReadLine();

        // Checks if the "Characters" cagegory exists
        if (!sessionData.ContainsKey("Characters"))
        {
            // If the category does not exist, creates a dictionary with an empty "Characters" list
            sessionData["Characters"] = new Dictionary<string, List<string>>();
        }
        
        // Checks if the story title exists under "Characters"
        // If not, it creates an entry for it
        if (!sessionData["Characters"].ContainsKey(title))
        {
            sessionData["Characters"][title] = new List<string>();
        }

        // Adds the character name to the list of characters for the specified story
        sessionData["Characters"][title].Add(name);

        // This message confirms that the character was added
        Console.WriteLine($"Character '{name}' added to story '{title}'.");
    }
}
