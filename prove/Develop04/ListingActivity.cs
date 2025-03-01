using System;
using System.Collections.Generic;
using System.Threading;

class ListingActivity : Activity
{

    //List of listing prompts
    private List<string> _listingPrompts = new List<string>
    {
        "1 Who are people that you appreciate?",
        "2 What are personal strengths of yours?",
        "3 Who are people that you have helped this week?",
        "4 When have you felt the Holy Ghost this month?",
        "5 Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        // Set the name and description of the activity
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public override void RunActivity()
    {
        StartMessage(); // Ask user for duration

        ShowPrompt(); // Display a random listing prompt
        Countdown(5); // Give user time to think before they start listing

        List<string> userResponses = GetUserResponses(); // Get user input

        Console.WriteLine($"\nYou listed {userResponses.Count} items.");
        EndMessage(); // End the activity
    }

private static List<string> _availablePrompts;

    private void ShowPrompt()
    {
        // If there are no available prompts left, refill the list and shuffle
        if (_availablePrompts == null || _availablePrompts.Count == 0)
        {
            _availablePrompts = new List<string>(_listingPrompts); // Copy all prompts
            ShuffleList(_availablePrompts); // Shuffle them for randomness
        }

        // Get the first prompt from the shuffled list
        string prompt = _availablePrompts[0];

        // Remove it from the list so it won't repeat until all have been used
        _availablePrompts.RemoveAt(0);

        // Display the selected prompt
        Console.WriteLine($"\n{prompt}\n");
    }

        // Randomizes the list order
    private void ShuffleList(List<string> list)
    {
        Random random = new Random();
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1); // Get a random index from the remaining elements
            (list[i], list[j]) = (list[j], list[i]); // Swap elements
        }
    }

    private void Countdown(int seconds)
    {
        // Countdown prep time for prompt
        Console.Write("Get ready... ");
        for (int i = seconds; i > 0; i--) // Counts from 5 to 1
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine("\nStart listing now!");
    }

    // Collect user responses
    private List<string> GetUserResponses()
    {
        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                responses.Add(response);
            }
        }
        return responses;
    }
}
