using System;
namespace GymTracker.Model;

public class Set
{
    public int Repetition { get; set; }
    public int Weight { get; set; }

    public Set(int repetition, int weight)
    {
        Repetition = repetition;
        Weight = weight;
    }
}

