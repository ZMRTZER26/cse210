using System;

class IdeaGenerator : WritingTool
{
    private string _lastIdea;

    public override void DisplayMenu()
    {
        Console.WriteLine("\n--- Idea Generator ---");
        string[] ideas =
        {
            "A futuristic city where dreams can be recorded and sold.",
            "A character discovers they can rewrite the past by editing a mysterious book.",
            "A world where emotions manifest as physical beings.",
            "An old photograph reveals a secret that was never meant to be uncovered.",
            "A cursed painting changes every time someone looks away."
        };

        Random rand = new Random();
        _lastIdea = ideas[rand.Next(ideas.Length)];
        Console.WriteLine("Generated Idea: " + _lastIdea);
    }

    public override string ExportData() => _lastIdea;
    public override void ImportData(string data) => _lastIdea = data;
}
