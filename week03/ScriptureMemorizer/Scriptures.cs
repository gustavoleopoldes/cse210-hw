public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int count)
    {
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        for (int i = 0; i < count && visibleWords.Any(); i++)
        {
            visibleWords[_random.Next(visibleWords.Count)].Hide();
        }
    }

    public bool IsComplete() => _words.All(w => w.IsHidden());
    public string GetText() => $"{_reference.GetText()} {string.Join(" ", _words.Select(w => w.GetText()))}";
}