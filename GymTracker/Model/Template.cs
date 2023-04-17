namespace GymTracker.Model;

public class Template
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Template(string name, string description)
    {
        Name = name;
        Description = description;
    }
}

