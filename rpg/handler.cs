public class Handler
{
    public string inputHandler(string input)
    {
        string[] args = input.Split(' ');
        switch (args[0])
        {
            case "help":
                if (args.Length < 2)
                {
                    printBasicHelp();
                    return "cmd-done";
                } else
                {
                    return "help-advanced";
                }
            case "status":
            case "st":
                return "status";
            case "travel":
            case "t":
                return args.Length < 2 ? "error-101" : "travel";
            case "fight":
            case "f":
                return "combat";
            default:
                return "error-102";
        }
    }

    public string travelHandler(string input)
    {
        string[] args = input.Split(' ');
        string destination = args[1] switch
        {
            "novice" => "nw",
            "nw" => "nw",
            "graveyard" => "gy",
            "gy" => "gy",
            _ => "error-103"
        };
        return destination;
    }

    public void helpHandler(string input)
    {
        string[] args = input.Split(' ');
    }

    private void printBasicHelp()
    {
        Console.WriteLine("Command List:");
        Console.WriteLine("help - Displays list of commands if there is less than 1 argument. Displays specifics about a command if a command is specified in arguments.");
        Console.WriteLine("fight - Fight a random enemy that spawns in your current location. Abbreviation 'f'.");
        Console.WriteLine("status - Displays current status of player. Abbreviation 'st'.");
        Console.WriteLine("travel - Requires at least 1 argument. Allows player to travel to a location, if unlocked. Abbreviation 't'.");
    }
}