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
        static Timer timer1 = new Timer();
        Stack<Disc> discs = new Stack<Disc>();
        int y_top_goal;
        public Tower(Form.ControlCollection control) : base(ref control, cfg.sizeTower)
        {
            visual_container.BackColor = cfg.colorTower;
            SetRoundedShape(visual_container, 10);
            visual_container.SendToBack();

            y_top_goal = visual_container.Location.Y + cfg.offsetYtower;
            timer1.Tick += wait;



        }
        public void Push(Disc disc, bool animation)
        {
            if (discs.Count != 0 && discs.Peek().radius < disc.radius)
            {
                disc.Return();
                return;
            }
            else
            {
                Mover.num_steps++;
                Engine.num_steps.Text = "Количество шагов: " + Mover.num_steps.ToString();
            }
            Point pos = CalculateDiscPosition(disc.visual_container.Width);
            discs.Push(disc);
            if (!animation)
                disc.Draw(pos);
            else
                DiscAnimDraw(disc,pos);
            disc.curTower = this;

        }
        void DiscAnimDraw(Disc disc,Point final_pos)
        {
            timer1.Interval = 80;
            bool flag = true;
            Point cur_pos = disc.visual_container.Location;
            //timer1.Start();
            disc.visual_container.Location = cur_pos;
           

            //while (disc.Location != final_pos)
            //{
            //    if (cur_pos.Y > y_top_goal && flag)
            //    {
            //        cur_pos.Y -= cfg.df;
            //        continue;

            //    }
            //    else if (cur_pos.X < final_pos.X)
            //    {
            //        if (cur_pos.X < final_pos.X)
            //        {
            //            cur_pos.X += cfg.df;
            //            continue;

            //        }

            //    }
            //    else if (cur_pos.X >= final_pos.X)
            //    {
            //        cur_pos.X -= cfg.df;
            //        continue;
 
            //    }
            //    flag = false;
            //    if (cur_pos.Y < final_pos.Y&& !flag)
            //    {
            //        cur_pos.Y += cfg.df;
            //    }
     
 
            //}




        }
        void wait(object sender, EventArgs e)
        {
            //timer1.Enabled = false;
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
