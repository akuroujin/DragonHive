using Godot;
using System;
using System.Collections.Generic;

public partial class XmlTest : Control
{
    FileDialog dialog;
    PlayerCharacter character;
    public override void _Ready()
    {

        Resistance resistance = new(DamageType.Slashing);
        List<Damage> damages = [new Damage(2, DiceTypes.D6, 5, new Resistance(DamageType.Piercing))];
        List<Element> elements = [new Element()];
        List<Attack> attacks = [new Attack("hit", "hits enemy", damages, 5, 1, true, false, false, BaseStatTypes.Strength), new()];
        List<Spell> spells = [new Spell("hit", "hits enemy", damages, 5, 1, true, false, false, BaseStatTypes.Intelligence, 2, 1, 2, elements, 2, 5), new(), new()];
        List<Item> items = [new Item("TestItem", "Test the item", new Money(gold: 2), 3, 5)];
        List<Equipment> equippables = [new Armor("Testarmor", "Testing", new Money(gold: 10), 10, 1, ["test"], [], 16)];
        UnitBaseStats unitBaseStats = new(10, 12, 12, 10, 5, 16);
        UnitStats stats = new(30, 50, 30, 14);
        List<CharacterClass> characterClasses = [new CharacterClass("Fighter", 7, [ProficiencyType.Acrobatics], [ProficiencyType.Arcana])];

        List<SubClass> subClasses = [new SubClass("SubFighter", "Fights the subs")];

        character = new PlayerCharacter("Tester1", [resistance], attacks, spells, items, equippables, unitBaseStats, stats,
         40000, characterClasses, subClasses);


        dialog = GetNode<FileDialog>("../FileDialog");
        dialog.FileSelected += OnFileSelected;

        dialog.FileMode = FileDialog.FileModeEnum.SaveFile;
        dialog.AddFilter("*.xml", "XML Files");
        dialog.Popup();
    }

    private void OnFileSelected(string path)
    {
        XMLWriter.Export(path, character);
    }

}
