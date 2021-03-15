using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MedievalLibrary
{
    [Serializable]
    public class User
    {
        public string userName { get; set; }
        public string userRace { get; set; }
        public string userClass { get; set; }
        public int userHP { get; set; }
        public int userMP { get; set; }
        public int userMaxHP { get; set; }
        public int userMaxMP { get; set; }
        public double userAttPow { get; set; }
        public double userMagPow { get; set; }
        public int arenaWins { get; set; }
        public int arenaLosses { get; set; }
        public int userGold { get; set; }
        public int userEXP { get; set; }
        public int userExpToLevel { get; set; }
        public int userLevel { get; set; }

        public User()
        {
            userName = "Default name";
            userRace = "Default race";
            userHP = 100;
            userMP = 100;
            userMaxHP = 100;
            userMaxMP = 100;
            userAttPow = 5;
            userMagPow = 5;
            arenaWins = 0;
            arenaLosses = 0;
            userGold = 0;
            userEXP = 0;
            userExpToLevel = 25;
            userLevel = 1;
        }

        public User(string userName, string userRace, string userClass, int userHP, int userMaxHP, int userMP, int userMaxMP, double userAttPow, double userMagPow, int arenaWins, int arenaLosses, int userGold, int userEXP,int userExpToLevel, int userLevel)
        {
            this.userName = userName;
            this.userRace = userRace;
            this.userClass = userClass;
            this.userHP = userHP;
            this.userMP = userMP;
            this.userMaxHP = userMaxHP;
            this.userMaxMP = userMaxMP;
            this.userAttPow = userAttPow;
            this.userMagPow = userMagPow;
            this.arenaWins = arenaWins;
            this.arenaLosses = arenaLosses;
            this.userGold = userGold;
            this.userEXP = userEXP;
            this.userExpToLevel = userExpToLevel;
            this.userLevel = userLevel;
        }

        public string UserName(string inputName)
        {
            int nameLength = inputName.Length;
            while (nameLength > 12 || nameLength < 1)
            {
                Console.Write("Please enter a valid name between 1 and 12 characters: ");
                inputName = Console.ReadLine();
                nameLength = inputName.Length;
            }
            userName = inputName;

            return $"\nYour character name has been set as {userName}.\nPress <ENTER> to continue...";
        }

        public string UserRace(string inputRace)
        {
            userRace = inputRace;
            return $"You have chosen {userRace}.\nPress <ENTER> to continue...";
        }

    }
}
