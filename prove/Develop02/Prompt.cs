using System;
using System.Collections.Generic;

public class PromptManager
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    private string _lastPrompt = ""; 

    public string GetRandomPrompt()
    {
        Random random = new Random();
        string prompt;

        do
        {
            prompt = _prompts[random.Next(_prompts.Count)];
        }
        while (prompt == _lastPrompt);

        _lastPrompt = prompt;
        return prompt;
    }
}
