using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraculasDungeon
{
    class Program
    {
        public static Player currentPlayer = new Player();
        
        static void Main(string[] args)
        {
            Start();
            Encounters.FirstEncounter();
        }

        static void Start()
        {
            Console.WriteLine("Dracula's Dungeon");
            Console.WriteLine("Name:");
            currentPlayer.name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You awake on a cold stone floor with no memory of the recent past");
            if (currentPlayer.name == "")
                Console.WriteLine("Even lack even the knowledge of your own name");
            else
                Console.WriteLine("You do remember your name, " + currentPlayer.name);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You trace your hand around the floor and walls until you find a door handle, with much effort " +
                "you are able to push the great iron slab open. Blinded by the light that floods your senses, you make out a dark shape " +
                "moving towards you, with what appears to be a weapon raised!");
        }
    }
}