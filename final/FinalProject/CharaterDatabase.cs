using System;
using System.Collections.Generic;

class CharacterDatabase : WritingTool
{
    private List<string> _characters = new List<string>();

    public override void DisplayMenu()
    {
        Console.WriteLine("\n--- Character Database ---");
        Console.Write("Enter character name: ");
        string name = Console.ReadLine();
        _characters.Add(name);
        Console.WriteLine($"Character '{name}' added.");
    }

    public override string ExportData() => string.Join(";", _characters);
    public override void ImportData(string data) => _characters = new List<string>(data.Split(';'));
}
