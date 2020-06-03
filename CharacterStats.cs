using System;
namespace RecreateDND
{
    public class CharacterStats
    {
        public string weaponName, armorName, PCclass, race, name, weaponName2, weaponName3, weakness, resistance;
        public int str, dex, con, intel, wis, cha, maxHealth, health, speed, ac, gold, 
            profbonus, weaponDamageDice, ammo, meleeATKBonus, rangedATKBonus, damageDiceMax, 
            damageDiceNumber, damageDiceNumber2, damageDiceNumber3, damageDiceMax2, damageDiceMax3,
            spellModifier, maxSpellPoints, spellPoints,attackNum;
        public bool stealthDis, isWeaponRanged, isWeapon2Ranged, isWeapon3Ranged;


        /*public static CharacterStats InitDefaultEnemy()
        {
            return new CharacterStats("default annoyance", 10, 10, 10, 10, 10, 10, 10);
        } */


        public CharacterStats(string name = "", string race = "", int str = 0, int dex = 0, int con = 0, int intel = 0, int wis = 0, int cha = 0,
                                int maxHealth = 10, int speed = 0, int ac = 10, int gold = 0, int maxSpellPoints = 0, int spellPoints = 0, string weaponName = "Fist", string armorName = "None", int damageDiceNumber = 1,
                                int damageDiceMax = 1, int health = 0, int ammo = 10, int meleeATKBonus = 2, int rangedATKBonus = 2, bool stealthDis = false, bool isWeaponRanged = false,
                                string weaponName2 = "", int damageDiceNumber2 = 1, int damageDiceMax2 = 1, bool isWeapon2Ranged = false,
                                string weaponName3 = "", int damageDiceNumber3 = 1, int damageDiceMax3 = 1, bool isWeapon3Ranged = false,
                                string PCclass = "", int profBonus = 2, int spellModifier = 0, string weakness = "", string resistance = "", int attackNum = 1)
        {

            // WeaponDamageDice, Ammo, ATK Bonus Melee, ATK Bonus Ranged 

            // Completed Sample Character { "Kyler", "Human", "Cleric", 4, 2, 3, 2, -1, 1, 2, true, false, true, false, false, false, true, false, false, true, false, false, false, true, false, false, false, false, false, false, false, false, false, false, 13, 13, 30, 16, 170, "Greatsword", "Chain Mail", 6, 2, 0, 2, 2, true}
            //        

            this.PCclass = PCclass;
            this.race = race;
            this.name = name;

            this.str = str;
            this.dex = dex;
            this.con = con;
            this.intel = intel;
            this.wis = wis;
            this.cha = cha;
            this.maxHealth = maxHealth;
            this.health = health;
            health = maxHealth;
            this.speed = speed;
            this.ac = ac;
            this.gold = gold;

            this.weaponName = weaponName;
            this.armorName = armorName;
            this.damageDiceMax = damageDiceMax;
            this.damageDiceNumber = damageDiceNumber;
            this.ammo = ammo;
            this.meleeATKBonus = meleeATKBonus;
            this.rangedATKBonus = rangedATKBonus;

            this.weaponName2 = weaponName2;
            this.weaponName3 = weaponName3;
            this.damageDiceNumber2 = damageDiceNumber2;
            this.damageDiceNumber3 = damageDiceNumber3;
            this.damageDiceMax2 = damageDiceMax2;
            this.damageDiceMax3 = damageDiceMax3;
            this.isWeapon2Ranged = isWeapon2Ranged;
            this.isWeapon3Ranged = isWeapon3Ranged;

            this.isWeaponRanged = isWeaponRanged;
            this.stealthDis = stealthDis;

            this.spellPoints = spellPoints;
            maxSpellPoints = spellPoints;

            this.attackNum = attackNum;

            this.spellModifier = spellModifier;
            this.weakness = weakness;
            this.resistance = resistance;
            if (this.health == 0)
            {
                this.health = this.maxHealth;
            }
        }

        public double getHealthPercentage()
        {
            return health / (double)maxHealth * 100;
        }

        public void DispStats()
        {
            Console.WriteLine("StrMod: " + str + " DexMod: " + dex + " ConstMod: " + con);
            Console.WriteLine("IntMod: " + intel + " WisMod: " + wis + " ChaMod: " + cha);
            Console.WriteLine("Max Health: " + maxHealth + " Current Health: " + health + " Speed: " + speed);
            Console.WriteLine("Armor Class: " + ac + " Gold: " + gold);
            Console.WriteLine("You are wielding a " + weaponName + ", and wearing " + armorName + " armor.");
            Console.ReadLine();
        }
    }
}


