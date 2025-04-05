using System;
using System.Collections.Generic;
using System.IO;

// Manages the entire program.
// Handles class execution, saving data, loading data, and displaying saved/loaded data
class WritingHub
{
    private List<WritingTool> _tools;

    // Dictionary for saving session data
    // Saved as: Category -> Story Title -> List of Entries(characters, locations, concepts, etc.)
    private Dictionary<string, Dictionary<string, List<string>>> _sessionData;
    private const string FileName = "writing_data.txt"; // File the data is being saved to

    // Execute the selected class
    public WritingHub()
    {
        _tools = new List<WritingTool>
        {
            new PromptGenerator(), // Generate writing prompts
            new DailyChallengeManager(), // Generate daily challenge
            new StoryTracker(), // Creates and stores new story and/or designates the story to be tracked
            new CharacterDatabase(), // Creates and stores character profiles under the designated title. Only creates character names at this point
            new WorldbuildingDatabase(), // Creates and stores worldbuilding elements under the designated title. 
            new ProgressTracker() // Tracks writing progress based on word count
        };

        _sessionData = new Dictionary<string, Dictionary<string, List<string>>>();
        LoadData();
    }

    // Run the selected class
    public void UseTool(int index)
    {
        // Check if the desired index is valid
        if (index >= 0 && index < _tools.Count)
        {
            _tools[index].Run(_sessionData);
        }
        else
        {
            Console.WriteLine("Invalid tool selection."); // Error message for invalid index
        }
    }

    // Save all session data to a txt file
    public void SaveData()
    {
        using (StreamWriter writer = new StreamWriter(FileName)) // Overwrite txt file
        {
            foreach (var category in _sessionData)
            {
                writer.WriteLine($"--- {category.Key} ---"); // Section header
                foreach (var title in category.Value)
                {
                    writer.WriteLine($"Story: {title.Key}"); // Story title
                    foreach (var entry in title.Value)
                    {
                        // Each piece of data will be stored under the corresponding story
                        writer.WriteLine(entry); 
                    }
                }
                writer.WriteLine();
            }
        }
        Console.WriteLine("Data saved successfully."); // Confirms that the data was saved
    }

    // Load data from a txt file
    public void LoadData()
    {
        if (!File.Exists(FileName))
        {
            // Message for when no file is found
            Console.WriteLine("No saved data found."); 
            return;
        }

        _sessionData.Clear(); // Clears existing session data to avoid duplicating anything
        string currentCategory = ""; // Tracks current category
        string currentTitle = ""; // Tracks current story

        foreach (var line in File.ReadLines(FileName))
        {
            // If the line starts with "--- ", it marks the start of a new category
            if (line.StartsWith("--- ")) 
            {
                // Extract and clean up the category name (remove the "---")
                currentCategory = line.Substring(4, line.Length - 8); 

                // Makes sure the category exists
                if (!_sessionData.ContainsKey(currentCategory)) 
                {
                    _sessionData[currentCategory] = new Dictionary<string, List<string>>();
                }
            }
            // If the line starts with "Story", it marks a new story being worked on
            else if (line.StartsWith("Story: ")) 
            {
                // Extract and clean up the story title, removing the prefix
                currentTitle = line.Substring(7); 
                
                // Makes sure the story title exists
                if (!_sessionData[currentCategory].ContainsKey(currentTitle))
                {
                    _sessionData[currentCategory][currentTitle] = new List<string>();
                }
            }
            // Current story data, if the line is not empty
            else if (!string.IsNullOrWhiteSpace(line))
            {
                _sessionData[currentCategory][currentTitle].Add(line);
            }
        }
        // This message confirms that the data was loaded
        Console.WriteLine("Saved data loaded successfully.");
    }

    // Display all saved story data
    public void DisplayStoryData()
    {
        // Checks for any saved data to display
        if (_sessionData.Count == 0)
        {
            // Message for when no saved data exists
            Console.WriteLine("No saved story data available.");
            return;
        }

        // Runs through each category
        foreach (var category in _sessionData)
        {
            // Prints the coresponding header
            Console.WriteLine($"\n--- {category.Key} ---");

            // Runs through each story title in each category
            foreach (var title in category.Value)
            {
                // Prints the coresponding title
                Console.WriteLine($"Story: {title.Key}");

                // Prints all data under each title
                foreach (var item in title.Value)
                {
                    Console.WriteLine($"  - {item}"); // Indendts entries for readability
                }
            }
        }
    }
}
