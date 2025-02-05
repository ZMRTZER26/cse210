using System;
using System.Collections.Generic;

public class SearchEntries
{
    public void Search(List<Entry> entries)
    {
        Console.Write("Enter a keyword to search: ");
        string keyword = Console.ReadLine().ToLower();

        Console.WriteLine("\nSearch Results:");
        int found = 0;
        foreach (Entry entry in entries)
        {
            if (entry._response.ToLower().Contains(keyword) || entry._prompt.ToLower().Contains(keyword))
            {
                entry.Display();
                found++;
            }
        }

        if (found == 0)
        {
            Console.WriteLine("No matching entries found.\n");
        }
    }
}
