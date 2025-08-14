using System;
using System.Collections.Generic;

// Base class
public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime Date => _date;
    public int Minutes => _minutes;

    // Abstract methods to be overridden by derived classes
    public abstract double GetDistance(); // miles or km depending on units used
    public abstract double GetSpeed();    // mph or kph
    public abstract double GetPace();     // min per mile or min per km

    // Shared summary method using the above calculations
    public virtual string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {this.GetType().Name} ({Minutes} min) - Distance: {GetDistance():F1} miles, " +
               $"Speed: {GetSpeed():F1} mph, Pace: {GetPace():F2} min per mile";
    }
}

// Running activity
public class Running : Activity
{
    private double _distance; // in miles

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed() => (GetDistance() / Minutes) * 60;

    public override double GetPace() => Minutes / GetDistance();
}

// Cycling activity
public class Cycling : Activity
{
    private double _speed; // in mph

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => (_speed * Minutes) / 60;

    public override double GetSpeed() => _speed;

    public override double GetPace() => 60 / _speed;
}

// Swimming activity
public class Swimming : Activity
{
    private int _laps;
    private const double LapLengthMeters = 50;
    private const double MetersToMiles = 0.000621371;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    // Distance in miles
    public override double GetDistance() => _laps * LapLengthMeters * MetersToMiles;

    public override double GetSpeed() => (GetDistance() / Minutes) * 60;

    public override double GetPace() => Minutes / GetDistance();

    // Override summary to specify laps as well
    public override string GetSummary()
    {
        return $"{Date:dd MMM yyyy} Swimming ({Minutes} min) - Laps: {_laps}, Distance: {GetDistance():F2} miles, " +
               $"Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }
}

class Program
{
    static void Main()
    {
        // Create one activity of each type
        Activity run = new Running(new DateTime(2022, 11, 3), 30, 3.0);     // 3 miles in 30 mins
        Activity cycle = new Cycling(new DateTime(2022, 11, 3), 45, 12.0); // 12 mph for 45 mins
        Activity swim = new Swimming(new DateTime(2022, 11, 3), 60, 40);   // 40 laps in 60 mins

        // Put them in a list
        List<Activity> activities = new List<Activity>() { run, cycle, swim };

        // Display summaries for each
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
