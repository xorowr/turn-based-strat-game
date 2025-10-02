internal class Program
{
    private static void Main(string[] args)
    {
        // introduction to the game
        Console.WriteLine("Welcome to the battle of your lifetime!");
        Console.WriteLine("To win, you must defeat your opponent. Pretty easy, right?");
        Console.WriteLine("You have five actions you can pick from each turn. Some of these consume energy I'll explain what they are properly when we get there.");
        Console.WriteLine("Good luck out there. Or bad luck... Depends which side I'm on today.");
        Console.WriteLine();

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



    }
}