using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Platformer002
{
    class Monster
    {

        private PictureBox pbMonster = new PictureBox();
        public int Speed = 10;
        public int LeftLimit = 100;
        public int RightLimit = 700;


        public Monster()
        {
            pbMonster.Width = 30;
            pbMonster.Height = 60;
            pbMonster.BackColor = Color.Red;
            // pbMonster.ImageLocation = @"Image\1.png";

        }

        public void drawTo(Form f)
        {
            f.Controls.Add(pbMonster);
        }

        public Rectangle getBounds()
        {
            return pbMonster.Bounds;
        }

        public void setPos(int x, int y)
        {
            pbMonster.Location = new Point(x, y);
        }
        public void moveX(int x){
            pbMonster.Left = x;
        }
    }
}