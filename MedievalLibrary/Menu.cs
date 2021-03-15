using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MedievalLibrary
{
    public class Menu
    {
        public string MainMenu(string userName, string userRace, string userClass, double userHP, double userMaxHP, double userMP, double userMaxMP, double userAttPow, double userMagPow, int arenaWins, int arenaLosses, int userGold, int userEXP, int userExpToLevel, int userLevel)
        {
            Console.WriteLine($" --------------------------------------------------------------------------------------------------------------------- \n" +
                               "|                                                 ***MAIN MENU***                                                     \n" +
                               "|                                                                                                                     \n" +
                               "| 1. Go and fight!                                                                                                    \n" +
                               "| 2. See your stats                                                                                                   \n" +
                              $"| 3. Visit the healer ({((int)(userMaxHP - (int)userHP) / 4)} gold)                                                   \n" +
                               "| 4. Visit the Weapons Shop  ***COMING SOON***                                                                        \n" +
                               "| 5. Visit the Armor Shop    ***COMING SOON***                                                                        \n" +
                               "| 6. Save and Exit Program                                                                                            \n" +
                               "|                                                                                                                     \n" +
                               " --------------------------------------------------------------------------------------------------------------------- \n");
            Console.Write($" <{userName} | <{(int)userHP}/{(int)userMaxHP}HP> | <{(int)userMP}/{(int)userMaxMP}MP> :");
            try
            {
                int menuChoice = int.Parse(Console.ReadLine());
                while (menuChoice > 6 || menuChoice < 1)
                {
                    Console.WriteLine("     Invalid entry, please select from the menu: ");
                    menuChoice = int.Parse(Console.ReadLine());
                }
                switch (menuChoice)
                {
                    case 1:
                        Combat(userName, userHP, userMaxHP, userMP, userMaxMP, userAttPow, userMagPow, userRace, userClass, arenaWins, arenaLosses, userGold, userEXP, userExpToLevel, userLevel);
                        MainMenu(userName, userRace, userClass, userHP, userMaxHP, userMP, userMaxMP, userAttPow, userMagPow, arenaWins, arenaLosses, userGold, userEXP, userExpToLevel, userLevel);
                        break;
                    case 2:
                        Stats(userName, userRace, userClass, userHP, userMaxHP, userMP, userMaxMP, userAttPow, userMagPow, arenaWins, arenaLosses, userGold, userEXP, userExpToLevel, userLevel);
                        break;
                    case 3:
                        if (userGold < ((userMaxHP - (int)userHP) / 4))
                        {
                            Console.WriteLine("You don't have enough gold to pay the healer!");
                            Console.ReadLine();
                            MainMenu(userName, userRace, userClass, userHP, userMaxHP, userMP, userMaxMP, userAttPow, userMagPow, arenaWins, arenaLosses, userGold, userEXP, userExpToLevel, userLevel);
                        }
                        Console.WriteLine("You have been healed of your wounds.  Next time, try to dodge a little better!");
                        userGold = userGold - ((int)(userMaxHP - (int)userHP) / 4);
                        userHP = userMaxHP;
                        MainMenu(userName, userRace, userClass, userHP, userMaxHP, userMP, userMaxMP, userAttPow, userMagPow, arenaWins, arenaLosses, userGold, userEXP, userExpToLevel, userLevel);
                        break;
                    case 4:
                        Console.WriteLine("The Weapons Shop is under construction, try back later!");
                        Console.ReadLine();
                        MainMenu(userName, userRace, userClass, userHP, userMaxHP, userMP, userMaxMP, userAttPow, userMagPow, arenaWins, arenaLosses, userGold, userEXP, userExpToLevel, userLevel);
                        break;
                    case 5:
                        Console.WriteLine("The Armor Shop is under construction, try back later!");
                        Console.ReadLine();
                        MainMenu(userName, userRace, userClass, userHP, userMaxHP, userMP, userMaxMP, userAttPow, userMagPow, arenaWins, arenaLosses, userGold, userEXP, userExpToLevel, userLevel);
                        break;
                    case 6:
                        User user = new User(userName, userRace, userClass, (int)userHP, (int)userMaxHP, (int)userMP, (int)userMaxMP, userAttPow, userMagPow, arenaWins, arenaLosses, userGold, userEXP, userExpToLevel, userLevel);
                        Stream SaveFileStream = File.Create(@$"../../../{userName}.bin");
                        BinaryFormatter serializer = new BinaryFormatter();
                        serializer.Serialize(SaveFileStream, user);
                        SaveFileStream.Close();
                        Environment.Exit(0);
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid entry, please select from the menu: ");
                MainMenu(userName, userRace, userClass, userHP, userMaxHP, userMP, userMaxMP, userAttPow, userMagPow, arenaWins, arenaLosses, userGold, userEXP, userExpToLevel, userLevel);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid entry, please select from the menu: ");
                MainMenu(userName, userRace, userClass, userHP, userMaxHP, userMP, userMaxMP, userAttPow, userMagPow, arenaWins, arenaLosses, userGold, userEXP, userExpToLevel, userLevel);
            }
            return "";
        }

        public void Stats(string userName, string userRace, string userClass, double userHP, double userMaxHP, double userMP, double userMaxMP, double userAttPow, double userMagPow, int arenaWins, int arenaLosses, int userGold, int userEXP, int userExpToLevel, int userLevel)
        {
            Console.Clear();
            Console.WriteLine($" --------------------------------------------------------------------------------------------------------------------- \n" +
                              $"|                                           ***CURRENT STATISTICS***                                                   \n" +
                              $"|                                                                                                                      \n" +
                              $"|  Character Name:  {userName}                               Race: {userRace}                    Level: {userLevel}   \n" +
                              $"|  Character Class: {userClass}                                                                                        \n" +
                              $"|  Total Experience: {userEXP}                               HitPoints: {userHP}/{userMaxHP}                            \n" +
                              $"|  Experience Until Level-Up: {userExpToLevel}               Magic Points: {userMP}/{userMaxMP}                         \n" +
                              $"|  Attack Power: {userAttPow}                                                                                          \n" +
                              $"|  Magic Power: {userMagPow}                                                                                           \n" +
                              $"|                                                                                                                      \n" +
                              $"|  Total Arena Wins: {arenaWins}                                                                                       \n" +
                              $"|  Total Arena Losses: {arenaLosses}                                                                                   \n" +
                              $"|                                                                                                                      \n" +
                              $"|  Total Gold Coins: {userGold}                                                                                        \n" +
                               " ----------------------------------------------------------------------------------------------------------------------\n");

            Console.WriteLine("Press <ENTER> to return to Main Menu.");
            Console.ReadLine();
            Console.Clear();
            MainMenu(userName, userRace, userClass, userHP, userMaxHP, userMP, userMaxMP, userAttPow, userMagPow, arenaWins, arenaLosses, userGold, userEXP, userExpToLevel, userLevel);
        }

        public void Combat(string userName, double userHP, double userMaxHP,double userMP, double userMaxMP, double userAttPow, double userMagPow, string userRace, string userClass, int arenaWins, int arenaLosses, int userGold, int userEXP, int userExpToLevel, int userLevel)
        {
            Enemy enemy = new Enemy();
            Random userAttack = new Random();
            Console.Clear();
            GateDisplay();
            void GateDisplay()
            {
                Console.Write("You enter the arena to loud cheers and encouragement!!  As you slowly take in the scene, a large metal gate across the arena slowly opens.\n" +
                                  "From the shadowy hall on the other side of the gate, a fierce growl pierces the air...It is time to defend yourself...\n\n" +
                                  "                          ------------------------------------------------------------------                            \n" +
                                  "                          -----------------________________________________-----------------                            \n" +
                                  "                          ----------------/___|_________|____|_________|___\\----------------                            \n" +
                                  "                          --------------/     |         |    |         |     \\--------------                            \n" +
                                  "                          ------------/|      |         |    |         |      |\\------------                            \n" +
                                  "                          -----------/ |      |         |    |         |      | \\-----------                            \n" +
                                  "                          ----------/__|______|_________|____|_________|______|__\\----------                            \n" +
                                  "                          ---------/   |      |         |    |         |      |   \\---------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|____|______|_________|____|_________|______|____|--------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|____|______|_________|____|_________|______|____|--------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|____|______|_________|____|_________|______|____|--------                            \n" +
                                  "                          ------------------------------------------------------------------                            \n" +
                                  "                          ------------------------------------------------------------------                            \n");
                System.Threading.Thread.Sleep(200);
                Console.Clear();
                Console.Write("You enter the arena to loud cheers and encouragement!!  As you slowly take in the scene, a large metal gate across the arena slowly opens.\n" +
                      "From the shadowy hall on the other side of the gate, a fierce growl pierces the air...It is time to defend yourself...\n\n" +
                                  "                          ------------------------------------------------------------------                            \n" +
                                  "                          -----------------________________________________-----------------                            \n" +
                                  "                          ----------------/   |         |    |         |   \\----------------                            \n" +
                                  "                          --------------/     |         |    |         |     \\--------------                            \n" +
                                  "                          ------------/|______|_________|____|_________|______|\\------------                            \n" +
                                  "                          -----------/ |      |         |    |         |      | \\-----------                            \n" +
                                  "                          ----------/  |      |         |    |         |      |  \\----------                            \n" +
                                  "                          ---------/   |      |         |    |         |      |   \\---------                            \n" +
                                  "                          --------|____|______|_________|____|_________|______|____|--------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|____|______|_________|____|_________|______|____|--------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|____|______|_________|____|_________|______|____|--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          ------------------------------------------------------------------                            \n" +
                                  "                          ------------------------------------------------------------------                            \n");
                System.Threading.Thread.Sleep(200);
                Console.Clear();
                Console.Write("You enter the arena to loud cheers and encouragement!!  As you slowly take in the scene, a large metal gate across the arena slowly opens.\n" +
                     "From the shadowy hall on the other side of the gate, a fierce growl pierces the air...It is time to defend yourself...\n\n" +
                                  "                          ------------------------------------------------------------------                            \n" +
                                  "                          -----------------________________________________-----------------                            \n" +
                                  "                          ----------------/___|_________|____|_________|___\\----------------                            \n" +
                                  "                          --------------/     |         |    |         |     \\--------------                            \n" +
                                  "                          ------------/|      |         |    |         |      |\\------------                            \n" +
                                  "                          -----------/ |      |         |    |         |      | \\-----------                            \n" +
                                  "                          ----------/__|______|_________|____|_________|______|__\\----------                            \n" +
                                  "                          ---------/   |      |         |    |         |      |   \\---------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|____|______|_________|____|_________|______|____|--------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|____|______|_________|____|_________|______|____|--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          ------------------------------------------------------------------                            \n" +
                                  "                          ------------------------------------------------------------------                            \n");
                System.Threading.Thread.Sleep(200);
                Console.Clear();
                Console.Write("You enter the arena to loud cheers and encouragement!!  As you slowly take in the scene, a large metal gate across the arena slowly opens.\n" +
                      "From the shadowy hall on the other side of the gate, a fierce growl pierces the air...It is time to defend yourself...\n\n" +
                                  "                          ------------------------------------------------------------------                            \n" +
                                  "                          -----------------________________________________-----------------                            \n" +
                                  "                          ----------------/   |         |    |         |   \\----------------                            \n" +
                                  "                          --------------/     |         |    |         |     \\--------------                            \n" +
                                  "                          ------------/|______|_________|____|_________|______|\\------------                            \n" +
                                  "                          -----------/ |      |         |    |         |      | \\-----------                            \n" +
                                  "                          ----------/  |      |         |    |         |      |  \\----------                            \n" +
                                  "                          ---------/   |      |         |    |         |      |   \\---------                            \n" +
                                  "                          --------|____|______|_________|____|_________|______|____|--------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|____|______|_________|____|_________|______|____|--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          ------------------------------------------------------------------                            \n" +
                                  "                          ------------------------------------------------------------------                            \n");
                System.Threading.Thread.Sleep(200);
                Console.Clear();
                Console.Write($"You enter the arena to loud cheers and encouragement!!  As you slowly take in the scene, a large metal gate across the arena slowly opens.\n" +
                      "From the shadowy hall on the other side of the gate, a fierce growl pierces the air...It is time to defend yourself...\n\n" +
                                  "                          ------------------------------------------------------------------                            \n" +
                                  "                          -----------------________________________________-----------------                            \n" +
                                  "                          ----------------/___|_________|____|_________|___\\----------------                            \n" +
                                  "                          --------------/     |         |    |         |     \\--------------                            \n" +
                                  "                          ------------/|      |         |    |         |      |\\------------                            \n" +
                                  "                          -----------/ |      |         |    |         |      | \\-----------                            \n" +
                                  "                          ----------/__|______|_________|____|_________|______|__\\----------                            \n" +
                                  "                          ---------/   |      |         |    |         |      |   \\---------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|    |      |         |    |         |      |    |--------                            \n" +
                                  "                          --------|____|______|_________|____|_________|______|____|--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          ------------------------------------------------------------------                            \n" +
                                  "                          ------------------------------------------------------------------                            \n");
                System.Threading.Thread.Sleep(200);
                Console.Clear();
                Console.Write("You enter the arena to loud cheers and encouragement!!  As you slowly take in the scene, a large metal gate across the arena slowly opens.\n" +
                      "From the shadowy hall on the other side of the gate, a fierce growl pierces the air...It is time to defend yourself...\n\n" +
                                  "                          ------------------------------------------------------------------                            \n" +
                                  "                          -----------------________________________________-----------------                            \n" +
                                  "                          ----------------/   |         |    |         |   \\----------------                            \n" +
                                  "                          --------------/     |         |    |         |     \\--------------                            \n" +
                                  "                          ------------/|______|_________|____|_________|______|\\------------                            \n" +
                                  "                          -----------/ |      |         |    |         |      | \\-----------                            \n" +
                                  "                          ----------/  |      |         |    |         |      |  \\----------                            \n" +
                                  "                          ---------/   |      |         |    |         |      |   \\---------                            \n" +
                                  "                          --------|____|______|_________|____|_________|______|____|--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          ------------------------------------------------------------------                            \n" +
                                  "                          ------------------------------------------------------------------                            \n");
                System.Threading.Thread.Sleep(200);
                Console.Clear();
                Console.Write("You enter the arena to loud cheers and encouragement!!  As you slowly take in the scene, a large metal gate across the arena slowly opens.\n" +
                      "From the shadowy hall on the other side of the gate, a fierce growl pierces the air...It is time to defend yourself...\n\n" +
                                  "                          ------------------------------------------------------------------                            \n" +
                                  "                          -----------------________________________________-----------------                            \n" +
                                  "                          ----------------/___|_________|____|_________|___\\----------------                            \n" +
                                  "                          --------------/     |         |    |         |     \\--------------                            \n" +
                                  "                          ------------/|      |         |    |         |      |\\------------                            \n" +
                                  "                          -----------/ |      |         |    |         |      | \\-----------                            \n" +
                                  "                          ----------/__|______|_________|____|_________|______|__\\----------                            \n" +
                                  "                          ---------/                                              \\---------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          ------------------------------------------------------------------                            \n" +
                                  "                          ------------------------------------------------------------------                            \n");
                System.Threading.Thread.Sleep(200);
                Console.Clear();
                Console.Write("You enter the arena to loud cheers and encouragement!!  As you slowly take in the scene, a large metal gate across the arena slowly opens.\n" +
                     "From the shadowy hall on the other side of the gate, a fierce growl pierces the air...It is time to defend yourself...\n\n" +
                                  "                          ------------------------------------------------------------------                            \n" +
                                  "                          -----------------________________________________-----------------                            \n" +
                                  "                          ----------------/   |         |    |         |   \\----------------                            \n" +
                                  "                          --------------/     |         |    |         |     \\--------------                            \n" +
                                  "                          ------------/|______|_________|____|_________|______|\\------------                            \n" +
                                  "                          -----------/                                          \\-----------                            \n" +
                                  "                          ----------/                                            \\----------                            \n" +
                                  "                          ---------/                                              \\---------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          --------|                                                |--------                            \n" +
                                  "                          ------------------------------------------------------------------                            \n" +
                                  "                          ------------------------------------------------------------------                            \n");
            }
            Random enemyType = new Random();
            int enemyRoll = enemyType.Next(1, 10);
            if (enemyRoll < 4)
            {
                Spider spider = new Spider();
                enemy.enemyName = spider.enemyName;
                enemy.enemyHP = spider.enemyHP;
                enemy.enemyAttPow = spider.enemyAttPow;
            }
            if (enemyRoll > 3 && enemyRoll < 7)
            {
                Orc orc = new Orc();
                enemy.enemyName = orc.enemyName;
                enemy.enemyHP = orc.enemyHP;
                enemy.enemyAttPow = orc.enemyAttPow;
            }
            if (enemyRoll > 6 && enemyRoll < 9)
            {
                Golem golem = new Golem();
                enemy.enemyName = golem.enemyName;
                enemy.enemyHP = golem.enemyHP;
                enemy.enemyAttPow = golem.enemyAttPow;
            }
            if (enemyRoll == 9)
            {
                Dragon dragon = new Dragon();
                enemy.enemyName = dragon.enemyName;
                enemy.enemyHP = dragon.enemyHP;
                enemy.enemyAttPow = dragon.enemyAttPow;
            }
            if (enemyRoll == 10)
            {
                Cyclops cyclops = new Cyclops();
                enemy.enemyName = cyclops.enemyName;
                enemy.enemyHP = cyclops.enemyHP;
                enemy.enemyAttPow = cyclops.enemyAttPow;
            }
            Console.WriteLine($"\nA massive {enemy.enemyName} with {enemy.enemyHP}HP has entered the arena!!\n");
            Console.ReadLine();
            Console.Write($" --------------------------------------------------------------------------------------------------------------------- \n" +
                           "|                                                                                                                     |\n" +
                           "| 1.  Attack                                                                                                          |\n" +
                           "| 2.  Run away (Counts as loss)                                                                                       |\n" +
                           "|                                                                                                                     |\n" +
                           " --------------------------------------------------------------------------------------------------------------------- \n" +
                         $"Player: <{userName}> | <{(int)userHP}/{(int)userMaxHP}HP> | <{(int)userMP}/{(int)userMaxMP}MP>\nEnemy: <{enemy.enemyName}> | <{enemy.enemyHP}HP>\n");
            try
            {
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    while (userHP > 0 && enemy.enemyHP > 0)
                    {
                        int playerDamage = (int)userAttPow + userAttack.Next(-3, 3);
                        int enemyDamage = (int)enemy.enemyAttPow + userAttack.Next(-3, 3);
                        Console.WriteLine($"\nYou hit the enemy for {playerDamage} damage!");
                        Console.WriteLine($"The enemy hits you for {enemyDamage} damage!");

                        userHP -= enemyDamage;
                        enemy.enemyHP -= (int)playerDamage;
                        if (enemy.enemyHP < 0)
                        {
                            enemy.enemyHP = 0;
                        }
                        Console.WriteLine($"Player: <{userName}> | <{(int)userHP}/{(int)userMaxHP}HP> | <{(int)userMP}/{(int)userMaxMP}MP>\nEnemy:  <{enemy.enemyName}> | <{enemy.enemyHP}HP>\n\n");
                        System.Threading.Thread.Sleep(1300);
                    }
                    if (userHP < 1)
                    {
                        arenaLosses++;
                        Console.WriteLine("You have died in the arena...");
                        userHP = 0;
                        userHP += (userMaxHP / 2);
                        Console.WriteLine("Press <ENTER> to return to the menu.");
                        Console.ReadLine();
                        MainMenu(userName, userRace, userClass, userHP, userMaxHP, userMP, userMaxMP, userAttPow, userMagPow, arenaWins, arenaLosses, userGold, userEXP, userExpToLevel, userLevel);
                    }
                    if (enemy.enemyHP < 1)
                    {
                        arenaWins++;
                        double arenaWinnings = (enemy.enemyAttPow - enemy.enemyHP) / .3;
                        userGold += (int)arenaWinnings;
                        userEXP += (int)((enemy.enemyAttPow + enemy.enemyHP) / .7);
                        userExpToLevel -= (int)((enemy.enemyAttPow + enemy.enemyHP) / .7);
                        Console.WriteLine($"You have defeated your enemy and earned {(int)arenaWinnings} gold and {(int)((enemy.enemyAttPow + enemy.enemyHP) / .7)} experience!!");
                        if (userExpToLevel < 1)
                        {
                            userLevel += 1;
                            userExpToLevel = (userLevel - 1)*(userLevel * 25);
                            Console.WriteLine($"Congratulations, your character has reached level {userLevel}!!");
                        }
                        Console.WriteLine("Press <ENTER> to return to the menu.");
                        Console.ReadLine();
                        MainMenu(userName, userRace, userClass, userHP, userMaxHP, userMP, userMaxMP, userAttPow, userMagPow, arenaWins, arenaLosses, userGold, userEXP, userExpToLevel, userLevel);
                    }
                }
                if (choice == 2)
                    arenaLosses++;
                Console.WriteLine("You have fled like a coward from the arena!!");
                MainMenu(userName, userRace, userClass, userHP, userMaxHP, userMP, userMaxMP, userAttPow, userMagPow, arenaWins, arenaLosses, userGold, userEXP, userExpToLevel, userLevel);
            }
            catch (FormatException)
            {
                Console.WriteLine("Your invalid input has cancelled the arena fight and resulted in a loss being added to your record.");
                Console.WriteLine("Please try to enter valid responses in the game!");
                Console.ReadLine();
                arenaLosses++;
                MainMenu(userName, userRace, userClass, userHP, userMaxHP, userMP, userMaxMP, userAttPow, userMagPow, arenaWins, arenaLosses, userGold, userEXP, userExpToLevel, userLevel);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Your invalid input has cancelled the arena fight and resulted in a loss being added to your record.");
                Console.WriteLine("Please try to enter valid responses in the game!");
                Console.ReadLine();
                arenaLosses++;
                MainMenu(userName, userRace, userClass, userHP, userMaxHP, userMP, userMaxMP, userAttPow, userMagPow, arenaWins, arenaLosses, userGold, userEXP, userExpToLevel, userLevel);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Your invalid input has cancelled the arena fight and resulted in a loss being added to your record.");
                Console.WriteLine("Please try to enter valid responses in the game!");
                Console.ReadLine();
                arenaLosses++;
                MainMenu(userName, userRace, userClass, userHP, userMaxHP, userMP, userMaxMP, userAttPow, userMagPow, arenaWins, arenaLosses, userGold, userEXP, userExpToLevel, userLevel);
            }
            catch (Exception)
            {
                Console.WriteLine("Your invalid input has cancelled the arena fight and resulted in a loss being added to your record.");
                Console.WriteLine("Please try to enter valid responses in the game!");
                Console.ReadLine();
                arenaLosses++;
                MainMenu(userName, userRace, userClass, userHP, userMaxHP, userMP, userMaxMP, userAttPow, userMagPow, arenaWins, arenaLosses, userGold, userEXP, userExpToLevel, userLevel);
            }
        }
    }
}
