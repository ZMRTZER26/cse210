using System;
using System.Collections.Generic;

class WorldbuildingDatabase : WritingTool
{
    private List<string> _worldElements = new List<string>();

    public override void DisplayMenu()
    {
        Console.WriteLine("\n--- Worldbuilding Database ---");
        Console.Write("Enter a worldbuilding element: ");
        string element = Console.ReadLine();
        _worldElements.Add(element);
        Console.WriteLine($"World element '{element}' added.");
    }

    public override string ExportData() => string.Join(";", _worldElements);
    public override void ImportData(string data) => _worldElements = new List<string>(data.Split(';'));
}
