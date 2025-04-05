public class ActivityLog
{
    public Dictionary<string, (int count, int totalSeconds)> ActivityStats { get; private set; }
    private const string LOG_FILE = "activity_log.txt";

    public ActivityLog()
    {
        ActivityStats = new Dictionary<string, (int count, int totalSeconds)>();
        LoadLog();
    }

    public void AddActivity(string activityName, int duration)
    {
        if (ActivityStats.ContainsKey(activityName))
        {
            var (count, totalSeconds) = ActivityStats[activityName];
            ActivityStats[activityName] = (count + 1, totalSeconds + duration);
        }
        else
        {
            ActivityStats[activityName] = (1, duration);
        }
        SaveLog();
    }

    public void DisplayStats()
    {
        Console.WriteLine("\n=== Activity Statistics ===");
        foreach (var stat in ActivityStats)
        {
            Console.WriteLine($"{stat.Key}:");
            Console.WriteLine($"  Times performed: {stat.Value.count}");
            Console.WriteLine($"  Total time: {stat.Value.totalSeconds} seconds");
            Console.WriteLine($"  Average time: {stat.Value.totalSeconds / stat.Value.count} seconds per session");
            Console.WriteLine();
        }
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    private void SaveLog()
    {
        List<string> lines = new List<string>();
        foreach (var stat in ActivityStats)
        {
            lines.Add($"{stat.Key},{stat.Value.count},{stat.Value.totalSeconds}");
        }
        File.WriteAllLines(LOG_FILE, lines);
    }

    private void LoadLog()
    {
        if (File.Exists(LOG_FILE))
        {
            string[] lines = File.ReadAllLines(LOG_FILE);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3)
                {
                    string name = parts[0];
                    int count = int.Parse(parts[1]);
                    int totalSeconds = int.Parse(parts[2]);
                    ActivityStats[name] = (count, totalSeconds);
                }
            }
        }
    }
}