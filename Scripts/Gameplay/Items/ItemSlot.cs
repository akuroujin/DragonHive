using Godot;

[GlobalClass]
public partial class ItemSlot : Resource
{
    public ItemSlot(ItemEntry entry, int amount = 1)
    {
        Entry = entry;
        Amount = amount;
    }
    [Export] public ItemEntry Entry;
    [Export] public int Amount { get; set; }
    public int TotalWeight => Entry.Weight * Amount;
    public Money TotalPrice => Entry.Price * Amount;
}