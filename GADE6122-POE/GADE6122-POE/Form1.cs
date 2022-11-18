using GADE6122_POE.Classes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.IO;

namespace GADE6122_POE
{
    [Serializable]
    public partial class frmGame : Form
    {       
        GameEngine gameEngine = new GameEngine();

        public frmGame()
        {
            InitializeComponent();
        }

        GameEngine engine = new GameEngine();

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateMap();
        }

        private void UpdateMap()
        {   
            //Create map
            lblMap.Text = engine.ToString();

            //Show player stats
            lblPlayerStats.Text = engine.Map.HeroPlayer.ToString();

            //Adds enemies and items to comboboxes
            cmbEnemies.DataSource = gameEngine.Map.arrEnemies;
            cmbItems.DataSource = gameEngine.Map.arrItems;

            btnShop1.Text = gameEngine.Map.shop.DisplayWeapons(gameEngine.Map.shop.ArrayOfWeapons[0].Cost);
            btnShop2.Text = gameEngine.Map.shop.DisplayWeapons(gameEngine.Map.shop.ArrayOfWeapons[1].Cost);
            btnShop3.Text = gameEngine.Map.shop.DisplayWeapons(gameEngine.Map.shop.ArrayOfWeapons[2].Cost);

            gameEngine.Map.UpdateVision();

            CheckShopCost();
            Win();
            Lost();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            engine.Map.MapUpdate();
            engine.Map.HeroPlayer.Move(engine.Map.HeroPlayer.ReturnMove(Characters.Character.MovementEnum.Up));
            engine.Map.EnemyMovement();
            engine.Map.MapUpdate();
            UpdateMap();

            cmbEnemies.DataSource = engine.Map.arrEnemies;
            cmbItems.DataSource = engine.Map.arrItems;

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            engine.Map.MapUpdate();
            engine.Map.HeroPlayer.Move(engine.Map.HeroPlayer.ReturnMove(Characters.Character.MovementEnum.Down));
            engine.Map.EnemyMovement();
            engine.Map.MapUpdate();
            UpdateMap();

            cmbEnemies.DataSource = engine.Map.arrEnemies;
            cmbItems.DataSource = engine.Map.arrItems;

        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            engine.Map.MapUpdate();
            engine.Map.HeroPlayer.Move(engine.Map.HeroPlayer.ReturnMove(Characters.Character.MovementEnum.Right));
            engine.Map.EnemyMovement();
            engine.Map.MapUpdate();
            UpdateMap();

            cmbEnemies.DataSource = engine.Map.arrEnemies;
            cmbItems.DataSource = engine.Map.arrItems;
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            engine.Map.MapUpdate();
            engine.Map.HeroPlayer.Move(engine.Map.HeroPlayer.ReturnMove(Characters.Character.MovementEnum.Left));
            engine.Map.EnemyMovement();
            engine.Map.MapUpdate();
            UpdateMap();

            cmbEnemies.DataSource = engine.Map.arrEnemies;
            cmbItems.DataSource = engine.Map.arrItems;

        }
        //Attacks enemies if they are in range
        private void btnAttack_Click(object sender, EventArgs e)
        {
            engine.Map.MapUpdate();
            // for (int i = 0; i < engine.Map.arrEnemies.Length; i++)
            //{
            if (engine.Map.HeroPlayer.CheckRange(engine.Map.arrEnemies[cmbEnemies.SelectedIndex]))
            {
                    engine.Map.HeroPlayer.Attack(engine.Map.arrEnemies[cmbEnemies.SelectedIndex]);
                    gameEngine.Map.EnemyMovement();
                lblDialoge.Text = "Enemy was attacked";

                if (gameEngine.Map.arrEnemies[cmbEnemies.SelectedIndex].isDead())
                {
                    lblDialoge.Text = $"You killed {gameEngine.Map.arrEnemies[cmbEnemies.SelectedIndex]}!";
                }
            }
            else
            {
                lblDialoge.Text = "Enemy not in range";
            }
            //}
            
            engine.Map.MapUpdate();
            
            UpdateMap();

            cmbEnemies.DataSource = engine.Map.arrEnemies;
            cmbItems.DataSource = engine.Map.arrItems;

        }
        //Saves game
        private void SaveGame()
        {
            BinaryFormatter Formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\SaveFile.dat", FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            Formatter.Serialize(fileStream, gameEngine); //For some reason the save file is empty
            fileStream.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveGame();
        }
        //Loads game
        private void LoadGame()
        {
            BinaryFormatter Formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\SaveFile.dat", FileMode.Open, FileAccess.Read);
            gameEngine = (GameEngine)Formatter.Deserialize(fileStream);//I think this would work if the savefile wasn't empty
            gameEngine.Map.MapUpdate();
            UpdateMap();
            fileStream.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadGame();
        }

        private void lblEnemiesList_Click(object sender, EventArgs e)
        {

        }

        private void lblPlayerStats_Click(object sender, EventArgs e)
        {

        }

        private void cmbEnemies_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblItemsList_Click(object sender, EventArgs e)
        {

        }

        private void btnShop1_Click(object sender, EventArgs e)
        {
            if (gameEngine.Map.shop.Buyable(gameEngine.Map.shop.ArrayOfWeapons[0].Cost))
            {
                gameEngine.Map.shop.Buy(gameEngine.Map.shop.ArrayOfWeapons[0].Cost);
                lblDialoge.Text = $"You baught a {gameEngine.Map.shop.ArrayOfWeapons[0]}!";
                UpdateMap();
            }
            else
            {
                lblDialoge.Text = "Cannot afford that!";
                UpdateMap();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (gameEngine.Map.shop.Buyable(gameEngine.Map.shop.ArrayOfWeapons[1].Cost))
            {
                gameEngine.Map.shop.Buy(gameEngine.Map.shop.ArrayOfWeapons[1].Cost);
                lblDialoge.Text = $"You baught a {gameEngine.Map.shop.ArrayOfWeapons[1]}!";
                UpdateMap();
            }
            else
            {
                lblDialoge.Text = "Cannot afford that!";
                UpdateMap();
            }
        }

        private void btnShop3_Click(object sender, EventArgs e)
        {
            if (gameEngine.Map.shop.Buyable(gameEngine.Map.shop.ArrayOfWeapons[2].Cost))
            {
                gameEngine.Map.shop.Buy(gameEngine.Map.shop.ArrayOfWeapons[2].Cost);
                lblDialoge.Text = $"You baught a {gameEngine.Map.shop.ArrayOfWeapons[2]}!";
                UpdateMap();
            }
            else
            {
                lblDialoge.Text = "Cannot afford that!";
                UpdateMap();
            }
        }

        private void CheckShopCost()
        {
            if (gameEngine.Map.shop.ArrayOfWeapons[0].Cost <= gameEngine.Map.HeroPlayer.GoldOnHand)
            {
                btnShop1.Enabled = true;
            }
            else
            {
                btnShop1.Enabled = false;
            }
           
            if (gameEngine.Map.shop.ArrayOfWeapons[1].Cost <= gameEngine.Map.HeroPlayer.GoldOnHand)
            {
                btnShop2.Enabled = true;
            }
            else
            {
                btnShop2.Enabled = false;
            }
           
            if (gameEngine.Map.shop.ArrayOfWeapons[2].Cost <= gameEngine.Map.HeroPlayer.GoldOnHand)
            {
                btnShop3.Enabled = true;
            }
            else
            {
                btnShop3.Enabled = false;
            }
        }

        private void Win()
        {
            if (gameEngine.Map.arrEnemies.Length == 0)
            {
                lblDialoge.Text = "You win!";
            }
        }

        private void Lost()
        {
            if (gameEngine.Map.HeroPlayer.isDead())
            {
                lblDialoge.Text = "You lose!";
            }
        }


    }
}