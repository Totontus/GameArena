using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using GameArena.Players;

namespace GameArena
{
    internal class Arena
    {
        private Player player1;
        private Player player2;
        private Dice dice;

        public Arena(Player player1, Player player2, Dice dice)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.dice = dice;
        }

        private void PrintPlayer(Player w)
        {
            Console.WriteLine(w);
            Console.Write("Health: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(w.HealthBar());
            Console.ResetColor();
            if (w is Mage)
            {
                Console.Write("Mana:   ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(((Mage)w).ManaBar());
                Console.ResetColor();
            }
            else if (w is Warrior)
            {
                Console.Write("Stamina:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(((Warrior)w).StaminaBar());
                Console.ResetColor();
            }
        }
        private void Render()
        {
            Console.Clear();
            Console.WriteLine(@"
                         _____    ______   _   _            
                 /\     |  __ \  |  ____| | \ | |     /\    
                /  \    | |__) | | |__    |  \| |    /  \   
               / /\ \   |  _  /  |  __|   | . ` |   / /\ \  
              / ____ \  | | \ \  | |____  | |\  |  / ____ \ 
             /_/    \_\ |_|  \_\ |______| |_| \_| /_/    \_\");
            Console.WriteLine("Players: \n");
            PrintPlayer(player1);
            Console.WriteLine();
            PrintPlayer(player2);
            Console.WriteLine();
        }
        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(500);
        }
        public void Fight()
        {
            Player w1 = player1;
            Player w2 = player2;
            Console.WriteLine("Welcome to Arena!");
            Console.WriteLine("Today {0} will fight with {1}! \n", player1, player2);
            bool warrior2Starts = (dice.Roll() <= dice.GetSidesCount() / 2);
            if (warrior2Starts)
            {
                w1 = player2;
                w2 = player1;
            }
            Console.WriteLine("The fighter {0} begins! \nLet the battle begin...", w1);
            Console.ReadKey();
            // fight loop
            while (w1.Alive() && w2.Alive())
            {
                w1.Attack(w2);
                Render();
                PrintMessage(w1.GetLastMessage()); // message about the attack
                PrintMessage(w2.GetLastMessage()); // message about the defense
                Console.ReadKey();
                if (w2.Alive())
                {
                    w2.Attack(w1);
                    Render();
                    PrintMessage(w2.GetLastMessage()); // message about the attack
                    PrintMessage(w1.GetLastMessage()); // message about the defense
                    Console.ReadKey();
                }
                Console.WriteLine();
            }
        }
    }
}
