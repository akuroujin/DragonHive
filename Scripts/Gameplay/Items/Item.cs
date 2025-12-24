public class Item
{
    public Item(ItemEntry entry, int amount = 1)
    {
        Entry = entry;
        Amount = amount;
    }
    public ItemEntry Entry;
    public int Amount { get; set; }
    public int TotalWeight => Entry.Weight * Amount;
}