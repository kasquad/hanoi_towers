using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hanoi_towers
{
    class Mover
    {
        static public Disc disc;
        static public Tower next_tower;

        static public void Transfer(object sender, MouseEventArgs e)
        {
            Point disc_pos = disc.Location;
            for(int i = 0; i < cfg.numTowers; i++)
            {
                Point tower_pos = Form1.towers[i].Location;
                if (disc_pos.X < tower_pos.X &&
                    disc_pos.Y > tower_pos.Y &&
                    disc_pos.X + disc.radius > tower_pos.X &&
                    disc_pos.Y + cfg.discHeight < tower_pos.Y + cfg.sizeTower.Height
                    )
                {
                    next_tower = Form1.towers[i];
                    break;
                }
            }
            next_tower.Push(disc.curTower.Pop());

        }
    }
}
