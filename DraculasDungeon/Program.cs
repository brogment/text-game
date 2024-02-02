﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DraculasDungeon
{
    public class Program
    {
        public static Random rand = new Random();
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }
            currentPlayer = Load(out bool newP);
            if (newP)
            {
                Encounters.FirstEncounter();
            }
            while (mainLoop)
            {
                Encounters.RandomEncounter();
            }

        }

        static Player NewStart(int i)
        {
            Console.Clear();
            Player p = new Player();
            Console.WriteLine("Dracula's Dungeon");
            Console.WriteLine("Name:");
            p.name = Console.ReadLine();
            p.id = i;
            Console.Clear();
            Console.WriteLine("You awake on a cold stone floor with no memory of the recent past");
            if (p.name == "")
                Console.WriteLine("Even lack even the knowledge of your own name");
            else
                Console.WriteLine("You do remember your name, " + p.name);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You trace your hand around the floor and walls until you find a door handle, with much effort " +
                "you are able to push the great iron slab open. Blinded by the light that floods your senses, you make out a dark shape " +
                "moving towards you, with what appears to be a weapon raised!");
            return p;
        }

        public static void Quit()
        {
            Save();
            Environment.Exit(0);
        }

        public static void Save()
        {
            BinaryFormatter binForm = new BinaryFormatter();
            string path = "saves/" + currentPlayer.id.ToString() + ".level";
            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            binForm.Serialize(file, currentPlayer);
            file.Close();
        }

        public static Player Load(out bool newP)
        {
            newP = false;
            Console.Clear();
            string[] paths = Directory.GetFiles("saves");
            List<Player> players = new List<Player>();
            int idCount = 0;

            BinaryFormatter binForm = new BinaryFormatter();
            foreach (string p in paths)
            {
                FileStream file = File.Open(p, FileMode.Open);
                Player player = (Player)binForm.Deserialize(file);
                file.Close();
                players.Add(player);
            }

            idCount = players.Count;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose your save:");

                foreach (Player p in players)
                {
                    Console.WriteLine(p.id + ": " + p.name);
                }
                
                Console.WriteLine("Please input player name or id (id:# or playername). Type 'create' to start a new save.");
                string[] data = Console.ReadLine().Split(':');

                try
                {
                    if(data[0] == "id")
                    {
                        if (int.TryParse(data[1], out int id))
                        {
                            foreach(Player player in players)
                            {
                                if(player.id == id)
                                {
                                    return player; 
                                }
                            }
                            Console.WriteLine("There is no playe with that id.");
                            Console.ReadKey();
                        } 
                        else
                        {
                            Console.WriteLine("Your id needs to be a number. Press any key to continue");
                            Console.ReadKey();
                        }
                    }
                    else if (data[0] == "create")
                    {
                        Player newPlayer = NewStart(idCount);
                        newP = true;
                        return newPlayer;
                    }
                    else 
                    { 
                        foreach (Player player in players)
                        {
                            if(player.name== data[0])
                            {
                                return player;
                            }
                        }
                        Console.WriteLine("There is no player with that name.");
                        Console.ReadKey();
                    }

                }
                catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("Your id needs to be a number. Press any key to continue");
                    Console.ReadKey();
                }

            }
            
        }

    }
}