using System;
using System.Collections.Generic;
using System.Linq;

public class Influence
{
    public double MinStrength { get; set; }
    public double MaxStrength { get; set; }
    public int IntensityPerMonth { get; set; }
    public double PerceptionCoefficient { get; set; }

    public double GenerateRandomStrength(Random random)
    {
        return random.NextDouble() * (MaxStrength - MinStrength) + MinStrength;
    }
}

public class Simulation
{
    //порогові значення
    private Dictionary<string, double> thresholdValues = new Dictionary<string, double>
    {
        {"g0-g1", 0.3}, {"g0-g2", 0.5}, {"g0-g3", 0.8},
        {"g1-g2", 0.2}, {"g1-g3", 0.5}, {"g1-g4", 0.7},
        {"g2-g3", 0.4}, {"g2-g4", 0.6},
        {"g3-g4", 0.1}
    };

    public void RunSimulation()
    {
        var random = new Random();
        double accumulatedInfluence = 0;
        string currentState = "g0";
        int day = 1;
        int totalDays = 0;
        int daysInCurrentState = 0;
        Dictionary<string, int> timeSpentInStates = new Dictionary<string, int>();
        //таблиця впливу
        Influence[] influences = new Influence[]
        {
            new Influence { MinStrength = 0.6, MaxStrength = 0.8, IntensityPerMonth = 4, PerceptionCoefficient = 1 },
            new Influence { MinStrength = 0.3, MaxStrength = 0.4, IntensityPerMonth = 8, PerceptionCoefficient = 0.9 },
            new Influence { MinStrength = 0.2, MaxStrength = 0.3, IntensityPerMonth = 10, PerceptionCoefficient = 0.8 }
        };
        //доки не досягне стану g4
        while (currentState != "g4")
        {
            bool stateChanged = false;

            foreach (var influence in influences)
            {
                if (random.Next(1, 31) <= influence.IntensityPerMonth)
                {
                    double strength = influence.GenerateRandomStrength(random) * influence.PerceptionCoefficient;
                    accumulatedInfluence += strength;
                    Console.WriteLine($"День {day}: Отримано вплив, накопичено = {accumulatedInfluence:F2}");

                    //отримуємо порогові значення для поточного стану
                    var possibleTransitions = thresholdValues
                        .Where(t => t.Key.StartsWith(currentState))
                        .OrderByDescending(t => t.Value); //від найвищого до найнижчого порога

                    foreach (var threshold in possibleTransitions)
                    {
                        if (accumulatedInfluence >= threshold.Value)
                        {
                            timeSpentInStates[currentState] = daysInCurrentState;
                            string nextState = threshold.Key.Split('-')[1];
                            Console.WriteLine($"Перехід з {currentState} до {nextState} через {daysInCurrentState} день/дні");

                            //переходимо в новий стан, обнуляємо накопичене
                            currentState = nextState;
                            accumulatedInfluence = 0;
                            daysInCurrentState = 0;
                            stateChanged = true;
                            break;
                        }
                    }
                }
                if (stateChanged) break;
            }

            day++;
            daysInCurrentState++;
            totalDays++;
        }

        timeSpentInStates["g4"] = daysInCurrentState;
        Console.WriteLine($"\nВсього днів до стану g4: {totalDays}\n");

        foreach (var state in timeSpentInStates)
        {
            Console.WriteLine($"Час проведено в стані {state.Key}: {state.Value} день/днів");
        }
    }

    public static void Main()
    {
        Simulation simulation = new Simulation();
        simulation.RunSimulation();
    }
}