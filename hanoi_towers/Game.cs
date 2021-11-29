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
    public partial class Game : Form
    {
        static ControlCollection control;
        Engine engine;
        public Game()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            control = (ControlCollection)this.Controls;
            engine = new Engine(control);
            engine.ConfigureEnviroment();
        }
    }
}
