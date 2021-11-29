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
    class Engine
    {
        TrackBar numDiskSelector;
        static public Label num_steps = new Label();

        Form.ControlCollection control;
        static public Tower[] towers = new Tower[cfg.numTowers];
        List<Disc> discs = new List<Disc>();


        public Engine(Form.ControlCollection control) => this.control = control;
        public void ConfigureEnviroment()
        {
            numDiskSelector = new TrackBar();
            numDiskSelector.Maximum = cfg.maxNumDisk;
            numDiskSelector.Minimum = cfg.minNumDisk;
            numDiskSelector.Value = numDiskSelector.Minimum;
            numDiskSelector.Location = new Point(0, 0);
            control.Add(numDiskSelector);


            num_steps.Location = new Point(300, 0);
            num_steps.Size = new Size(100, 30);
            control.Add(num_steps);

            Button start_button = new Button();
            start_button.Location = new Point(150, 0);
            start_button.Text = "Старт!";
            start_button.Click += new EventHandler(this.Start);
            control.Add(start_button);

            for (int i = 0; i < cfg.numTowers; i++)
            {
                towers[i] = new Tower(control);
                towers[i].Draw(new Point((int)(cfg.offsetXtower * (0.7 + i)), cfg.offsetYtower));
            }


        }
        public void Start(object sender, EventArgs e)
        {
            cfg.num_disc = numDiskSelector.Value;
            Mover.num_steps = -cfg.num_disc;
            num_steps.Text = "Количество шагов: 0";

            for (int i = 0; i < cfg.numTowers; i++)
                towers[i].Clear();

            for (int i = 0; i < cfg.num_disc; i++)
                towers[0].Push(new Disc(control, new Size((int)(cfg.discMaxWidth * (1 - i / 10.0)), cfg.discHeight), ref towers[0]),false);

            //Mover.Solver(cfg.num_disc, 0, 2, 1);
        }
    }
}
