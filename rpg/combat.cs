using System;

public class Combat
{
	public void fight(Player player, Enemy[] enemies)
    {
        Enemy enemy = enemies[Random(enemies.Length)];
        bool playerTurn = Random(2) == 0 ? false : true;
        if (playerTurn) playerCombat(player, enemy); else enemyCombat(player, enemy);
        while (player.hp > 0 && enemy.hp > 0)
        {
            playerTurn = playerTurn ? playerCombat(player, enemy) : enemyCombat(player, enemy);
        }
    }

    private int Random(int max)
    {
        Random random = new Random();
        return random.Next(max);
    }

    private bool playerCombat(Player player, Enemy enemy)
    {
        Console.WriteLine("Please enter combat commands! For help, type c-help.");
        string input = Console.ReadLine();
        int action = combatHandler(input);
        if (action == 1)
        {
            bool is_crit = Random(100) + player.crit_rate >= 100;
            
            return true;
        } 
        else if (action == 2)
        {

        } 
        else if (action == 3)
        {

        } 
        else if (action == 102)
        {
            Console.WriteLine("Error 102: Command not recognized.");
        }
        return false;
    }

    private int combatHandler(string input)
    {
        string[] args = input.Split(' ');
        switch (args[0])
        {
            case "attack":
            case "atk":
                return 1;
            case "ability":
            case "aby":
                return 2;
            case "use":
            case "item":
                return 3;
            default:
                return 102;
        }
    }

    private bool enemyCombat(Player player, Enemy enemy)
    {
        EnemyAttack attack = enemy.attacks[Random(enemy.attacks.Length)];
        bool is_crit = Random(100) + enemy.crit_rate >= 100;
        int dmg_dealt = (is_crit ? attack.crit_dmg : attack.dmg);
        player.hp -= dmg_dealt * Convert.ToInt32(1 - player.def * 0.001);
        Console.WriteLine("{0} used {1} on {2}, dealing {3}{4} damage!", enemy.name, attack.name, player.name, dmg_dealt, is_crit ? "(CRIT HIT)" : "");
        return true;
    }
}
