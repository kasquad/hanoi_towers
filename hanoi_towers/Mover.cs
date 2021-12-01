using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hanoi_towers
{
    class Mover
    {
        static public Disc disc;
        static public Tower next_tower;
        static public bool IsCorrectPick;
        static public int num_steps = 0;
        static public void Transfer(object sender, MouseEventArgs e)
        {
            if (!IsCorrectPick)
                return;
            
            Point disc_pos = disc.Location;
            for(int i = 0; i < cfg.numTowers; i++)
            {
                Point tower_pos = Engine.towers[i].Location;
                if (disc_pos.X < tower_pos.X &&
                    disc_pos.Y > tower_pos.Y &&
                    disc_pos.X + disc.radius > tower_pos.X &&
                    disc_pos.Y + cfg.discHeight < tower_pos.Y + cfg.sizeTower.Height
                    )
                {
                    next_tower = Engine.towers[i];
                    if(next_tower != disc.curTower)
                    Mover.num_steps++;
                    Engine.num_steps.Text = "Количество шагов: " + Mover.num_steps.ToString();
                    next_tower.Push(disc,false);
                    Engine.solve_button.Enabled = false;
                  
                    return;
                }
            }
            disc.Return();
        }
        public static void Solver(int num_disc, int i,int k)
        {
            if (num_disc == 1)
                Engine.towers[k].Push(Engine.towers[i].Pop(),true);
            else
            {
                int tmp = 3 - i - k;
                Solver(num_disc - 1, i, tmp);
                Engine.towers[k].Push(Engine.towers[i].Pop(), true);
                Solver(num_disc - 1, tmp, k);
            }
        }
    }
    
}
