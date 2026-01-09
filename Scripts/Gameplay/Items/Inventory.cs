using Godot.Collections;
using Godot;

public partial class Inventory : Resource
{
    [Export]
    Array<ItemSlot> Items;
    [Export]
    Array<Equipment> EquippedItems;
}