using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GADE6122_POE.Characters;

namespace GADE6122_POE.Classes.Characters
{
    [Serializable]
    class Mage : Enemy
    {   //Constructor of Mage
        public Mage(int X, int Y) : base(X, Y, 'M', 5, 5)
        {

        }

        public override MovementEnum ReturnMove(MovementEnum move = MovementEnum.NoMovement)
        {
            return MovementEnum.NoMovement;
        }

        public override bool CheckRange(Character target)
        {
            bool Attackable;

            bool CheckAccross(Character character)
            {
                bool InRange = true;
                //Checks to see if the mage can attack in a x pattern
                if (Math.Abs(this.X - character.x) == 2 || Math.Abs(this.Y - character.x) == 2)
                {
                    InRange = false;
                }
                
                return InRange;
            }

            //Checks to see if mage can attack around itself
            if (DistanceTo(target) == 1 || CheckAccross(target))
            {
                Attackable = true;
            }
            else
            {
                Attackable = false;
            }

            return Attackable;
            
        }
    }
}
