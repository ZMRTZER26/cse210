using System;

public class AddEntry
{
    private PromptManager _promptManager;

    public AddEntry(PromptManager promptManager)
    {
        _promptManager = promptManager;
    }

    public Entry CreateEntry()
    {
        string prompt = _promptManager.GetRandomPrompt();
        Console.WriteLine("\n" + prompt);
        Console.Write("> ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        return new Entry(prompt, response, date);
    }
}
