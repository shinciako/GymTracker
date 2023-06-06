namespace GymTracker.Model;

public class Training
{
    public Exercise Exercise { get; set; }
    public int Sets { get; set; }
    public List<int> Repetitions { get; set; }
    public List<float> Kilograms { get; set; }
}

