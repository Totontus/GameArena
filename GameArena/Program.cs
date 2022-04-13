using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameArena.Players;

namespace GameArena
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // creating objects
            Dice dice = new Dice(10);
            Player dragon = new Warrior("Dragon", 200, 30, 5, dice, 50, 60);
            Player yarman = new Mage("Yarman", 150, 15, 20, dice, 30, 50);

            Arena arena = new Arena(yarman, dragon, dice);
            // fight
            arena.Fight();
            Console.ReadKey();
        }
    }
}
