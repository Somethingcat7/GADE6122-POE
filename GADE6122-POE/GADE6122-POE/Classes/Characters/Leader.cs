using GADE6122_POE.Characters;
using GADE6122_POE.Classes.Items;
using GADE6122_POE.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_POE.Classes.Characters
{
    [Serializable]
    class Leader : Enemy
    {
        private Tile target;

        public Tile Target { get { return target; } set { target = value; } }

        public Leader(int x, int y) : base (x, y, 'L', 2, 20) 
        {
            this.weapon = new MeleeWeapon(MeleeWeapon.MeleeTypes.LONGSWORD);
            this.GoldOnHand = 2;
        }

        public override MovementEnum ReturnMove(MovementEnum move = MovementEnum.NoMovement)
        {
            MovementEnum movementEnum = MovementEnum.NoMovement;

            int xMove = this.x - target.x;
            int yMove = this.y - target.y;

            Random random = new Random();

            int direction = random.Next(0, 2);

            switch (direction)
            {
                case 0: this.x = xMove;
                    if (yMove < -1)
                    {
                        if (VisionArray[3].GetType() == typeof(EmptyTile) || VisionArray[3].GetType() == typeof(Gold) || VisionArray[3].GetType() == typeof(MeleeWeapon) || VisionArray[3].GetType() == typeof(RangedWeapon))
                        {
                            movementEnum = MovementEnum.Right;
                        }
                    }
                    
                    else if (yMove > 1)
                    {
                        if (VisionArray[2].GetType() == typeof(EmptyTile) || VisionArray[2].GetType() == typeof(Gold) || VisionArray[2].GetType() == typeof(MeleeWeapon) || VisionArray[2].GetType() == typeof(RangedWeapon))
                        {
                            movementEnum = MovementEnum.Left;
                        }
                    }

                    else if (yMove == 1 || yMove == -1)
                    {
                        movementEnum = MovementEnum.NoMovement;
                        goto case 1;
                    }

                    else if (yMove == 0)
                    {
                        goto case 1;
                    }
                   
                    break;

                case 1:

                    if (xMove < -1)
                    {
                        if (VisionArray[0].GetType() == typeof(EmptyTile) || VisionArray[0].GetType() == typeof(Gold) || VisionArray[0].GetType() == typeof(MeleeWeapon) || VisionArray[0].GetType() == typeof(RangedWeapon))
                        {
                            movementEnum = MovementEnum.Up;
                        }
                    }

                    else if (xMove > 1)
                    {
                        if (VisionArray[1].GetType() == typeof(EmptyTile) || VisionArray[1].GetType() == typeof(Gold) || VisionArray[1].GetType() == typeof(MeleeWeapon) || VisionArray[1].GetType() == typeof(RangedWeapon))
                        {
                            movementEnum = MovementEnum.Down;
                        }
                    }

                    else if (xMove == 1 || xMove == -1)
                    {
                        movementEnum = MovementEnum.NoMovement;
                        goto case 1;
                    }

                    else if (xMove == 0)
                    {
                        goto case 1;
                    }
                    
                    break;
                
            }

            return movementEnum;
        }
    }
}
