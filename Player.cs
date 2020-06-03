using System;
namespace RecreateDND
{
    public class Player
    {
        private string name;

        private PlayerStats playerStats;

        private CharacterStats characterStats;

        static readonly Random dice = new Random();
        static int RollDice(int diceCount, int maxRoll, int modifier = 0)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int temp = 0, total = 0, final = 0;
            string disp = "";
            for (int i = 0; i < diceCount; i++)
            {
                for (int k = 0; k < 20; k++)
                {
                    temp = dice.Next(1, maxRoll);
                    System.Threading.Thread.Sleep(100);

                    if (temp <= 9)
                        disp = "  " + temp;
                    else if (temp <= 99)
                        disp = " " + temp;
                    else
                        disp = "" + temp;

                    Console.Write(disp);

                    Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop);
                    k++;
                }

                final = temp;
                total += final;
                Console.Write(final + "  ");
            }
            total += modifier;
            return total;
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        static int RollSilent(int diceCount, int maxRoll, int modifier = 0)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int total = 0;
            for (int i = 0; i < diceCount; i++)
            {
                total += dice.Next(1, maxRoll);
            }
            total += modifier;
            Console.ForegroundColor = ConsoleColor.Cyan;
            return total;

        }
        public Player()
        {
            playerStats = new PlayerStats();
            characterStats = new CharacterStats();
        }

        public PlayerStats getPlayerStats()
        {
            return playerStats;
        }

        public CharacterStats getCharacterStats()
        {
            return characterStats;
        }

        public void setName(string name) {

            this.name = name;

        }

        public string getName()
        {
            return name;

        }

        public void InitPlayer(PlayerClass playerClass)
        {
            characterStats.PCclass = playerClass.name;
            characterStats.str += playerClass.str;
            characterStats.dex += playerClass.dex;
            characterStats.con += playerClass.con;
            characterStats.wis += playerClass.wis;
            characterStats.intel += playerClass.intel;
            characterStats.cha += playerClass.cha;

            characterStats.maxSpellPoints = playerClass.playerSpellPoints;
            characterStats.spellPoints = playerClass.playerSpellPoints;

            playerStats.strSaving = playerClass.strSaving; 
            playerStats.dexSaving = playerClass.dexSaving; 
            playerStats.constSaving = playerClass.constSaving; 
            playerStats.intSaving = playerClass.intSaving; 
            playerStats.wisSaving = playerClass.wisSaving;                   
            playerStats.chaSaving = playerClass.chaSaving; 
            playerStats.acrobatics = playerClass.acrobatics; 
            playerStats.animalHandling = playerClass.animalHandling; 
            playerStats.arcana = playerClass.arcana; 
            playerStats.athletics = playerClass.athletics;                 
            playerStats.deception = playerClass.deception; 
            playerStats.history = playerClass.history; 
            playerStats.insight = playerClass.insight; 
            playerStats.intimidation = playerClass.intimidation; 
            playerStats.investigation = playerClass.investigation;                  
            playerStats.medicine = playerClass.medicine; 
            playerStats.nature = playerClass.nature; 
            playerStats.perception = playerClass.perception; 
            playerStats.performance = playerClass.performance; 
            playerStats.persuasion = playerClass.persuasion;                 
            playerStats.religion = playerClass.religion; 
            playerStats.sleightOfHand = playerClass.sleightOfHand; 
            playerStats.stealth = playerClass.stealth;
            playerStats.survival = playerClass.survival;



            Random r = new Random();
            characterStats.str += r.Next(1, 2);
            characterStats.dex += r.Next(1, 2);
            characterStats.con += r.Next(1, 2);
            characterStats.wis += r.Next(1, 2);
            characterStats.intel += r.Next(1, 2);
            characterStats.cha += r.Next(1, 2);

            characterStats.gold = r.Next(2, 7) * 100;

            characterStats.maxHealth = characterStats.con + 10;
            characterStats.health = characterStats.maxHealth;

            characterStats.str = Math.Min(characterStats.str, 5);
            characterStats.dex = Math.Min(characterStats.dex, 5);
            characterStats.con = Math.Min(characterStats.con, 5);
            characterStats.wis = Math.Min(characterStats.wis, 5);
            characterStats.intel = Math.Min(characterStats.intel, 5);
            characterStats.cha = Math.Min(characterStats.cha, 5);

            characterStats.meleeATKBonus = 2 + characterStats.str; 
            characterStats.rangedATKBonus = 2 + characterStats.dex;

            if (playerClass.spellModifier == "str")
            {
                characterStats.spellModifier = characterStats.str;
            }
            else
            if (playerClass.spellModifier == "dex")
            {
                characterStats.spellModifier = characterStats.dex;
            }
            else
            if (playerClass.spellModifier == "con")
            {
                characterStats.spellModifier = characterStats.con;
            }
            else
            if (playerClass.spellModifier == "intel")
            {
                characterStats.spellModifier = characterStats.intel;
            }
            else
            if (playerClass.spellModifier == "wis")
            {
                characterStats.spellModifier = characterStats.wis;
            }
            else
            if (playerClass.spellModifier == "cha")
            {
                characterStats.spellModifier = characterStats.cha;
            }
        }

        

        public void InitPlayerRace(PlayerRace playerRace)
        {
            characterStats.race = playerRace.name;
            characterStats.str += playerRace.str;
            characterStats.dex += playerRace.dex;
            characterStats.con += playerRace.con;
            characterStats.wis += playerRace.wis;
            characterStats.intel += playerRace.intel;
            characterStats.cha += playerRace.cha;

            characterStats.speed = playerRace.speed;
        }

            public void SetWeapon(Weapon weapon)
        {
            characterStats.weaponName = weapon.name;
            characterStats.damageDiceMax = weapon.damageDiceMax;
            characterStats.damageDiceNumber = weapon.damageDiceNumber;
            characterStats.ammo = weapon.ammo;
            characterStats.isWeaponRanged = weapon.isWeaponRanged;
        }

        public void SetArmor(Armor armor)
        {
            characterStats.armorName = armor.name;
            characterStats.ac = armor.ac + Math.Min(characterStats.dex, armor.maxBonus);
            characterStats.stealthDis = armor.stealthDis;
        }

        public void GiveGold(int gold)
        {
            characterStats.gold += gold;
        }

        public int CastSpell(Spells spell, CharacterStats enemy)
        {
            Random dice = new Random();
            if (spell.spellDamageDiceNumber > 0)
            {
                int totalDamage = 0;
                for (int i = 0; i < spell.spellDamageDiceNumber; i++)
                {
                    totalDamage += dice.Next(1, spell.spellDiceMax);
                }
                totalDamage += getCharacterStats().spellModifier;
                if (enemy.weakness == spell.spellDamageType)
                    totalDamage = totalDamage * 2;
                else if (enemy.resistance == spell.spellDamageType)
                    totalDamage = totalDamage / 2;
                return totalDamage;
            }
            if (spell.spellHealDiceNumber > 0)
            {
                int totalHeal = 0;
                for (int i = 0; i < spell.spellHealDiceNumber; i++)
                {
                    totalHeal += dice.Next(1, spell.spellDiceMax);
                }
                totalHeal += getCharacterStats().spellModifier;
                
                return totalHeal;
            }
            return 0;
        }
        public bool AbilityCheck(string ability, int checkDC, int tries = 1)
        {
            int abilityModifier = 0;
            switch (ability)
            {
                case "strSaving":
                    abilityModifier = getCharacterStats().str;
                    if (getPlayerStats().strSaving == true)
                        abilityModifier *= 2;
                    break;
                case "dexSaving":
                    abilityModifier = getCharacterStats().dex;
                    if (getPlayerStats().dexSaving == true)
                        abilityModifier *= 2;
                    break;
                case "conSaving":
                    abilityModifier = getCharacterStats().con;
                    if (getPlayerStats().constSaving == true)
                        abilityModifier *= 2;
                    break;
                case "wisSaving":
                    abilityModifier = getCharacterStats().wis;
                    if (getPlayerStats().wisSaving == true)
                        abilityModifier *= 2;
                    break;
                case "intSaving":
                    abilityModifier = getCharacterStats().intel;
                    if (getPlayerStats().intSaving == true)
                        abilityModifier *= 2;
                    break;
                case "chaSaving":
                    abilityModifier = getCharacterStats().cha;
                    if (getPlayerStats().chaSaving == true)
                        abilityModifier *= 2;
                    break;
                case "str":
                    abilityModifier = getCharacterStats().str;
                    break;
                case "dex":
                    abilityModifier = getCharacterStats().dex;
                    break;
                case "con":
                    abilityModifier = getCharacterStats().con;
                    break;
                case "wis":
                    abilityModifier = getCharacterStats().wis;
                    break;
                case "int":
                    abilityModifier = getCharacterStats().intel;
                    break;
                case "cha":
                    abilityModifier = getCharacterStats().cha;
                    break;
                case "acrobatics":
                    if (getPlayerStats().acrobatics)
                        abilityModifier = getCharacterStats().profbonus;
                    break;
                case "animalHandling":
                    if (getPlayerStats().animalHandling)
                        abilityModifier = getCharacterStats().profbonus;
                    break;
                case "arcana":
                    if (getPlayerStats().arcana)
                        abilityModifier = getCharacterStats().profbonus;
                    break;
                case "history":
                    if (getPlayerStats().history)
                        abilityModifier = getCharacterStats().profbonus;
                    break;
                case "insight":
                    if (getPlayerStats().insight)
                        abilityModifier = getCharacterStats().profbonus;
                    break;
                case "intimidation":
                    if (getPlayerStats().intimidation)
                        abilityModifier = getCharacterStats().profbonus;
                    break;
                case "investigation":
                    if (getPlayerStats().investigation)
                        abilityModifier = getCharacterStats().profbonus;
                    break;
                case "medicine":
                    if (getPlayerStats().medicine)
                        abilityModifier = getCharacterStats().profbonus;
                    break;
                case "nature":
                    if (getPlayerStats().nature)
                        abilityModifier = getCharacterStats().profbonus;
                    break;
                case "perception":
                    if (getPlayerStats().perception)
                        abilityModifier = getCharacterStats().profbonus;
                    break;
                case "performance":
                    if (getPlayerStats().performance)
                        abilityModifier = getCharacterStats().profbonus;
                    break;
                case "religion":
                    if (getPlayerStats().religion)
                        abilityModifier = getCharacterStats().profbonus;
                    break;
                case "sleightOfHand":
                    if (getPlayerStats().sleightOfHand)
                        abilityModifier = getCharacterStats().profbonus;
                    break;
                case "stealth":
                    if (getPlayerStats().stealth)
                        abilityModifier = getCharacterStats().profbonus;
                    break;
                case "survival":
                    if (getPlayerStats().survival)
                        abilityModifier = getCharacterStats().profbonus;
                    break;
                default:
                    abilityModifier = 0;
                    break;
            }

            for (int i = 0; i < tries; i++)
            {
                if (RollDice(1, 20, abilityModifier) >= checkDC)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public void LongRest(Player player)
        {
            player.getCharacterStats().health = player.getCharacterStats().maxHealth;
            player.getCharacterStats().spellPoints = player.getCharacterStats().maxSpellPoints;
            Console.WriteLine("You performed a long rest!");
        }

        public void playerLevelUp(Player player)
        {
            Console.WriteLine("You leveled up!");
            player.getCharacterStats().maxHealth += RollSilent(1, 8, player.getCharacterStats().con);
            upgradeStat:
            switch (RollSilent(1, 6))
            {
                case 1: player.getCharacterStats().str += 1;
                    if (player.getCharacterStats().str > 5)
                    {
                        player.getCharacterStats().str = 5;
                        goto upgradeStat;
                    }
                    break;
                case 2:
                    player.getCharacterStats().dex += 1;
                    if (player.getCharacterStats().dex > 5)
                    {
                        player.getCharacterStats().dex = 5;
                        goto upgradeStat;
                    }
                    break;
                case 3:
                    player.getCharacterStats().con += 1;
                    if (player.getCharacterStats().con > 5)
                    {
                        player.getCharacterStats().con = 5;
                        goto upgradeStat;
                    }
                    break;
                case 4:
                    player.getCharacterStats().wis += 1;
                    if (player.getCharacterStats().wis > 5)
                    {
                        player.getCharacterStats().wis = 5;
                        goto upgradeStat;
                    }
                    break;
                case 5:
                    player.getCharacterStats().intel += 1;
                    if (player.getCharacterStats().intel > 5)
                    {
                        player.getCharacterStats().intel = 5;
                        goto upgradeStat;
                    }
                    break;
                case 6:
                    player.getCharacterStats().cha += 1;
                    if (player.getCharacterStats().cha > 5)
                    {
                        player.getCharacterStats().cha = 5;
                        goto upgradeStat;
                    }
                    break;
            }
            if(player.getCharacterStats().maxSpellPoints > 0)
            {
                player.getCharacterStats().maxSpellPoints += RollSilent(2,4);
            }
            Console.WriteLine("Your stats have increased!");
        }
    }

}
