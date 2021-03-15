using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MedievalLibrary
{
    public class Enemy
    {
        public string enemyName { get; set; }
        public int enemyHP { get; set; }
        public int enemyLoot { get; set; }
        public int enemyHPMin { get; set; }
        public int enemyHPMax { get; set; }
        public int enemyAttPow { get; set; }
        public int enemyAttMin { get; set; }
        public int enemyAttMax { get; set; }



        public Enemy()
        {
            enemyName = "Enemy";
            enemyHP = 100;
            enemyLoot = 100;
            enemyHPMin = 50;
            enemyHPMax = 100;
            enemyAttPow = 10;
        }
    }

    public class Spider : Enemy
    {
        public Spider()
        {
            this.enemyName = "Spider";
            this.enemyHPMin = 20;
            this.enemyHPMax = 40;
            this.enemyAttMin = 5;
            this.enemyAttMax = 6;
            Random enemyRoll = new Random();
            int enemyHPRoll = enemyRoll.Next(enemyHPMin, enemyHPMax);
            this.enemyHP = enemyHPRoll;
            this.enemyAttPow = enemyRoll.Next(enemyAttMin, enemyAttMax);

        }
    }

    public class Orc : Enemy
    {
        public Orc()
        {
            this.enemyName = "Orc";
            this.enemyHPMin = 30;
            this.enemyHPMax = 45;
            this.enemyAttMin = 6;
            this.enemyAttMax = 9;
            Random enemyRoll = new Random();
            int enemyHPRoll = enemyRoll.Next(enemyHPMin, enemyHPMax);
            this.enemyHP = enemyHPRoll;
            this.enemyAttPow = enemyRoll.Next(enemyAttMin, enemyAttMax);
        }
    }

    public class Golem : Enemy
    {
        public Golem()
        {
            this.enemyName = "Golem";
            this.enemyHPMin = 40;
            this.enemyHPMax = 60;
            this.enemyAttMin = 8;
            this.enemyAttMax = 10;
            Random enemyRoll = new Random();
            int enemyHPRoll = enemyRoll.Next(enemyHPMin, enemyHPMax);
            this.enemyHP = enemyHPRoll;
            this.enemyAttPow = enemyRoll.Next(enemyAttMin, enemyAttMax);
        }
    }

    public class Dragon : Enemy
    {
        public Dragon()
        {
            this.enemyName = "Dragon";
            this.enemyHPMin = 55;
            this.enemyHPMax = 80;
            this.enemyAttMin = 10;
            this.enemyAttMax = 13;
            Random enemyRoll = new Random();
            int enemyHPRoll = enemyRoll.Next(enemyHPMin, enemyHPMax);
            this.enemyHP = enemyHPRoll;
            this.enemyAttPow = enemyRoll.Next(enemyAttMin, enemyAttMax);
        }
    }

    public class Cyclops : Enemy
    {
        public Cyclops()
        {
            this.enemyName = "Spider";
            this.enemyHPMin = 60;
            this.enemyHPMax = 80;
            this.enemyAttMin = 9;
            this.enemyAttMax = 13;
            Random enemyRoll = new Random();
            int enemyHPRoll = enemyRoll.Next(enemyHPMin, enemyHPMax);
            this.enemyHP = enemyHPRoll;
            this.enemyAttPow = enemyRoll.Next(enemyAttMin, enemyAttMax);
        }
    }
}
