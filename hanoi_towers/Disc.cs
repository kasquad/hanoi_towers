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
        public Disc(Form.ControlCollection control, Size size) : base(ref control, size)
        {
            visual_container.BackColor = cfg.disc_color;
            visual_container.BringToFront();
        }
    }
}
