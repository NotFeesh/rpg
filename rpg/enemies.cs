public class Enemy
{
    public string name;
    public int hp_max, hp, def, crit_rate, xpDrop;
    public EnemyAttack[] attacks;
    public WeaponDrop[] weapon_drops;
    public ArtifactDrop[] artifact_drops;

    public Enemy(string name, int hp_max, int def, int crit_rate, EnemyAttack[] attacks, WeaponDrop[] weapon_drops, ArtifactDrop[] artifact_drops, int xpDrop)
    {
        this.name = name;
        this.hp_max = hp_max;
        this.hp = hp_max;
        this.def = def;
        this.crit_rate = crit_rate;
        this.attacks = attacks;
        this.weapon_drops = weapon_drops;
        this.artifact_drops = artifact_drops;
        this.xpDrop = xpDrop;
    }
}

public class EnemyAttack
{
    public string name, desc;
    public int dmg, crit_dmg;

    public EnemyAttack(string name, string desc, int dmg, int crit_dmg)
    {
        this.name = name;
        this.desc = desc;
        this.dmg = dmg;
        this.crit_dmg = crit_dmg;
    }
}

public class WeaponDrop
{
    public int chance;
    public Weapon weapon;
    public WeaponDrop(int chance, Weapon weapon)
    {
        this.chance = chance;
        this.weapon = weapon;
    }
}

public class ArtifactDrop
{
    public int chance;
    public Artifact artifact;

    public ArtifactDrop(int chance, Artifact artifact)
    {
        this.chance = chance;
        this.artifact = artifact;
    }
}