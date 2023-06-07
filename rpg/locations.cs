public class Location
{
    public string name;
    public string abbr;
    public Enemy[] spawns;

    public Location(string name, string abbr, Enemy[] spawns)
    {
        this.name = name;
        this.abbr = abbr;
        this.spawns = spawns;
    }
}