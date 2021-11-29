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

    public class Tower : DrawableObject
    {
        Stack<Disc> discs = new Stack<Disc>();
        public Tower(Form.ControlCollection control) : base(ref control, cfg.sizeTower)
        {
            visual_container.BackColor = cfg.colorTower;
            SetRoundedShape(visual_container, 10);
            visual_container.SendToBack();
        }
        public void Push(Disc disc)
        {
            if (discs.Count != 0 && discs.Peek().radius < disc.radius)
            {
                disc.Return();
                return;
            }
            Point pos = CalculateDiscPosition(disc.visual_container.Width);
            disc.curTower = this;
            discs.Push(disc);
            disc.Draw(pos);
        }


        public Disc Pop()
        {
            Disc disc = discs.Peek();
            discs.Pop();
            return disc;
        }

        public Disc Peek()
        {
            return discs.Peek();
        }
        private Point CalculateDiscPosition(int width)
        {
            int x = visual_container.Location.X - width / 2 + cfg.sizeTower.Width/2;
            int y = visual_container.Location.Y + visual_container.Height - cfg.discHeight - discs.Count*30 ;
            return new Point(x, y);
        }

        public void Clear()
        {
            while(discs.Count != 0)
            {
                discs.Peek().Delete();
                discs.Pop();
            }
        }
        
    }
}
