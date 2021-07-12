using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Truck_inventory
{
    public partial class splash : Form
    {
        int LoadPercent;
        public splash()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            splashTimer1.Enabled = true;
            LoadPercent = 0;
        }

        private void splashTimer1_Tick(object sender, EventArgs e)
        {
            if (LoadPercent < 100)
            {
                LoadPercent += 1;
                lblLoadPerc.Text = LoadPercent.ToString() + "% Loaded";
            }
            else
            {
                splashTimer1.Enabled = false;
                this.Close();
            }
        }
    }
}
