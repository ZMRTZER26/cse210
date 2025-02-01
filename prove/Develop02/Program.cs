using System;
using System.IO;
using System.Collections.Generic;

// Creates journal entry template
public class Entry
{
    public string _prompt;
    public string _response;
    public string _date;

    public Entry(string prompt, string response, string date)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}\n");
    }
}

// Generate and select prompts
public class PromptManager
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    private string _lastPrompt = ""; // Store the last used prompt

    public string GetRandomPrompt()
    {
        Random random = new Random();
        string prompt;

        // Keep picking a new prompt until it's different from the last one
        do
        {
            prompt = _prompts[random.Next(_prompts.Count)];
        }
        while (prompt == _lastPrompt);

        _lastPrompt = prompt; // Update last used prompt
        return prompt;
    }
}

// Create an entry
public class AddEntry
{
    private PromptManager _promptManager;

    public AddEntry(PromptManager promptManager)
    {
        _promptManager = promptManager;
    }

    public Entry CreateEntry()
    {
        string prompt = _promptManager.GetRandomPrompt();
        Console.WriteLine("\n" + prompt);
        Console.Write("> ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        return new Entry(prompt, response, date);
    }
}


// Display the journal entries
public class DisplayEntries
{
    public void Show(List<Entry> entries)
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("\nNo entries to display.\n");
            return;
        }

        //Added a count of the total journal entries
        Console.WriteLine($"\nJournal Entries: ({entries.Count} total)");
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
    }
}

//Save entry to the loaded txt file
public class SaveEntries
{
    public void SaveToFile(List<Entry> entries, string filePath)
    {
        List<Entry> existingEntries = new List<Entry>();

        // Load existing entries before writing new ones
        if (File.Exists(filePath))
        {
            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    existingEntries.Add(new Entry(parts[1], parts[2], parts[0]));
                }
            }
        }

        using (StreamWriter writer = new StreamWriter(filePath, false)) // Overwrite file but include previous entries
        {
            foreach (Entry entry in existingEntries)
            {
                writer.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
            }
            foreach (Entry entry in entries)
            {
                writer.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
            }
        }

        Console.WriteLine("Journal entry saved.\n");
    }
}



// Loads entries from a txt file
public class LoadEntries
{
    public List<Entry> LoadFromFile()
    {
        Console.Write("Enter the filename to load from: ");
        string filePath = Console.ReadLine();

        List<Entry> _entries = new List<Entry>();

        if (File.Exists(filePath))
        {
            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    _entries.Add(new Entry(parts[1], parts[2], parts[0]));
                }
            }
            Console.WriteLine("Journal loaded successfully.\n");
        }
        else
        {
            Console.WriteLine("File not found. Please check the filename and try again.\n");
        }

        return _entries;
    }
}

// Search for specific entries via keywords
public class SearchEntries
{
    public void Search(List<Entry> _entries)
    {
        Console.Write("Enter a keyword to search: ");
        string keyword = Console.ReadLine().ToLower();

        Console.WriteLine("\nSearch Results:");
        int _found = 0;
        foreach (Entry entry in _entries)
        {
            if (entry._response.ToLower().Contains(keyword) || entry._prompt.ToLower().Contains(keyword))
            {
                entry.Display();
                _found++;
            }
        }

        if (_found == 0)
        {
            Console.WriteLine("No matching entries found.\n");
        }
    }
}

// Main program
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

        string filePath = "journal.txt";
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
                //Added an autosave feature
                //Not quite sure how it works but it sounded cool
                journalEntries.Add(addEntry.CreateEntry());
                saveEntries.SaveToFile(journalEntries, filePath);
            }
            else if (choice == "2")
            {
                displayEntries.Show(journalEntries);
            }
            else if (choice == "3")
            {
                saveEntries.SaveToFile(journalEntries, filePath);
            }
            else if (choice == "4")
            {
                //Added it so that this choice asks to input the specific txt file
                //Makes the load class work with multiple txt files
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
