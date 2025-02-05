using System;

using System.Diagnostics;
using System.Globalization;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int wholeNumber)
    {
        _numerator = wholeNumber;
        _denominator = 1;
    }

    public Fraction(int top, int bottom)
    {
        _numerator = top;
        _denominator = bottom;
    }

    public string GetFraction()
    {
        string text = $"{_numerator}/{_denominator}";
        return text;
    }

    public double getDecimalValue()
    {
        return (double)_numerator / (double)_denominator;
    }
}