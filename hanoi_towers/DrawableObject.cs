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
        static internal void SetRoundedShape(Control control, int radius) //Взял метод из интернета
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddLine(radius, 0, control.Width - radius, 0);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddLine(control.Width, radius, control.Width, control.Height - radius);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddLine(control.Width - radius, control.Height, radius, control.Height);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.AddLine(0, control.Height - radius, 0, radius);
            path.AddArc(0, 0, radius, radius, 180, 90);
            control.Region = new Region(path);
        }

    }
}
