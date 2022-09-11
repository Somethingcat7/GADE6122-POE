using GADE6122_POE.Classes;

namespace GADE6122_POE
{
    public partial class frmGame : Form
    {
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

        private void btnAttack_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < engine.Map.arrEnemies.Length; i++)
            {
             if (engine.Map.HeroPlayer.CheckRange(engine.Map.arrEnemies[i]))
             {
                    engine.Map.HeroPlayer.Attack(engine.Map.arrEnemies[i]);
             }
            }
           
        }
    }
}