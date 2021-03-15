using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MedievalLibrary
{
    public class Race : IRace
    {
        public string raceName { get; set; }
        public double raceAttMod { get; set; }
        public double raceMagMod { get; set; }
        public double raceHP { get; set; }
        public double raceMP { get; set; }
    }   
    
    public class Human : Race
    {
        public Human()
        {
            this.raceName = "Human";
            this.raceAttMod = 1;
            this.raceMagMod = 1;
            this.raceHP = 100;
            this.raceMP = 100;
        }
    }
    
    public class Giant : Race
    {
        public Giant()
        {
            this.raceName = "Giant";
            this.raceAttMod = 1.3;
            this.raceMagMod = .8;
            this.raceHP = 120;
            this.raceMP = 80;
        }
    }

    public class Elf : Race
    {
        public Elf()
        {
            this.raceName = "Elf";
            this.raceAttMod = .8;
            this.raceMagMod = 1.3;
            this.raceHP = 85;
            this.raceMP = 120;
        }
    }

    public class Goblin : Race
    {
        public Goblin()
        {
            this.raceName = "Goblin";
            this.raceAttMod = .8;
            this.raceMagMod = .8; 
            this.raceHP = 90;
            this.raceMP = 80;
        }
    }
    
    public class ClassDescriptions
    {
        public string DisplayDescriptions()
            {
            return $" -------------------------------------------------------------------------------------------------------------------- \n" +
                   $"|                                             ***AVAILABLE RACES***                                                  |\n" +
                    "|                                                                                                                    |\n" +
                    "| 1.  Human:  Humans are the most common race in Medieval Legends.                                                   |\n" +
                    "|             They have increased intelligence compared to most other races.                                         |\n" +
                    "|             Initial Hit Points = 100                                                                               |\n" +
                    "|             Initial Magic Points = 100                                                                             |\n" +
                    "|             Available Classes: Warrior, Wizard                                                                     |\n" +
                    "|                                                                                                                    |\n" +
                    "| 2.  Giant:  Gaints are the largest humanoid race in Medieval Legends.                                              |\n" +
                    "|             They have increased hit points, but lower magic points than most other races.                          |\n" +
                    "|             Initial Hit Points = 120                                                                               |\n" +
                    "|             Initial Magic Points = 80                                                                              |\n" +
                    "|             Available Classes: Brute, Man-Eater                                                                    |\n" +
                    "|                                                                                                                    |\n" +
                    "| 3.  Elf:    Elves are the most intelligent race in Medieval Legends.                                               |\n" +
                    "|             They have increased Magic Points compared to all other races.                                          |\n" +
                    "|             Initial Hit Points = 85                                                                                |\n" +
                    "|             Initial Magic Points = 120                                                                             |\n" +
                    "|             Available Classes: Druid, Necromancer                                                                  |\n" +
                    "|                                                                                                                    |\n" +
                    "| Other races coming soon!                                                                                           |\n" +
                    /*"| 4. Goblin:  Goblins are the most mischevious creatures in Medieval Legends.                                        |\n" +
                    "|             They have decreased Hit Points and Magic Points, but make up for this by having extra attacks.         |\n" +
                    "|             Initial Hit Points = 90                                                                                |\n" +
                    "|             Initial Magic Points = 80                                                                              |\n" +
                    "|             Available Classes: Thief                                                                               |\n" + */
                    "|                                                                                                                    |\n" +
                    " --------------------------------------------------------------------------------------------------------------------\n\n";
            }
    }
}
