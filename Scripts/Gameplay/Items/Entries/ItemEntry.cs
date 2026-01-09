using Godot;

[GlobalClass, Icon("res://icon.svg")]
public partial class ItemEntry : Resource
{
    public ItemEntry(string name, string description, Money price, int weight)
    {
        Name = name;
        Description = description;
        Price = price;
        Weight = weight;
    }
    [Export] public string ID { get; set; }
    [Export] public string Name { get; set; }
    [Export] public string Description { get; set; }
    [Export] public Money Price { get; set; }
    [Export] public int Weight { get; set; }
}