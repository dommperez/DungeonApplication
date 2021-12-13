using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using DungeonMonstersLibrary;

namespace DungeonProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Berserk Mini Game";
            Console.WriteLine("\n");

            int score = 0;
            string name;
            string player;
            string weapon;

            //1. Create a player
            Console.WriteLine("Please enter a name:\n");
            name = Console.ReadLine();
            player = name;

            do
            {
                Console.WriteLine("\nChoose Your Race:\n" +
                    "H) Human\n" +
                    "E) Elf\n" +
                    "D) Dwarf\n");
                ConsoleKey choosePlayer = Console.ReadKey(true).Key;

                Console.Clear();

                switch (choosePlayer)
                {
                    case ConsoleKey.H:
                        Console.WriteLine($"You {name}, have become a human while you may be weaker your weapon surley is not");
                        break;

                    case ConsoleKey.E:

                    case ConsoleKey.D:

                    default:
                        Console.WriteLine("I do not understand this language you are trying to speak please try again...");
                        break;
                }//end switch

                //2. Create a weapon for the player

                Weapon MagicStaff = new Weapon(10, "Magic Staff", 25, false, 4);
                Weapon BattleAxe = new Weapon(20, "Battle Axe", 1, true, 10);
                Weapon DragonSlayer = new Weapon(100, "Dragon Slayer", 0, true, 100);
                Weapon sword = new Weapon(15, "Sword", 35, false, 8);





                //Start at a certain room
                //Extra weapon or a special weapon
                //They get the ability to attack as soon as they go in the room

                //4. Create a loop for the room
                bool exit = false;

                do
                {
                    Console.WriteLine(GetRoom());

                    MonsterType r1 = new MonsterType();
                    MonsterType r2 = new MonsterType("Troll", 25, 25, 50, 20, 2, 8, "Look out it's a troll!", true);

                    Monster[] monsters = { r1, r2, r2, r1, r1 };

                    Random rand = new Random();
                    int randomNbr = rand.Next(monsters.Length);
                    Monster monster = monsters[randomNbr];

                    Console.WriteLine("\nIn this room: " + monster.Name); ;

                    bool reload = false;
                    do
                    {
                        Console.WriteLine("\nPlease choose an action:\n" +
                            "A) Attack\n" +
                            "R) Run Away\n" +
                            "P) Player Info\n" +
                            "M) Monster Info\n" +
                            "X) Exit\n");
                        ConsoleKey userChoice = Console.ReadKey(true).Key;

                        Console.Clear();

                        switch (userChoice)
                        {
                            case ConsoleKey.A:
                                Combat.DoBattle(player, monster);
                                if (monster.Life <= 0)
                                {
                                    //its dead
                                    //Possible custimization: here you could have logic for the player to collect items like loot
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nYou killed {0}!\n", monster.Name);
                                    Console.ResetColor();
                                    reload = true; //breaks us out of the loop to get a new room and new monster
                                    score++;
                                }
                                break;
                            case ConsoleKey.R:
                                //13. Handle the monster's free attack
                                Console.WriteLine($"{monster.Name} attacks you as you flee!");
                                Combat.DoAttack(monster, player); //free attack
                                Console.WriteLine();
                                reload = true; //load a new room 
                                break;
                            case ConsoleKey.P:
                                Console.WriteLine("Player Info");
                                //TODO 14. Write out player info to screen
                                Console.WriteLine(player);
                                break;
                            case ConsoleKey.M:
                                Console.WriteLine("Monster Info");
                                //15. Write out monster info to screen
                                Console.WriteLine(monster);
                                break;
                            case ConsoleKey.X:
                            case ConsoleKey.E:
                                Console.WriteLine("No one likes a quitter.....");
                                exit = true;
                                break;
                            default:
                                Console.WriteLine("I do not understand this language you are trying to speak please try again...");
                                break;
                        }//end switch

                        //16. Check the players life 
                        if (player.Life <= 0)
                        {
                            Console.WriteLine("Dude.... you died!");
                            exit = true; //breaks out of both loops
                        }

                    } while (!exit && !reload);

                } while (!exit);

                //17. Show player how many monsters they defeated
                Console.WriteLine("You defeated " + score + " monster" + (score == 1 ? "." : "s."));

            }//end Main()

        private static string GetRoom()
            {
                string[] rooms =
                {
                "This chamber is clearly a prison. Small barred cells line the walls, leaving a 15-foot-wide pathway for a guard to walk.Channels run down either side of the path next to the cages, probably to allow the prisoners' waste to flow through the grates on the other side of the room. The cells appear empty but your vantage point doesn't allow you to see the full extent of them all.",
                " This room is a tomb. Stone sarcophagi stand in five rows of three, each carved with the visage of a warrior lying in state. In their center, one sarcophagus stands taller than the rest. Held up by six squat pillars, its stone bears the carving of a beautiful woman who seems more asleep than dead. The carving of the warriors is skillful but seems perfunctory compared to the love a sculptor must have lavished upon the lifelike carving of the woman.",
                " This hall stinks with the wet, pungent scent of mildew. Black mold grows in tangled veins across the walls and parts of the floor. Despite the smell, it looks like it might be safe to travel through. A path of stone clean of mold wends its way through the hallway.",
                "Several white marble busts that rest on white pillars dominate this room. Most appear to be male or female humans of middle age, but one clearly bears small horns projecting from its forehead and another is spread across the floor in a thousand pieces, leaving one pillar empty.",
                "You gaze into the room and hundreds of skulls gaze coldly back at you. They're set in niches in the walls in a checkerboard pattern, each skull bearing a half-melted candle on its head. The grinning bones stare vacantly into the room, which otherwise seems empty."
            };

                Random rand = new Random();
                int indexNbr = rand.Next(rooms.Length);

                string room = rooms[indexNbr];

                return room;
            }
        }
    }
