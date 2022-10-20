using GADE6122_POE.Classes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace GADE6122_POE
{
    public partial class frmGame : Form
    {

        Stream Stream;
        IFormatter Formatter;
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
            
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            engine.Map.HeroPlayer.Move(engine.Map.HeroPlayer.ReturnMove(Characters.Character.MovementEnum.Down));
            engine.Map.EnemyMovement();
            engine.Map.MapUpdate();
            MapCreate();

        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            engine.Map.HeroPlayer.Move(engine.Map.HeroPlayer.ReturnMove(Characters.Character.MovementEnum.Right));
            engine.Map.EnemyMovement();
            engine.Map.MapUpdate();
            MapCreate();

        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            engine.Map.HeroPlayer.Move(engine.Map.HeroPlayer.ReturnMove(Characters.Character.MovementEnum.Left));
            engine.Map.EnemyMovement();
            engine.Map.MapUpdate();
            MapCreate();

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
           
        }

        private void SaveGame()
        {
            Stream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "SaveFile.dat", FileMode.Create, FileAccess.Write);
            Formatter.Serialize(Stream, GameEngine);
            Stream.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveGame();
        }

        private void LoadGame()
        {
            Stream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "SaveFile.dat", FileMode.Open, FileAccess.Read);
            GameEngine = (GameEngine)Formatter.Deserialize(Stream);
            GameEngine.Map.MapUpdate();
            MapCreate();
            Stream.Close();
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