using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace hanoi_towers
{

    class Tower : DrawableObject
    {
        Stack<Disc> discs;
        public Tower(Form.ControlCollection control) : base(ref control, cfg.sizeTower)
        {
            visual_container.BackColor = cfg.colorTower;
        }
        public void Push( Disc disc)
        {
            if (discs.Count != 0 && discs.Peek().radius > disc.radius)
            {
                return;
            }
            Point pos = CalculateDiscPosition();
            discs.Push(disc);
            discs.Peek().Draw(pos);
        }
        public void Pop(object sender, EventArgs e)
        {
            if ((sender as Panel) != discs.Peek().visual_container)
                return;
        }

        private Point CalculateDiscPosition()
        {
            return new Point(0, 0);
        }
        
    }
}
