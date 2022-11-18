using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_POE.Characters
{
    [Serializable]
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
            string state;
            bool equiped;

            if (this.weapon == null)
            {
                state = "Barehanded";
                equiped = false;
            }
            else
            {
                state = "Equiped";
                equiped = true;
            }

            if (equiped)
            {
                return $"Equiped {this.GetType().Name}\n at [{this.X}, {this.Y}] with {this.weapon.ToString()} \n{this.weapon.Durability} x {this.weapon.Damage} DMG";
            }
            else
            {
                return $"Barehanded {this.GetType().Name}\n at [{this.X}, {this.Y}] with {this.damage} DMG";
            }

            
        }
    }
}
