using System;

namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        private int _laps;
        private const double LapDistanceInMiles = 50.0 / 1000 * 0.62;

        public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            return _laps * LapDistanceInMiles;
        }

        public override double GetSpeed()
        {
            return (GetDistance() / Minutes) * 60;
        }

        public override double GetPace()
        {
            return Minutes / GetDistance();
        }
    }
}