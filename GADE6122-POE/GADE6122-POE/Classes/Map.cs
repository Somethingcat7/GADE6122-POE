using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GADE6122_POE.Tiles;
using GADE6122_POE.Characters;
using GADE6122_POE.Classes.Characters;
using GADE6122_POE.Classes.Items;

namespace GADE6122_POE.Classes
{
    class Map
    {   //Map tile array
        public Tile[,] tilesMap;

        //Item tile array
        public Tile[] arrItems;

        //Player object
        private Hero heroPlayer;

        //Enemy array
        public Enemy[] arrEnemies;

        //Enemy amount
        private int numEnemies;

        //Map width and height
        private int mapWidth;
        private int mapHeight;

        //Random number generator
        Random random = new Random();

        //Accessors
        public Tile[,] TilesMap { get { return tilesMap; } set { tilesMap = value; } }
        public Hero HeroPlayer { get { return heroPlayer; } set { heroPlayer = value; } }
        public Enemy[] ArrEnemies { get { return arrEnemies; } set { arrEnemies = value; } }
        public int NumEnemies { get { return numEnemies; } set { numEnemies = value; } }
        public int MapWidth { get { return mapWidth; } set { mapWidth = value; } }
        public int MapHeight { get { return mapHeight; } set { mapHeight = value; } }

        //Constructor for map class
        public Map(int MinWidth, int MaxWidth, int MinHeight, int MaxHeight, int NumEnemies, int GoldAmount)
        {
            Random random = new Random();

            mapWidth = random.Next(MinWidth, MaxWidth + 1);
            mapHeight = random.Next(MinHeight, MaxHeight + 1);

            this.numEnemies = NumEnemies;

            TilesMap = new Tile[mapWidth, mapHeight];
            arrEnemies = new Enemy[numEnemies];
            arrItems = new Item[GoldAmount];

            //Filling the map array
            MapFill();
            
            //Adding player/hero to the map
            heroPlayer = (Hero)Create(Tile.TileType.Hero);
            AddToMap(HeroPlayer);
            
            //Adding enemies to their array and map
            for (int i = 0; i < arrEnemies.Length; i++)
            {
                arrEnemies[i] = (Enemy)Create(Tile.TileType.Enemy);
                AddToMap(ArrEnemies[i]);
            }

            for (int i = 0; i < GoldAmount; i++)
            {
                arrItems[i] = (Gold)Create(Tile.TileType.Gold);
                arrItems[i].PickUp = false;
                AddToMap(arrItems[i]);
            }

            UpdateVision();

        }

        //Update vision mathod
        public void UpdateVision()
        {   //Up
            heroPlayer.VisionArray[0] = tilesMap[heroPlayer.x - 1, heroPlayer.y];
            //Down
            heroPlayer.VisionArray[1] = tilesMap[heroPlayer.x + 1, heroPlayer.y];
            //Left
            heroPlayer.VisionArray[2] = tilesMap[heroPlayer.x, heroPlayer.y - 1];
            //Right
            heroPlayer.VisionArray[3] = tilesMap[heroPlayer.x, heroPlayer.y + 1];

            foreach (Enemy enemy in arrEnemies)
            {   //Up
                enemy.VisionArray[0] = tilesMap[enemy.x - 1, enemy.y];
                //Up
                enemy.VisionArray[1] = tilesMap[enemy.x + 1, enemy.y];
                //Up
                enemy.VisionArray[2] = tilesMap[enemy.x, enemy.y - 1];
                //Up
                enemy.VisionArray[3] = tilesMap[enemy.x, enemy.y + 1];
            }
        }

        //Create method
        public Tile Create(Tile.TileType tileType)
        {
            Random random = new Random();
            int randomX;
            int randomY;

            bool isTileOpen(int X, int Y)
            {
                if (tilesMap[X, Y].GetType() != typeof(EmptyTile))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            switch (tileType)
            {
                //Create hero tile in map
                case Tile.TileType.Hero:
                    do
                    {
                        randomX = random.Next(1, tilesMap.GetLength(0));
                        randomY = random.Next(1, tilesMap.GetLength(1));
                    } while (isTileOpen(randomX, randomY));

                    return new Hero(randomX, randomY);

                //Creates enemy tile in map
                case Tile.TileType.Enemy:
                    do
                    {
                        randomX = random.Next(1, tilesMap.GetLength(0));
                        randomY = random.Next(1, tilesMap.GetLength(1));
                    } while (isTileOpen(randomX, randomY));

                    int num = random.Next(0,2);
                    switch (num)
                    {
                        case 0:
                            return new Swamp_Creature(randomX, randomY);
                        case 1:
                            return new Mage(randomX, randomY);
                        default:
                            return null;
                    }

                case Tile.TileType.Gold:
                    do
                    {
                        randomX = random.Next(1, tilesMap.GetLength(0));
                        randomY = random.Next(1, tilesMap.GetLength(1));
                    } while (isTileOpen(randomX,randomY));
                    return new Gold(randomX, randomY);

                //Create empty tile in map
                case Tile.TileType.Empty:
                    do
                    {
                        randomX = random.Next(1, tilesMap.GetLength(0));
                        randomY = random.Next(1, tilesMap.GetLength(1));
                    } while (isTileOpen(randomX, randomY));

                    return new EmptyTile(randomX, randomY,'.');

                default:
                    return null;
            }
        }

        public void AddToMap(Tile tile)
        {
            tilesMap[tile.x, tile.y] = tile;
        }

        public void MapFill()
        {   //Fills map array
            for (int i = 0; i < tilesMap.GetLength(0); i++)
            {
                for (int j = 0; j < tilesMap.GetLength(1); j++)
                {
                    tilesMap[i, j] = new EmptyTile(i, j, '.');
                }
            }
            //Creates borders in first/last collum/row
            for (int i = 0; i < tilesMap.GetLength(0); i++)
            {
                for (int j = 0; j < tilesMap.GetLength(1); j++)
                {
                    if (i == 0 || j == 0 || i == mapWidth - 1 || j == mapHeight -1)
                    {
                        tilesMap[i, j] = new Obstacle(i, j);
                    }
                }
            }
        }
        public void MapUpdate()
        {
            MapFill();
            AddToMap(HeroPlayer);

            //Removes dead enemies from enemy array
            for (int i = 0; i < arrEnemies.Length; i++)
            {
                int num = i;

                if (arrEnemies[i].isDead())
                {
                    arrEnemies = arrEnemies.Where((source, index) => index != i).ToArray();
                }
            }

            for (int i = 0; i < arrEnemies.Length; i++)
            {
                AddToMap(arrEnemies[i]);
            }

            foreach (var enemy in arrEnemies)
            {
                if (enemy.CheckRange(HeroPlayer))
                {
                    enemy.Attack(heroPlayer);
                }
            }

            UpdateVision();
        }
        public void EnemyMovement()
        {
            Random random = new Random();
            int enmDirection;

            for (int i = 0; i < arrEnemies.Length; i++)
            {
                enmDirection = random.Next(0,5);
                arrEnemies[i].Move(arrEnemies[i].ReturnMove((Character.MovementEnum)enmDirection));
            }
        }
    }
}
