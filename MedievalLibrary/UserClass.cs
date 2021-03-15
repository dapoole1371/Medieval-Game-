using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MedievalLibrary
{
    public class UserClass
    {
        public string userClassName { get; set; }
        public double userClassHPMod { get; set; }
        public double userClassMPMod { get; set; }
        public double userClassMagAttMod { get; set; }
        public double userClassAttPowMod { get; set; }
        
        public UserClass()
        {
            userClassName = "Generic class";
            userClassHPMod = 1;
            userClassMPMod = 1;
            userClassMagAttMod = 1;
            userClassAttPowMod = 1;
        }
    public string HumanClassSel()
        {
            Console.WriteLine("Choose a class for your character:");
            Console.WriteLine("1.  Warrior (Increased Attack Power, decreased Magic Power)\n2.  Wizard(Decreased Attack Power, increased Magic Power)");
            int classSelect;
            classSelect = int.Parse(Console.ReadLine());
            if (classSelect == 1)
            {
                userClassName = "Warrior";
                return userClassName;
            }
            if (classSelect == 2)
            {
                userClassName = "Wizard";
                return userClassName;
            }
            else return "Invalid";
        }
    }
    //Human Classes (Warrior, Wizard)
    public class Warrior : UserClass
    {
        public Warrior()
        {
            this.userClassName = "Warrior";
            this.userClassHPMod = 1.1;
            this.userClassMPMod = .8;
            this.userClassMagAttMod = .8;
            this.userClassAttPowMod = 1.4;
        }
    }
    
    public class Wizard : UserClass
    {
        public Wizard()
        {
            this.userClassName = "Wizard";
            this.userClassHPMod = .9;
            this.userClassMPMod = 1.3;
            this.userClassMagAttMod = 1.5;
            this.userClassAttPowMod = .8;
        }
    }
    //Giant Classes (brute maneater)
    public class Brute : Warrior
    {
        public Brute()
        {
            this.userClassName = "Brute";
            this.userClassHPMod = 1.1;
            this.userClassMPMod = .8;
            this.userClassMagAttMod = .8;
            this.userClassAttPowMod = 1.4;
        }
    }
    
    public class ManEater : UserClass
    {
        public ManEater()
        {
            this.userClassName = "Man-Eater";
            this.userClassHPMod = 1.3;
            this.userClassMPMod = .5;
            this.userClassMagAttMod = .5;
            this.userClassAttPowMod = 1.2;
        }
    }
    //Elf Classes (druid, ??)
    public class Druid : Wizard
    {
        public Druid()
        {
            this.userClassName = "Druid";
            this.userClassHPMod = .9;
            this.userClassMPMod = 1.3;
            this.userClassMagAttMod = 1.5;
            this.userClassAttPowMod = .7;
        }
    }

    public class Necromancer : UserClass
    {
        public Necromancer()
        {
            this.userClassName = "Necromancer";
            this.userClassHPMod = .8;
            this.userClassMPMod = 1.1;
            this.userClassMagAttMod = 1;
            this.userClassAttPowMod = 1.2;
        }
    }
    //Goblin Classes (Warrior, Thief)
    public class Thief : UserClass
    {
        public Thief()
        {
            this.userClassName = "Thief";
            this.userClassHPMod = .8;
            this.userClassMPMod = .8;
            this.userClassMagAttMod = .8;
            this.userClassAttPowMod = 1.2;
        }
    }
    
}
