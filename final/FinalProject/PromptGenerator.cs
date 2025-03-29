using System;

class PromptGenerator : WritingTool
{
    private string _lastPrompt;

    public override void DisplayMenu()
    {
        Console.WriteLine("\n--- Writing Prompt Generator ---");
        string[] prompts = { "Write about a lost traveler.", "Describe a mysterious object.", "Create a dialogue-only story." };
        Random rand = new Random();
        _lastPrompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine("Prompt: " + _lastPrompt);
    }

    public override string ExportData() => _lastPrompt;
    public override void ImportData(string data) => _lastPrompt = data;
}
