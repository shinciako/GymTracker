namespace GymTracker.Model;

public class Training
{
    public int Sets { get; set; }
    public List<int> Repetitions { get; set; }
    public List<float> Kilograms { get; set; }
    public Exercise Exercise { get; set; }

    public Training()
	{
	}
}

