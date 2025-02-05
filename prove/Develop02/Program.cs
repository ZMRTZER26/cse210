using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Entry> journalEntries = new List<Entry>();
        PromptManager promptManager = new PromptManager();
        AddEntry addEntry = new AddEntry(promptManager);
        DisplayEntries displayEntries = new DisplayEntries();
        SaveEntries saveEntries = new SaveEntries();
        LoadEntries loadEntries = new LoadEntries();
        SearchEntries searchEntries = new SearchEntries();

        bool running = true;

        while (running)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal");
            Console.WriteLine("4. Load the journal");
            Console.WriteLine("5. Search journal entries");
            Console.WriteLine("6. Exit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                journalEntries.Add(addEntry.CreateEntry());
                saveEntries.SaveToFile(journalEntries, "journal.txt");
            }
            else if (choice == "2")
            {
                displayEntries.Show(journalEntries);
            }
            else if (choice == "3")
            {
                Console.Write("Enter the filename to save as: ");
                string saveFile = Console.ReadLine();
                saveEntries.SaveToFile(journalEntries, saveFile);
            }
            else if (choice == "4")
            {
                journalEntries = loadEntries.LoadFromFile();
                displayEntries.Show(journalEntries);
            }
            else if (choice == "5")
            {
                searchEntries.Search(journalEntries);
            }
            else if (choice == "6")
            {
                running = false;
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.\n");
            }
        }
    }
}
