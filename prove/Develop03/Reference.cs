using System;

//Manages the book, chapter, and verse number(s) of the scriptures
//Returns formatted reference as a string
class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;
    private bool _isRange;

//Reference info for single verse scriptures
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _isRange = false;
    }

//Reference info for muli-verse scriptures
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
        _isRange = true;
    }

    public string GetReference()
    {
        return _isRange ? $"{_book} {_chapter}:{_verse}-{_endVerse}" : $"{_book} {_chapter}:{_verse}";
    }
}
