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
        Stack<Disc> discs = new Stack<Disc>();
        public Tower(Form.ControlCollection control) : base(ref control, cfg.sizeTower)
        {
            visual_container.BackColor = cfg.colorTower;
        }
        public void Push(Disc disc)
        {
            if (discs.Count != 0 && discs.Peek().radius < disc.radius)
            {
                disc.Return();
                return;
            }
            Point pos = CalculateDiscPosition(disc.visual_container.Width);
            discs.Push(disc);
            disc.curTower = this;
            discs.Peek().Draw(pos);
        }
        public Disc Pop(/*object sender, EventArgs e*/)
        {
            //if ((sender as Panel) != discs.Peek().visual_container)
            //{
            //    MessageBox.Show("Error");
            //    return;
            //}
            Disc disc = discs.Peek();
            discs.Pop();
            return disc;
        }

        private Point CalculateDiscPosition(int width)
        {
            int x = visual_container.Location.X - width / 2 + cfg.sizeTower.Width/2;
            int y = visual_container.Location.Y + visual_container.Height - cfg.discHeight - discs.Count*30 ;
            return new Point(x, y);
        }
        
    }
}
