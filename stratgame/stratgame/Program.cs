using System.Diagnostics;

internal class Program
{

    static void choices()
    {
        Console.WriteLine("Time to make your move! Enter the number that corresponds to the move you would like to do.");
        Console.WriteLine("[1] Attack - Standard strike on the enemy. - 1-10 damage and 80% chance to hit - Costs 5 energy");
        Console.WriteLine("[2] Special Attack - A special attack - 5-20 damage and 50% chance to hit - Costs 10 energy.");
        Console.WriteLine("[3] Recharge - Recharges energy at 4 times the normal rate. Increase the chance you'll be hit by 20%. No energy is used.");
        Console.WriteLine("[4] Dodge - Dodges the enemy's attack. Decrease enemy's chance of hitting by 30%. Recharges only 2 energy.");
        Console.WriteLine("[5] Heal - Can convert up to half of the stored energy into health. This can be used alongsie another action. Costs 10 energy.");

    }




    private static void Main(string[] args)
    {
        // introduction to the game
        Console.WriteLine("Welcome to the battle of your lifetime!");
        Console.WriteLine("To win, you must defeat your opponent. Pretty easy, right?");
        Console.WriteLine("You have five actions you can pick from each turn. Some of these consume energy. You recharge 4 points of energy each turn. I'll explain what they are properly when we get there.");
        Console.WriteLine("Good luck out there. Or bad luck... Depends which side I'm on today.");
        Console.WriteLine();

        // constants for various areas of the code
        const string attack = "1";
        const string specialattack = "2";
        const string recharge = "3";
        const string dodge = "4";
        const string heal = "5";
        const int healththresh = 99;
        const int energythresh = 49;
        const int pdodgeattack = 6;
        const int pattack = 9;
        const int turnrecharge = 4;
        const int pspecattack = 6;
        const int pspecdodgeattack = 3;
        const int energycheck = 9;
        const int maxhealth = 100;
        const int maxenergy = 50;


        // variables
        int playerhealth = 100;
        int playerenergy = 50;
        int enemyhealth = 100;
        int enemyenergy = 50;
        bool turnsuccess = false;

        Console.WriteLine("Before I forget, here are the current stats of you and the enemy.");
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
        choices();
        string playerchoice = Console.ReadLine();

        int firstchoice = roll.Next(1, 5);
        while (firstchoice == 3 && enemyenergy! < 35)
        {
            firstchoice = roll.Next(1, 5);
        }

        // continues choice selection until a turn has been successfully made
        while (turnsuccess == false)
        {
            // choice 1 - player
            if (playerchoice == attack && playerenergy > 4)
            {
                playerenergy -= 5;
                int chance = roll.Next(1, 10);
                if (firstchoice == 4)
                {
                    if (chance < pdodgeattack)
                    {
                        int damage = roll.Next(1, 10);
                        Console.WriteLine("Your attack was successful. You dealt " + damage + " damage");
                        enemyhealth -= damage;
                        playerenergy += turnrecharge;
                        turnsuccess = true;
                    }
                    else
                    {
                        Console.WriteLine("Your attack has failed!");
                        playerenergy += turnrecharge;
                        turnsuccess = true;
                    }
                }
                if (chance < pattack)
                {
                    int damage = roll.Next(1, 10);
                    Console.WriteLine("Your attack was successful. You dealt " + damage + " damage");
                    enemyhealth -= damage;
                    playerenergy += turnrecharge;
                    turnsuccess = true;
                }
                else
                {
                    Console.WriteLine("Your attack has failed!");
                    playerenergy += turnrecharge;
                    turnsuccess = true;
                }
            }
            else if (playerchoice == attack && playerenergy < 5)
            {
                Console.WriteLine("You do not have enough energy for this move. Pick a new move");
                choices();
                playerchoice = Console.ReadLine();
                turnsuccess = false;
            }



            // choice 2 - player
            if (playerchoice == specialattack && playerenergy > energycheck)
            {
                playerenergy -= 10;
                int chance = roll.Next(1, 10);
                if (firstchoice == 4)
                {
                    if (chance < pspecdodgeattack)
                    {
                        int damage = roll.Next(1, 10);
                        Console.WriteLine("Your attack was successful. You dealt " + damage + " damage");
                        enemyhealth -= damage;
                        playerenergy += turnrecharge;
                        turnsuccess = true;
                    }
                    else
                    {
                        Console.WriteLine("Your attack has failed!");
                        playerenergy += turnrecharge;
                        turnsuccess = true;
                    }
                }
                if (chance < pspecattack)
                {
                    int damage = roll.Next(1, 10);
                    Console.WriteLine("Your attack was successful. You dealt " + damage + " damage");
                    enemyhealth -= damage;
                    playerenergy += turnrecharge;
                    turnsuccess = true;
                }
                else
                {
                    Console.WriteLine("Your attack has failed.");
                    playerenergy += turnrecharge;
                    turnsuccess = true;
                }

            }
            else if (playerchoice == specialattack && playerenergy <= energycheck)
            {
                Console.WriteLine("You do not have enough energy for this move. Pick a new move");
                choices();
                playerchoice = Console.ReadLine();
                turnsuccess = false;
            }


            // choice 3 - player
            if (playerchoice == recharge)
            {
                if (playerenergy < maxenergy)
                {
                    int newenergy = maxenergy - playerenergy;
                    if (playerenergy < 35)
                    {
                        playerenergy += 16;
                        bool hitincrease = true;
                        Console.WriteLine("You have recharged 16 energy, which is the max energy you can recharge.");
                        turnsuccess = true;
                    }
                    else
                    {
                        playerenergy += newenergy;
                        bool hitincrease = true;
                        Console.WriteLine("You have recharged " + newenergy + " energy");
                        turnsuccess = true;
                    }
                }
                else
                {
                    Console.WriteLine("You don't need to recharge.");
                    choices();
                    playerchoice = Console.ReadLine();
                    turnsuccess = false;
                }
            }



            // choice 4 - player
            if (playerchoice == dodge)
            {
                bool hitdecrease = true;
                Console.WriteLine("You are attempting to dodge. You will find out if its successful on the enemy's turn.");
                if (playerenergy < energythresh)
                {
                    playerenergy += 2;
                    Console.WriteLine("You have recharged 2 energy");
                    turnsuccess = true;
                }
                else
                {
                    Console.WriteLine("You do not need to recharge");
                    turnsuccess = true;
                }
            }



            // choice 5 - player - half the energy to find max heal, heal energy until 50 is reached, allow second action
            if (playerchoice == heal)
            {
                if (playerhealth < healththresh && playerenergy > energycheck)
                {
                    playerenergy -= 10;
                    int halfstored = playerenergy / 2;
                    int healamount = maxhealth - playerhealth;
                    playerhealth += healamount;
                    int addenergy = halfstored - healamount;
                    playerenergy = (playerenergy - halfstored) + addenergy;
                    Console.WriteLine("You have healed " + healamount + " health");

                }
                else
                {
                    Console.WriteLine("You either cannot or do not need to heal. You can pick to do a new action.");
                    choices();
                    playerchoice = Console.ReadLine();
                    turnsuccess = false;

                }

            }
        }
        Console.WriteLine("After your turn, here are the stats of you and the enemy:");



    }
}
