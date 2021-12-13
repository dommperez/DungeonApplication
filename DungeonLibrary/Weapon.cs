using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        //field 
        private int _minDamage;

        //property
        public int MaxDamage { get; set; }
        public string Name { get; set; }
        public int BonusHitChance { get; set; }
        public bool IsTwoHanded { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //minDamage cant be more than maxDamage and cannot be less than 1
                if (value > 0 && value <= MaxDamage)
                {
                    //less than max and more than 1 - good to go
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }//end of property


        //ctor 
        //only creating the FQ ctor because we dont want to allow for creating a weapon with empty values (default ctor)
        public Weapon(int maxDamage, string name, int bonusHitChance, bool isTwoHanded, int minDamage)
        {
            //The order in which you do the assignments below doesnt matter unless you have a biz rule that compares one prop to another (minDamage)
            //You have to assign a value to the prop used in the comparison (maxDamage) first so taht you ar enot comparing against a null value

            MaxDamage = maxDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
            MinDamage = minDamage;
        }

        //methods
        public override string ToString()
        {
            return string.Format($"{Name}\t{MinDamage} to {MaxDamage}\nBonus Hit: {BonusHitChance}%\nIs Two Handed? {(IsTwoHanded ? "Yes" : "No")}");
        }
    }

}
