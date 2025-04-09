public class EternalGoal : Goal
{
    private int _timesCompleted;

    public EternalGoal(string name, string description, string points) 
        : base(name, description, points)
    {
        _timesCompleted = 0;
    }

    public override void RecordEvent()
    {
        _timesCompleted++;
    }

    public override bool IsCompleted()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {_shortName} ({_description}) - Eternal Goal (Completed {_timesCompleted} times)";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points},{_timesCompleted}";
    }

    public override int GetCompletionCount()
    {
        return _timesCompleted;
    }
}