using System;
using System.Collections.Generic;

//Manages scripture text
//Controls how scriptures are displayed and hidden
class ScriptureEntry
{
    private Reference _reference;
    private List<Word> _words;

    public ScriptureEntry(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] wordsArray = text.Split(' ');
        foreach (string word in wordsArray)
        {
            _words.Add(new Word(word));
        }
    }

    public void Display()
    {
        Console.WriteLine(_reference.GetReference() + "\n");

        foreach (Word word in _words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
        Console.WriteLine();
    }

    public void HideWords(int count)
    {
        Random random = new Random();
        List<Word> visibleWords = _words.FindAll(w => !w.IsHidden());

        if (visibleWords.Count == 0)
        {
            return;  // Stop trying to hide words if everything is already hidden
        }

        int wordsToHide = Math.Min(count, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }
    
//Checks if all words are hidden
    public bool IsFullyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
                return false;
        }
        return true;
    }
}
