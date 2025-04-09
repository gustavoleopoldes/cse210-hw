//I created a new class of achievements so there are some missions and we can report progress between completed or pending
using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}