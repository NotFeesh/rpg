public class Passive
{
    public string type;
    public string subtype;
    public string desc;

    public int value;

    public Passive(string type, string subtype, int value, string desc)
    {
        this.type = type;
        this.desc = desc;
        this.subtype = subtype;
        this.value = value;
    }
}

public class Race
{
    public string name;

    public int base_hp;
    public int base_mp;
    public int base_def;
    public int base_atk;
    public int base_crit_rate;
    public int base_crit_dmg;

    public float hp_scale;
    public float mp_scale;
    public float def_scale;
    public float atk_scale;
    public float crit_rate_scale;
    public float crit_dmg_scale;

    public Passive[] passives;

    public Race(string name, int base_hp, int base_mp, int base_def, int base_atk, int base_crit_rate, int base_crit_dmg, float hp_scale, float mp_scale, float def_scale, float atk_scale, float crit_rate_scale, float crit_dmg_scale, Passive[] passives)
    {
        this.name = name;
        this.base_hp = base_hp;
        this.base_mp = base_mp;
        this.base_def = base_def;
        this.base_atk = base_atk;
        this.base_crit_rate = base_crit_rate;
        this.base_crit_dmg = base_crit_dmg;
        this.hp_scale = hp_scale;
        this.mp_scale = mp_scale;
        this.def_scale = def_scale;
        this.atk_scale = atk_scale;
        this.crit_rate_scale = crit_rate_scale;
        this.crit_dmg_scale = crit_dmg_scale;
        this.passives = passives;
    }
}

public class Class
{
    public string name;

    public int base_hp;
    public int base_mp;
    public int base_def;
    public int base_atk;
    public int base_crit_rate;
    public int base_crit_dmg;

    public float hp_scale;
    public float mp_scale;
    public float def_scale;
    public float atk_scale;
    public float crit_rate_scale;
    public float crit_dmg_scale;

    public Passive[] passives;

    public Class(string name, int base_hp, int base_mp, int base_def, int base_atk, int base_crit_rate, int base_crit_dmg, float hp_scale, float mp_scale, float def_scale, float atk_scale, float crit_rate_scale, float crit_dmg_scale, Passive[] passives)
    {
        this.name = name;
        this.base_hp = base_hp;
        this.base_mp = base_mp;
        this.base_def = base_def;
        this.base_atk = base_atk;
        this.base_crit_rate = base_crit_rate;
        this.base_crit_dmg = base_crit_dmg;
        this.hp_scale = hp_scale;
        this.mp_scale = mp_scale;
        this.def_scale = def_scale;
        this.atk_scale = atk_scale;
        this.crit_rate_scale = crit_rate_scale;
        this.crit_dmg_scale = crit_dmg_scale;
        this.passives = passives;
    }
}

public class Player
{
    public string name;
    public Class profession;
    public Race race;

    public Weapon weapon_equipped;
    public Weapon[] weapons;

    public Artifact[] artifacts;

    public int hp_max;
    public int hp;

    public int mp_max;
    public int mp;

    public int def;
    public int atk;
    public int crit_rate;
    public int crit_dmg;

    public int xp;
    public int xpToNextLevel;
    public int level;

    public Location current_location;

    public Player(string name, Class profession, Race race, Weapon weapon_equipped, Weapon[] weapons, Artifact[] artifacts, Location current_location)
    {
        this.name = name;
        this.profession = profession;
        this.race = race;
        this.weapon_equipped = weapon_equipped;
        this.weapons = weapons;
        this.artifacts = artifacts;
        this.xp = 0;
        this.xpToNextLevel = 100;
        this.level = 0;
        this.current_location = current_location;
    }

    private int CalculateArtifactStat(string stat_type)
    {
        int stat = 0;
        foreach (Artifact artifact in artifacts)
        {
            foreach (Substat substat in artifact.substats)
            {
                if (substat.type.Equals(stat_type))
                {
                    stat += substat.value;
                }
            }
        }
        return stat;
    }

    private int CalculateWeaponStat(string stat_type)
    {
        int stat = 0;
            foreach (Substat substat in weapon_equipped.substats)
            {
                if (substat.type.Equals(stat_type))
                {
                    stat += substat.value;
                }
            }
        return stat;
    }

    private int CalculateRaceStat(string stat_type)
    {
        int stat = 0;
        foreach (Passive passive in race.passives)
        {
            if (passive.type.Equals("stat"))
            {
                if (passive.subtype.Equals(stat_type))
                {
                    stat += passive.value;
                }
            }
        }
        return stat;
    }

    private int CalculateClassStat(string stat_type)
    {
        int stat = 0;
        foreach (Passive passive in profession.passives)
        {
            if (passive.type.Equals("stat"))
            {
                if (passive.subtype.Equals(stat_type))
                {
                    stat += passive.value;
                }
            }
        }
        return stat;
    }

    public void CalculateStats()
    {
        hp_max = (int)(race.base_hp + race.base_hp * race.hp_scale * level) + (int)(profession.base_hp + profession.base_hp * profession.hp_scale * level) + CalculateArtifactStat("HP") + CalculateWeaponStat("HP") + CalculateRaceStat("HP") + CalculateClassStat("HP");

        mp_max = (int)(race.base_mp + race.base_mp * race.mp_scale * level) + (int)(profession.base_mp + profession.base_mp * profession.mp_scale * level) + CalculateArtifactStat("MP") + CalculateWeaponStat("MP") + CalculateRaceStat("MP") + CalculateClassStat("MP");

        def = (int)(race.base_def + race.base_def * race.def_scale * level) + (int)(profession.base_def + profession.base_def * profession.def_scale * level) + CalculateArtifactStat("DEF") + CalculateWeaponStat("DEF") + CalculateRaceStat("DEF") + CalculateClassStat("DEF");

        atk = (int)(race.base_atk + race.base_atk * race.atk_scale * level) + (int)(profession.base_atk + profession.base_atk * profession.atk_scale * level) + weapon_equipped.atk + CalculateArtifactStat("ATK") + CalculateWeaponStat("ATK") + CalculateRaceStat("ATK") + CalculateClassStat("ATK");

        crit_rate = (int)(race.base_crit_rate + race.base_crit_rate * race.crit_rate_scale * level) + (int)(profession.base_crit_rate + profession.base_crit_rate * profession.crit_rate_scale * level) + CalculateArtifactStat("Crit Rate") + CalculateWeaponStat("Crit Rate") + CalculateRaceStat("Crit Rate") + CalculateClassStat("Crit Rate");

        crit_dmg = (int)(race.base_crit_dmg + race.base_crit_dmg * race.crit_dmg_scale * level) + (int)(profession.base_crit_dmg + profession.base_crit_dmg * profession.crit_dmg_scale * level) + CalculateArtifactStat("Crit DMG") + CalculateWeaponStat("Crit DMG") + CalculateRaceStat("Crit DMG") + CalculateClassStat("Crit DMG");
    }

    public void PrintPlayer()
    {
        CalculateStats();
        Console.WriteLine(name);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("CURRENT LOCATION: {0}", current_location.name);
        Console.ResetColor();
        Console.WriteLine("{0} {1}", race.name, profession.name);
        Console.WriteLine("Weapon: {0}", weapon_equipped.name);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("HP: {0}/{1}", hp, hp_max);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("MP: {0}/{1}", mp, mp_max);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("ATK: {0}", atk);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("DEF: {0}", def);
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Crit Rate: {0}%", crit_rate < 100 ? crit_rate : 100);
        Console.WriteLine("Crit DMG: {0}%", crit_dmg);
        Console.ResetColor();
        Console.WriteLine("Weapons:");
        foreach(Weapon weapon in weapons)
        {
            Console.ForegroundColor = weapon.rarity.color;
            Console.WriteLine(weapon.name);
            Console.ResetColor();
        }
        Console.WriteLine("Artifacts:");
        foreach(Artifact artifact in artifacts)
        {

            Console.ForegroundColor = artifact.rarity.color;
            Console.WriteLine(artifact.name);
            Console.ResetColor();
        }
    }

    public void Regenerate()
    {
        hp = hp_max;
        mp = mp_max;
    }

}