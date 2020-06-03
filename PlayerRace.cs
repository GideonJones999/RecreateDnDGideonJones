using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecreateDND
{
        public abstract class PlayerRace
        {
            private static PlayerRace[] PlayerRaces = new PlayerRace[] { new Dwarf(), new Elf(), new Halfling(), new Human(), new Dragonborn(), new Gnome(), new HalfElf(), new HalfOrc(), new Tiefling()};

            public int str = 0, dex = 0, con = 0, wis = 0, intel = 0, cha = 0, speed = 30;

            public string name;

            public static PlayerRace[] GetPlayerRaces()
            {
                return PlayerRaces;
            }
        }

        public class Dwarf : PlayerRace
        {
            public Dwarf()
            {
                name = "Dwarf";
                con = 2;
                speed = 25;
            }
        }
        public class Elf : PlayerRace
        {
            public Elf()
            {
                name = "Elf";
                dex = 2;
                wis = 1;
            }
        }
        public class Halfling : PlayerRace
        {
            public Halfling()
            {
                name = "Halfling";
                dex = 2;
                cha = 1;
                speed = 25;
            }
        }
        public class Human : PlayerRace
        {
            public Human()
            {
                name = "Human";
                str = 1;
                dex = 1;
                con = 1;
                intel = 1;
                wis = 1;
                cha = 1;
            }
        }
        public class Dragonborn : PlayerRace
        {
            public Dragonborn()
            {
                name = "Dragonborn";
                str = 2;
                cha = 1;
            }
        }
        public class Gnome : PlayerRace
        {
            public Gnome()
            {
                name = "Gnome";
                dex = 2;
                cha = 1;
            }
        }
        public class HalfElf : PlayerRace
        {
            public HalfElf()
            {
                name = "Half-Elf";
                str = 1;
                dex = 1;
                cha = 2;
            }
        }
        public class HalfOrc : PlayerRace
        {
            public HalfOrc()
            {
                name = "Half-Orc";
                str = 2;
                con = 1;
            }
        }
        public class Tiefling : PlayerRace
        {
            public Tiefling()
            {
                name = "Tiefling";
                dex = 1;
                intel = 2;
                cha = 1;
            }
        }
    }


