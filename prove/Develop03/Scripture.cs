using System;
using System.Collections.Generic;

//Creates and stores list of scriptures
//Allows the random scripture selection and user input
class Scripture
{
    private Random _random;
    private List<ScriptureEntry> _scriptureList;

    public Scripture()
    {
        _random = new Random();
        _scriptureList = new List<ScriptureEntry>
        {
            //Creates new instance. This allowed this part of the code to actually work. Stumbled upon it more by accident so still studying up on exactly how and why.
            new ScriptureEntry(new Reference("John", 3, 16),
                "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),

            new ScriptureEntry(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),

            new ScriptureEntry(new Reference("Philippians", 4, 6, 7),
                "Do not be anxious about anything, but in every situation, by prayer and petition, with thanksgiving, present your requests to God. " +
                "\nAnd the peace of God, which transcends all understanding, will guard your hearts and your minds in Christ Jesus.")
        };
    }

//Randomly selected scripture
    public ScriptureEntry GetRandomScripture()
    {
        return _scriptureList[_random.Next(_scriptureList.Count)];
    }

//User generated scripture
    public ScriptureEntry GetUserScripture()
    {
        Console.Write("\nEnter the book name: ");
        string book = Console.ReadLine().Trim();

        Console.Write("Enter the chapter number: ");
        int chapter = int.Parse(Console.ReadLine().Trim());

        Console.Write("Enter the verse number: ");
        int verse = int.Parse(Console.ReadLine().Trim());
        
        //Allows for multi-verse scriptures
        Console.Write("Is this a range of verses? (yes/no): ");
        string isRange = Console.ReadLine().Trim().ToLower();

        int endVerse = verse;  // Default to a single verse

        if (isRange == "yes")
        {
            Console.Write("Enter the ending verse number: ");
            endVerse = int.Parse(Console.ReadLine().Trim());
        }

        Console.Write("\nEnter the scripture text: ");
        string text = Console.ReadLine().Trim();

        // Create the appropriate Reference object
        Reference userReference = (isRange == "yes") ? new Reference(book, chapter, verse, endVerse) 
                                                     : new Reference(book, chapter, verse);

        return new ScriptureEntry(userReference, text);
    }
}
