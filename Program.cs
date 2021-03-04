using System;
using MedievalLibrary;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Medieval_Game
{
    class Program
    {
        public static void Main()
        {
            User user = new User();
            Menu menu = new Menu();
            ClassDescriptions desc = new ClassDescriptions();
            //Console.WindowHeight = 50;
            Console.WriteLine($"This is a prototype of a basic arena style combat game where the user fights random types of enemies.\nI know that" +
                               " the classes are very unbalanced right now, so I recommend using a Giant Man-Eater or Giant Brute \n" + 
                              $"to see how the game plays out!\n\nThere will be additional races in the game soon...\n\nAs of now, magic has not been implemented in the game, " +
                              $"but it will be in the near future!\n\nWe will also be adding: \n  Race and class specific skills\n  Weapons store\n  Armor Store");
            Console.Write("Please press <ENTER> to start the game!");
            Console.ReadLine();
            Console.Clear();            
            Console.WriteLine($" --------------------------------------------------------------------------------------------------------------------- \n" +
                              $"|         _                                                                                                 _         |\n" +
                              $"|        |$|                                                                                               |$|        |\n" +
                              $"|        |$|                              ***WELCOME TO MEDIEVAL LEGENDS***                                |$|        |\n" +
                              $"|        |$|                                                                                               |$|        |\n" +
                              $"|     ---------                                                                                         ---------     |\n" +
                              $"|       | | |                                                                                             | | |       |\n" +
                              $"|       | | |                                                                                             | | |       |\n" +
                              $"|       | | |                                                                                             | | |       |\n" +
                              $"|       | | |                 ---------------------------*-*---------------------------                   | | |       |\n" +
                              $"|       | | |                |                                                         |                  | | |       |\n" +
                              $"|       | | |                | CREATED BY: Dave Poole                                  |                  | | |       |\n" +
                              $"|       | | |                | GRAPHIC DESIGN: Corbin Poole & Dave Poole               |                  | | |       |\n" +
                              $"|       | | |                |                                                         |                  | | |       |\n" +
                              $"|       | | |                 ---------------------------------------------------------                   | | |       |\n" +
                              $"|       | | |                                                                                             | | |       |\n" +
                              $"|        \\ /                                                                                               \\ /        |\n" +
                              $"|                                                                                                                     |\n" +
                               " --------------------------------------------------------------------------------------------------------------------- \n\n");
            try
            {
                Console.WriteLine("1. Create a new character\n2. Load an existing character ");
                int initial = int.Parse(Console.ReadLine());
                while (initial > 2 || initial < 1)
                {
                    Console.Write("Invalid entry.  Please select either 1 to create and new character, or 2 to load a saved character: ");
                    initial = int.Parse(Console.ReadLine());
                }
                if (initial == 2)
                {
                    Console.Write("Enter your saved character name: ");
                    string loadName = Console.ReadLine();
                    if (File.Exists(@$"../../../{loadName}.bin"))
                    {
                        Console.WriteLine("Reading saved file");
                        Stream openFileStream = File.OpenRead(@$"../../../{loadName}.bin");
                        BinaryFormatter deserializer = new BinaryFormatter();
                        user = (User)deserializer.Deserialize(openFileStream);
                        openFileStream.Close();
                    }
                    if (!File.Exists(@$"../../../{loadName}.bin"))
                    {
                        Console.WriteLine("Character does not exist!");
                        Console.ReadLine();
                        Main();
                    }
                        menu.MainMenu(user.userName, user.userRace, user.userClass, user.userHP, user.userMaxHP, user.userMP, user.userMaxMP, user.userAttPow, user.userMagPow, user.arenaWins, user.arenaLosses, user.userGold, user.userEXP, user.userExpToLevel, user.userLevel);
                }
                Console.Write(" Please enter a name for your character: ");
                Console.WriteLine(user.UserName(Console.ReadLine()));
                Console.ReadLine();
                Console.Clear();
                Console.Write(desc.DisplayDescriptions());
                Console.Write("Please choose a race(1 - 3): ");
                int race = int.Parse(Console.ReadLine());
                while (race > 3 || race < 1)
                {
                    Console.WriteLine("Invalid entry, please select from the menu: ");
                    race = int.Parse(Console.ReadLine());
                }
                if (race == 1)
                {
                    Human userRace = new Human();
                    user.userHP = (int)userRace.raceHP;
                    user.userMP = (int)userRace.raceMP;
                    user.userAttPow *= userRace.raceAttMod;
                    user.userMagPow *= userRace.raceMagMod;
                    Console.WriteLine(user.UserRace(userRace.raceName));
                    Console.ReadLine();
                    Console.Write($" --------------------------------------------------------------------------------------------------------------------- \n" +
                                   "|                                          ***AVAILABLE HUMAN CLASSES***                                              |\n" +
                                   "|                                                                                                                     |\n" +
                                   "| 1.  Warrior (Increased Attack Power, decreased Magic Power)                                                         |\n" +
                                   "| 2.  Wizard (Decreased Attack Power, increased Magic Power)                                                          |\n" +
                                   "| 3. *COMING SOON*                                                                                                    |\n" +
                                   "| 4. *COMING SOON*                                                                                                    |\n" +
                                   "|                                                                                                                     |\n" +
                                   " --------------------------------------------------------------------------------------------------------------------- \n\n" +
                                  "Choose a class for your character: ");
                    int classSelect = int.Parse(Console.ReadLine());
                    while (classSelect > 2 || classSelect < 1)
                    {
                        Console.WriteLine("Invalid entry, please select from the menu: ");
                        classSelect = int.Parse(Console.ReadLine());
                    }
                    if (classSelect == 1)
                    {
                        Warrior userClass = new Warrior();
                        user.userAttPow = user.userAttPow * userClass.userClassAttPowMod;
                        user.userMagPow = user.userMagPow * userClass.userClassMagAttMod;
                        user.userMaxHP = (int)(user.userMaxHP * userClass.userClassHPMod);
                        user.userMaxMP = (int)((double)user.userMaxMP * userClass.userClassMPMod);
                        user.userHP = user.userMaxHP;
                        user.userMP = user.userMaxMP;
                        user.userClass = userClass.userClassName;
                        Console.Write($"You have chosen to be a {user.userClass}.");
                        Console.ReadLine();
                    }
                    if (classSelect == 2)
                    {
                        Wizard userClass = new Wizard();
                        user.userAttPow = user.userAttPow * userClass.userClassAttPowMod;
                        user.userMagPow = user.userMagPow * userClass.userClassMagAttMod;
                        user.userMaxHP = (int)(user.userMaxHP * userClass.userClassHPMod);
                        user.userMaxMP = (int)((double)user.userMaxMP * userClass.userClassMPMod);
                        user.userHP = user.userMaxHP;
                        user.userMP = user.userMaxMP;
                        user.userClass = userClass.userClassName;
                        Console.Write($"You have chosen to be a {user.userClass}.");
                        Console.ReadLine();
                    }
                }
                if (race == 2)
                {
                    Giant userRace = new Giant();
                    user.userHP = (int)userRace.raceHP;
                    user.userMP = (int)userRace.raceMP;
                    user.userAttPow *= userRace.raceAttMod;
                    user.userMagPow *= userRace.raceMagMod;  
                    Console.WriteLine(user.UserRace(userRace.raceName));
                    Console.ReadLine();
                    Console.Write($" --------------------------------------------------------------------------------------------------------------------- \n" +
                                   "|                                        ***AVAILABLE GIANT CLASSES***                                                |\n" +
                                   "|                                                                                                                     |\n" +
                                   "| 1.  Brute (Increased Attack Power, decreased Magic Power)                                                           |\n" +
                                   "| 2.  Man-Eater (Increased Attack and HP, decreased Magic)                                                            |\n" +
                                   "| 3. *COMING SOON*                                                                                                    |\n" +
                                   "| 4. *COMING SOON*                                                                                                    |\n" +
                                   " --------------------------------------------------------------------------------------------------------------------- \n\n" +
                                  "Choose a class for your character: ");
                    int classSelect = int.Parse(Console.ReadLine());
                    while (classSelect > 2 || classSelect < 1)
                    {
                        Console.WriteLine("Invalid entry, please select from the menu: ");
                        classSelect = int.Parse(Console.ReadLine());
                    }
                    if (classSelect == 1)
                    {
                        Brute userClass = new Brute();
                        user.userAttPow = user.userAttPow * userClass.userClassAttPowMod;
                        user.userMagPow = user.userMagPow * userClass.userClassMagAttMod;
                        user.userMaxHP = (int)(user.userMaxHP * userClass.userClassHPMod);
                        user.userMaxMP = (int)((double)user.userMaxMP * userClass.userClassMPMod);
                        user.userHP = user.userMaxHP;
                        user.userMP = user.userMaxMP;
                        user.userClass = userClass.userClassName;
                        Console.Write($"You have chosen to be a {user.userClass}.");
                        Console.ReadLine();
                    }
                    if (classSelect == 2)
                    {
                        ManEater userClass = new ManEater();
                        user.userAttPow = user.userAttPow * userClass.userClassAttPowMod;
                        user.userMagPow = user.userMagPow * userClass.userClassMagAttMod;
                        user.userMaxHP = (int)(user.userMaxHP * userClass.userClassHPMod);
                        user.userMaxMP = (int)((double)user.userMaxMP * userClass.userClassMPMod);
                        user.userHP = user.userMaxHP;
                        user.userMP = user.userMaxMP;
                        user.userClass = userClass.userClassName;
                        Console.Write($"You have chosen to be a {user.userClass}.");
                        Console.ReadLine();
                    }
                }
                if (race == 3)
                {
                    Elf userRace = new Elf();
                    user.userHP = (int)userRace.raceHP;
                    user.userMP = (int)userRace.raceMP;
                    user.userAttPow *= userRace.raceAttMod;
                    user.userMagPow *= userRace.raceMagMod;
                    Console.WriteLine(user.UserRace(userRace.raceName));
                    Console.ReadLine();
                    Console.Write($" --------------------------------------------------------------------------------------------------------------------- \n" +
                                   "|                                          ***AVAILABLE ELF CLASSES***                                                |\n" +
                                   "|                                                                                                                     |\n" +
                                   "| 1.  Druid (Decreased Attack Power, increased Magic Power)                                                           |\n" +
                                   "| 2.  Necromancer (Decreased HP, increased Attack Power)                                                              |\n" +
                                   "| 3. *COMING SOON*                                                                                                    |\n" +
                                   "| 4. *COMING SOON*                                                                                                    |\n" +
                                   " --------------------------------------------------------------------------------------------------------------------- \n\n" +
                                    "Choose a class for your character: ");
                    int classSelect = int.Parse(Console.ReadLine());
                    while (classSelect > 2 || classSelect < 1)
                    {
                        Console.Write("Invalid entry, please select from the menu: ");
                        classSelect = int.Parse(Console.ReadLine());
                    }
                    if (classSelect == 1)
                    {
                        Druid userClass = new Druid();
                        user.userAttPow = user.userAttPow * userClass.userClassAttPowMod;
                        user.userMagPow = user.userMagPow * userClass.userClassMagAttMod;
                        user.userMaxHP = (int)(user.userMaxHP * userClass.userClassHPMod);
                        user.userMaxMP = (int)((double)user.userMaxMP * userClass.userClassMPMod);
                        user.userHP = user.userMaxHP;
                        user.userMP = user.userMaxMP;
                        user.userClass = userClass.userClassName;
                        Console.Write($"You have chosen to be a {user.userClass}.");
                        Console.ReadLine();
                    }
                    if (classSelect == 2)
                    {
                        Necromancer userClass = new Necromancer();
                        user.userAttPow = user.userAttPow * userClass.userClassAttPowMod;
                        user.userMagPow = user.userMagPow * userClass.userClassMagAttMod;
                        user.userMaxHP = (int)(user.userMaxHP * userClass.userClassHPMod);
                        user.userMaxMP = (int)((double)user.userMaxMP * userClass.userClassMPMod);
                        user.userHP = user.userMaxHP;
                        user.userMP = user.userMaxMP;
                        user.userClass = userClass.userClassName;
                        Console.Write($"You have chosen to be a {user.userClass}.");
                        Console.ReadLine();
                    }
                }
                //if (race == 4)
                //{
                //    Goblin userRace = new Goblin();
                //    user.userHP = (int)userRace.raceHP;
                //    user.userMP = (int)userRace.raceMP;
                //    user.userAttPow *= userRace.raceAttMod;
                //    user.userMagPow *= userRace.raceMagMod;
                //    Console.WriteLine(user.UserRace(userRace.raceName));
                //    Console.ReadLine();
                //}
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid entry");
                Main();
            }
            Console.Clear();
            menu.MainMenu(user.userName, user.userRace, user.userClass, user.userHP, user.userMaxHP, user.userMP, user.userMaxMP, user.userAttPow, user.userMagPow, user.arenaWins, user.arenaLosses, user.userGold, user.userEXP, user.userExpToLevel, user.userLevel);
        }        
    }
}
