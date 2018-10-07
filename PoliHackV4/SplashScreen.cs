using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoliHackV4
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            this.Icon = PoliHackV4.Properties.Resources.Icons_Land_Medical_People_Doctor_Male__2_;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int value = progressBar1.Value;
            progressBar1.Value = value + 1;
            progressBar1.Value = value;
            progressBar1.Increment(1);
            string s = timer1.ToString();
            if (progressBar1.Value == 100)
            {
                this.Close();
                timer1.Stop();
            }  
        }
    }
}
