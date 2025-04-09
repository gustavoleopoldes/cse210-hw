public abstract class Goal
{
    public string _shortName;
    public string _description;
    public string _points;

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public virtual int GetCompletionCount()
    {
        return 0;
    }

    public abstract void RecordEvent();
    public abstract bool IsCompleted();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}