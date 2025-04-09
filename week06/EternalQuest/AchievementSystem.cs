using System;
using System.Collections.Generic;
using System.Linq;

public class AchievementSystem
{
    private int _currentLevel;
    private int _pointsToNextLevel;
    private Dictionary<string, bool> _achievements;

    public AchievementSystem()
    {
        _currentLevel = 1;
        _pointsToNextLevel = 1000;
        _achievements = new Dictionary<string, bool>
        {
            {"First Goal", false},
            {"Goal Master", false},
            {"Eternal Warrior", false},
            {"Checklist Champion", false},
            {"Level 5 Reached", false},
            {"Point Collector", false}
        };
    }

    public void UpdateLevel(int totalPoints)
    {
        int newLevel = 1 + (totalPoints / 1000);
        if (newLevel != _currentLevel)
        {
            _currentLevel = newLevel;
            Console.WriteLine("\n*** CONGRATULATIONS! ***");
            Console.WriteLine($"You've reached level {_currentLevel}!");
            Console.WriteLine($"Next level at {(_currentLevel * 1000)} points");
            Console.WriteLine("************************");
            
            if (_currentLevel >= 5 && !_achievements["Level 5 Reached"])
            {
                UnlockAchievement("Level 5 Reached");
            }
        }
    }

    public void CheckAchievements(List<Goal> goals, int totalPoints)
    {
        if (goals.Count >= 1 && !_achievements["First Goal"])
        {
            UnlockAchievement("First Goal");
        }

        if (goals.Count >= 5 && !_achievements["Goal Master"])
        {
            UnlockAchievement("Goal Master");
        }

        int eternalGoalsCompleted = goals.Count(g => g is EternalGoal && g.GetCompletionCount() >= 10);
        if (eternalGoalsCompleted >= 3 && !_achievements["Eternal Warrior"])
        {
            UnlockAchievement("Eternal Warrior");
        }

        int checklistGoalsCompleted = goals.Count(g => g is ChecklistGoal && g.IsCompleted());
        if (checklistGoalsCompleted >= 3 && !_achievements["Checklist Champion"])
        {
            UnlockAchievement("Checklist Champion");
        }

        if (totalPoints >= 5000 && !_achievements["Point Collector"])
        {
            UnlockAchievement("Point Collector");
        }
    }

    private void UnlockAchievement(string achievementName)
    {
        _achievements[achievementName] = true;
        Console.WriteLine("\n*************************");
        Console.WriteLine("* Achievement Unlocked! *");
        Console.WriteLine($"* {achievementName}");
        Console.WriteLine("*************************");
    }

    public void DisplayStatus()
    {
        Console.WriteLine($"\nCurrent Level: {_currentLevel}");
        Console.WriteLine($"Points to next level: {(_currentLevel * 1000) - _pointsToNextLevel}");
        
        Console.WriteLine("\nAchievements:");
        foreach (var achievement in _achievements)
        {
            string status = achievement.Value ? "[X]" : "[ ]";
            Console.WriteLine($"{status} {achievement.Key}");
        }
    }
}