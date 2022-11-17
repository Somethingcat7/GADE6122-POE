using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_POE.Classes.Items
{
    [Serializable]
    abstract class Weapon : Item
    {
        protected int damage;
        protected int range;
        protected int durability;
        protected int cost;
        protected string weaponType;

        public virtual int Range { get { return range; } set { range = value; } }
        public int Damage { get { return damage; } set { damage = value; } }
        public int Durability { get { return durability; } set { durability = value; } }
        public int Cost { get { return cost; } set { cost = value; } }
        public string WeaponType { get { return weaponType; } set { weaponType = value; } }

        public Weapon(int X = 0, int Y = 0) : base (X, Y, 'W')
        {

        }

    }
}
