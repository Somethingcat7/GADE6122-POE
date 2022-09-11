using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_POE.Characters
{
    abstract class Enemy : Character
    {
        //Protected variable
        protected Random random = new Random();

        //Constructor
        public Enemy(int X, int Y, char Symbol, int Damage, int MaxHP) : base (X, Y, Symbol,Damage, MaxHP)
        {

        }

        //ToString Method for enemies
        public override string ToString()
        {
            return $"{this.GetType().Name}\n at [{this.X}, {this.Y}] with {this.damage} DMG";
        }
    }
}
