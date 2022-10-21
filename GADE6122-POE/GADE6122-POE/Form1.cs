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
        GameEngine GameEngine = new GameEngine();

        public frmGame()
        {
            InitializeComponent();
        }

        GameEngine engine = new GameEngine();

        private void Form1_Load(object sender, EventArgs e)
        {
            MapCreate();
        }

        private void MapCreate()
        {   
            //Create map
            lblMap.Text = engine.ToString();

            //Show player stats
            lblPlayerStats.Text = engine.Map.HeroPlayer.ToString();

            //Adds enemies and items to comboboxes
            cmbEnemies.DataSource = GameEngine.Map.arrEnemies;
            cmbItems.DataSource = GameEngine.Map.arrItems;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            engine.Map.HeroPlayer.Move(engine.Map.HeroPlayer.ReturnMove(Characters.Character.MovementEnum.Up));
            engine.Map.EnemyMovement();
            engine.Map.MapUpdate();
            MapCreate();

            cmbEnemies.DataSource = engine.Map.arrEnemies;
            cmbItems.DataSource = engine.Map.arrItems;

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            engine.Map.HeroPlayer.Move(engine.Map.HeroPlayer.ReturnMove(Characters.Character.MovementEnum.Down));
            engine.Map.EnemyMovement();
            engine.Map.MapUpdate();
            MapCreate();

            cmbEnemies.DataSource = engine.Map.arrEnemies;
            cmbItems.DataSource = engine.Map.arrItems;

        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            engine.Map.HeroPlayer.Move(engine.Map.HeroPlayer.ReturnMove(Characters.Character.MovementEnum.Right));
            engine.Map.EnemyMovement();
            engine.Map.MapUpdate();
            MapCreate();

            cmbEnemies.DataSource = engine.Map.arrEnemies;
            cmbItems.DataSource = engine.Map.arrItems;
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            engine.Map.HeroPlayer.Move(engine.Map.HeroPlayer.ReturnMove(Characters.Character.MovementEnum.Left));
            engine.Map.EnemyMovement();
            engine.Map.MapUpdate();
            MapCreate();

            cmbEnemies.DataSource = engine.Map.arrEnemies;
            cmbItems.DataSource = engine.Map.arrItems;

        }
        //Attacks enemies if they are in range
        private void btnAttack_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < engine.Map.arrEnemies.Length; i++)
            {
             if (engine.Map.HeroPlayer.CheckRange(engine.Map.arrEnemies[cmbEnemies.SelectedIndex]))
             {
                    engine.Map.HeroPlayer.Attack(engine.Map.arrEnemies[cmbEnemies.SelectedIndex]);
                    GameEngine.Map.EnemyMovement();
             }
            }

            engine.Map.MapUpdate();

            cmbEnemies.DataSource = engine.Map.arrEnemies;
            cmbItems.DataSource = engine.Map.arrItems;

        }
        //Saves game
        private void SaveGame()
        {
            BinaryFormatter Formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\SaveFile.dat", FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            Formatter.Serialize(fileStream, GameEngine);
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
            GameEngine = (GameEngine)Formatter.Deserialize(fileStream);
            GameEngine.Map.MapUpdate();
            MapCreate();
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
    }
}