using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Platformer002
{
    class Coin
    {

        private PictureBox pbCoin = new PictureBox();

        public Coin()
        {
            pbCoin.Width = 5;
            pbCoin.Height = 15;
            pbCoin.BackColor = Color.Gold;
        }

        public void drawTo(Form f)
        {
            f.Controls.Add(pbCoin);
        }

        public Rectangle getBounds()
        {
            return pbCoin.Bounds;
        }

        public void setPos(int x, int y)
        {
            pbCoin.Location = new Point(x, y);
        }
    }
}