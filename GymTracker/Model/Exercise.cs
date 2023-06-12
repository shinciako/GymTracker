using SQLite;
using SQLiteNetExtensions.Attributes;

namespace GymTracker.Model;

[Table("Exercise")]
public class Exercise
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Name { get; set; }
    public string MusclePart { get; set; }

    [ManyToOne]
    public Training Training { get; set; }
}
