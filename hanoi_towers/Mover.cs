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
                   
                    next_tower.Push(disc);
                    return;
                }
            }
            disc.Return();
        }
        //void autoSolution(int n, int A, int B)
        //{
        //    if (n == 1)
        //    {
        //        cont.tmpD = n - 1;
        //        System.Threading.Thread.Sleep(350);
        //        mover(B - 1);
        //        // cout << A << " --> " << B << endl;
        //    }
        //    else
        //    {
        //        autoSolution(n - 1, A, 6 - A - B);
        //        cont.tmpD = n - 1;
        //        System.Threading.Thread.Sleep(350);
        //        mover(B - 1);

        //        // cout << A << " --> " << B << endl;
        //        autoSolution(n - 1, 6 - A - B, B);
        //    }
        //}
        public static void Solver(int num_disc, int a, int b, int c)
        {
            if (num_disc > 1) Solver(num_disc - 1, a, c, b);
            Thread.Sleep(200);
            Engine.towers[b].Push(Engine.towers[a].Pop());
            if (num_disc > 1) Solver(num_disc - 1, c, b, a);
        }
    }
    
}
