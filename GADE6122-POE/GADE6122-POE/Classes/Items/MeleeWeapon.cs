using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_POE.Classes.Items
{
    class MeleeWeapon : Weapon
    {

        public override int Range { get => base.Range; set => base.Range = value; }

        public enum MeleeTypes
        {
            DAGGER,
            LONGSWORD,
        }

        public MeleeWeapon(MeleeTypes types, int x = 0, int y = 0) : base (x,y)
        {
            switch (types)
            {
                case MeleeTypes.DAGGER:
                    durability = 10;
                    damage = 3;
                    cost = 3;
                    weaponType = "Dagger";
                    break;

                case MeleeTypes.LONGSWORD:
                    durability = 6;
                    damage = 4;
                    cost = 5;
                    weaponType = "Longsword";
                    break;
            }
        }

        public override string ToString()
        {
            return $"{this.weaponType}";
        }

    }
}
