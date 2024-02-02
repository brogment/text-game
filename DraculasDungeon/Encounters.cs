using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraculasDungeon
{
    class Encounters
    {
        static Random rand = new Random();
        //Encounter Generic
        
        //Encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("The humanoid figure charges you. You grab a bar of metal that broke off your prison door when you " +
                "busted it open, and prepare for battle.");
            Console.ReadKey();
            Combat(false, "Prison Guard", 1, 4);
        }
        //Encounter Tools

        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;

            if(random)
            {

            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while(h> 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine(p + "/" + h);
                Console.WriteLine("=====================");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("|   (R)un   (H)eal  |");
                Console.WriteLine("=====================");
                Console.WriteLine("Potions: " + Program.currentPlayer.potion + " Health: " + Program.currentPlayer.health);
                string input = Console.ReadLine();
                if(input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    //Attack
                    Console.WriteLine("You take an offensive stance. As you make your attack, the "
                        + n + "attempts a counter");
                    int damage = p - Program.currentPlayer.armorValue;
                    if(damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 4);
                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage.");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //Defend
                    Console.WriteLine("You decide to take a defense stance against the " + n + "'s incoming blow.");
                    int damage = (p/4) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue)/2;
                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage.");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    //Run
                    if(rand.Next(0,2) == 0)
                    {
                        Console.WriteLine("You trip as you try to sprint away from the " + n + " , allowing the " + " to land a blow");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You lose " + damage + " health");
                        Console.ReadKey();
                    } else
                    {
                        Console.WriteLine("Deciding it would be best to turn and run, you narrowly evade the " + "'s attack and successfully escape" );
                        Console.ReadKey();
                        //TODO: go to store
                    }
                    
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    //Heal TODO: Make it random if you get attacked or not while healing
                    if(Program.currentPlayer.potion == 0)
                    {
                        Console.WriteLine("You desperately feel around for your bag for a healing poition but to your great dismay there is only lint and empty wrappers.");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("While you were distracted the " + " is able to attack. You lose " + damage + " health.");
                    } else
                    {
                        Console.WriteLine("You pull out a coveted potion and gulp it down in a hurry.");
                        int potionV = 5;
                        Console.WriteLine("You gain " + potionV + " health");
                        Program.currentPlayer.health += potionV;

                        int damage = (p/2) - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("While you were distracted the " + " is able to attack. You lose " + damage + " health.");

                    }
                    Console.ReadKey();
                }
                Console.ReadKey();
            }
        }
    }
}
