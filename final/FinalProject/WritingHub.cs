using System;
using System.IO;
using System.Collections.Generic;

class WritingHub
{
    private List<WritingTool> _tools;
    private const string FileName = "writing_data.txt";

    public WritingHub()
    {
        _tools = new List<WritingTool>
        {
            new PromptGenerator(),
            new StoryTracker(),
            new CharacterDatabase(),
            new WorldbuildingDatabase(),
            new DailyChallengeManager(),
            new IdeaGenerator(),
            new ProgressTracker()
        };
    }

    public void UseTool(int index)
    {
        if (index >= 0 && index < _tools.Count)
        {
            _tools[index].DisplayMenu();
        }
    }

    public void SaveData()
    {
        using (StreamWriter writer = new StreamWriter(FileName))
        {
            foreach (WritingTool tool in _tools)
            {
                writer.WriteLine(tool.ExportData());
            }
        }
    }

    public void ViewSavedData()
    {
        if (File.Exists(FileName))
        {
            Console.WriteLine("\n--- Saved Data ---");
            string[] lines = File.ReadAllLines(FileName);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("\nNo saved data found.");
        }
    }
}
