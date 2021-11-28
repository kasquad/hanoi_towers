using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hanoi_towers
{
    class Disc : DrawableObject
    {
        public int radius;
        public Tower curTower;
        public Disc(Form.ControlCollection control, Size size, ref Tower curTower) : base(ref control, size)
        {
            visual_container.BackColor = cfg.disc_color;
            visual_container.BringToFront();
            radius = size.Width;
            this.curTower = curTower;
        }
        
        public void Return()
        {
            MessageBox.Show("Incorrect move");
            curTower.Push(this);
        }
    }
}
