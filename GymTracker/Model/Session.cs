namespace GymTracker.Model;

public class Session
{
    public int Id { get; set; }
    public List<Training> Trainings { get; set; }
    public DateTime Timestamp { get; set; }

    public Session()
	{
	}
}

