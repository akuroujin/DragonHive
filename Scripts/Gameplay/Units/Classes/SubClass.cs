using System.Xml.Serialization;
public class SubClass
{
    public SubClass() : this("SubClass", "Desc") { }
    public SubClass(string name, string description)
    {
        Name = name;
        Description = description;
    }
    [XmlElement]
    public string Name { get; set; }
    [XmlElement]
    public string Description { get; set; }
}
