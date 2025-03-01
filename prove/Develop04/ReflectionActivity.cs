using System;
using System.Collections.Generic;

class ReflectionActivity : Activity
{
    // List of reflection prompts
    private List<string> _reflectionPrompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    // List of reflection questions
    private List<string> _reflectionQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
    {
        // Set the name and description of the activity
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. " +
                       "This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public override void RunActivity()
    {
        StartMessage(); // Get user-defined duration

        ShowPrompt(); // Display a random reflection prompt

        int elapsedTime = 0;
        int questionPause = 5; // Pause duration in seconds for each question

        // Continue asking questions until the specified duration is reached
        while (elapsedTime < _duration)
        {
            AskQuestion();
            PauseWithSpinner(questionPause);
            elapsedTime += questionPause;
        }

        EndMessage();
    }

    // Static list to track unused prompts so they persist across multiple activity runs
    private static List<string> _availablePrompts;

    private void ShowPrompt()
    {
        // If there are no available prompts left, refill the list and shuffle
        if (_availablePrompts == null || _availablePrompts.Count == 0)
        {
            _availablePrompts = new List<string>(_reflectionPrompts); // Copy all prompts
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

    private void AskQuestion()
    {
        Random random = new Random();
        // Pick a random question from the list
        string question = _reflectionQuestions[random.Next(_reflectionQuestions.Count)];
        Console.WriteLine($"> {question}");
    }

    private void PauseWithSpinner(int seconds)
    {
        // Simple loading spinner to give the user time to reflect
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < seconds * 2; i++) // Runs twice per second
        {
            Console.Write($"\r{spinner[i % 4]}"); // Rotate through spinner characters
            System.Threading.Thread.Sleep(500);
        }
        Console.WriteLine(); // Move to a new line after the spinner completes
    }
}
