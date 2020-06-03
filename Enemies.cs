using System;
namespace RecreateDND
{
    public class Enemies
    {

        public static Random r = new Random();
        static string weaponName, armorName, PCclass, race, name, weaponName2, weaponName3, weakness, resistance;
        static int str, dex, con, intel, wis, cha, maxHealth, health, speed, ac, gold, profbonus, ammo, meleeATKBonus, 
            rangedATKBonus, damageDiceMax, damageDiceNumber, damageDiceNumber2, damageDiceMax2, damageDiceNumber3, damageDiceMax3, attackNum;
        static bool stealthDis, isWeaponRanged, isWeapon2Ranged, isWeapon3Ranged;
        public static CharacterStats CreateEnemy(string enemyName = "")
        {
            switch (enemyName)
            {

                case "Dummy":
                    name = "Dummy";
                    race = "Dummy";
                    str = -1;
                    maxHealth = 10;
                    speed = 10;
                    ac = 10;
                    gold = 3;
                    weaponName = "Rusty Sword";
                    armorName = "Cracked Leather";
                    damageDiceNumber = 1;
                    damageDiceMax = 4;
                    attackNum = 1;
                    break;
                case "Goblin":
                    name = "Goblin";
                    race = "Goblin";
                    str = -1;
                    dex = 2;
                    wis = -1;
                    cha = -1;
                    maxHealth = RollSilent(2, 6);
                    ac = 15;
                    weaponName = "Scimitar";
                    meleeATKBonus = 4;
                    damageDiceNumber = 1;
                    damageDiceMax = 4;
                    damageDiceNumber2 = 1;
                    damageDiceMax2 = 6;
                    isWeapon2Ranged = true;
                    break;
                case "triAttacker":
                    name = "TriAttack";
                    str = 5;
                    meleeATKBonus = 9999;
                    weaponName = "Attack1";
                    weaponName2 = "Attack2";
                    weaponName3 = "Attack3";
                    maxHealth = 10000000;
                    break;
                case "ancientRedDragon":
                    name = "Ancient Red Dragon";
                    ac = 22;
                    maxHealth = RollSilent(28, 20, 252);
                    str = 10;
                    dex = 0;
                    con = 9;
                    intel = 8;
                    wis = 2;
                    cha = 6;
                    meleeATKBonus = 17;
                    weaponName = "Bite";
                    damageDiceNumber = 3;
                    damageDiceMax = 10;
                    weaponName2 = "Claw";
                    damageDiceNumber2 = 2;
                    damageDiceMax2 = 10;
                    weaponName3 = "Tail";
                    damageDiceNumber3 = 3;
                    damageDiceMax3 = 6;
                    attackNum = 3;
                    break;
                case "Skeleton":
                    name = "Skeleton";
                    ac = 12;
                    maxHealth = RollSilent(3, 10, 5);
                    str = 2;
                    dex = 1;
                    con = 0;
                    intel = 0;
                    wis = 0;
                    cha = 0;
                    meleeATKBonus = 3;
                    weaponName = "Rib Bone Throw";
                    damageDiceNumber = 2;
                    damageDiceMax = 6;
                    isWeaponRanged = true;
                    weaponName2 = "Sharp Bone";
                    damageDiceNumber2 = 1;
                    damageDiceMax2 = 10;
                    attackNum = 2;
                    break;
                case "Ghost":
                    name = "Ghost";
                    ac = 15;
                    maxHealth = RollSilent(4, 8, 10);
                    str = 3;
                    dex = 0;
                    con = 0;
                    intel = 0;
                    wis = 2;
                    cha = 0;
                    meleeATKBonus = 4;
                    weaponName = "Slime";
                    damageDiceNumber = 2;
                    damageDiceMax = 6;
                    isWeaponRanged = true;
                    weaponName2 = "Ghostly Hug";
                    damageDiceNumber2 = 4;
                    damageDiceMax2 = 4;
                    attackNum = 1;
                    weakness = "Radiant";
                    break;
                case "Vampire":
                    name = "Vampire";
                    ac = 16;
                    maxHealth = RollSilent(4, 12, 15);
                    str = 4;
                    dex = 3;
                    con = 4;
                    intel = 0;
                    wis = 2;
                    cha = 2;
                    meleeATKBonus = 5;
                    weaponName = "Fang";
                    damageDiceNumber = 2;
                    damageDiceMax = 6;
                    weaponName2 = "Vampiric Drain";
                    damageDiceNumber2 = 2;
                    damageDiceMax2 = 10;
                    attackNum = 2;
                    break;
                case "Zombie":
                    name = "Zombie";
                    ac = 10;
                    maxHealth = RollSilent(5, 10, 5);
                    str = 4;
                    dex = -1;
                    con = 4;
                    intel = 0;
                    wis = 0;
                    cha = 0;
                    meleeATKBonus = 5;
                    weaponName = "Bite";
                    damageDiceNumber = 3;
                    damageDiceMax = 6;
                    weaponName2 = "Claw";
                    damageDiceNumber2 = 1;
                    damageDiceMax2 = 10;
                    attackNum = 2;
                    weakness = "Fire";
                    break;
                case "Raccoon":
                    name = "Rabid Raccoon";
                    ac = 11;
                    maxHealth = RollSilent(1, 10);
                    str = 0;
                    dex = 3;
                    con = 1;
                    intel = -5;
                    wis = 3;
                    cha = -5;
                    meleeATKBonus = 1;
                    weaponName = "Bite";
                    damageDiceNumber = 1;
                    damageDiceMax = 3;

                    break;

            }



            health = maxHealth;
            return new CharacterStats(name, race, str, dex, con, wis, intel, cha, maxHealth, speed, ac, gold, 0, 0, weaponName, armorName, damageDiceNumber, damageDiceMax, health, ammo, meleeATKBonus, rangedATKBonus, stealthDis, isWeaponRanged,
                weaponName2, damageDiceNumber2, damageDiceMax2, isWeapon2Ranged, weaponName3, damageDiceNumber3, damageDiceMax3, isWeapon3Ranged,
                PCclass, profbonus, 0, weakness, resistance, attackNum);

        }

        static int RollSilent(int diceCount, int maxRoll, int modifier = 0)
        {
            int total = 0;
            for (int i = 0; i < diceCount; i++)
            {
                total += r.Next(1, maxRoll);
            }
            total += modifier;
            return total;
        }
    }
}
