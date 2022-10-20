using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GADE6122_POE.Tiles;
using GADE6122_POE.Classes.Items;

namespace GADE6122_POE.Characters
{
    class Hero : Character
    {
        //Constructor
        public Hero(int X, int Y) : base(X, Y, 'H', 2, 50)
        {
            
        }

        //Movement
        public override MovementEnum ReturnMove(MovementEnum move)
        {
            MovementEnum moveDirection = MovementEnum.NoMovement;

            switch (move)
            {
                case MovementEnum.Up:
                    if (VisionArray[0].GetType() == typeof(EmptyTile) || visionArray[0].GetType() == typeof(Gold))
                    {
                        moveDirection = MovementEnum.Up;
                    }
                    break;
                case MovementEnum.Down:
                    if (VisionArray[1].GetType() == typeof(EmptyTile) || visionArray[1].GetType() == typeof(Gold))
                    {
                        moveDirection = MovementEnum.Down;
                    }
                    break;
                case MovementEnum.Left:
                    if (VisionArray[2].GetType() == typeof(EmptyTile) || visionArray[2].GetType() == typeof(Gold))
                    {
                        moveDirection = MovementEnum.Left;
                    }
                    break;
                case MovementEnum.Right:
                    if (VisionArray[3].GetType() == typeof(EmptyTile) || visionArray[3].GetType() == typeof(Gold))
                    {
                        moveDirection = MovementEnum.Right;
                    }
                    break;
                default:
                    moveDirection = MovementEnum.NoMovement;
                    break;
                
            }
            return moveDirection;
        }

        //ToString method for hero
        public override string ToString()
        {
            return $"Player Stats: \nHp: {this.HP}/{this.MaxHp} \nDamage: {this.damage} \n[{this.X},{this.Y}]";
        }
    }
}
