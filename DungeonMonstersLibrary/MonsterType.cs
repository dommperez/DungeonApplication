using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace DungeonMonstersLibrary
{
    public class MonsterType : Monster
    {
        //properties
        public bool IsAngry { get; set; }

        //ctor
        //FQ Ctor
        public MonsterType(string name, int life, int maxLife, int hitChance, int block, int minDamge, int maxDamage, string description, bool isAngry) : base(name, life, maxLife, hitChance, block, maxDamage, description, minDamge)
        {
            IsAngry = isAngry;
        }

        //we will make a custom default ctor - it will accept NO parameters but it will set some default values in the body of the method
        public MonsterType()
        {
            //default values
            MaxLife = 10;
            MaxDamage = 2;
            Name = "Troll";
            Life = 6;
            HitChance = 25;
            Block = 5;
            MinDamage = 1;
            Description = "A hairy, apelike huminoid with black fur and faces that comprise elements of pigs and rodents";
            IsAngry = false;
        }

        //methods
        public override string ToString()
        {
            return base.ToString() + (IsAngry ? "Angry" : "He doesn't look too angry");
        }

        public override int CalcHitChance()
        {
            //We will use is angry to determine if the monster gets a boost to their block ability
            int calculatedHitChance = HitChance;

            if (IsAngry)
            {
                calculatedHitChance += calculatedHitChance / 2; //this gives the monster a 50% boost if they are angry
            }

            return calculatedHitChance;
        }
    }
}
