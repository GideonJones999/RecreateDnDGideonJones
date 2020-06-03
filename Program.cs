using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace RecreateDND
{

    class Program
    {

        private static readonly Random dice = new Random();

        private static readonly Random randChoice = new Random();

        private readonly Remark remark = new Remark(); // to be able to get funny comments

        private readonly Enemies GetEnemies = new Enemies();

        private static bool DEBUG_BATTLE = false;
        private static bool DEBUG_MODE = false;

        static void Main(string[] args)
        {
            Console.SetWindowSize(90, 25);
            Player player = new Player();
            StartScreen start = new StartScreen();
            start.Main();

            // Keep slowtext, but speed past setup
            if (DEBUG_BATTLE)
            {
                player.setName("Kyler");
                player.InitPlayerRace(new Dragonborn());
                player.InitPlayer(new Paladin());
                Weapon weapon = new Dagger();
                Armor armor = new ShardPlate();
                player.SetWeapon(weapon);
                player.SetArmor(armor);

                //debug
                StartFight(player, Enemies.CreateEnemy("Dummy"));
                StartFight(player, Enemies.CreateEnemy("Goblin"));
                StartFight(player, Enemies.CreateEnemy("Skeleton"));
                StartFight(player, Enemies.CreateEnemy("Zombie"));
                StartFight(player, Enemies.CreateEnemy("Ghost"));
                StartFight(player, Enemies.CreateEnemy("ancientRedDragon"));
                StartFight(player, Enemies.CreateEnemy("triAttacker"));

            }
            else
            {
                player.setName(Intro());
                InitiatePlayer(player);
                ChooseWeapon(player);
                ChooseArmor(player);
                player.getCharacterStats().DispStats();
                CampaignStart(player);
            }

            Console.ReadLine();

        }

        static void CampaignStart(Player player)
        {
            // Start your campaign here!
            Conversation1(player);
        }

        static void Conversation1(Player player)
        {
            SlowText("Well done, you were able to beat up a test dummy.", 10, ConsoleColor.DarkGray);
            SlowText("There is another type of check in this game, it tests to see if you can succeed on a test.", 10, ConsoleColor.DarkGray);
            SlowText("Here, lets try a check. Try to steal something from me with Sleight Of Hand!", 10, ConsoleColor.DarkGray);
            if (player.AbilityCheck("sleightOfHand", 10))
            {
                SlowText("You succeeded!");
                player.GiveGold(10);
                SlowText("Very nice! Can you give that gold back to me?", 10, ConsoleColor.DarkGray);
                SlowText("You try to persuade him to keep his gold...");
                if (player.AbilityCheck("persuasion", 10))
                {
                    SlowText("I guess you can keep it...", 10, ConsoleColor.DarkGray);
                }
                else
                {
                    SlowText("I'll be taking the gold then.", 10, ConsoleColor.DarkGray);
                    SlowText("You lost 10 gold!");
                }
            }
            else
            {
                SlowText("You failed!", 10, ConsoleColor.DarkGray);
                player.getCharacterStats().health -= 1;
                SlowText("You lose one health!");
            }
            SlowText("That is how you do an ability check.", 10, ConsoleColor.DarkGray);
        }

        #region Choose @ Beginning
        static string Intro()
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            string Name;
            SlowText("What is your name?", 10, ConsoleColor.DarkGray);

            if (DEBUG_MODE)
                Name = "Gideon";
            else
                Name = Console.ReadLine();

            Name = textInfo.ToTitleCase(Name);

            return Name;
        }

        static void InitiatePlayer(Player player)
        {
            ChooseRace(player);
            ChooseClass(player);
        }

        private static void ChooseRace(Player player)
        {
            CharacterStats characterStats = player.getCharacterStats();

            PlayerRace[] playerRaces = PlayerRace.GetPlayerRaces();

            SlowText("What is your race?", 5, ConsoleColor.DarkGray);
            for (int i = 0; i < playerRaces.Length; i++)
            {
                SlowText((i + 1) + " - " + playerRaces[i].name, 5, ConsoleColor.DarkGray);
            }

            int choice;
            if (DEBUG_MODE)
                choice = 5;
            else
                choice = int.Parse(Console.ReadLine());

            if (choice > playerRaces.Length)
            {
                SlowText("Uh, I don't think that's an option. Try again.", 15, ConsoleColor.DarkGray);
                ChooseRace(player);
            }
            else
            {
                PlayerRace chosenPlayerRace = playerRaces[choice - 1];
                player.InitPlayerRace(chosenPlayerRace);
            }
            Console.WriteLine();
        }

        private static void ChooseClass(Player player)
        {
            PlayerClass[] playerClasses = PlayerClass.GetPlayerClasses();

            SlowText("What is your class?", 5, ConsoleColor.DarkGray);

            for (int i = 0; i < playerClasses.Length; i++)
            {
                SlowText((i + 1) + " - " + playerClasses[i].name, 5, ConsoleColor.DarkGray);
            }

            int choice;
            if (DEBUG_MODE)
                choice = 7;
            else
                choice = int.Parse(Console.ReadLine());


            if (choice > playerClasses.Length)
            {
                SlowText("Uh, I don't think that's an option. Try again.", 15, ConsoleColor.DarkGray);
                ChooseClass(player);
            }
            else
            {
                PlayerClass chosenPlayerClass = playerClasses[choice - 1]; // write code to choose the player class 
                player.InitPlayer(chosenPlayerClass);
            }
            Console.WriteLine();
        }

        private static void ChooseWeapon(Player player)
        {
            SlowText("Choose a weapon.", 10, ConsoleColor.DarkGray);

            Weapon[] weapons = Weapon.GetWeapons(player.getCharacterStats().str, player.getCharacterStats().dex, player.getName());

            for (int i = 0; i < weapons.Length; i++)
            {
                SlowText((i + 1) + " - " + weapons[i].name, 5, ConsoleColor.DarkGray);
            }

            int choice;
            if (DEBUG_MODE)
                choice = 13;
            else
                choice = int.Parse(Console.ReadLine());

            if (choice > weapons.Length)
            {
                SlowText("Uh, I don't think that's an option. Try again.", 15, ConsoleColor.DarkGray);
                ChooseClass(player);
            }
            else
            {
                Weapon weapon = weapons[choice - 1];
                player.SetWeapon(weapon);
            }
            Console.WriteLine();
        }

        private static void ChooseArmor(Player player)
        {

            List<Armor> armors = Armor.GetArmors(player.getCharacterStats().PCclass, player.getName());

            if (armors.Count == 0)
            {
                SlowText("Your class does not allow you to wear armor.", 5, ConsoleColor.DarkGray);
                player.getCharacterStats().armorName = "No";
            }
            else
            {
                SlowText("Choose your Armor:", 10, ConsoleColor.DarkGray);

                for (int i = 0; i < armors.Count; i++)
                {
                    SlowText((i + 1) + " - " + armors[i].name, 5, ConsoleColor.DarkGray);
                }

                int choice;
                if (DEBUG_MODE)
                    choice = 4;
                else
                    choice = int.Parse(Console.ReadLine());

                if (choice > armors.Count)
                {
                    SlowText("Uh, I don't think that's an option. Try again.", 15, ConsoleColor.DarkGray);
                    ChooseClass(player);
                }
                else
                {
                    Armor armor = armors[choice - 1];
                    player.SetArmor(armor);
                    Console.WriteLine("You chose " + armor.name + " armor!");
                }
            }
            Console.WriteLine();
        }

        #endregion

        #region Fighting

        static void StartFight(Player player, CharacterStats enemy)
        {
            // Roll initiative

            SlowText(enemy.name + " has challenged you!", 30);
            SlowText("Roll Initiative!");

            int playerDice = RollSilent(1, 20) + player.getCharacterStats().dex;
            SlowTextWrite(playerDice - player.getCharacterStats().dex + " + " + player.getCharacterStats().dex + " vs ", 50);
            int enemyDice = RollSilent(1, 20) + enemy.dex;
            SlowText(enemyDice - enemy.dex + " + " + enemy.dex, 50);

            if (playerDice >= enemyDice)
            {
                SlowText("The player goes first!");
                playerTurn(player, enemy);
            }
            else
            {
                SlowText("The enemy goes first!");
                if (randChoice.Next(1, 2) == 1)
                    SlowText("It's a speedy boi!", 10, ConsoleColor.Gray);

            }
            while (player.getCharacterStats().health > 0 && enemy.health > 0)
            {
                enemyTurn(player, enemy);
                if (player.getCharacterStats().health > 0 && enemy.health > 0)
                    playerTurn(player, enemy);
                else
                    break;
            }
            if (player.getCharacterStats().health <= 0)
            {
                SlowText("You have fallen...", 70);
                gameEnd();
            }

            else
                SlowText("You have slain " + enemy.name + "!");

            SlowText("You have gained " + enemy.gold + " gold!");

            player.GiveGold(enemy.gold);
        }

        public static void playerTurn(Player player, CharacterStats enemy)
        {
            int rollToHit = 0;
            int damageToEnemy = 0;

            playerTurnStart:
            Console.WriteLine();
            SlowText("What would you like to do?");
            SlowText("1 - Weapon Attack");
            SlowText("2 - Cast Spell");
            SlowText("3 - Insult");
            SlowText("4 - View Player Stats");
            int answer;
            if (DEBUG_MODE)
                answer = 1;
            else
                try
                {
                    answer = int.Parse(Console.ReadLine());
                }
                catch
                {
                    SlowText("That is not a valid input.");
                    goto playerTurnStart;
                }


            switch (answer)
            {

                case 1:
                    for (int i = 0; i < player.getCharacterStats().attackNum; i++)
                    {
                        if (player.getCharacterStats().ammo == 0 && player.getCharacterStats().isWeaponRanged)
                        {
                            Console.WriteLine("You have no ammo left!");
                            break;
                        }

                        SlowText("You attempt to hit - ");


                        if (!player.getCharacterStats().isWeaponRanged)
                            rollToHit = RollDice(1, 20, player.getCharacterStats().meleeATKBonus);
                        else if (player.getCharacterStats().isWeaponRanged)
                            rollToHit = RollDice(1, 20, player.getCharacterStats().rangedATKBonus);
                        Console.WriteLine(rollToHit + " ~ " + enemy.ac);
                        if (rollToHit >= enemy.ac)
                        {
                            SlowText("You hit!");

                            if (!player.getCharacterStats().isWeaponRanged)
                                damageToEnemy = RollDice(player.getCharacterStats().damageDiceNumber, player.getCharacterStats().damageDiceMax, player.getCharacterStats().str);
                            if (player.getCharacterStats().isWeaponRanged)
                                damageToEnemy = RollDice(player.getCharacterStats().damageDiceNumber, player.getCharacterStats().damageDiceMax, player.getCharacterStats().dex);

                            SlowText("You deal " + damageToEnemy + " damage!");
                            if (player.getCharacterStats().isWeaponRanged)
                            {
                                player.getCharacterStats().ammo--;
                                SlowText("You have " + player.getCharacterStats().ammo + " ammo left.");
                            }

                            WriteRemark(Remark.ReturnRemark("playerAttackHit"));

                            enemy.health -= damageToEnemy;
                            if (enemy.health < 0)
                                enemy.health = 0;
                            SlowText("Enemy health: " + enemy.health);

                        }
                        else
                        {
                            Console.WriteLine("You miss!");

                            WriteRemark(Remark.ReturnRemark("PlayerAttackMiss"));

                        }
                        Console.ReadLine();
                    }
                    break;
                case 2:

                    Spells[] spells = Spells.GetSpells(player);

                    try
                    {
                        if (spells[0] != null)
                        {
                        }
                    }
                    catch
                    {
                        if (player.getCharacterStats().spellPoints == 0 && player.getCharacterStats().maxSpellPoints > 0)
                        {
                            SlowText("You're out of spell points.");
                        }
                        else
                            SlowText("You don't know any spells :(");
                        goto playerTurnStart;
                    }

                    SpellCastStart:
                    SlowText("Choose a spell to cast!");
                    SlowText("You have " + player.getCharacterStats().spellPoints + " spell points!");

                    for (int i = 0; i < spells.Length; i++)
                    {
                        SlowText((i + 1) + " - " + spells[i].spellName + " : " + spells[i].spellPoints + " Spell Points.", 5, ConsoleColor.DarkGray);
                    }

                    int choice = int.Parse(Console.ReadLine());

                    if (choice > spells.Length)
                    {
                        SlowText("Uh, I don't think that's an option. Try again.", 15, ConsoleColor.DarkGray);
                        goto SpellCastStart;
                    }
                    else
                    {
                        Spells spell = spells[choice - 1];
                        if (player.getCharacterStats().spellPoints < spell.spellPoints)
                        {
                            SlowText("You don't have enough spell points, choose again.");
                            goto playerTurnStart;
                        }
                        if (spell.spellDamageDiceNumber > 0)
                        {
                            SlowText("Roll for accuracy!");
                            if (RollDice(1, 20, player.getCharacterStats().spellModifier) >= enemy.ac)
                            {
                                SlowText("You hit!");
                                RollDiceGraphic(spell.spellDiceMax);
                                int magicDamageToEnemy = player.CastSpell(spell, enemy);
                                enemy.health -= magicDamageToEnemy;
                                SlowText("You dealt " + magicDamageToEnemy + " damage!");
                            }
                            else
                            {
                                SlowText("You missed!");
                                WriteRemark(Remark.ReturnRemark("playerAttackMiss"));

                            }
                            player.getCharacterStats().spellPoints -= spell.spellPoints;
                            if (spell.spellHealDiceNumber > 0)
                            {
                                goto healSpell;
                            }
                            else
                            {
                                break;
                            }
                        }
                        healSpell:
                        int totalHealed = player.CastSpell(spell, enemy);
                        if (player.getCharacterStats().health > player.getCharacterStats().maxHealth)
                        {
                            SlowText("You are fully healed already!");
                        }
                        else
                        {
                            if (spell.spellHealDiceNumber > 0)
                            {
                                player.getCharacterStats().health += totalHealed;
                            }
                            SlowText("You healed " + totalHealed + " health!");
                            if (player.getCharacterStats().health > player.getCharacterStats().maxHealth)
                                player.getCharacterStats().health = player.getCharacterStats().maxHealth;
                        }
                        WriteRemark(Remark.ReturnRemark(spell.spellDamageType));
                        WriteRemark(Remark.ReturnRemark(spell.spellName));

                        player.getCharacterStats().spellPoints -= spell.spellPoints;
                    }
                    Console.WriteLine();
                    break;
                case 3:
                    SlowText(Remark.PlayerInsult(), 10, ConsoleColor.Cyan);
                    if (dice.Next(1, 4) == 1)
                    {
                        SlowText("The " + enemy.race + " was shooketh from your roast! It's your turn again!");
                        goto playerTurnStart;
                    }
                    else
                        SlowText(enemy.name + " is not impressed.");
                    break;

                case 4:
                    player.getCharacterStats().DispStats();
                    Console.WriteLine();
                    goto playerTurnStart;

                default:
                    SlowText("That is not a valid option. Try again.");
                    goto playerTurnStart;

            }
        }

        public static void enemyTurn(Player player, CharacterStats enemy)
        {

            int rollToHit = 0;
            int damageToPlayer = 0;
            int randomChoice;
            for (int i = 0; i < enemy.attackNum; i++)
            {
                randomChoice = randChoice.Next(1, 4);
                ChooseAttack:
                if (randomChoice == 1) // choose up to 3 different attacks at random
                {

                    SlowText("The enemy attempts to hit you with its " + enemy.weaponName + ".");

                    if (!enemy.isWeaponRanged)
                        rollToHit = RollDice(1, 20, enemy.meleeATKBonus);
                    if (enemy.isWeaponRanged)
                        rollToHit = RollDice(1, 20, enemy.rangedATKBonus);
                    Console.WriteLine(rollToHit + " ~ " + player.getCharacterStats().ac);
                    if (rollToHit >= player.getCharacterStats().ac)
                    {
                        SlowText("It hits you!");
                        WriteRemark(Remark.ReturnRemark("enemyAttackHit"));

                        if (!enemy.isWeaponRanged)
                            damageToPlayer = RollDice(enemy.damageDiceNumber, enemy.damageDiceMax, enemy.str);
                        if (enemy.isWeaponRanged)
                            damageToPlayer = RollDice(enemy.damageDiceNumber, enemy.damageDiceMax, enemy.dex);
                        if (damageToPlayer < 0)
                            damageToPlayer = 0;
                        SlowText("It deals " + damageToPlayer + " damage!");
                        player.getCharacterStats().health -= damageToPlayer;

                        SlowText("Your health: " + player.getCharacterStats().health);
                        if (damageToPlayer != 0)
                            WriteRemark(Remark.ReturnRemark("enemyAttackHit"));
                    }
                    else
                    {
                        SlowText("It misses!");

                        WriteRemark(Remark.ReturnRemark("enemyAttackMiss"));
                    }

                }
                else if (randomChoice == 2)
                {
                    if (enemy.weaponName2 == "")
                    {
                        randomChoice = 1;
                        goto ChooseAttack;
                    }

                    SlowText("The enemy attempts to hit you -" + enemy.weaponName2);

                    if (!enemy.isWeapon2Ranged)
                        rollToHit = RollDice(1, 20, enemy.meleeATKBonus);
                    if (enemy.isWeapon2Ranged)
                        rollToHit = RollDice(1, 20, enemy.rangedATKBonus);
                    Console.WriteLine(rollToHit + " ~ " + player.getCharacterStats().ac);
                    if (rollToHit >= player.getCharacterStats().ac)
                    {
                        SlowText("It hits you!");


                        if (!enemy.isWeapon2Ranged)
                            damageToPlayer = RollDice(enemy.damageDiceNumber2, enemy.damageDiceMax2, enemy.str);
                        if (enemy.isWeapon2Ranged)
                            damageToPlayer = RollDice(enemy.damageDiceNumber2, enemy.damageDiceMax2, enemy.dex);
                        if (damageToPlayer < 0)
                            damageToPlayer = 0;
                        SlowText("It deals " + damageToPlayer + " damage!");
                        player.getCharacterStats().health -= damageToPlayer;

                        SlowText("Your health: " + player.getCharacterStats().health);
                        if (damageToPlayer != 0)
                            WriteRemark(Remark.ReturnRemark("enemyAttackHit"));
                    }
                    else
                    {
                        SlowText("It misses!");

                        WriteRemark(Remark.ReturnRemark("enemyAttackMiss"));
                    }

                }
                else if (randomChoice == 3)
                {
                    if (enemy.weaponName3 == "")
                    {
                        randomChoice = 1;
                        goto ChooseAttack;
                    }

                    SlowText("The enemy attempts to hit you -" + enemy.weaponName3);

                    if (!enemy.isWeapon3Ranged)
                        rollToHit = RollDice(1, 20, enemy.meleeATKBonus);
                    if (enemy.isWeapon3Ranged)
                        rollToHit = RollDice(1, 20, enemy.rangedATKBonus);
                    Console.WriteLine(rollToHit + " ~ " + player.getCharacterStats().ac);
                    if (rollToHit >= player.getCharacterStats().ac)
                    {
                        SlowText("It hits you!");


                        if (!enemy.isWeapon3Ranged)
                            damageToPlayer = RollDice(enemy.damageDiceNumber3, enemy.damageDiceMax3, enemy.str);
                        if (enemy.isWeapon3Ranged)
                            damageToPlayer = RollDice(enemy.damageDiceNumber3, enemy.damageDiceMax3, enemy.dex);
                        if (damageToPlayer < 0)
                            damageToPlayer = 0;
                        SlowText("It deals " + damageToPlayer + " damage!");
                        player.getCharacterStats().health -= damageToPlayer;

                        SlowText("Your health: " + player.getCharacterStats().health);
                        if (damageToPlayer != 0)
                            WriteRemark(Remark.ReturnRemark("enemyAttackHit"));
                    }
                    else
                    {
                        SlowText("It misses!");

                        WriteRemark(Remark.ReturnRemark("enemyAttackMiss"));
                    }
                }
                else
                {
                    WriteRemark(Remark.ReturnRemark("enemyTaunt"));
                }
            }
        }

        public static void gameEnd()
        {
            SlowText("Through all your fighting and adventuring, your legend has come to an end", 40, ConsoleColor.Red);
            SlowText("...", 200, ConsoleColor.Red);
            System.Threading.Thread.Sleep(10000);
            while (true)
            {
                Console.Clear();
            }

        }


        #endregion Fighting

        #region Utility
        public static void SlowText(string input, int chartime = 10, ConsoleColor color = ConsoleColor.White, int timeWait = 150)
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i]);

                if (!DEBUG_MODE)
                    System.Threading.Thread.Sleep(chartime);
            }

            if (!DEBUG_MODE)
                System.Threading.Thread.Sleep(timeWait);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
        }

        static void SlowTextWrite(string input, int chartime = 10, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i]);

                if (!DEBUG_MODE)
                    System.Threading.Thread.Sleep(chartime);
            }

            if (!DEBUG_MODE)
                System.Threading.Thread.Sleep(150);

            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        static void WriteRemark(string input)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(input);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

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

        static void RollDiceGraphic(int maxRoll)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int temp = 0;
            string disp = "";

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
            Console.Write("   ");
            Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop);

            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        #endregion Utility
    }
}