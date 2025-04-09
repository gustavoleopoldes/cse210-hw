using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private AchievementSystem _achievementSystem;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _achievementSystem = new AchievementSystem();
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": running = false; break;
                default: Console.WriteLine("Invalid choice. Please try again."); break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
        _achievementSystem.DisplayStatus();
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i]._shortName}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        
        string goalType = Console.ReadLine();
        
        Console.Write("What is the name of your goal? ");
        string goalName = Console.ReadLine();
        
        Console.Write("What is a short description of it? ");
        string goalDesc = Console.ReadLine();
        
        Console.Write("What is the amount of points associated with this goal? ");
        string goalPoints = Console.ReadLine();

        switch (goalType)
        {
            case "1":
                _goals.Add(new SimpleGoal(goalName, goalDesc, goalPoints));
                break;
            case "2":
                _goals.Add(new EternalGoal(goalName, goalDesc, goalPoints));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(goalName, goalDesc, goalPoints, target, bonus));
                break;
        }

        _achievementSystem.CheckAchievements(_goals, _score);
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals available. Please create some goals first.");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        ListGoalNames();
        Console.Write("\nWhich goal did you accomplish? ");
        
        if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex > 0 && goalIndex <= _goals.Count)
        {
            goalIndex--;
            _goals[goalIndex].RecordEvent();
            int points = int.Parse(_goals[goalIndex]._points);
            _score += points;
            
            if (_goals[goalIndex] is ChecklistGoal checklistGoal && checklistGoal.IsCompleted())
            {
                _score += checklistGoal._bonus;
                Console.WriteLine("\n*** BONUS POINTS ***");
                Console.WriteLine($"You earned {checklistGoal._bonus} bonus points!");
                Console.WriteLine("******************");
            }
            
            Console.WriteLine($"\nCongratulations! You have earned {points} points!");
            Console.WriteLine($"You now have {_score} points.");

            _achievementSystem.UpdateLevel(_score);
            _achievementSystem.CheckAchievements(_goals, _score);
        }
        else
        {
            Console.WriteLine("\nInvalid goal number.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("\nWhat is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("\nWhat is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string[] data = parts[1].Split(",");

            switch (parts[0])
            {
                case "SimpleGoal":
                    SimpleGoal simpleGoal = new SimpleGoal(data[0], data[1], data[2]);
                    if (bool.Parse(data[3])) simpleGoal.RecordEvent();
                    _goals.Add(simpleGoal);
                    break;
                    
                case "EternalGoal":
                    EternalGoal eternalGoal = new EternalGoal(data[0], data[1], data[2]);
                    int timesCompleted = int.Parse(data[3]);
                    for (int j = 0; j < timesCompleted; j++)
                    {
                        eternalGoal.RecordEvent();
                    }
                    _goals.Add(eternalGoal);
                    break;
                    
                case "ChecklistGoal":
                    ChecklistGoal checklistGoal = new ChecklistGoal(
                        data[0], data[1], data[2], 
                        int.Parse(data[3]), int.Parse(data[4]));
                    
                    int completedCount = int.Parse(data[5]);
                    for (int j = 0; j < completedCount; j++)
                    {
                        checklistGoal.RecordEvent();
                    }
                    _goals.Add(checklistGoal);
                    break;
            }
        }
        
        _achievementSystem.UpdateLevel(_score);
        _achievementSystem.CheckAchievements(_goals, _score);
        Console.WriteLine("Goals loaded successfully!");
    }
}