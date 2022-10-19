using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GADE6122_POE.Characters;
using GADE6122_POE.Tiles;
using GADE6122_POE.Classes.Items;

namespace GADE6122_POE.Characters
{
    class Swamp_Creature : Enemy
    {   
        //Constructor for Swamp Creature
        public Swamp_Creature(int x, int y) : base(x,y,'S',1,10)
        {

        }

        //Movement
        public override MovementEnum ReturnMove(MovementEnum move)
        {
            MovementEnum moveDirection = MovementEnum.NoMovement;

            switch (move)
            {
                case MovementEnum.Up:
                    if (visionArray[0].GetType() == typeof(EmptyTile) || visionArray[0].GetType() == typeof(Gold))
                    {
                        if (visionArray[0].GetType() != typeof(Hero))
                        {
                            moveDirection = MovementEnum.Up;
                        }
                    }
                    break;
                case MovementEnum.Down:
                    if (visionArray[1].GetType() == typeof(EmptyTile) || visionArray[0].GetType() == typeof(Gold))
                    {
                        if (visionArray[1].GetType() != typeof(Hero))
                        {
                            moveDirection = MovementEnum.Down;
                        }
                    }
                    break;
                case MovementEnum.Left:
                    if (visionArray[2].GetType() == typeof(EmptyTile) || visionArray[0].GetType() == typeof(Gold))
                    {
                        if (visionArray[2].GetType() != typeof(Hero))
                        {
                            moveDirection = MovementEnum.Left;
                        }
                    }
                    break;
                case MovementEnum.Right:
                    if (visionArray[3].GetType() == typeof(EmptyTile) || visionArray[0].GetType() == typeof(Gold))
                    {
                        if (visionArray[3].GetType() != typeof(Hero))
                        {
                            moveDirection = MovementEnum.Right;
                        }
                    }
                    break;

                default:
                    moveDirection = MovementEnum.NoMovement;
                    break;
            }

            return moveDirection;
        }
    }
}
