using GADE6122_POE.Characters;
using GADE6122_POE.Classes.Items;
using GADE6122_POE.Tiles;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
            // variable for a move direction
            MovementEnum moveDirection = MovementEnum.NoMovement;

            int xDist = this.X - target.x;
            int yDist = this.Y - target.y;

            Random rnd = new Random();
            // 0 is horizontal
            // 1 is veritcal
            int direction = rnd.Next(0, 2);

            switch (direction)
            {
                //{ 0 = north, 1 = south, 2 = west, 3 = east } in VisionArray

                case 0:

                    if (yDist < -1) // neg
                    {
                        if (VisionArray[3].GetType() == typeof(EmptyTile) || VisionArray[3].GetType() == typeof(Gold) || VisionArray[3].GetType() == typeof(MeleeWeapon) || VisionArray[3].GetType() == typeof(RangedWeapon))
                        {
                            moveDirection = MovementEnum.Right;
                        }
                    }
                    else if (yDist > 1) //pos
                    {
                        if (VisionArray[2].GetType() == typeof(EmptyTile) || VisionArray[2].GetType() == typeof(Gold) || VisionArray[2].GetType() == typeof(MeleeWeapon) || VisionArray[2].GetType() == typeof(RangedWeapon))
                        {
                            moveDirection = MovementEnum.Left;
                        }
                    }

                    else if (yDist == 1 || yDist == -1) //next to hero
                    {
                        moveDirection = MovementEnum.NoMovement;
                        goto case 1;
                    }

                    else if (yDist == 0) // same collumn
                    {
                        goto case 1;
                    }

                    break;

                case 1:

                    if (xDist > -1)
                    {
                        if (VisionArray[0].GetType() == typeof(EmptyTile) || VisionArray[0].GetType() == typeof(Gold) || VisionArray[0].GetType() == typeof(MeleeWeapon) || VisionArray[0].GetType() == typeof(RangedWeapon))
                        {
                            moveDirection = MovementEnum.Up;
                        }
                    }
                    else if (xDist < 1)
                    {
                        if (VisionArray[1].GetType() == typeof(EmptyTile) || VisionArray[1].GetType() == typeof(Item) || VisionArray[1].GetType() == typeof(MeleeWeapon) || VisionArray[1].GetType() == typeof(RangedWeapon))
                        {
                            moveDirection = MovementEnum.Down;
                        }
                    }

                    else if (xDist == 1 || xDist == -1)
                    {
                        moveDirection = MovementEnum.NoMovement;
                        goto case 0;
                    }

                    else if (xDist == 0)
                    {
                        goto case 0;
                    }

                    break;

            }

            return moveDirection;


        }
    }
}
