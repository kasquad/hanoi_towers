using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hanoi_towers
{
    public class Disc : DrawableObject
    {
        public int radius;
        public Tower curTower;

        static private Point move_pos = new Point();
        public Disc(Form.ControlCollection control, Size size, ref Tower curTower) : base(ref control, size)
        {
            visual_container.BackColor = cfg.disc_color;
            visual_container.BringToFront();
            radius = size.Width;
            this.curTower = curTower;
            SetRoundedShape(visual_container, 10);

            visual_container.MouseDown += new MouseEventHandler(MouseDown);
            visual_container.MouseMove += new MouseEventHandler(Disc.Move);
            visual_container.MouseUp += new MouseEventHandler(Mover.Transfer);
        }

        public void Return()
        {
            MessageBox.Show("Incorrect move");
            curTower.Push(this);
        }

       static public void Move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                Panel v_c = (sender as Panel);
                Point newlocation = v_c.Location;
                newlocation.X += e.X - move_pos.X;
                newlocation.Y += e.Y - move_pos.Y;
                v_c.Location = newlocation;
            }
        }

         public void MouseDown(object sender, MouseEventArgs e) {
            move_pos.X = e.X;
            move_pos.Y = e.Y;
            Mover.disc = this;
            if (this != this.curTower.Peek())
            {
                Mover.IsCorrectPick = false;
                MessageBox.Show("Incorrect move");
                return;
            }
            else
            {
                Mover.IsCorrectPick = true;
                this.curTower.Pop();
            }
        }
       
        
    }
}
