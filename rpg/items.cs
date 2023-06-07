using System;

public class Substat
{
    public string type;
    public int value;

    public Substat(string type, int value)
    {
        this.type = type;
        this.value = value;
    }
}

public class Rarity
{
    public string rarity;
    public ConsoleColor color;

    public Rarity(string rarity, ConsoleColor color)
    {
        this.rarity = rarity;
        this.color = color;
    }
}

public class Artifact
{
    public string name;
    public Rarity rarity;
    public Substat[] substats;

    public string ability_desc;
    public string ability_type;
    public string ability_name;


    public Artifact(string name, Rarity rarity, Substat[] substats, string ability_desc, string ability_type, string ability_name)
    {
        this.name = name;
        this.rarity = rarity;
        this.substats = substats;
        this.ability_desc = ability_desc;
        this.ability_type = ability_type;
        this.ability_name = ability_name;
    }

    public void PrintArtifact()
    {
        Console.ForegroundColor = rarity.color;
        Console.WriteLine(name);
        Console.ResetColor();
        foreach(Substat substat in substats)
        {
            Console.WriteLine("{0}: +{1}", substat.type, substat.value);
        }
        Console.WriteLine(ability_desc);
    }
}

public class Weapon
{
    public string name;
    public Rarity rarity;
    public bool ranged;
    public int atk;
    public Substat[] substats;

    public string ability_desc;
    public string ability_type;
    public string ability_name;
    
    public Weapon(string name, Rarity rarity, bool ranged, int atk, Substat[] substats, string ability_desc, string ability_type, string ability_name)
    {
        this.name=name;
        this.rarity=rarity;
        this.ranged=ranged;
        this.atk=atk;
        this.substats=substats;
        this.ability_desc=ability_desc;
        this.ability_type=ability_type;
        this.ability_name=ability_name;
    }

    public void PrintWeapon()
    {
        Console.ForegroundColor = rarity.color;
        Console.WriteLine(name);
        Console.ResetColor();
        Console.WriteLine("ATK: {0}", atk);
        foreach (Substat substat in substats)
        {
            Console.WriteLine("{0}: +{1}", substat.type, substat.value);
        }
        Console.WriteLine(ability_desc);
    }

}


