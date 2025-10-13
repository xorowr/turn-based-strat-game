
using System.Diagnostics;
using System.Security.Authentication;

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

    static void ChoicesNoHeal()
    {
        Console.WriteLine("Time to make your move! Enter the number that corresponds to the move you would like to do.");
        Console.WriteLine("[1] Attack - Standard strike on the enemy. - 1-10 damage and 80% chance to hit - Costs 5 energy");
        Console.WriteLine("[2] Special Attack - A special attack - 5-20 damage and 50% chance to hit - Costs 10 energy.");
        Console.WriteLine("[3] Recharge - Recharges energy at 4 times the normal rate. Increase the chance you'll be hit by 20%. No energy is used.");
        Console.WriteLine("[4] Dodge - Dodges the enemy's attack. Decrease enemy's chance of hitting by 30%. Recharges only 2 energy.");

    }


    static void HealthEnergyStats(int playerhealth, int playerenergy, int enemyhealth, int enemyenergy)
    {
        Console.WriteLine("Your health: " + playerhealth + "/100");
        Console.WriteLine("Your energy: " + playerenergy + "/50");
        Console.WriteLine("Enemey's health: " + enemyhealth + "/100");
        Console.WriteLine("Enemy's energy " + enemyenergy + "/50");
    }


    private static void Main(string[] args)
    {
        // constants for various areas of the code
        const string attack = "1";
        const string specialattack = "2";
        const string recharge = "3";
        const string dodge = "4";
        const string heal = "5";

        const int healththresh = 99;
        const int energythresh = 49;
        const int passdodgeattack = 6;
        const int passattack = 9;
        const int turnrecharge = 4;
        const int passspecialattack = 6;
        const int passspecialdodgeattack = 3;
        const int passrechargeattack = 10;
        const int passrechargespecialattack = 7;
        const int energycheck = 9;
        const int maxhealth = 100;
        const int maxenergy = 50;
        const int maxrecharge = 16;
        const int attackenergy = 5;
        const int othermoveenergy = 10;
        const int minenergyneed = 4;
        const int maxenergyrecharge = 35;
        const int halfrecharge = 2;
        const int minattackdamage = 1;
        const int maxattackdamage = 10;
        const int minspecialattackdamage = 5;
        const int maxspecialattackdamage = 20;



        // variables
        int playerhealth = maxhealth;
        int playerenergy = maxenergy;
        int enemyhealth = maxhealth;
        int enemyenergy = maxenergy;
        bool pturnsuccess = false;
        bool eturnsuccess = false;




        // introduction to the game
        Console.WriteLine("Welcome to the battle of your lifetime!");
        Console.WriteLine("To win, you must defeat your opponent. Pretty easy, right?");
        Console.WriteLine("You have five actions you can pick from each turn. Some of these consume energy. You recharge 4 points of energy each turn. I'll explain what they are properly when we get there.");
        Console.WriteLine("Good luck out there. Or bad luck... Depends which side I'm on today.");
        Console.WriteLine();


        Console.WriteLine("Before I forget, here are the current stats of you and the enemy.");
        HealthEnergyStats(playerhealth, playerenergy, enemyhealth, enemyenergy);

        Console.WriteLine("Right! I think that's everything. Are you ready? Not that I care or anything...");
        Console.ReadLine();
        Console.WriteLine("I don't actually care. I'm asking to be nice. Anyway, let's get this show on the road!");
        Console.WriteLine();

        Random roll = new Random();


        while (playerhealth > 0 && enemyhealth !> 0 || playerhealth !> 0 && enemyhealth > 0)
        {
            choices();
            string playerchoice = Console.ReadLine();

            int enemyroll = roll.Next(1, 5);
            string enemychoice = Convert.ToString(enemyroll);

            // continues choice selection until a turn has been successfully made
            while (pturnsuccess == false)
            {
                // choice 1 (attack) - player
                if (playerchoice == attack && playerenergy > minenergyneed)
                {
                    playerenergy -= attackenergy;
                    int chance = roll.Next(1, 10);
                    if (enemychoice == dodge)
                    {
                        if (chance < passdodgeattack)
                        {
                            int damage = roll.Next(minattackdamage, maxattackdamage);
                            Console.WriteLine("Your attack was successful. You dealt " + damage + " damage");
                            enemyhealth -= damage;
                            playerenergy += turnrecharge;
                            pturnsuccess = true;
                        }
                        else
                        {
                            Console.WriteLine("Your attack has failed! The enemy's dodge was successful.");
                            playerenergy += turnrecharge;
                            pturnsuccess = true;
                        }
                    }
                    if (chance < passattack && enemychoice != dodge)
                    {
                        int damage = roll.Next(minattackdamage, maxattackdamage);
                        Console.WriteLine("Your attack was successful. You dealt " + damage + " damage");
                        enemyhealth -= damage;
                        playerenergy += turnrecharge;
                        pturnsuccess = true;
                    }
                    else if (chance <= passrechargeattack && enemychoice == recharge)
                    {
                        int damage = roll.Next(minattackdamage, maxattackdamage);
                        Console.WriteLine("Your attack was successful. You dealt " + damage + " damage");
                        enemyhealth -= damage;
                        playerenergy += turnrecharge;
                        pturnsuccess = true;
                    }
                    else if (chance !<= passrechargeattack && enemychoice == recharge)
                    {
                        Console.WriteLine("Your attack has failed!");
                        playerenergy += turnrecharge;
                        pturnsuccess = true;
                    }
                }
                else if (playerchoice == attack && playerenergy <= minenergyneed)
                {
                    Console.WriteLine("You do not have enough energy for this move. Pick a new move");
                    choices();
                    playerchoice = Console.ReadLine();
                    pturnsuccess = false;
                }



                // choice 2 (special attack) - player
                if (playerchoice == specialattack && playerenergy > energycheck)
                {
                    playerenergy -= othermoveenergy;
                    int chance = roll.Next(1, 10);
                    if (enemychoice == dodge)
                    {
                        if (chance < passspecialdodgeattack)
                        {
                            int damage = roll.Next(minspecialattackdamage, maxspecialattackdamage);
                            Console.WriteLine("Your attack was successful. You dealt " + damage + " damage");
                            enemyhealth -= damage;
                            playerenergy += turnrecharge;
                            pturnsuccess = true;
                        }
                        else
                        {
                            Console.WriteLine("Your attack has failed! The enemy's dodge was successful.");
                            playerenergy += turnrecharge;
                            pturnsuccess = true;
                        }
                    }
                    if (chance < passspecialattack && enemychoice != dodge)
                    {
                        int damage = roll.Next(minspecialattackdamage, maxspecialattackdamage);
                        Console.WriteLine("Your attack was successful. You dealt " + damage + " damage");
                        enemyhealth -= damage;
                        playerenergy += turnrecharge;
                        pturnsuccess = true;
                    }
                    else if (chance <= passrechargespecialattack && enemychoice == recharge)
                    {
                        int damage = roll.Next(minspecialattackdamage, maxspecialattackdamage);
                        Console.WriteLine("Your attack was successful. You dealt " + damage + " damage");
                        enemyhealth -= damage;
                        playerenergy += turnrecharge;
                        pturnsuccess = true;
                    }
                    else if (chance !<= passrechargespecialattack && enemychoice == recharge)
                    {
                        Console.WriteLine("Your attack has failed.");
                        playerenergy += turnrecharge;
                        pturnsuccess = true;
                    }

                }
                else if (playerchoice == specialattack && playerenergy <= energycheck)
                {
                    Console.WriteLine("You do not have enough energy for this move. Pick a new move");
                    choices();
                    playerchoice = Console.ReadLine();
                    pturnsuccess = false;
                }


                // choice 3 (recharge) - player
                if (playerchoice == recharge)
                {
                    if (playerenergy < maxenergy)
                    {
                        int newenergy = maxenergy - playerenergy;
                        if (playerenergy < maxenergyrecharge)
                        {
                            playerenergy += maxrecharge;
                            bool hitincrease = true;
                            Console.WriteLine("You have recharged 16 energy, which is the max energy you can recharge.");
                            pturnsuccess = true;
                        }
                        else
                        {
                            playerenergy += newenergy;
                            bool hitincrease = true;
                            Console.WriteLine("You have recharged " + newenergy + " energy");
                            pturnsuccess = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You don't need to recharge.");
                        choices();
                        playerchoice = Console.ReadLine();
                        pturnsuccess = false;
                    }
                }



                // choice 4 (dodge) - player
                if (playerchoice == dodge)
                {
                    bool hitdecrease = true;
                    Console.WriteLine("You are attempting to dodge. You will find out if its successful on the enemy's turn.");
                    if (playerenergy < energythresh)
                    {
                        playerenergy += halfrecharge;
                        Console.WriteLine("You have recharged 2 energy");
                        pturnsuccess = true;
                    }
                    else
                    {
                        Console.WriteLine("You do not need to recharge");
                        pturnsuccess = true;
                    }
                }



                // choice 5 (heal) - player
                if (playerchoice == heal)
                {
                    if (playerhealth < healththresh && playerenergy > energycheck)
                    {
                        playerenergy -= othermoveenergy;
                        int halfstored = playerenergy / 2;
                        int healamount = maxhealth - playerhealth;
                        playerhealth += healamount;
                        int addenergy = halfstored - healamount;
                        playerenergy = (playerenergy - halfstored) + addenergy;
                        Console.WriteLine("You have healed " + healamount + " health");
                        Console.WriteLine("You can now pick to do another move. It cannot be another heal");
                        ChoicesNoHeal();
                        playerchoice = Console.ReadLine();
                        pturnsuccess = false;

                    }
                    else
                    {
                        Console.WriteLine("You either cannot or do not need to heal. You can pick to do a new action.");
                        choices();
                        playerchoice = Console.ReadLine();
                        pturnsuccess = false;

                    }

                }

                // errors out with any invalid input
                if (playerchoice != attack && playerchoice != specialattack && playerchoice != recharge && playerchoice != dodge && playerchoice != heal)
                {
                    Console.WriteLine("Your input was invalid. Please pick a new input.");
                    choices();
                    playerchoice = Console.ReadLine();
                    pturnsuccess = false;
                }


            }

            // turn summary
            Console.WriteLine("After your turn, here are the stats of you and the enemy:");
            HealthEnergyStats(playerhealth, playerenergy, enemyhealth, enemyenergy);
            Console.WriteLine();
            eturnsuccess = false;

            // rerolls if it lands on a recharge when a recharge is not needed
            while (enemychoice == recharge && enemyenergy >= maxenergyrecharge)
            {
                enemyroll = roll.Next(1, 5);
                enemychoice = Convert.ToString(enemyroll);
            }


            while (eturnsuccess == false)
            {

                // choice 1 - enemy
                if (enemychoice == attack && enemyenergy > minenergyneed)
                {
                    enemyenergy -= attackenergy;
                    int chance = roll.Next(1, 10);
                    if (playerchoice == dodge)
                    {
                        if (chance < passdodgeattack)
                        {
                            int damage = roll.Next(minattackdamage, maxattackdamage);
                            Console.WriteLine("The enemy's attack was successful. They dealt " + damage + " damage");
                            playerhealth -= damage;
                            enemyenergy += turnrecharge;
                            eturnsuccess = true;
                        }
                        else
                        {
                            Console.WriteLine("The enemy's attack has failed! Your dodge was succesful.");
                            enemyenergy += turnrecharge;
                            eturnsuccess = true;
                        }
                    }
                    if (chance < passattack && playerchoice != dodge)
                    {
                        int damage = roll.Next(minattackdamage, maxattackdamage);
                        Console.WriteLine("The enemy's attack was successful. They dealt " + damage + " damage");
                        playerhealth -= damage;
                        enemyenergy += turnrecharge;
                        eturnsuccess = true;
                    }
                    else if (chance <= 10 && playerchoice == recharge)
                    {
                        int damage = roll.Next(minattackdamage, maxattackdamage);
                        Console.WriteLine("The enemy's attack was successful. They dealt " + damage + " damage");
                        enemyhealth -= damage;
                        playerenergy += turnrecharge;
                        eturnsuccess = true;
                    }
                    else
                    {
                        Console.WriteLine("The enemy's attack has failed!");
                        enemyenergy += turnrecharge;
                        eturnsuccess = true;
                    }
                }

                // choice 2 - enemy
                if (enemychoice == specialattack && enemyenergy > energycheck)
                {
                    enemyenergy -= othermoveenergy;
                    int chance = roll.Next(1, 10);
                    if (playerchoice == dodge)
                    {
                        if (chance < passspecialdodgeattack)
                        {
                            int damage = roll.Next(minspecialattackdamage, maxspecialattackdamage);
                            Console.WriteLine("The enemy's attack was successful. They dealt " + damage + " damage");
                            playerhealth -= damage;
                            enemyenergy += turnrecharge;
                            eturnsuccess = true;
                        }
                        else
                        {
                            Console.WriteLine("The enemy's attack has failed! Your dodge was successful.");
                            enemyenergy += turnrecharge;
                            eturnsuccess = true;
                        }
                    }
                    if (chance < passspecialattack && playerchoice != dodge)
                    {
                        int damage = roll.Next(minspecialattackdamage, maxspecialattackdamage);
                        Console.WriteLine("The enemy's attack was successful. They dealt " + damage + " damage");
                        playerhealth -= damage;
                        enemyenergy += turnrecharge;
                        eturnsuccess = true;
                    }
                    else if (chance <= 7 && playerchoice == recharge)
                    {
                        int damage = roll.Next(minspecialattackdamage, maxspecialattackdamage);
                        Console.WriteLine("The enemy's attack was successful. They dealt " + damage + " damage");
                        playerhealth -= damage;
                        enemyenergy += turnrecharge;
                        eturnsuccess = true;
                    }
                    else
                    {
                        Console.WriteLine("The enemy's attack has failed.");
                        enemyenergy += turnrecharge;
                        eturnsuccess = true;
                    }

                }


                // choice 3 - enemy
                if (enemychoice == recharge)
                {
                    if (enemyenergy < maxenergy)
                    {
                        int newenergy = maxenergy - enemyenergy;
                        if (enemyenergy < maxenergyrecharge)
                        {
                            enemyenergy += maxrecharge;
                            bool hitincrease = true;
                            Console.WriteLine("The enemy has recharged 16 energy, which is the max energy they can recharge.");
                            pturnsuccess = true;
                        }
                        else
                        {
                            enemyenergy += newenergy;
                            bool hitincrease = true;
                            Console.WriteLine("The enemy has recharged " + newenergy + " energy");
                            pturnsuccess = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The enemy doesn't need to recharge.");
                        enemyroll = roll.Next(1, 5);
                        enemychoice = Convert.ToString(enemyroll);
                        pturnsuccess = false;
                    }
                }



                // choice 4 = enemy
                if (enemychoice == dodge)
                {
                    bool hitdecrease = true;
                    Console.WriteLine("The enemy is attempting to dodge. They will find out if its successful on the player's turn.");
                    if (enemyenergy < energythresh)
                    {
                        enemyenergy += halfrecharge;
                        Console.WriteLine("The enemy has recharged 2 energy");
                        eturnsuccess = true;
                    }
                    else
                    {
                        Console.WriteLine("The enemy does not need to recharge");
                        eturnsuccess = true;
                    }
                }


                // choice 5 - enemy
                if (enemychoice == heal)
                {
                    if (enemyhealth < healththresh && enemyenergy > energycheck)
                    {
                        enemyenergy -= othermoveenergy;
                        int halfstored = enemyenergy / 2;
                        int healamount = maxhealth - enemyhealth;
                        enemyhealth += healamount;
                        int addenergy = halfstored - healamount;
                        enemyenergy = (enemyenergy - halfstored) + addenergy;
                        Console.WriteLine("You have healed " + healamount + " health");
                        Console.WriteLine("You can now pick to do another move. It cannot be another heal");
                        ChoicesNoHeal();
                        playerchoice = Console.ReadLine();
                        eturnsuccess = false;

                    }
                    else
                    {
                        Console.WriteLine("The enemy cannot or does not need to heal. They can pick to do a new action.");
                        enemyroll = roll.Next(1, 5);
                        enemychoice = Convert.ToString(enemyroll);
                        eturnsuccess = false;

                    }

                }
                // turn summary
                Console.WriteLine("After the enemy's turn, here are the stats of you and the enemy:");
                HealthEnergyStats(playerhealth, playerenergy, enemyhealth, enemyenergy);
                Console.WriteLine();
                pturnsuccess = false;

            }

        }
        Console.WriteLine("Game over!");
        if (playerhealth <=0)
        {
            Console.WriteLine("The enemy has won. You lose.");
        }
        else
        {
            Console.WriteLine("You have won! Congrats");
        }
    }
}

