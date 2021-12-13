using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
        //The internal access modifier is the default access for all classes. It does
        //not have to be explicitly declared (like private for method signatures). The
        //internal access modifier states that the class is available only within the
        //assembly (project) where it is declared. If this was an internal class, Character would be
        //available to everything else in DungeonLibrary, but would not be accessible outside
        //of the project.

        //The abstract modifier indicates that the thing being modified 
        //has an incomplete implementation. The abstract modifier 
        //can be used with classes, methods, and properties. Use the abstract 
        //modifier in a class declaration to indicate that the
        //class is intended to only be a base(parent) class of other classes.

        //this file is public - it can be accessed from anywhere in the solution
        public abstract class Character
        {
            //fields
            private int _life;

            //properties - automatic property syntax
            public string Name { get; set; }
            //When you use this syntax, you do NOT have to create a field. The field will be made for you at runtime by the .NET framework
            //This syntax ONLY works if you have NO business rules
            public int HitChance { get; set; }
            public int Block { get; set; }
            public int MaxLife { get; set; }

            //This is NOT automatic property syntax. We had to define it the long way because of the business rule.
            public int Life
            {
                get { return _life; }
                set
                {
                    //business rule, life should never be more than max life
                    if (value <= MaxLife)
                    {
                        //good to go- the value can be stored in the field
                        _life = value;
                    }//end if 
                    else
                    {
                        _life = MaxLife;
                    }//end else
                }//end set
            }//end Life

            //ctors (constructors)
            //We will only need the default ctor here. Therefore, we can use the free parametersless, default ctor the .NET Framework gives us.

            //methods
            //That we will never create an object of type character. We will only make a player or monster.
            //Inheritance will helpuse understand how to EXTEND this functionality to make a player and a monster
            //Since we will not make a character object, we have no need for a ToString()

            //below are methods we want ot be inherited by player and monster, so we ar ecreating default versions here that the child classes will 
            //be able to use. The child class can use the defailt functionality defined below. Or they can use the "overide" to replace the parent
            //functionality with their own.
            //Without the virtual keyword, the child cannot use the override functionality

            public virtual int CalcBlock()
            {
                return Block;
            }

            public virtual int CalcHitChance()
            {
                return HitChance;
            }

            public virtual int CalcDamage()
            {
                return 0;
            }
        }
}
