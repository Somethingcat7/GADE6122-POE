using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GADE6122_POE.Tiles;
using GADE6122_POE.Classes.Items;
using GADE6122_POE.Classes.Characters;

namespace GADE6122_POE.Characters
{
    [Serializable]
    abstract class Character : Tile
    {
        //protected variables
        protected int hp;
        protected int maxHp;
        protected int damage;
        protected int goldOnHand;

        protected Weapon weapon;
        
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
        public Weapon Weapon { get { return weapon; } }
        public int GoldOnHand { get { return goldOnHand; } set{ goldOnHand = value; } }
        
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
            if (this.weapon == null)
            {
                target.hp -= this.damage;
            }
            else if (this.weapon != null)
            {
                target.hp -= this.weapon.Damage;
                this.weapon.Durability -= 1;

                if (this.weapon.Durability == 0)
                {
                    this.weapon = null;
                }
            }

            if (this.GetType() == typeof(Mage) && target.isDead())
            {
                this.GoldOnHand += target.GoldOnHand;
            }
            else if (target.isDead())
            {
                if (target.weapon != null)
                {
                    this.weapon = target.weapon;
                }
                this.GoldOnHand += target.GoldOnHand;
            }
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
            bool attackable = false;

            if (this.weapon == null || this.weapon.GetType() == typeof(MeleeWeapon))
            {
                if (DistanceTo(target) == 1 || DistanceTo(target) == 0)
                {
                    attackable = true;
                }
                
                else
                {
                    attackable = false;
                }
            }
            
            else if (this.weapon.GetType() == typeof(RangedWeapon))
            {
                bool CheckDiagonal(Character target, int range)
                {
                    bool inRange = true;

                    if (Math.Abs(this.Y - target.Y) == range + 1 || Math.Abs(this.X - target.X) == range + 1)
                    {
                        inRange = false;
                    }
                    return inRange;
                }

                if (this.weapon.Range == 2)
                {
                    if (DistanceTo(target) <= this.weapon.Range)
                    {
                        attackable = true;
                    }
                   
                    else if (DistanceTo(target) == 3)
                    {
                        if (CheckDiagonal(target, this.weapon.Range + 1))
                        {
                            attackable = true;
                        }
                       
                        else
                        {
                            attackable = false;
                        }
                    }
                    
                    else if (DistanceTo(target) == 4)
                    {
                        if (CheckDiagonal(target, this.weapon.Range + 2))
                        {
                            attackable = true;
                        }
                       
                        else
                        {
                            attackable = false;
                        }
                    }
                   
                    else
                    {
                        attackable = false;
                    }
                }
                
                else if (this.weapon.Range == 3)
                {
                    if (DistanceTo(target) <= this.weapon.Range)
                    {
                        attackable = true;
                    }
                    else if (DistanceTo(target) == 4)
                    {
                        if (CheckDiagonal(target, this.weapon.Range + 1))
                        {
                            attackable = true;
                        }
                        else
                        {
                            attackable = false;
                        }
                    }
                   
                    else if (DistanceTo(target) == 5)
                    {
                        if (CheckDiagonal(target, this.weapon.Range + 2))
                        {
                            attackable = true;
                        }
                        else
                        {
                            attackable = false;
                        }
                    }
                    
                    else if (DistanceTo(target) == 6)
                    {
                        if (CheckDiagonal(target, this.weapon.Range + 3))
                        {
                            attackable = true;
                        }
                        else
                        {
                            attackable = false;
                        }
                    }
                   
                    else
                    {
                        attackable = false;
                    }

                }

            }
            else
            {
                attackable = false;
            }

            return attackable;
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

        public void Equip(Weapon weapon)
        {
            this.weapon = weapon;
        }

    }
}
