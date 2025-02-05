using System;
using System.IO;
using System.Collections.Generic;

public class LoadEntries
{
    public List<Entry> LoadFromFile()
    {
        Console.Write("Enter the filename to load from: ");
        string filePath = Console.ReadLine();

        List<Entry> entries = new List<Entry>();

        if (File.Exists(filePath))
        {
            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    entries.Add(new Entry(parts[1], parts[2], parts[0]));
                }
            }
            Console.WriteLine("Journal loaded successfully.\n");
        }
        else
        {
            Console.WriteLine("File not found. Please check the filename and try again.\n");
        }

        return entries;
    }
}
