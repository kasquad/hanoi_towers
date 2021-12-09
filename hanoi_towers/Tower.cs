using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace hanoi_towers
{

    public class Tower : DrawableObject
    {
        //static Timer timer1 = new Timer();
        Stack<Disc> discs = new Stack<Disc>();
        int y_top_goal;
        public int CountDisks()
        {
            return discs.Count();
        }
        public Tower(Form.ControlCollection control) : base(ref control, cfg.sizeTower)
        {
            visual_container.BackColor = cfg.colorTower;
            SetRoundedShape(visual_container, 10);
            visual_container.SendToBack();

            y_top_goal = visual_container.Location.Y + cfg.offsetYtower;
            //timer1.Tick += wait;



        }
        public void Push(Disc disc, bool animation)
        {
            if (discs.Count != 0 && discs.Peek().radius < disc.radius)
            {
                disc.Return();
                return;
            }
            
            Point pos = CalculateDiscPosition(disc.visual_container.Width);
            discs.Push(disc);
            if (!animation)
                disc.Draw(pos);
            else
                DiscAnimDraw(disc,pos);
            disc.curTower = this;
            Engine.win();

        }
        void DiscAnimDraw(Disc disc,Point final_pos)
        {
            //timer1.Interval = 200;
            Point cur_pos = disc.visual_container.Location;
            Move(y_top_goal, disc, true);
            Move(final_pos.X, disc, false);
            Move(final_pos.Y, disc, true);
            Mover.num_steps++;
            Engine.num_steps.Text = "Количество шагов: " + Mover.num_steps.ToString();


        }
        /// <summary>
        /// dir - false - horizontal , true - vertical
        /// </summary>
        /// <param name="goal"></param>
        /// <param name="dir"></param>
        /// <param name = "disc"></param>
        void Move(int goal, Disc disc , bool dir )
        {
            int eps = 1;
            int sign;
           
            if (dir)
            {
                sign = Math.Sign(goal - disc.visual_container.Location.Y);
                while (Math.Abs(goal - disc.visual_container.Location.Y) > eps)
                {
                    disc.visual_container.Location = new Point(disc.visual_container.Location.X,
                                                               disc.visual_container.Location.Y + sign * cfg.df);
                    Thread.Sleep(cfg.Animation_speed_param);
                }
                return;
            }
            sign = Math.Sign(goal - disc.visual_container.Location.X);

            while(Math.Abs(goal - disc.visual_container.Location.X) > eps)
            {
                disc.visual_container.Location = new Point(disc.visual_container.Location.X  + sign *cfg.df,
                                                           disc.visual_container.Location.Y);
                Thread.Sleep(cfg.Animation_speed_param);
            }
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
