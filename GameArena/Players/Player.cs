using System;
using System.Collections.Generic;
using System.Text;

namespace GameArena
{
    internal class Player
    {
        protected string name;
        protected int health;
        protected int maxHealth;
        protected int damage;
        protected int defense;
        protected Dice dice;
        private string message;

        public Player(string name, int health, int damage, int defense, Dice dice)
        {
            this.name = name;
            this.health = health;
            this.maxHealth = health;
            this.damage = damage;
            this.defense = defense;
            this.dice = dice;
        }
        public override string ToString()
        {
            return name;
        }
        public bool Alive()
        {
            return (health > 0);
        }
        public string GraphicalBar(int current, int maximum)
        {
            string s = "";
            int total = 20;
            double count = Math.Round(((double)current / maximum) * total);
            if ((count == 0) && (Alive()))
                count = 1;
            for (int i = 0; i < count; i++)
                s += "█";
            s = s.PadRight(total);
            return s;
        }
        public string HealthBar()
        {
            return GraphicalBar(health, maxHealth);
        }
        public virtual void Attack(Player enemy)
        {
            int hit = damage + dice.Roll();
            SetMessage(String.Format("{0} attacks with {1} hp hit", name, hit));
            enemy.Defend(hit);
        }
        public void Defend(int hit)
        {
            int injury = hit - (defense + dice.Roll());
            if (injury > 0) // Injured
            {
                health -= injury;
                message = String.Format("{0} got an injury of {1} hp", name, injury);
                if (health <= 0)
                {
                    health = 0;
                    message += " and died";
                }
            }
            else // No damage taken
                message = String.Format("{0} parried a hit", name);
            SetMessage(message);
        }
        protected void SetMessage(string message)
        {
            this.message = message;
        }
        public string GetLastMessage()
        {
            return message;
        }
    }
}
