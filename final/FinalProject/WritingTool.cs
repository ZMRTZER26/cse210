using System;
using System.Collections.Generic;

// Abstract base class
abstract class WritingTool
{
    public abstract void Run(Dictionary<string, Dictionary<string, List<string>>> sessionData);
}
