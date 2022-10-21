using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_POE.Tiles
{
    [Serializable]
    class EmptyTile : Tile
    {   //Constructor
        public EmptyTile(int X, int Y, char symbol) : base(X, Y)
        {

        }
    }
}
