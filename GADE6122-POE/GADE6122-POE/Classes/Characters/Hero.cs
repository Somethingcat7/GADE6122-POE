using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GADE6122_POE.Tiles;
using GADE6122_POE.Classes.Items;
using System.Diagnostics.Metrics;

namespace GADE6122_POE.Characters
{
    [Serializable]
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
                    if (VisionArray[0].GetType() == typeof(EmptyTile) || VisionArray[0].GetType() == typeof(Gold) || VisionArray[0].GetType() == typeof(MeleeWeapon) || VisionArray[0].GetType() == typeof(RangedWeapon))
                    {
                        moveDirection = MovementEnum.Up;
                    }
                    break;
                case MovementEnum.Down:
                    if (VisionArray[1].GetType() == typeof(EmptyTile) || VisionArray[1].GetType() == typeof(Gold) || VisionArray[1].GetType() == typeof(MeleeWeapon) || VisionArray[1].GetType() == typeof(RangedWeapon))
                    {
                        moveDirection = MovementEnum.Down;
                    }
                    break;
                case MovementEnum.Left:
                    if (VisionArray[2].GetType() == typeof(EmptyTile) || VisionArray[2].GetType() == typeof(Gold) || VisionArray[2].GetType() == typeof(MeleeWeapon) || VisionArray[2].GetType() == typeof(RangedWeapon))
                    {
                        moveDirection = MovementEnum.Left;
                    }
                    break;
                case MovementEnum.Right:
                    if (VisionArray[3].GetType() == typeof(EmptyTile) || VisionArray[3].GetType() == typeof(Gold) || VisionArray[3].GetType() == typeof(MeleeWeapon) || VisionArray[3].GetType() == typeof(RangedWeapon))
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
            if (this.weapon == null)
            {
                return $"Player Stats: \nHp: {this.HP}/{this.MaxHp} \nCurrent Weapon: Bare Hands \nDamage: {this.damage} \nRange: 1 \n[{this.X},{this.Y}] \nGold: {this.GoldOnHand}";
            }
            else
            {
                return $"Player Stats: \nHp: {this.HP}/{this.MaxHp} \nCurrent Weapon: {this.weapon} \nDamage: {this.damage} \nRange: {this.weapon.Range} \n[{this.X},{this.Y}] \nGold: {this.GoldOnHand}";
            }
            
        }
    }
}
