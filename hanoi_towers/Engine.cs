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

        static public Button solve_button;

        public Engine(Form.ControlCollection control) => this.control = control;
        public void ConfigureEnviroment()
        {
            numDiskSelector = new TrackBar();
            numDiskSelector.Maximum = cfg.maxNumDisk;
            numDiskSelector.Minimum = cfg.minNumDisk;
            numDiskSelector.Value = numDiskSelector.Minimum;
            numDiskSelector.Location = new Point(730, 10);
            control.Add(numDiskSelector);

            Button start_button = new Button();
            start_button.Location = new Point(730, 60);
            start_button.Text = "Старт!";
            start_button.Click += new EventHandler(this.Start);
            control.Add(start_button);

            num_steps.Location = new Point(20, 20);
            num_steps.Size = new Size(100, 30);
            num_steps.Text = "Количество шагов: 0";
            control.Add(num_steps);


            solve_button = new Button();
            solve_button.Location = new Point(730, 300);
            solve_button.Text = "Решить";
            solve_button.Click += new EventHandler(this.Solve);
            solve_button.Enabled = false;
            control.Add(solve_button);

            for (int i = 0; i < cfg.numTowers; i++)
            {
                towers[i] = new Tower(control);
                towers[i].Draw(new Point((int)(cfg.offsetXtower * (0.7 + i)), cfg.offsetYtower));
            }


        }
        public void Start(object sender, EventArgs e)
        {
            solve_button.Enabled = true;
            cfg.num_disc = numDiskSelector.Value;
            Mover.num_steps = 0;
            num_steps.Text = "Количество шагов: 0";

            for (int i = 0; i < cfg.numTowers; i++)
                towers[i].Clear();

            for (int i = 0; i < cfg.num_disc; i++)
                towers[0].Push(new Disc(control, new Size((int)(cfg.discMaxWidth * (1 - i / 10.0)), cfg.discHeight), ref towers[0]),false);

        }
        public void Solve(object sender,EventArgs e)
        {
            solve_button.Enabled = false;
            Mover.Solver(cfg.num_disc, 0, 2, 1);

        }
    }
}
