using System;
namespace RecreateDND
{
    public class Remark
    {
        public static string ReturnRemark(string request)
        {
            Random choice = new Random();
            switch (request)
            {
                case "playerSpeed":
                    switch (choice.Next(1, 3))
                    {
                        case 1: return "Gotta go fast!";
                        case 2: return "Speed. I am speed.";
                        default: return "";
                    }
                case "enemySpeed":
                    switch (choice.Next(1, 3))
                    {
                        case 1: return "It's a speedy boi!";
                        case 2: return "It has the need for speed!";
                        default: return "";
                    }
                case "playerAttackMiss":
                    switch (choice.Next(1, 3))
                    {
                        case 1: return "You had one job!";
                        case 2: return "He is right in front of your face!";
                        default: return "";
                    }
                case "enemyAttackMiss":
                    switch (choice.Next(1, 3))
                    {
                        case 1: return "Juke Skywalker!";
                        case 2: return "Swiggity Swoogity!";
                        default: return "";
                    }
                case "playerAttackHit":
                    switch (choice.Next(1, 3))
                    {
                        case 1: return "whaBAM!";
                        case 2: return "Right where it hurts!";
                        default: return "";
                    }
                case "enemyAttackHit":
                    switch (choice.Next(1, 4))
                    {
                        case 1: return "That must have hurt.";
                        case 2: return "Your health is melting away!";
                        case 3: return "It's just a flesh wound.";
                        default: return "";
                    }
                case "enemyTaunt":
                    switch (choice.Next(1, 4))
                    {
                        case 1: return "You are about to get Rekt!";
                        case 2: return "Your skull will be smashed in so hard your children will feel it!";
                        case 3: return "The enemy sits and thinks of a good roast...";
                        default: return "";
                    }

                case "Fire":
                    return "BURN...";

                case "Ice":
                    switch (choice.Next(1, 3))
                    {
                        case 1: return "Thats a pretty ICE spell!";
                        case 2: return "You need to COOL down...";
                        default: return "";
                    }
                    

                case "Lightning":
                    switch (choice.Next(1, 3))
                    {
                        case 1: return "Zip Zap!";
                        case 2: return "The enemy is shocked!";
                        default: return "";
                    }
                    

                case "Radiant":
                    return "Not today Satan!";

                case "Vicious Mockery":
                    Program.SlowText(PlayerInsult(), 15, ConsoleColor.Cyan);
                    Console.Write("");
                    return "";

                case "Heal":
                    switch (choice.Next(1, 3))
                    {
                        case 1: return "My life grows...";
                        case 2: return "The doctor is in the house!";
                        default: return "";
                    }
                default: return "";
            }

        }
        public static string PlayerInsult()
        {
            Random choice = new Random();
            string part1 = "";
            string part2 = "";
            string part2a = "";
            string part2b = "";
            string part3 = "";

            switch (choice.Next(1, 9))
            {
                case 1:
                    part1 = "sniviling";
                    break;
                case 2:
                    part1 = "qualling";
                    break;
                case 3:
                    part1 = "begging";
                    break;
                case 4:
                    part1 = "shiverring";
                    break;
                case 5:
                    part1 = "worthless";
                    break;
                case 6:
                    part1 = "pecking";
                    break;
                case 7:
                    part1 = "cowardly";
                    break;
                default:
                    part1 = "insufferable";
                    break;
            }

            #region Part2
            switch (choice.Next(1, 6))
            {
                case 1:
                    part2a = "Onion";
                    break;
                case 2:
                    part2a = "Mutten";
                    break;
                case 3:
                    part2a = "Carrot";
                    break;
                case 4:
                    part2a = "Dog";
                    break;
                default:
                    part2a = "Bird";
                    break;
            }
            switch (choice.Next(1, 5))
            {
                case 1:
                    part2b = "Eyed";
                    break;
                case 2:
                    part2b = "Hearted";
                    break;
                case 3:
                    part2b = "Skulled";
                    break;
                default:
                    part2b = "Brained";
                    break;
            }
            part2 = part2a + "-" + part2b;
            #endregion
            switch (choice.Next(1, 6))
            {
                case 1:
                    part3 = "Stock Fish";
                    break;
                case 2:
                    part3 = "Unable Worm";
                    break;
                case 3:
                    part3 = "Scurvy Companion";
                    break;
                case 4:
                    part3 = "Platypus";
                    break;
                default:
                    part3 = "Tree Hugger";
                    break;
            }
            return "Thou " + part1 + ", " + part2 + ", " + part3 + "!";
        }
    }
}
