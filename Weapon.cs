using System;
using System.Collections;

namespace RecreateDND
{
    public abstract class Weapon
    {
        private static readonly Weapon[] weapons = new Weapon[] {
            new Greatclub(),
            new Dagger(),
            new Handaxe(),
            new Javelin(),
            new Mace(),
            new Quarterstaff(),
            new LightCrossbow(),
            new Longsword(),
            new Greatsword(),
            new Shortbow(),
            new Longbow(),
            new Pike(),
            new MorningStar(),
            new BlowGun(),
            new WarHammer(),
            new Trident(),
            new HalfShard(),
            new ShardBlade()
            
        };

        public int damageDiceMax = 1, damageDiceNumber = 1, ammo = 0, minCharacterStrength = 0, minCharacterDex = 0;

        public string name;

        public bool isWeaponRanged = false;


        public static Weapon[] GetWeapons(int str, int dex , string name)
        {
            ArrayList result = new ArrayList();
            foreach (Weapon weapon in weapons)
            {
                if (str >= weapon.minCharacterStrength && dex >= weapon.minCharacterDex)
                  result.Add(weapon);
            }

            if (name == "Gideon" || name == "Kyler")
                result.Add(new ShardBlade());

            Weapon[] array = result.ToArray(typeof(Weapon)) as Weapon[];
            return array;
        }
    }

    public class Longsword : Weapon
    {
        public Longsword()
        {
            name = "Longsword";
            damageDiceMax = 8;
        }
    }
    public class Greatclub : Weapon
    {
        public Greatclub()
        {
            name = "Greatclub";
            damageDiceMax = 8;
        }
    }
    public class Dagger : Weapon
    {
        public Dagger()
        {
            name = "Dagger";
            damageDiceMax = 4;
        }
    }

    public class Handaxe : Weapon
    {
        public Handaxe()
        {
            name = "Handaxe";
            damageDiceMax = 6;
        }
    }

    public class Javelin : Weapon
    {
        public Javelin()
        {
            name = "Javelin";
            damageDiceMax = 6;
        }
    }

    public class Mace : Weapon
    {
        public Mace()
        {
            name = "Mace";
            damageDiceMax = 8;
        }
    }

    public class Quarterstaff : Weapon
    {
        public Quarterstaff()
        {
            name = "Quarterstaff";
            damageDiceMax = 4;
        }
    }

    public class LightCrossbow : Weapon
    {
        public LightCrossbow()
        {
            name = "Light Crossbow";
            damageDiceMax = 8;
            ammo = 20;
            minCharacterDex = 3;
            isWeaponRanged = true;
        }
    }

    public class Shortbow : Weapon
    {
        public Shortbow()
        {
            name = "Shortbow";
            damageDiceMax = 6;
            ammo = 20;
            minCharacterDex = 2;
            isWeaponRanged = true;
        }
    }

    public class Longbow : Weapon
    {
        public Longbow()
        {
            name = "Longbow";
            damageDiceMax = 10;
            ammo = 15;
            minCharacterDex = 4;
            isWeaponRanged = true;
        }
    }

    public class Greatsword : Weapon
    {
        public Greatsword()
        {
            name = "Greatsword";
            damageDiceMax = 6;
            damageDiceNumber = 2;
            minCharacterStrength = 4;
        }
    }
    
    public class Pike : Weapon
    {
        public Pike()
        {
            name = "Pike";
            damageDiceMax = 10;
            minCharacterStrength = 3;
        }
    }
    public class MorningStar : Weapon
    {
        public MorningStar()
        {
            name = "Morning Star";
            damageDiceMax = 8;
            minCharacterStrength = 3;
        }
    }
    public class BlowGun : Weapon
    {
        public BlowGun()
        {
            name = "Blow Gun";
            damageDiceMax = 1;
            minCharacterDex = 2;
            isWeaponRanged = true;
        }
    }
    public class WarHammer : Weapon
    {
        public WarHammer()
        {
            name = "War Hammer";
            damageDiceMax = 10;
            minCharacterStrength = 3;
        }
    }
    public class Trident : Weapon
    {
        public Trident()
        {
            name = "Trident";
            damageDiceMax = 6;
            minCharacterStrength = 3;
        }
    }
    public class HalfShard : Weapon
    {
        public HalfShard()
        {
            name = "Half Shard";
            damageDiceMax = 10;
            damageDiceNumber = 3;
            minCharacterStrength = 5;
            minCharacterDex = 5;
        }
    }

    public class ShardBlade : Weapon
    {
        public ShardBlade()
        {
            name = "Shard Blade";
            damageDiceMax = 100;
            damageDiceNumber = 5;
            minCharacterStrength = 10;
        }
    }
}
