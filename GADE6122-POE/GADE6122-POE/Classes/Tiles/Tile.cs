using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_POE.Tiles
{
    abstract class Tile
    {
        //Protected Variables
        protected int X;
        protected int Y;
        //Public Variables
        public enum TileType
        {
            Hero,
            Enemy,
            Gold,
            Weapon,
            Empty
        }

        //Public Constructor
        public Tile(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        //Public accessors
        public int x { get { return X; } set { X = value; } }
        public int y { get { return Y; } set { Y = value; } }
        public bool PickUp { get; internal set; }

    }
}
