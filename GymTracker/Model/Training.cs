using SQLite;
using SQLiteNetExtensions.Attributes;

namespace GymTracker.Model;

[Table("Training")]
public class Training
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [ForeignKey(typeof(Session))]
    public int SessionId { get; set; }

    [ManyToOne]
    public Session Session { get; set; }

    [ForeignKey(typeof(Exercise))]
    public int ExerciseId { get; set; }

    [ManyToOne]
    public Exercise Exercise { get; set; }

    public int Repetition { get; set; }
    public int Weight { get; set; }
}

