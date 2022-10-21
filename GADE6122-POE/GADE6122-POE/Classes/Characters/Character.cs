using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GADE6122_POE.Tiles;
using GADE6122_POE.Classes.Items;

namespace GADE6122_POE.Characters
{
    [Serializable]
    abstract class Character : Tile
    {
        //protected variables
        protected int hp;
        protected int maxHp;
        protected int damage;
        protected int GoldOnHand;
        
        //Vision array
        protected Tile[] visionArray = new Tile[4];
        
        //Movement
        public enum MovementEnum
        {
            NoMovement,
            Up,
            Down,
            Left,  
            Right,
        }

        //Public Accessors
        public int HP { get { return hp; } set { hp = value; } }
        public int MaxHp { get { return maxHp; } set { maxHp = value; } }
        public int Damage { get { return damage; } set { damage = value; } }
        public Tile[] VisionArray { get{ return visionArray; } set{ visionArray = value; } }
        
        //Constructor
        public Character(int X, int Y, char Symbol, int Damage, int MaxHP) : base (X,Y)
        {
            this.hp = MaxHP;
            this.maxHp = MaxHP;
            this.damage = Damage;
        }

        //Attack method
        public virtual void Attack(Character target)
        {
            target.hp -= this.damage;
        }

        //Death method
        public bool isDead()
        {
            if (this.hp <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Chack range method
        public virtual bool CheckRange(Character target)
        {
            if (DistanceTo(target) == 1 || DistanceTo(target) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Distance check method
        public int DistanceTo(Character target)
        {
            int calcDistance(int origin, int destination)
            {
                int distance = destination - origin;
                return Math.Abs(distance);
            }

            return calcDistance(this.X, target.X) + calcDistance(this.Y, target.Y);
        }

        //Movement method
        public void Move(MovementEnum move)
        {
            switch (move)
            {
                case MovementEnum.NoMovement:
                    break;
                case MovementEnum.Up:
                    this.X -= 1;
                    break;
                case MovementEnum.Down:
                    this.X += 1;
                    break;
                case MovementEnum.Left:
                    this.Y -= 1;
                    break;
                case MovementEnum.Right:
                    this.Y += 1;
                    break;
            }
        }
        //Additional code for movement
        public abstract MovementEnum ReturnMove(MovementEnum move = MovementEnum.NoMovement);

        //ToString method
        public abstract override string ToString();

        //Pick up method
        public void PickUp(Item i)
        {
            if (i.GetType() == typeof(Gold))
            {
                Random random = new Random();
                GoldOnHand += random.Next(1, 5);
                i.PickUp = true; 
            }
        }

        
    }
}
