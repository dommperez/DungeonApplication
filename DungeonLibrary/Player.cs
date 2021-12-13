using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
        //The sealed keyword means that this is the end of the inheritance chain. It is now impossible to setup a child of Player.
        public sealed class Player : Character 
        {
            //fields
            //No fields because the info specific to Player does not need biz rules

            //properties 
            public Race CharacterRace { get; set; }
            //We need our player to have a weapon. I want this weapon to be made up of many attributes (i.e. kind, is two handed, etc) so i need to 
            //make a custom data type class for weapon
            public Weapon EquippedWeapon { get; set; }

            //ctors
            public Player(string name, int hitChance, int block, int life, int maxLife, Race characterRace, Weapon equippedWeapon)
            {
                //Since life depends on MaxLife we will set a value for MaxLife first
                MaxLife = maxLife;
                Name = name;
                HitChance = hitChance;
                Block = block;
                Life = life;
                CharacterRace = characterRace;
                EquippedWeapon = equippedWeapon;

                switch (CharacterRace)
                {
                    case Race.Human:
                    HitChance += 5;
                        break;
                    case Race.Elf:
                    Life += 15;
                        break;
                    case Race.Dwarf:
                    HitChance += 10;
                        break;
                }
            }


            //methods
            public override string ToString()
            {
                string description = "";

                switch (CharacterRace)
                {
                    case Race.Human:
                        description = "Human: One of the primary inhabitants of the Physical World, and one of the most dominant lifeforms on Earth. They are comprised of " +
                        "unique classes of individuals, such as warriors, aristocrats, clergy, mages, and even post-human apostles.";
                        break;
                    case Race.Elf:
                        description = "Elf: Astral beings which hail from the kingdom of Elfhelm, the domain of the Flower Storm Monarch.";
                        break;
                    case Race.Dwarf:
                        description = "Dwarf: A race of short and squat beings. Its members often make their dwellings in dark, tight spaces, such as the stone forest in" +
                        " Skellig";
                        break;
                
                }//end switch

                return string.Format($"----{Name}----\n" +
                    $"Life: {Life} of {MaxLife}\n" +
                    $"Hit Chance: {CalcHitChance()}%\n" +
                    $"Weapon:\n{EquippedWeapon}\n" +
                    $"Block: {Block}\n" +
                    $"Description:\n{description}");
            }

            public override int CalcDamage()
            {
                //return base.CalcDamage();   This just gives us 0.

                //Create a random object
                Random rand = new Random();

                //determine damage 
                int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);

                return damage;
            }

            public override int CalcHitChance()
            {
                return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
            }
        }
}
