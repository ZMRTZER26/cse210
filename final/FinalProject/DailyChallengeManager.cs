using System;
using System.Collections.Generic;

// Provides random writing challenges for the user
// Inherits from WritingTool overriding the Run() method
class DailyChallengeManager : WritingTool
{
    private List<string> _challenges = new List<string>
    {
        "Write a 500-word story using only dialogue.",
        "Describe a setting using all five senses.",
        "Write a scene from the perspective of an inanimate object."
    };

    // Override the Run() method
    public override void Run(Dictionary<string, Dictionary<string, List<string>>> sessionData)
    {
        // Randomize the challenges selected from the list
        Random rand = new Random();
        string challenge = _challenges[rand.Next(_challenges.Count)];

        Console.WriteLine($"Daily Challenge: {challenge}");

        // Checks that the "Daily Challenges" category exists
        if (!sessionData.ContainsKey("Daily Challenges"))
        {
            // If the category does not exist, creates a dictionary with an empty list
            sessionData["Daily Challenges"] = new Dictionary<string, List<string>> { { "Challenges", new List<string>() } };
        }

        // Adds the selected challenges to the session data under "Daily Challenges"
        sessionData["Daily Challenges"]["Challenges"].Add(challenge);
    }
}
