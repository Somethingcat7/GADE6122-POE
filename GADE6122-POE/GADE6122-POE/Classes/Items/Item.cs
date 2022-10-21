using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GADE6122_POE.Tiles;

namespace GADE6122_POE.Classes.Items
{
    [Serializable]
    abstract class Item : Tile
    {

        public Item (int X, int Y, char symbol) : base (X,Y)
        {

        }

        public abstract override string ToString();
    }
}
