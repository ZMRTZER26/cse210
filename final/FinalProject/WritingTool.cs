abstract class WritingTool
{
    public abstract void DisplayMenu();
    public virtual string ExportData() => "";
    public virtual void ImportData(string data) { }
}
