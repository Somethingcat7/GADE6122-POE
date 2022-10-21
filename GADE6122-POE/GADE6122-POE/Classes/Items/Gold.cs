using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_POE.Classes.Items
{
    [Serializable]
    class Gold : Item
    {
        private int GoldAmount;
        private Random Randomamount = new Random();
       
        //Accessor for gold
        public int MaxGoldAmount { get { return GoldAmount; } set { GoldAmount = value; } }
        
        //Constructor for gold
        public Gold(int X, int Y) : base (X,Y,'$')
        {
            GoldAmount = Randomamount.Next(1,6);
        }
       
        //String Override method
        public override string ToString()
        {
            return $"Gold located at [{this.X},{this.Y}]";
        }
    }
}
