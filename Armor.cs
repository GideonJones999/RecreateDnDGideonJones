using System;
using System.Collections;
using System.Collections.Generic;

namespace RecreateDND
{
    public abstract class Armor
    {
        private static readonly Armor[] armors = new Armor[] {
            new Padded(),
            new Leather(),
            new Studded(),
            new ScaleMail(),
            new ChainMail(),
        };

        public PlayerClass[] classes;

        public int ac = 0, maxBonus = 0;

        public string name;

        public bool stealthDis = false;

        public static List<Armor> GetArmors(string pcClass, string name)
        {
            List<Armor> result = new List<Armor>();
            foreach (Armor armor in armors)
            {
                foreach(PlayerClass playerClass in armor.classes)
                {
                    if (pcClass == playerClass.name)
                    {
                        result.Add(armor);
                        break;
                    }
                }
            }
            if (name == "Gideon" || name == "Kyler")
            {
                result.Add(new ShardPlate());
            }
            return result;
        }
    }

    public class Padded : Armor
    {
        public Padded()
        {
            name = "Padded";
            ac = 11;
            maxBonus = 2;
            classes = new PlayerClass[] { new Bard(), new Rogue(), new Ranger(), new Druid() };
        }
    }
    public class Leather : Armor
    {
        public Leather()
        {
            name = "Leather";
            ac = 11;
            maxBonus = 2;
            classes = new PlayerClass[] { new Fighter(), new Barbarian(), new Cleric(), new Paladin(), new Warlock(), new Wizard(), new Sorcerer(), new Bard(), new Rogue(), new Ranger(), new Druid() };
        } 
    }

    public class Studded : Armor
    {
        public Studded()
        {
            name = "Studded";
            ac = 12;
            maxBonus = 2;
            classes = new PlayerClass[] { new Wizard(), new Sorcerer(), new Bard(), new Rogue(), new Ranger(), new Druid() };
        }
    }

    public class ScaleMail : Armor
    {
        public ScaleMail()
        {
            name = "Scale Mail";
            ac = 14;
            classes = new PlayerClass[] { new Fighter(), new Barbarian(), new Cleric(), new Paladin() };
            stealthDis = true;
        }
    }

    public class ChainMail : Armor
    {
        public ChainMail()
        {
            name = "Chain Mail";
            ac = 16;
            classes = new PlayerClass[] { new Fighter(), new Barbarian(), new Cleric(), new Paladin() };
            stealthDis = true;
        }
    }
    public class ShardPlate : Armor
    {
        public ShardPlate()
        {
            name = "Shard Plate";
            ac = 100;
            classes = new PlayerClass[] { new Barbarian(), new Bard(), new Cleric(), new Druid(), new Fighter(), new Monk(), new Paladin(), new Ranger(), new Rogue(), new Sorcerer(), new Warlock(), new Wizard() };
        }
    }
}
