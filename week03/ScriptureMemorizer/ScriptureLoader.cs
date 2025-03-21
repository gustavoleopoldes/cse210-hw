public class ScriptureLoader
{
    public List<Scripture> LoadFromFile(string filename)
    {
        return File.ReadAllLines(filename)
            .Select(line => line.Split('|'))
            .Select(parts => new Scripture(
                new Reference(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3])),
                parts[4]))
            .ToList();
    }
}