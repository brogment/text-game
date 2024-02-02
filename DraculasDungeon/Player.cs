using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraculasDungeon
{
    public class Player
    {

        Random rand = new Random();

        public string name;
        public int coins = 0;
        public int health = 10;
        public int damage = 1;
        public int armorValue = 0;
        public int potion = 5;
        public int weaponValue = 1;

        public int difficulty = 0;

        public int GetHealth()
        {
            int upper = (2 * difficulty  + 5);
            int lower = (    difficulty + 2);
            return rand.Next(lower, upper);
        }

        public int GetPower()
        {
            int upper = (2 * difficulty + 3);
            int lower = (difficulty + 1);
            return rand.Next(lower, upper);
        }

        public int GetCoins()
        {
            int upper = (10 * difficulty + 50);
            int lower = (10 * difficulty + 1);
            return rand.Next(lower, upper);
        }
    }
}
