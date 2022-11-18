using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GADE6122_POE.Classes;
using GADE6122_POE.Characters;
using GADE6122_POE.Tiles;
using GADE6122_POE.Classes.Characters;
using GADE6122_POE.Classes.Items;


namespace GADE6122_POE.Classes
{
    [Serializable]
    class GameEngine
    {
        private Map map;

        public Map Map { get { return map; } }

        public GameEngine()
        {
            map = new Map(10, 25, 10, 25, 3, 5);
        }

        private static readonly char playerTile = 'H';
        private static readonly char emptyTile = ' ';
        private static readonly char obsTile = 'X';
        private static readonly char smpMonTile = 'S';
        private static readonly char mageTile = 'M';
        private static readonly char goldTile = '$';
        private static readonly char leaderTile = 'L';
        private static readonly char weaponTile = 'W';

        public override string ToString()
        {
            string strMap = string.Empty;
            char[,] chrMap = new char[map.MapWidth, map.MapHeight];

            for (int i = 0; i < map.MapWidth; i++)
            {
                for (int j = 0; j < map.MapHeight; j++)
                {
                    //Empty tiles placed
                    if (map.TilesMap[i,j].GetType() == typeof(EmptyTile))
                    {
                        chrMap[i, j] = emptyTile;
                    }

                    //Obstacle tiles placed
                    if (map.TilesMap[i, j].GetType() == typeof(Obstacle))
                    {
                        chrMap[i, j] = obsTile;
                    }

                    //Hero tile placed
                    if (map.TilesMap[i, j].GetType() == typeof(Hero))
                    {
                        chrMap[i, j] = playerTile;
                    }

                    //Swamp Creature tile placed
                    if (map.TilesMap[i, j].GetType() == typeof(Swamp_Creature))
                    {
                        chrMap[i, j] = smpMonTile;
                    }
                    //Mage tile placed
                    if (map.TilesMap[i,j].GetType() == typeof(Mage))
                    {
                        chrMap[i, j] = mageTile;
                    }
                    //Gold tile placed
                    if (map.TilesMap[i,j].GetType() == typeof(Gold))
                    {
                        chrMap[i, j] = goldTile;
                    }
                    //Leader tile placed
                    if (map.TilesMap[i,j] is Leader)
                    {
                        chrMap[i, j] = leaderTile;
                    }
                    //Weapon tile placed
                    if (map.TilesMap[i,j].GetType() == typeof(RangedWeapon) || map.TilesMap[i, j].GetType() == typeof(MeleeWeapon))
                    {
                        chrMap[i, j] = weaponTile;
                    }
                    strMap += chrMap[i, j];
                }

                strMap += "\n";
            }

            return $"{strMap}";
        }

    }
}
