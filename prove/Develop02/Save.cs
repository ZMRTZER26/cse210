using System;
using System.IO;
using System.Collections.Generic;

public class SaveEntries
{
    public void SaveToFile(List<Entry> entries, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true)) // Append mode enabled
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
            }
        }

        Console.WriteLine("Journal entries saved successfully.\n");
    }
}
