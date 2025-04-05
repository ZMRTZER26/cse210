using System;
using System.Collections.Generic;

// Provides random writing prompts for the user
// Inherits from WritingTool overriding the Run() method
class PromptGenerator : WritingTool
{
    private List<string> _prompts = new List<string>
    {
        "Write about a character who can only speak the truth.",
        "Describe a world where magic is illegal.",
        "Write a scene where a hero meets their villain for the first time."
    };

    // Overried the Run() method
    public override void Run(Dictionary<string, Dictionary<string, List<string>>> sessionData)
    {
        // Randomize the prompts selected from the list
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];

        Console.WriteLine($"Prompt: {prompt}");

        // Checks that the "Prompts" category exists
        if (!sessionData.ContainsKey("Prompts"))
        {
            // If the category does not exist, creates a dictionary with an empty "Prompts" list
            sessionData["Prompts"] = new Dictionary<string, List<string>> { { "Prompts", new List<string>() } };
        }
        // Adds the generated prompt tot he "Prompts" category
        sessionData["Prompts"]["Prompts"].Add(prompt);
    }
}
