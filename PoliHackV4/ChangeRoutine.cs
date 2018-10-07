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
    public partial class ChangeRoutine : Form
    {
        decimal minute = 60m;
        decimal vals = 0.1m;
        private string name;
        private int Id;
        private int numar = 0;
        public ChangeRoutine()
        {
            this.Icon = PoliHackV4.Properties.Resources.Icons_Land_Medical_People_Doctor_Male__2_;
            InitializeComponent();

            textBox1.Text = "";
            //  ((Parent)this.MdiParent).TextBox1Value = "Valid";

        }
        public int PacientForm
        {
            get
            {
                return numar;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            numar = int.Parse(textBox1.Text);
            this.Close();
        }
        
    }
}
