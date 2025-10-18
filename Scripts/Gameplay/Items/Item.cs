using System.Xml.Serialization;

public class Item
{
    public Item() : this("TestItem", "Test the item", new Money(gold: 2), 3, 5) { }
    public Item(string name, string description, Money price, int weight, int amount)
    {
        Name = name;
        Description = description;
        Price = price;
        Weight = weight;
        Amount = amount;
    }

    [XmlElement]
    public string Name { get; set; }
    [XmlElement]
    public string Description { get; set; }
    [XmlElement]
    public Money Price { get; set; }
    [XmlElement]
    public int Weight { get; set; }
    [XmlElement]
    public int Amount { get; set; }
    public int TotalWeight => Weight * Amount;
}