using System.Xml.Serialization;
using Godot;
[GlobalClass]
public partial class SubClass : Resource
{
    public SubClass() : this("SubClass", "Desc") { }
    public SubClass(string name, string description)
    {
        Name = name;
        Description = description;
    }
    [Export]
    public string Name { get; set; }
    [Export]
    public string Description { get; set; }
}
