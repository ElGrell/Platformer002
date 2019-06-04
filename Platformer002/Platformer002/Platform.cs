using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Platformer002
{
    class Platform
    {

        private PictureBox pbPlatform = new PictureBox();

        public Platform()
        {
            pbPlatform.Width = 130;
            pbPlatform.Height = 15;
            pbPlatform.BackColor = Color.ForestGreen;
        }

        public void drawTo(Form f)
        {
            f.Controls.Add(pbPlatform);
        }

        public Rectangle getBounds()
        {
            return pbPlatform.Bounds;
        }

        public void setPos(int x, int y)
        {
            pbPlatform.Location = new Point(x, y);
        }
        public PictureBox getPictureBox()
        {
            return pbPlatform;
        }
    }
}