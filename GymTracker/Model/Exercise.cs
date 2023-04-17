namespace GymTracker.Model;

public class Exercise
{
    public string Name { get; set; }
    public string MusclePart { get; set; }

    public Exercise(string name, string musclePart)
    {
        Name = name;
        MusclePart = musclePart;
    }
}

