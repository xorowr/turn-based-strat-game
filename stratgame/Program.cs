using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        // introduction to the game
        Console.WriteLine("Welcome to the battle of your lifetime!");
        Console.WriteLine("To win, you must defeat your opponent. Pretty easy, right?");
        Console.WriteLine("You have five actions you can pick from each turn. Some of these consume energy. You recharge 4 points of energy each turn. I'll explain what they are properly when we get there.");
        Console.WriteLine("Good luck out there. Or bad luck... Depends which side I'm on today.");
        Console.WriteLine();

        //constants for moves for clarity
        const string attack = "1";
        const string specialattack = "2";
        const string recharge = "3";
        const string dodge = "4";
        const string heal = "5";


        // stats
        Console.WriteLine("Before I forget, here are the current stats of you and the enemy.");
        int playerhealth = 100;
        int playerenergy = 50;
        int enemyhealth = 100;
        int enemyenergy = 50;
        Console.WriteLine("Your health: " + playerhealth + "/100");
        Console.WriteLine("Your energy: " + playerenergy + "/50");
        Console.WriteLine("Enemey's health: " + enemyhealth + "/100");
        Console.WriteLine("Enemy's energy " + enemyenergy + "/50");

        Console.WriteLine("Right! I think that's everything. Are you ready? Not that I care or anything...");
        Console.ReadLine();
        Console.WriteLine("I don't actually care. I'm asking to be nice. Anyway, let's get this show on the road!");
        Console.WriteLine();

        Random roll = new Random();


        // while loop will begin here when i get to that point
        Console.WriteLine("Time to make your move! Enter the number that corresponds to the move you would like to do.");
        Console.WriteLine("[1] Attack - Standard strike on the enemy. - 1-10 damage and 80% chance to hit - Costs 5 energy");
        Console.WriteLine("[2] Special Attack - A special attack - 5-20 damage and 50% chance to hit - Costs 10 energy.");
        Console.WriteLine("[3] Recharge - Recharges energy at 4 times the normal rate. Increase the chance you'll be hit by 20%. No energy is used.");
        Console.WriteLine("[4] Dodge - Dodges the enemy's attack. Decrease enemy's chance of hitting by 30%. Recharges only 2 energy.");
        Console.WriteLine("[5] Heal - Can convert up to half of the stored energy into health. This can be used alongsie another action. Costs 10 energy.");

        string playerchoice = Console.ReadLine();
        int firstchoice = roll.Next(1, 5);
        while (firstchoice == 3 && enemyenergy! < 35)
        {
            firstchoice = roll.Next(1, 5);
        }

        // choice 1 - player
        if (playerchoice == attack)
        {
            playerenergy -= 5;
            int chance = roll.Next(1, 10);
            if (firstchoice == 4)
            {
                if (chance < 6)
                {
                    int damage = roll.Next(1, 10);
                    Console.WriteLine("Your attack was successful. You dealt " + damage + " damage");
                    enemyhealth -= damage;
                    playerenergy += 4;
                }
                else
                {
                    Console.WriteLine("Your attack has failed!");
                    playerenergy += 4;
                }
            }
            if (chance < 9)
            {
                int damage = roll.Next(1, 10);
                Console.WriteLine("Your attack was successful. You dealt " + damage + " damage");
                enemyhealth -= damage;
                playerenergy += 4;
            }
            else
            {
                Console.WriteLine("Your attack has failed!");
                playerenergy += 4;
            }
        }

        // choice 2 - player
        if (playerchoice == specialattack)
        {
            playerenergy -= 10;
            int chance = roll.Next(1, 10);
            if (firstchoice == 4)
            {
                if (chance < 3)
                {
                    Console.WriteLine("Your attack has failed.");
                    playerenergy += 4;
                }
            }
            if (chance < 6)
            {
                int damage = roll.Next(1, 10);
                Console.WriteLine("Your attack was successful. You dealt " + damage + " damage");
                enemyhealth -= damage;
                playerenergy += 4;
            }

        }
        // choice 3 - player
        if (playerchoice == recharge)
        {
            if (playerenergy! < 50)
            {
                int newenergy = 50 - playerenergy;
                if (newenergy < 35)
                {
                    playerenergy += 16;
                    bool hitincrease = true;
                    Console.WriteLine("You have recharged 16 energy, which is the max energy you can recharge.");
                }
                else
                {
                    playerenergy += newenergy;
                    bool hitincrease = true;
                    Console.WriteLine("You have recharged" + newenergy + "energy");
                }
            }
            else
            {
                Console.WriteLine("You don't need to recharge.");
            }
        }

        // choice 4 - player
        if (playerchoice == dodge)
        {
            bool hitdecrease = true;
            Console.WriteLine("You are attempting to dodge. You will find out if its successful on the enemy's turn.");
            if (playerenergy < 49)
            {
                playerenergy += 2;
                Console.WriteLine("You have recharged 2 energy");
            }
            else
            {
                Console.WriteLine("You do not need to recharge");
            }
        }

        // choice 5 - player - half the energy to find max heal, heal energy until 50 is reached, allow second action
        if (playerchoice == heal)
        {
            if (playerhealth < 99)
            {
                playerenergy -= 10;

                
                
            }

        }
    }

}
