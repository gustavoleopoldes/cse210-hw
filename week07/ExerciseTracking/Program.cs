using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>();

            activities.Add(new Running(new DateTime(2022, 11, 3), 30, 3.0));
            activities.Add(new Cycling(new DateTime(2022, 11, 4), 45, 15.0));
            activities.Add(new Swimming(new DateTime(2022, 11, 5), 60, 20));

            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}