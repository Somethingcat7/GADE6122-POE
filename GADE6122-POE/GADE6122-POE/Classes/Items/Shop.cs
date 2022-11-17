using GADE6122_POE.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_POE.Classes.Items
{
    [Serializable]
    class Shop
    {
        public enum WeaponTypesInShops
        {
            MELEE,
            RANGED,
        }

        private Random random;
        private Weapon[] arrayofWeapons = new Weapon[3];
        private Character character;

        private readonly int amount = 3;
        private readonly int WeaponVariants = Enum.GetNames(typeof(WeaponTypesInShops)).Length;

        public Weapon[] ArrayOfWeapons { get { return arrayofWeapons; } set { arrayofWeapons = value; } }

        public Shop(Character player) 
        {
           character = player;

            for (int i = 0; i < arrayofWeapons.Length; i++)
            {
                arrayofWeapons[i] = RandomWeapon() ;

                while (i != 0 && arrayofWeapons[i] == arrayofWeapons[i - 1])
                {
                    arrayofWeapons[i] = RandomWeapon();
                }
            }
        }

        public WeaponTypesInShops RandomWeaponType()
        {
            random = new Random();
            int num = random.Next(0, WeaponVariants);

            if (num == (int)WeaponTypesInShops.MELEE)
            {
                return WeaponTypesInShops.MELEE;
            }
            else if (num == (int)WeaponTypesInShops.RANGED)
            {
                return WeaponTypesInShops.RANGED;
            }
            else
            {
                return default;
            }
        }

        public Weapon RandomWeapon()
        {
            Item item;

            switch (RandomWeaponType())
            {

                case WeaponTypesInShops.MELEE:
                    switch (random.Next(0, Enum.GetNames(typeof(MeleeWeapon.MeleeTypes)).Length))
                    {
                        case (int)MeleeWeapon.MeleeTypes.DAGGER:
                            item = new MeleeWeapon(MeleeWeapon.MeleeTypes.DAGGER);
                            break;
                        case (int)MeleeWeapon.MeleeTypes.LONGSWORD:
                            item = new MeleeWeapon(MeleeWeapon.MeleeTypes.LONGSWORD);
                            break;
                        default:
                            item = null;
                            break;
                    }
                    break;

                case WeaponTypesInShops.RANGED:
                    switch (random.Next(0, Enum.GetNames(typeof(RangedTypes)).Length))
                    {
                        case (int)RangedTypes.RIFLE:
                            item = new RangedWeapon(RangedTypes.RIFLE);
                            break;
                        case (int)RangedTypes.LONGBOW:
                            item = new RangedWeapon(RangedTypes.LONGBOW);
                            break;
                        default:
                            item = null;
                            break;
                    }
                    break;

                default:
                    return null;
            }

            return (Weapon)item;
        }

        public bool Buyable(int Amount)
        {
            if (character.GoldOnHand >= Amount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Buy(int Amount)
        {
            for (int i = 0; i < arrayofWeapons.Length; i++)
            {
                if (Amount == arrayofWeapons[i].Cost)
                {
                    character.PickUp(arrayofWeapons[i]);
                    character.Equip(arrayofWeapons[i]);
                    arrayofWeapons[i] = RandomWeapon();
                    break;
                }
            }
        }

        public string DisplayWeapons(int Amount)
        {
            switch (Amount)
            {
                case 3:
                    return $"Buy Dagger for {Amount}";
                case 5:
                    return $"Buy Longsword for {Amount}";
                case 6:
                    return $"Buy Longbow for {Amount}";
                case 7:
                    return $"Buy Rifle for {Amount}";

                default:
                    return $"";
            }
        }
    }
}
