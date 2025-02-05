using System;
using System.Collections.Generic;

public class DisplayEntries
{
    public void Show(List<Entry> entries)
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("\nNo entries to display.\n");
            return;
        }

        Console.WriteLine($"\nJournal Entries: ({entries.Count} total)");
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
    }
}
