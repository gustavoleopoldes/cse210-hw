public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    public int _bonus;

    public ChecklistGoal(string name, string description, string points, int target, int bonus) 
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    public override bool IsCompleted()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"[{(_amountCompleted >= _target ? "X" : " ")}] {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
    }

    public override int GetCompletionCount()
    {
        return _amountCompleted;
    }
}