using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hanoi_towers
{
    public partial class Form1 : Form
    {

        TrackBar numDiskSelector;
        static ControlCollection control;

        Tower[] towers = new Tower[cfg.numTowers];
        List<Disc> discs = new List<Disc>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            control = (ControlCollection)this.Controls;
            ConfigureEnviroment();
            
        }

        private void ConfigureEnviroment()
        {  

            numDiskSelector = new TrackBar();
            numDiskSelector.Maximum = cfg.maxNumDisk;   
            numDiskSelector.Minimum = cfg.minNumDisk;
            numDiskSelector.Value = numDiskSelector.Minimum;
            numDiskSelector.Location = new Point(0, 0);
            this.Controls.Add(numDiskSelector);
            
            Button start_button = new Button();
            start_button.Location = new Point(150, 0);
            start_button.Text = "Старт!";
            start_button.Click += new EventHandler(this.Start);
            this.Controls.Add(start_button);

            for(int i = 0; i < cfg.numTowers; i++)
            {
                towers[i] = new Tower(control);
                towers[i].Draw(new Point((int)(cfg.offsetXtower * (0.7+i)), cfg.offsetYtower));
            }
        }
        void Start(object sender, EventArgs e)
        {
            cfg.num_disc = numDiskSelector.Value;
            Console.WriteLine("САЛАМ");

            for(int i = 0; i < cfg.num_disc; i++)
            {
                Console.WriteLine( (1 - i / 10.0));
                discs.Add(new Disc(control, new Size((int)(cfg.discMaxWidth * (1 - i / 10.0)), cfg.discHeight)));
                discs[i].Draw(new Point(towers[0].Location.X - discs[i].visual_container.Width/2, cfg.offsetYtower + cfg.sizeTower.Height - i * cfg.discHeight - i * 7));
                //discs[i].Draw(new Point(50, 50));
            }

        }
    }
}
