using System;
namespace RecreateDND
{
    public abstract class PlayerClass
    {
        private static PlayerClass[] playerClasses = new PlayerClass[] { new Barbarian(), new Bard(), new Cleric(), new Druid(), new Fighter(), new Monk(), new Paladin(), new Ranger(), new Rogue(), new Sorcerer(), new Warlock(), new Wizard()};

        public int str = 0, dex = 0, con = 0, wis = 0, intel = 0, cha = 0, playerSpellPoints = 0;

        public bool strSaving = false, dexSaving = false, constSaving = false, intSaving = false, wisSaving = false,
                                 chaSaving = false, acrobatics = false, animalHandling = false, arcana = false, athletics = false,
                                 deception = false, history = false, insight = false, intimidation = false, investigation = false,
                                 medicine = false, nature = false, perception = false, performance = false, persuasion = false,
                                 religion = false, sleightOfHand = false, stealth = false, survival = false;

        public string name, spellModifier;

        public static PlayerClass[] GetPlayerClasses()
        {
            return playerClasses;
        }
    }

    public class Barbarian : PlayerClass
    {
        public Barbarian()
        {
            name = "Barbarian";
            str = 2;
            con = 1;

            strSaving = true; 
            constSaving = true;
            athletics = true;
            intimidation = true;
        }
    }

    public class Bard : PlayerClass
    {
        public Bard()
        {
            name = "Bard";
            spellModifier = "cha";
            dex = 1;
            cha = 2;
            playerSpellPoints = 3;

            dexSaving = true;
            chaSaving = true;
            intimidation = true;
            perception = true;
            persuasion = true;
        }
    }

    public class Cleric : PlayerClass
    {
        public Cleric()
        {
            name = "Cleric";
            spellModifier = "const";
            intel = 2;
            wis = 1;

            playerSpellPoints = 4;

            wisSaving = true;
            chaSaving = true;
            insight = true;
            medicine = true;
        }
    }

    public class Druid : PlayerClass
    {
        public Druid()
        {
            name = "Druid";
            spellModifier = "wis";
            wis = 2;
            con = 1;

            playerSpellPoints = 4;

            wisSaving = true;
            constSaving = true;
            animalHandling = true;
            survival = true;
        }
    }

    public class Fighter : PlayerClass
    {
        public Fighter()
        {
            name = "Fighter";
            spellModifier = "wis";
            str = 2;
            con = 1;

            playerSpellPoints = 2;

            strSaving = true;
            constSaving = true;
            acrobatics = true;
            perception = true;
        }
    }

    public class Monk : PlayerClass
    {
        public Monk()
        {
            name = "Monk";
            spellModifier = "dex";
            dex = 2;
            str = 1;

            playerSpellPoints = 4;

            dexSaving = true;
            strSaving = true;
            acrobatics = true;
            insight = true;
        }
    }

    public class Paladin : PlayerClass
    {
        public Paladin()
        {
            name = "Paladin";
            spellModifier = "cha";
            str = 1;
            wis = 1;
            cha = 1;

            playerSpellPoints = 4;

            wisSaving = true;
            chaSaving = true;
            religion = true;
            intimidation = true;
        }
    }

    public class Ranger : PlayerClass
    {
        public Ranger()
        {
            name = "Ranger";
            spellModifier = "wis";
            dex = 1;
            wis = 1;
            str = 1;

            playerSpellPoints = 3;

            strSaving = true;
            dexSaving = true;
            nature = true;
            survival = true;
        }
    }

    public class Rogue : PlayerClass
    {
        public Rogue()
        {
            name = "Rogue";
            spellModifier = "intel";
            dex = 2;
            intel = 1;

            playerSpellPoints = 2;

            dexSaving = true;
            intSaving = true;
            acrobatics = true;
            stealth = true;
        }
    }

    public class Sorcerer : PlayerClass
    {
        public Sorcerer()
        {
            name = "Sorcerer";
            spellModifier = "cha";
            cha = 2;
            con = 1;

            playerSpellPoints = 6;

            chaSaving = true;
            constSaving = true;
            deception = true;
            insight = true;
            arcana = true;
        }
    }

    public class Warlock : PlayerClass
    {
        public Warlock()
        {
            name = "Warlock";
            spellModifier = "wis";
            wis = 2;
            cha = 1;

            playerSpellPoints = 6;

            wisSaving = true;
            chaSaving = true;
            history = true;
            investigation = true;
            arcana = true;
        }
    }

    public class Wizard : PlayerClass
    {
        public Wizard()
        {
            name = "Wizard";
            spellModifier = "intel";
            intel = 2;
            wis = 1;

            playerSpellPoints = 6;

            intSaving = true;
            wisSaving = true;
            medicine = true;
            insight = true;
            arcana = true;
            

        }
    }

}
