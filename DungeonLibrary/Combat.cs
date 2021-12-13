using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //This is not a datatype class. It is a warehouse of methods all related to a similar topic 

        public static void DoAttack(Character attacker, Character defender)
        {
            //get a random number from 1-100 as our dice roll
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(30);
            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //attacker hit the defender, calculate damage 
                int damageDealt = attacker.CalcDamage();

                //assign the damage to the defender
                defender.Life -= damageDealt;

                //write out to the screen the results
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damageDealt} damage!");
                Console.ResetColor();
            }
            else
            {
                //attacker missed
                Console.WriteLine($"{attacker.Name} missed!");
            }
        }

        public static void DoBattle(Player player, Monster monster)
        {
            //Player attack monster first
            DoAttack(player, monster);

            //Monster attack back, if they are alive.
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }
        }
    }
}
