
using System;
using System.IO;

public class GoalsTracker
{
    private List<GoalsTracker> _goals = new List<GoalsTracker>();

    private int _accumulatedPoints = 0;

    public int GetAccumulatedPoints() {

        int points = _accumulatedPoints;
        return points;

    }
    public void SaveGoals()
    {
        string fileName = "";
          Console.Write("What is the filename? ");
          fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            int totalAGP = GetAccumulatedPoints();
            outputFile.WriteLine(totalAGP.ToString());
            
            foreach(GoalsTracker goal in _goals)
            {
                outputFile.WriteLine(goal.Goals());
            }
        }
    }

    private ReadOnlySpan<char> Goals()
    {
        throw new NotImplementedException();
    }


    public void LoadGoals()
    {
        _goals.Clear(); 

        string fileName = "";
        Console.Write("What is the filename? ");
        fileName = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(fileName);

        _accumulatedPoints = Convert.ToInt32(lines[0]);

        for (int i = 1; i < lines.Count(); i++ )
        {
            string[] parts = lines[i].Split("|");

            if (parts[0] == "SimpleGoal") {

                SimpleGoal simpleGoal = new SimpleGoal(parts[1], parts[2], Convert.ToInt32(parts[3]), Convert.ToBoolean(parts[4]));
                _goals.Add(simpleGoal);             

            } else if (parts[0] == "EternalGoal") {

                EternalGoal eternalGoal = new EternalGoal(parts[1], parts[2], Convert.ToInt32(parts[3]));
                _goals.Add(eternalGoal);

            } else if (parts[0] == "ChecklistGoal") {
                
                ChecklistGoal checklistGoal = new ChecklistGoal(parts[1], parts[2], Convert.ToInt32(parts[3]), Convert.ToInt32(parts[4]), Convert.ToInt32(parts[5]), Convert.ToInt32(parts[6]));
                _goals.Add(checklistGoal);

            }
        }
 
    }

    public void ListGoals()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count(); i++) {
            Console.Write($"{i + 1}. ");
            _goals[i].ListGoal();
            Console.Write("\n");
        }
        Console.WriteLine();
    }

    public void addGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public int CalculateTotalAGP()
    {
        int totalAGP = _accumulatedPoints;
        foreach(Goal goal in _goals) {
            totalAGP += goal.CalculateAGP();
        }

        _accumulatedPoints = totalAGP;

        return totalAGP;
    }

    public void RecordEventInTracker()
    {
        string goalIndex = "";
        Console.Write("Which goal did you accomplish? ");
        goalIndex = Console.ReadLine();
        int goalIndexInt = Convert.ToInt32(goalIndex) - 1;

        if (_goals[goalIndexInt].IsComplete() == false) {

            _goals[goalIndexInt].RecordEvent();

            int pointsEarned = _goals[goalIndexInt].CalculateAGP();

            _accumulatedPoints += pointsEarned;

            Console.WriteLine($"Congratulations! You have earned {pointsEarned.ToString()} points!");
            Console.WriteLine($"You now have {_accumulatedPoints} points");

        } else {

            Console.WriteLine("You have already completed this goal.");

        }
    }
}

internal class SimpleGoal
{
    private string v1;
    private string v2;
    private int v3;
    private bool v4;

    public SimpleGoal(string v1, string v2, int v3, bool v4)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
        this.v4 = v4;
    }

}