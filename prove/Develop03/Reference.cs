using System;

class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;
    private bool _isRange;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _isRange = false;
    }

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
