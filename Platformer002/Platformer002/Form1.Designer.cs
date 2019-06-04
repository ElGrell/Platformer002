namespace Platformer002
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            this.tmrRight = new System.Windows.Forms.Timer(this.components);
            this.tmrLeft = new System.Windows.Forms.Timer(this.components);
            this.lblScore = new System.Windows.Forms.Label();
            this.lblTurorial = new System.Windows.Forms.Label();
            this.tmrGameLoop = new System.Windows.Forms.Timer(this.components);
            this.lblWon = new System.Windows.Forms.Label();
            this.lblLost = new System.Windows.Forms.Label();
            this.ceiling = new System.Windows.Forms.PictureBox();
            this.floor = new System.Windows.Forms.PictureBox();
            this.leftwall0 = new System.Windows.Forms.PictureBox();
            this.leftwall1 = new System.Windows.Forms.PictureBox();
            this.leftwall2 = new System.Windows.Forms.PictureBox();
            this.rightwall0 = new System.Windows.Forms.PictureBox();
            this.rightwall1 = new System.Windows.Forms.PictureBox();
            this.rightwall2 = new System.Windows.Forms.PictureBox();
            this.nextLevelDoor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceiling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.floor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftwall0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftwall1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftwall2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightwall0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightwall1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightwall2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextLevelDoor)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPlayer
            // 
            this.pbPlayer.BackColor = System.Drawing.Color.Indigo;
            this.pbPlayer.Location = new System.Drawing.Point(70, 100);
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.Size = new System.Drawing.Size(20, 40);
            this.pbPlayer.TabIndex = 1;
            this.pbPlayer.TabStop = false;
            // 
            // tmrRight
            // 
            this.tmrRight.Interval = 1;
            this.tmrRight.Tick += new System.EventHandler(this.tmrRight_Tick);
            // 
            // tmrLeft
            // 
            this.tmrLeft.Interval = 1;
            this.tmrLeft.Tick += new System.EventHandler(this.tmrLeft_Tick);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.LimeGreen;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(-2, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(92, 25);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "Score: 0";
            // 
            // lblTurorial
            // 
            this.lblTurorial.AutoSize = true;
            this.lblTurorial.BackColor = System.Drawing.Color.Transparent;
            this.lblTurorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurorial.Location = new System.Drawing.Point(1000, 1000);
            this.lblTurorial.Name = "lblTurorial";
            this.lblTurorial.Size = new System.Drawing.Size(430, 200);
            this.lblTurorial.TabIndex = 1;
            this.lblTurorial.Text = "Welcome to <INSERT GAME NAME HERE>\r\n\r\nPlay with WASD or Arrows\r\nAlso, SPACE for J" +
    "ump\r\nQ - reverse the gravity\r\nSHIFT to speed up\r\nCollect coins to go next level\r" +
    "\n15 Levels to win";
            // 
            // tmrGameLoop
            // 
            this.tmrGameLoop.Enabled = true;
            this.tmrGameLoop.Interval = 1;
            this.tmrGameLoop.Tick += new System.EventHandler(this.tmrGameLoop_Tick);
            // 
            // lblWon
            // 
            this.lblWon.AutoSize = true;
            this.lblWon.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblWon.ForeColor = System.Drawing.Color.Black;
            this.lblWon.Location = new System.Drawing.Point(225, 137);
            this.lblWon.Name = "lblWon";
            this.lblWon.Size = new System.Drawing.Size(368, 93);
            this.lblWon.TabIndex = 1;
            this.lblWon.Text = "You\'ve finished all the levels, \r\n Good Job! \r\n press R to restart";
            this.lblWon.Visible = false;
            // 
            // lblLost
            // 
            this.lblLost.AutoSize = true;
            this.lblLost.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblLost.ForeColor = System.Drawing.Color.Black;
            this.lblLost.Location = new System.Drawing.Point(303, 171);
            this.lblLost.Name = "lblLost";
            this.lblLost.Size = new System.Drawing.Size(226, 62);
            this.lblLost.TabIndex = 1;
            this.lblLost.Text = "Oh no! You died!\r\nPress R to restart";
            this.lblLost.Visible = false;
            // 
            // ceiling
            // 
            this.ceiling.BackColor = System.Drawing.Color.LimeGreen;
            this.ceiling.Location = new System.Drawing.Point(0, 0);
            this.ceiling.Name = "ceiling";
            this.ceiling.Size = new System.Drawing.Size(800, 25);
            this.ceiling.TabIndex = 0;
            this.ceiling.TabStop = false;
            // 
            // floor
            // 
            this.floor.BackColor = System.Drawing.Color.LimeGreen;
            this.floor.Location = new System.Drawing.Point(0, 435);
            this.floor.Name = "floor";
            this.floor.Size = new System.Drawing.Size(800, 15);
            this.floor.TabIndex = 0;
            this.floor.TabStop = false;
            // 
            // leftwall0
            // 
            this.leftwall0.BackColor = System.Drawing.Color.LimeGreen;
            this.leftwall0.Location = new System.Drawing.Point(0, 0);
            this.leftwall0.Name = "leftwall0";
            this.leftwall0.Size = new System.Drawing.Size(40, 175);
            this.leftwall0.TabIndex = 0;
            this.leftwall0.TabStop = false;
            // 
            // leftwall1
            // 
            this.leftwall1.BackColor = System.Drawing.Color.LimeGreen;
            this.leftwall1.Location = new System.Drawing.Point(0, 275);
            this.leftwall1.Name = "leftwall1";
            this.leftwall1.Size = new System.Drawing.Size(40, 175);
            this.leftwall1.TabIndex = 0;
            this.leftwall1.TabStop = false;
            // 
            // leftwall2
            // 
            this.leftwall2.BackColor = System.Drawing.Color.LimeGreen;
            this.leftwall2.Location = new System.Drawing.Point(0, 0);
            this.leftwall2.Name = "leftwall2";
            this.leftwall2.Size = new System.Drawing.Size(20, 450);
            this.leftwall2.TabIndex = 0;
            this.leftwall2.TabStop = false;
            // 
            // rightwall0
            // 
            this.rightwall0.BackColor = System.Drawing.Color.LimeGreen;
            this.rightwall0.Location = new System.Drawing.Point(760, 0);
            this.rightwall0.Name = "rightwall0";
            this.rightwall0.Size = new System.Drawing.Size(20, 450);
            this.rightwall0.TabIndex = 0;
            this.rightwall0.TabStop = false;
            // 
            // rightwall1
            // 
            this.rightwall1.BackColor = System.Drawing.Color.LimeGreen;
            this.rightwall1.Location = new System.Drawing.Point(760, 0);
            this.rightwall1.Name = "rightwall1";
            this.rightwall1.Size = new System.Drawing.Size(40, 175);
            this.rightwall1.TabIndex = 0;
            this.rightwall1.TabStop = false;
            // 
            // rightwall2
            // 
            this.rightwall2.BackColor = System.Drawing.Color.LimeGreen;
            this.rightwall2.Location = new System.Drawing.Point(760, 275);
            this.rightwall2.Name = "rightwall2";
            this.rightwall2.Size = new System.Drawing.Size(40, 175);
            this.rightwall2.TabIndex = 0;
            this.rightwall2.TabStop = false;
            // 
            // nextLevelDoor
            // 
            this.nextLevelDoor.BackColor = System.Drawing.Color.SaddleBrown;
            this.nextLevelDoor.Location = new System.Drawing.Point(780, 175);
            this.nextLevelDoor.Name = "nextLevelDoor";
            this.nextLevelDoor.Size = new System.Drawing.Size(20, 100);
            this.nextLevelDoor.TabIndex = 0;
            this.nextLevelDoor.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblLost);
            this.Controls.Add(this.lblWon);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.pbPlayer);
            this.Controls.Add(this.ceiling);
            this.Controls.Add(this.floor);
            this.Controls.Add(this.leftwall0);
            this.Controls.Add(this.leftwall1);
            this.Controls.Add(this.leftwall2);
            this.Controls.Add(this.rightwall0);
            this.Controls.Add(this.rightwall1);
            this.Controls.Add(this.rightwall2);
            this.Controls.Add(this.nextLevelDoor);
            this.Controls.Add(this.lblTurorial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Platformer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceiling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.floor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftwall0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftwall1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftwall2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightwall0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightwall1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightwall2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextLevelDoor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // private System.Windows.Forms.PictureBox pbGround01;
        private System.Windows.Forms.PictureBox pbPlayer;
        // private System.Windows.Forms.Timer tmrUp;
        private System.Windows.Forms.Timer tmrRight;
        private System.Windows.Forms.Timer tmrLeft;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblTurorial;
        private System.Windows.Forms.Timer tmrGameLoop;


        private System.Windows.Forms.PictureBox ceiling;
        private System.Windows.Forms.PictureBox floor;
        private System.Windows.Forms.PictureBox leftwall0;
        private System.Windows.Forms.PictureBox leftwall1;
        private System.Windows.Forms.PictureBox leftwall2;
        private System.Windows.Forms.PictureBox rightwall0;
        private System.Windows.Forms.PictureBox rightwall1;
        private System.Windows.Forms.PictureBox rightwall2;
        private System.Windows.Forms.PictureBox nextLevelDoor;




        // private System.Windows.Forms.PictureBox pbPlatform01;
        private System.Windows.Forms.Label lblWon;
        // private System.Windows.Forms.PictureBox pbGround02;
        // private System.Windows.Forms.PictureBox pbPlatform02;
        // private System.Windows.Forms.PictureBox Lava01;
        private System.Windows.Forms.Label lblLost;
    }
}

