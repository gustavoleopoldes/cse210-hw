public class Word
{
    private string _text;
    private bool _hidden;

    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }

    public void Hide() => _hidden = true;
    public bool IsHidden() => _hidden;
    public string GetText() => _hidden ? new string('_', _text.Length) : _text;
}