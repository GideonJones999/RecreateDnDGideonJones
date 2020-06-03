using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecreateDND
{
    public class Spells
    {

        public static readonly Spells[] spells = new Spells[]
        {
            new FireBolt(),
            new ChillingTouch(),
            new ViciousMockery(),
            new FireBall(),
            new FireSerpants(),
            new LightArrows(),
            new SpiritWeapon(),
            new IceBreath(),
            new CallLightning(),
            new EldrichBlast(),
            new ShockingGrasp(),
            new CureWounds(),
            new LeachLife(),
        };

        public string spellName = "", spellDamageType = "";

        public PlayerClass[] classes;

        public int spellDamageDiceNumber = 0, spellHealDiceNumber = 0, spellDiceMax = 0, spellPoints = 0;

        public static Spells[] GetSpells(Player player)
        {
            ArrayList result = new ArrayList();
            foreach (Spells spell in spells)
            {
                foreach (PlayerClass playerClass in spell.classes)
                {
                    if (player.getCharacterStats().PCclass == playerClass.name && player.getCharacterStats().spellPoints >= spell.spellPoints)
                    {
                        result.Add(spell);
                        break;
                    }
                }
            }
            Spells[] array = result.ToArray(typeof(Spells)) as Spells[];
            return array;
        }
        public class FireBolt : Spells
        {
            public FireBolt()
            {
                spellName = "Fire Bolt";
                spellDamageType = "Fire";
                spellDamageDiceNumber = 1;
                spellDiceMax = 4;
                spellPoints = 0;

                classes = new PlayerClass[] { new Wizard(), new Sorcerer(), new Warlock() };

            }
        }
        public class ChillingTouch : Spells
        {
            public ChillingTouch()
            {
                spellName = "Chilling Touch";
                spellDamageType = "Ice";
                spellDamageDiceNumber = 1;
                spellDiceMax = 4;
                spellPoints = 1;

                classes = new PlayerClass[] { new Wizard(), new Sorcerer(), new Warlock() };

            }
        }
        public class ShockingGrasp : Spells
        {
            public ShockingGrasp()
            {
                spellName = "Shocking Grasp";
                spellDamageType = "Lightning";
                spellDamageDiceNumber = 1;
                spellDiceMax = 8;
                spellPoints = 0;

                classes = new PlayerClass[] { new Wizard(), new Sorcerer(), new Warlock() };

            }
        }
        public class EldrichBlast : Spells
        {
            public EldrichBlast()
            {
                spellName = "Eldrich Blast";
                spellDamageDiceNumber = 1;
                spellDiceMax = 8;
                spellPoints = 0;

                classes = new PlayerClass[] { new Warlock() };

            }
        }
        public class ViciousMockery : Spells
        {
            public ViciousMockery()
            {
                spellName = "Vicious Mockery";
                spellDamageType = "Psychic";
                spellDamageDiceNumber = 2;
                spellDiceMax = 4;
                spellPoints = 1;



                classes = new PlayerClass[] { new Bard() };

            }
        }
        public class FireBall : Spells
        {
            public FireBall()
            {
                spellName = "Fire Ball";
                spellDamageType = "Fire";
                spellDamageDiceNumber = 8;
                spellDiceMax = 6;

                spellPoints = 15;

                classes = new PlayerClass[] { new Sorcerer(), new Wizard()};

            }
        }
        public class FireSerpants : Spells
        {
            public FireSerpants()
            {
                spellName = "Fire Serpants";
                spellDamageType = "Fire";
                spellDamageDiceNumber = 1;
                spellDiceMax = 10;

                spellPoints = 2;

                classes = new PlayerClass[] { new Monk(), new Fighter() };

            }
        }
        public class LightArrows : Spells
        {
            public LightArrows()
            {
                spellName = "Arrows of Light";
                spellDamageType = "Radiant";
                spellDamageDiceNumber = 3;
                spellDiceMax = 4;

                spellPoints = 2;

                classes = new PlayerClass[] { new Cleric(), new Paladin() };

            }
        }
        public class SpiritWeapon : Spells
        {
            public SpiritWeapon()
            {
                spellName = "Spiritual Weapon";
                spellDamageDiceNumber = 1;
                spellDiceMax = 8;

                spellPoints = 1;

                classes = new PlayerClass[] { new Warlock(), new Cleric(), new Paladin()};

            }
        }
        public class IceBreath : Spells
        {
            public IceBreath()
            {
                spellName = "Ice Breath";
                spellDamageType = "Ice";
                spellDamageDiceNumber = 2;
                spellDiceMax = 8;

                spellPoints = 1;

                classes = new PlayerClass[] { new Monk(), new Warlock(), new Druid()};

            }
        }
        public class CallLightning : Spells
        {
            public CallLightning()
            {
                spellName = "Call Lightning";
                spellDamageType = "Lightning";
                spellDamageDiceNumber = 1;
                spellDiceMax = 10;

                spellPoints = 2;

                classes = new PlayerClass[] { new Monk(), new Paladin(), new Ranger()};

            }
        }
        public class CureWounds : Spells
        {
            public CureWounds()
            {
                spellName = "Cure Wounds";
                spellDamageType = "Heal";
                spellHealDiceNumber = 1;
                spellDiceMax = 8;

                spellPoints = 1;

                classes = new PlayerClass[] { new Cleric(), new Bard(), new Wizard() };

            }
        }
        public class LeachLife : Spells
        {
            public LeachLife()
            {
                spellName = "Leach Life";
                spellDamageType = "Heal";
                spellHealDiceNumber = 1;
                spellDiceMax = 8;
                spellDamageDiceNumber = 1;

                spellPoints = 1;

                classes = new PlayerClass[] { new Sorcerer() };

            }
        }
        public class BurningHands : Spells
        {
            public BurningHands()
            {
                spellName = "Burning Hands";
                spellDamageType = "Fire";
                spellDamageDiceNumber = 2;
                spellDiceMax = 6;

                spellPoints = 1;

                classes = new PlayerClass[] { new Sorcerer(), new Wizard(), new Warlock() };

            }
        }

    }
}
