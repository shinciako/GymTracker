using Microsoft.Maui.Controls;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using System.Windows.Input;

namespace GymTracker.Model;

public class Session
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [OneToMany(CascadeOperations = CascadeOperation.All)]
    public List<Training> Trainings { get; set; }

    public DateTime Timestamp { get; set; }
}
