using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Form;

namespace hanoi_towers
{
    public class DrawableObject
    {
        internal ControlCollection control;
        internal Panel visual_container;
        public Point Location { get { return visual_container.Location; } }

        public DrawableObject(ref ControlCollection control, Size size)
        {
            this.control = control;
            visual_container = new Panel();
            visual_container.Size = size;
        }

        public void Draw(Point location)
        {
            visual_container.Location = location;
            control.Add(visual_container);
        }

    }
}
