namespace GymTracker.Model;
using SQLite;
using SQLiteNetExtensions.Attributes;


public class Template
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Exercise> Exercises { get; set; }
}