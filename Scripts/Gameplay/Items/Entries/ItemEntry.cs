public class ItemEntry
{
    public ItemEntry(string name, string description, Money price, int weight)
    {
        Name = name;
        Description = description;
        Price = price;
        Weight = weight;
    }
    public string ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Money Price { get; set; }
    public int Weight { get; set; }
}