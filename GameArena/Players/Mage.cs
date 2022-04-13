using System;
using System.Collections.Generic;
using System.Text;

namespace GameArena
{
    internal class Mage : Player
    {
        private int mana;
        private int maxMana;
        private int magicDamage;

        public Mage(string name, int health, int damage, int defense, Dice dice, int mana, int magicDamage) : base(name, health, damage, defense, dice)
        {
            this.mana = mana;
            this.maxMana = mana;
            this.magicDamage = magicDamage;
        }
        public override void Attack(Player enemy)
        {
            // Mana is not full
            if (mana < maxMana)
            {
                mana += 10;
                if (mana > maxMana)
                    mana = maxMana;
                base.Attack(enemy);
            }
            else // Magic damage
            {
                Console.WriteLine("{0} choose your skills: 1 - fireball, 2 - iceball", name);
                int choose = int.Parse(Console.ReadLine());
                if(choose == 1)
                {
                    int hit = magicDamage + dice.Roll();
                    SetMessage(String.Format("{0} used fireball for {1} hp", name, hit));
                    enemy.Defend(hit);
                    mana = 0;
                }
                else if(choose == 2)
                {
                    int hit = magicDamage + dice.Roll() + dice.Roll();
                    SetMessage(String.Format("{0} used iceball for {1} hp", name, hit));
                    enemy.Defend(hit);
                    mana = 0;
                }
                else
                {
                    base.Attack(enemy);
                }
            }
        }
        public string ManaBar()
        {
            return GraphicalBar(mana, maxMana);
        }
    }
}
