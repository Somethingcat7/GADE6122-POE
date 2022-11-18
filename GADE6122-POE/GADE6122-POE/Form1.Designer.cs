namespace GADE6122_POE
{
    //[Serializable]
    partial class frmGame
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMap = new System.Windows.Forms.Label();
            this.lblPlayerStats = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnAttack = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbEnemies = new System.Windows.Forms.ComboBox();
            this.cmbItems = new System.Windows.Forms.ComboBox();
            this.lblEnemiesList = new System.Windows.Forms.Label();
            this.lblItemsList = new System.Windows.Forms.Label();
            this.lblDialoge = new System.Windows.Forms.Label();
            this.btnShop1 = new System.Windows.Forms.Button();
            this.btnShop2 = new System.Windows.Forms.Button();
            this.btnShop3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMap.Location = new System.Drawing.Point(12, 9);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(98, 16);
            this.lblMap.TabIndex = 0;
            this.lblMap.Text = "Map Goes Here";
            // 
            // lblPlayerStats
            // 
            this.lblPlayerStats.AutoSize = true;
            this.lblPlayerStats.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPlayerStats.Location = new System.Drawing.Point(424, 9);
            this.lblPlayerStats.Name = "lblPlayerStats";
            this.lblPlayerStats.Size = new System.Drawing.Size(161, 16);
            this.lblPlayerStats.TabIndex = 1;
            this.lblPlayerStats.Text = "Player stats Goes Here";
            this.lblPlayerStats.Click += new System.EventHandler(this.lblPlayerStats_Click);
            // 
            // btnDown
            // 
            this.btnDown.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDown.Location = new System.Drawing.Point(93, 485);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "V";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLeft.Location = new System.Drawing.Point(12, 456);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 23);
            this.btnLeft.TabIndex = 3;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnAttack
            // 
            this.btnAttack.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAttack.Location = new System.Drawing.Point(93, 456);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(75, 23);
            this.btnAttack.TabIndex = 4;
            this.btnAttack.Text = "Attack";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // btnRight
            // 
            this.btnRight.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRight.Location = new System.Drawing.Point(174, 456);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 5;
            this.btnRight.Text = ">";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnUp
            // 
            this.btnUp.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUp.Location = new System.Drawing.Point(93, 427);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 6;
            this.btnUp.Text = "^";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLoad.Location = new System.Drawing.Point(174, 485);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(12, 485);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbEnemies
            // 
            this.cmbEnemies.FormattingEnabled = true;
            this.cmbEnemies.Location = new System.Drawing.Point(276, 396);
            this.cmbEnemies.Name = "cmbEnemies";
            this.cmbEnemies.Size = new System.Drawing.Size(369, 23);
            this.cmbEnemies.TabIndex = 9;
            this.cmbEnemies.SelectedIndexChanged += new System.EventHandler(this.cmbEnemies_SelectedIndexChanged);
            // 
            // cmbItems
            // 
            this.cmbItems.FormattingEnabled = true;
            this.cmbItems.Location = new System.Drawing.Point(276, 454);
            this.cmbItems.Name = "cmbItems";
            this.cmbItems.Size = new System.Drawing.Size(369, 23);
            this.cmbItems.TabIndex = 10;
            this.cmbItems.SelectedIndexChanged += new System.EventHandler(this.cmbItems_SelectedIndexChanged);
            // 
            // lblEnemiesList
            // 
            this.lblEnemiesList.AutoSize = true;
            this.lblEnemiesList.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEnemiesList.Location = new System.Drawing.Point(276, 377);
            this.lblEnemiesList.Name = "lblEnemiesList";
            this.lblEnemiesList.Size = new System.Drawing.Size(56, 16);
            this.lblEnemiesList.TabIndex = 11;
            this.lblEnemiesList.Text = "Enemies";
            this.lblEnemiesList.Click += new System.EventHandler(this.lblEnemiesList_Click);
            // 
            // lblItemsList
            // 
            this.lblItemsList.AutoSize = true;
            this.lblItemsList.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblItemsList.Location = new System.Drawing.Point(276, 428);
            this.lblItemsList.Name = "lblItemsList";
            this.lblItemsList.Size = new System.Drawing.Size(42, 16);
            this.lblItemsList.TabIndex = 12;
            this.lblItemsList.Text = "Items";
            this.lblItemsList.Click += new System.EventHandler(this.lblItemsList_Click);
            // 
            // lblDialoge
            // 
            this.lblDialoge.AutoSize = true;
            this.lblDialoge.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDialoge.Location = new System.Drawing.Point(424, 154);
            this.lblDialoge.Name = "lblDialoge";
            this.lblDialoge.Size = new System.Drawing.Size(56, 16);
            this.lblDialoge.TabIndex = 13;
            this.lblDialoge.Text = "Dialoge";
            // 
            // btnShop1
            // 
            this.btnShop1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnShop1.Location = new System.Drawing.Point(276, 483);
            this.btnShop1.Name = "btnShop1";
            this.btnShop1.Size = new System.Drawing.Size(119, 23);
            this.btnShop1.TabIndex = 15;
            this.btnShop1.Text = "button2";
            this.btnShop1.UseVisualStyleBackColor = true;
            this.btnShop1.Click += new System.EventHandler(this.btnShop1_Click);
            // 
            // btnShop2
            // 
            this.btnShop2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnShop2.Location = new System.Drawing.Point(401, 483);
            this.btnShop2.Name = "btnShop2";
            this.btnShop2.Size = new System.Drawing.Size(119, 23);
            this.btnShop2.TabIndex = 16;
            this.btnShop2.Text = "btnShop2";
            this.btnShop2.UseVisualStyleBackColor = true;
            this.btnShop2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnShop3
            // 
            this.btnShop3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnShop3.Location = new System.Drawing.Point(526, 483);
            this.btnShop3.Name = "btnShop3";
            this.btnShop3.Size = new System.Drawing.Size(119, 23);
            this.btnShop3.TabIndex = 17;
            this.btnShop3.Text = "button2";
            this.btnShop3.UseVisualStyleBackColor = true;
            this.btnShop3.Click += new System.EventHandler(this.btnShop3_Click);
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 518);
            this.Controls.Add(this.btnShop3);
            this.Controls.Add(this.btnShop2);
            this.Controls.Add(this.btnShop1);
            this.Controls.Add(this.lblDialoge);
            this.Controls.Add(this.lblItemsList);
            this.Controls.Add(this.lblEnemiesList);
            this.Controls.Add(this.cmbItems);
            this.Controls.Add(this.cmbEnemies);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.lblPlayerStats);
            this.Controls.Add(this.lblMap);
            this.Name = "frmGame";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblMap;
        private Label lblPlayerStats;
        private Button btnDown;
        private Button btnLeft;
        private Button btnAttack;
        private Button btnRight;
        private Button btnUp;
        private Button btnLoad;
        private Button btnSave;
        private ComboBox cmbEnemies;
        private ComboBox cmbItems;
        private Label lblEnemiesList;
        private Label lblItemsList;
        private Label lblDialoge;
        private Button btnShop1;
        private Button btnShop2;
        private Button btnShop3;
    }
}