using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hanoi_towers
{
    class cfg   
    {
        public static readonly int maxNumDisk = 8;
        public static readonly int minNumDisk = 2;
        public static readonly int discHeight = 23;
        public static readonly int discMaxWidth = 160;
        public static int num_disc = 3;
        public static readonly Color disc_color = Color.Aquamarine;


        public static readonly int numTowers = 3;
        public static readonly int offsetXtower = 200;
        public static readonly int offsetYtower = 50;
        public static Size sizeTower { get { return new Size(15, 300); } }
        public static readonly Color colorTower = Color.Gray;
    }
}
