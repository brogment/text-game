using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraculasDungeon
{
    public class PocketPlane
    {
        public static void LoadShop(Player p)
        {
            RunShop(p);
        }
        public static void RunShop(Player p)
        {
            int potionP;
            int armorP;
            int weaponP;
            int difP;
            while (true)
            {
                potionP = 20 + 10 * p.difficulty;
                armorP = 100 * (p.armorValue + 1);
                weaponP = 100 * p.weaponValue;
                difP = 0;
                Console.Clear();
                Console.WriteLine("              Shop           ");
                Console.WriteLine("=============================");
                Console.WriteLine("(W)eapon Upgrade     : $" + weaponP);
                Console.WriteLine("(A)rmor Upgrade      : $" + armorP);
                Console.WriteLine("(P)otions            : $" + potionP);
                Console.WriteLine("(D)ifficulty Changer : $" + difP);
                Console.WriteLine("=============================");
                Console.WriteLine("(E)xit Shop");
                Console.WriteLine("(Q)uit Game");



                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(p.name + "'s Stats");
                Console.WriteLine("=============================");
                Console.WriteLine("Coins:            " + p.coins);
                Console.WriteLine("Current Health:   " + p.health);
                Console.WriteLine("Weapon Strength:  " + p.weaponValue);
                Console.WriteLine("Armor Strength:   " + p.armorValue);
                Console.WriteLine("Potion Count:     " + p.potion);
                Console.WriteLine("Difficulty Level: " + p.difficulty);
                Console.WriteLine("=============================");

                //wait for input
                string input = Console.ReadLine().ToLower();
                if (input == "p")
                {
                    TryBuy("potion", potionP, p);
                }
                else if (input == "w")
                {
                    TryBuy("weapon", weaponP, p);
                }
                else if (input == "a")
                {
                    TryBuy("armor", armorP, p);
                }
                else if (input == "d")
                {
                    TryBuy("dif", difP, p);
                }
                else if(input == "q")
                {
                    Program.Quit();
                }
                else if (input == "e")
                    break;
            }
            
            static void TryBuy(string item, int cost, Player p)
            {
                if(p.coins >= cost)
                {
                    if (item == "potion")
                        p.potion++;
                    else if (item == "weapon")
                        p.weaponValue++;
                    else if (item == "armor")
                        p.armorValue++;
                    else if (item == "dif")
                        p.difficulty++;

                    p.coins -= cost;
                } 
                else
                {
                    Console.WriteLine("You do not have enough coins to purchase that item.");
                    Console.ReadKey();
                }
            }

        }
    }
}
