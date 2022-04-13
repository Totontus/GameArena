using System;
using System.Collections.Generic;
using System.Text;

namespace GameArena.Players
{
    internal class Warrior : Player
    {
        private int stamina;
        private int maxStamina;
        private int rageDamage;

        public Warrior(string name, int health, int damage, int defense, Dice dice, int stamina, int rageDamage) : base(name, health, damage, defense, dice)
        {
            this.stamina = stamina;
            this.maxStamina = stamina;
            this.rageDamage = rageDamage;
        }
        public override void Attack(Player enemy)
        {
            // Stamina is not full
            if (stamina < maxStamina)
            {
                stamina += 10;
                if (stamina > maxStamina)
                    stamina = maxStamina;
                base.Attack(enemy);
            }
            else // Rage damage
            {
                int hit = rageDamage + dice.Roll();
                SetMessage(String.Format("{0} used Dragon's Breath for {1} hp", name, hit));
                enemy.Defend(hit);
                stamina = 0;
            }
        }
        public string StaminaBar()
        {
            return GraphicalBar(stamina, maxStamina);
        }
    }
}
