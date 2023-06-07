Handler handler = new Handler();
Combat combat = new Combat();
//Declaring Consts

//Rarities
Rarity common = new Rarity("Common", ConsoleColor.White);
Rarity uncommon = new Rarity("Uncommon", ConsoleColor.Green);
Rarity rare = new Rarity("Rare", ConsoleColor.Blue);
Rarity epic = new Rarity("Epic", ConsoleColor.Magenta);
Rarity legendary = new Rarity("Legendary", ConsoleColor.Yellow);

//Weapons
Weapon rusty_sword = new Weapon("Rusty Sword", common, false, 10, new Substat[] { new Substat("DEF", 5) }, "None", "None", "None");

Weapon shreikh = new Weapon("Shreikh", uncommon, false, 30, new Substat[] { new Substat("Crit Rate", 5) }, "None", "None", "None");

Weapon sturdy_sword = new Weapon("Sturdy Sword", uncommon, false, 30, new Substat[] { new Substat("DEF", 15) }, "None", "None", "None");

Weapon first_demon_blade = new Weapon("First Demon's Blade", legendary, false, 250, new Substat[] { new Substat("Crit Rate", 10), new Substat("Crit DMG", 60) }, "None", "None", "None");

//Items
Artifact first_demon_heart = new Artifact("First Demon's Heart", legendary, new Substat[] { new Substat("HP", 300), new Substat("MP", 100) }, "Regenerate MP equal to HP lost", "post_dmg_MP", "First Demon's Blessing");
Artifact osmonds_rose = new Artifact("Osmond's Rose", legendary, new Substat[] {new Substat("Crit Rate", 5), new Substat("Crit Damage", 20) }, "Take 10% less damage from enemies.", "dmg_DEF", "Osmond's Protection");

//Classes
Class knight = new Class("Knight", 0, 0, 10, 10, 0, 0, 0f, 0f, 1.1f, 1.1f, 0f, 0f, new Passive[] {new Passive("stat", "ATK", 50, "+50 ATK") });

//Races
Race human = new Race("Human", 100, 100, 10, 10, 10, 50, 1.05f, 1.05f, 1.05f, 1.05f, 1.05f, 1.05f, new Passive[] { new Passive("stat", "HP", 50, "+50 HP") });

//Enemy Attacks
EnemyAttack scratch = new EnemyAttack("Scratch", "It wasn't very effective...", 10, 20);

//Weapon Drops
WeaponDrop saplingShreikh = new WeaponDrop(3, shreikh);
WeaponDrop zombieShreikh = new WeaponDrop(6, shreikh);

//Artifact Drops

//Enemies
Enemy sapling = new Enemy("Sapling", 50, 0, 0, new EnemyAttack[] {scratch}, new WeaponDrop[] {saplingShreikh}, new ArtifactDrop[] { }, 50);
Enemy zombie = new Enemy("Zombie", 100, 10, 5, new EnemyAttack[] { scratch }, new WeaponDrop[] { zombieShreikh }, new ArtifactDrop[] { }, 50);

//Locations
Location spawnforest = new Location("Novice Woods", "nw", new Enemy[] {sapling});

Location noviceGraveyard = new Location("Graveyard", "ng", new Enemy[] {zombie});

//Travel Function
void travelTo(Player player, string destination)
{
	player.current_location = destination switch
	{
		"nw" => spawnforest,
		"ng" => noviceGraveyard,
	};
}
//Setup
Console.WriteLine("Welcome to c# rpg!");

Console.WriteLine("Please Enter a Username:");
string name = Console.ReadLine();
while (string.IsNullOrEmpty(name))
{
    Console.WriteLine("Name can't be empty! Input your name once more");
    name = Console.ReadLine();
}
Console.Clear();


Console.WriteLine("Please Select a Class:");

//https://github.com/ricardogerbaudo/Console.InteractiveMenu/blob/main/Program.cs

(int left, int top) = Console.GetCursorPosition();
var option = 1;
var decorator = "█ \u001b[32m";
ConsoleKeyInfo key;
bool isSelected = false;

while (!isSelected)
{
	Console.SetCursorPosition(left, top);

	Console.WriteLine($"{(option == 1 ? decorator : "   ")}Knight \u001b[0m");
	Console.WriteLine($"{(option == 2 ? decorator : "   ")}Option \u001b[0m");
	Console.WriteLine($"{(option == 3 ? decorator : "   ")}Option \u001b[0m");

	key = Console.ReadKey(false);

	switch (key.Key)
	{
		case ConsoleKey.UpArrow:
			option = option == 1 ? 3 : option - 1;
			break;

		case ConsoleKey.DownArrow:
			option = option == 3 ? 1 : option + 1;
			break;

		case ConsoleKey.Enter:
			isSelected = true;
			break;
	}
}

Class profession = option switch
{
	1 => knight,
	2 => knight,
	3 => knight,
};

isSelected = false;
Console.Clear();




Console.WriteLine("Please Select a Race:");
(left, top) = Console.GetCursorPosition();

while (!isSelected)
{
	Console.SetCursorPosition(left, top);

	Console.WriteLine($"{(option == 1 ? decorator : "   ")}Human \u001b[0m");
	Console.WriteLine($"{(option == 2 ? decorator : "   ")}Option \u001b[0m");
	Console.WriteLine($"{(option == 3 ? decorator : "   ")}Option \u001b[0m");

	key = Console.ReadKey(false);

	switch (key.Key)
	{
		case ConsoleKey.UpArrow:
			option = option == 1 ? 3 : option - 1;
			break;

		case ConsoleKey.DownArrow:
			option = option == 3 ? 1 : option + 1;
			break;

		case ConsoleKey.Enter:
			isSelected = true;
			break;
	}
}

Race race = option switch
{
	1 => human,
	2 => human,
	3 => human,
};

isSelected = false;
Console.Clear();

Player player = new Player(name, profession, race, rusty_sword, new Weapon[] { }, new Artifact[] { }, spawnforest);

player.CalculateStats();
player.Regenerate();
Console.WriteLine("CREATED PLAYER:");
player.PrintPlayer();
Console.WriteLine("PRESS ENTER TO START");
Console.ReadLine();

//Game Loop

while (true)
{
	Console.Clear();
    Console.WriteLine("Welcome to c# rpg!");
    Console.WriteLine("Enter a command or type 'help' to begin!");
	string input = Console.ReadLine();
	string cmd = handler.inputHandler(input);
	switch (cmd)
    {
		case "error-101":
            Console.WriteLine("Error 101: Arguments for this command cannot be empty!");
			break;
		case "help-advanced":
			handler.helpHandler(input);
			break;
		case "status":
			player.PrintPlayer();
			break;
		case "travel":
			string destination = handler.travelHandler(input);
			if (destination.Equals("error-103")) { Console.WriteLine("Error 103: Arguments not recognized"); break; }
			player.current_location = destination switch
			{
				"nw" => spawnforest,
				"gy" => noviceGraveyard
			};
            Console.WriteLine("You have arrived at {0}!", player.current_location.name);
			break;
		case "combat":
			combat.fight(player, player.current_location.spawns);
			break;
		case "cmd-done":
			break;
		default:
            Console.WriteLine("Error 102: Command not recognized.");
			break;
		
    }
	Console.WriteLine("Press ENTER to continue");
	Console.ReadLine();
}