using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GADE6122_POE.Tiles;
using GADE6122_POE.Characters;
using GADE6122_POE.Classes.Characters;
using GADE6122_POE.Classes.Items;
using System.Diagnostics.Metrics;

namespace GADE6122_POE.Classes
{
    [Serializable]
    class Map
    {   //Map tile array
        public Tile[,] tilesMap;

        //Item tile array
        public Tile[] arrItems;

        //Player object
        private Hero heroPlayer;
        
        //Leader object
        private Leader leader;

        //Enemy array
        public Enemy[] arrEnemies;

        //Enemy amount
        private int numEnemies;

        //Map width and height
        private int mapWidth;
        private int mapHeight;

        //Random number generator
        Random random = new Random();
        
        //Shop class
        public Shop shop;

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

            //Replaces an enemy in array with leader

            leader = (Leader)Create(Tile.TileType.LEADER);
            int leaderindex = random.Next(0, arrEnemies.Length);
            arrEnemies[leaderindex] = leader;

            //Sets leader's target to player

            leader.Target = HeroPlayer;

            AddToMap(leader);

            //Shop
            shop = new Shop(HeroPlayer);

            //Gold
            for (int i = 0; i < GoldAmount; i++) // maxGoldDrops = itemArray.Length
            {
                arrItems[i] = (Item)Create(Tile.TileType.Gold);
                arrItems[i].PickUp = false;
                AddToMap(arrItems[i]);
            }

            //Weapons
            for (int i = 0; i < arrItems.Length; i++)
            {
                bool canReplace;

                // more or less 1/3 chance it gets replaced 
                switch (random.Next(0, 3))
                {
                    case 0:
                        canReplace = true;
                        break;
                    case 1:
                        canReplace = false;
                        break;
                    case 2:
                        canReplace = false;
                        break;
                    default:
                        canReplace = false;
                        break;
                }

                if (canReplace)
                {
                    switch (random.Next(0, 4))
                    {
                        case 0:
                            arrItems[i] = new MeleeWeapon(MeleeWeapon.MeleeTypes.DAGGER, arrItems[i].x, arrItems[i].y);
                            break;
                        case 1:
                            arrItems[i] = new MeleeWeapon(MeleeWeapon.MeleeTypes.LONGSWORD, arrItems[i].x, arrItems[i].y);
                            break;
                        case 2:
                            arrItems[i] = new RangedWeapon(RangedWeapon.RangedTypes.LONGBOW, arrItems[i].x, arrItems[i].y);
                            break;
                        case 3:
                            arrItems[i] = new RangedWeapon(RangedWeapon.RangedTypes.RIFLE, arrItems[i].x, arrItems[i].y);
                            break;
                        default:
                            break;
                    }
                }

                AddToMap(arrItems[i]);
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
                    tilesMap[i, j] = new EmptyTile(i, j, ' ');
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
            GetItemAtPosition(HeroPlayer);

            AddToMap(leader);

            //Removes dead enemies from enemy array
            for (int i = 0; i < arrEnemies.Length; i++)
            {
                int num = i;

                if (arrEnemies[i].isDead())
                {
                    arrEnemies = arrEnemies.Where((source, index) => index != i).ToArray();
                }
            }

            if (leader.isDead())
            {
                TilesMap[leader.x, leader.y] = new EmptyTile(leader.x, leader.y, ' ');
            }

            //Adding enemies to the array
            for (int i = 0; i < arrEnemies.Length; i++)
            {
                AddToMap(arrEnemies[i]);
            }
            
            //Adding items to the array
            for (int i = 0; i < arrItems.Length; i++)
            {
                tilesMap[arrItems[i].x, arrItems[i].y] = arrItems[i];
            }
           
            //Enemies attacking hero
            foreach (var enemy in arrEnemies)
            {
                if (enemy.CheckRange(HeroPlayer))
                {
                    enemy.Attack(heroPlayer);
                }
                
                GetItemAtPosition(enemy);
            }

            UpdateVision();          
        }
        public void EnemyMovement()
        {
            Random random = new Random();
            int enmDirection;

            for (int i = 0; i < arrEnemies.Length; i++)
            {
                enmDirection = random.Next(1,5);
                arrEnemies[i].Move(arrEnemies[i].ReturnMove((Character.MovementEnum)enmDirection));
            }

            if (!leader.isDead())
            {
                leader.Move(leader.ReturnMove(default));
            }
        }

        public void GetItemAtPosition(Character character)
        {
            for (int i = 0; i < arrItems.Length; i++)
            {
                if (character.x == arrItems[i].x && character.y == arrItems[i].y)
                {
                    if (arrItems[i].GetType() == typeof(Gold))
                    {
                        character.PickUp((Gold)arrItems[i]);

                        if (arrItems[i].PickUp)
                        {
                            arrItems = arrItems.Where((source, index) => index != i).ToArray();
                        }
                    }
                    else if (arrItems[i].GetType() == typeof(RangedWeapon))
                    {
                        character.PickUp((RangedWeapon)arrItems[i]);
                        character.Equip((RangedWeapon)arrItems[i]);

                        arrItems = arrItems.Where((source, Index) => Index != i).ToArray() ;
                    }
                    else if (arrItems[i].GetType() == typeof(MeleeWeapon))
                    {
                        character.PickUp((MeleeWeapon)arrItems[i]);
                        character.Equip((MeleeWeapon)arrItems[i]);

                        arrItems = arrItems.Where((source, Index) => Index != i).ToArray();
                    }
                }
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

                //Adds Leader to the map

                case Tile.TileType.LEADER:
                    do
                    {
                        randomX = random.Next(1, tilesMap.GetLength(0));
                        randomY = random.Next(1, tilesMap.GetLength(1));
                    } while (isTileOpen(randomX, randomY));

                    return new Leader(randomX, randomY);

                //Creates enemy tile in map
                case Tile.TileType.Enemy:
                    do
                    {
                        randomX = random.Next(1, tilesMap.GetLength(0));
                        randomY = random.Next(1, tilesMap.GetLength(1));
                    } while (isTileOpen(randomX, randomY));

                    int num = random.Next(0, 2);
                    switch (num)
                    {
                        case 0:
                            return new Swamp_Creature(randomX, randomY);
                        case 1:
                            return new Mage(randomX, randomY);
                        default:
                            return null;
                    }
                //Adds gold to the map
                case Tile.TileType.Gold:
                    do
                    {
                        randomX = random.Next(1, tilesMap.GetLength(0));
                        randomY = random.Next(1, tilesMap.GetLength(1));
                    } while (isTileOpen(randomX, randomY));
                    return new Gold(randomX, randomY);

                //Create empty tile in map
                case Tile.TileType.Empty:
                    do
                    {
                        randomX = random.Next(1, tilesMap.GetLength(0));
                        randomY = random.Next(1, tilesMap.GetLength(1));
                    } while (isTileOpen(randomX, randomY));

                    return new EmptyTile(randomX, randomY, ' ');
                //Adds weapons to map
                case Tile.TileType.Weapon:
                    do
                    {
                        randomX = random.Next(1, tilesMap.GetLength(0));
                        randomY = random.Next(1, tilesMap.GetLength(1));
                    } while (isTileOpen(randomX, randomY));

                    switch (random.Next(0, 4))
                    {

                        case 0:
                            return new MeleeWeapon(MeleeWeapon.MeleeTypes.DAGGER, randomX, randomY);
                        case 1:
                            return new MeleeWeapon(MeleeWeapon.MeleeTypes.DAGGER, randomX, randomY);
                        case 2:
                            return new MeleeWeapon(MeleeWeapon.MeleeTypes.DAGGER, randomX, randomY);
                        case 3:
                            return new MeleeWeapon(MeleeWeapon.MeleeTypes.DAGGER, randomX, randomY);

                        default:
                            return null;
                    }
                default:
                    return null;

            }
        }

        //Update vision mathod
        public void UpdateVision()
        {    // up
            heroPlayer.VisionArray[0] = TilesMap[heroPlayer.x - 1, heroPlayer.y];
            // down
            heroPlayer.VisionArray[1] = TilesMap[heroPlayer.x + 1, heroPlayer.y];
            //left
            heroPlayer.VisionArray[2] = TilesMap[heroPlayer.x, heroPlayer.y - 1];
            //right
            heroPlayer.VisionArray[3] = TilesMap[heroPlayer.x, heroPlayer.y + 1];

            foreach (Enemy enemy in arrEnemies)
            {
                // up
                enemy.VisionArray[0] = TilesMap[enemy.x - 1, enemy.y];
                // down
                enemy.VisionArray[1] = TilesMap[enemy.x + 1, enemy.y];
                // left
                enemy.VisionArray[2] = TilesMap[enemy.x, enemy.y - 1];
                // right
                enemy.VisionArray[3] = TilesMap[enemy.x, enemy.y + 1];

            }
        }
    }
}
