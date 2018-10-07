using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PoliHackV4
{
    public partial class RecoverPassForm : Form
    {
        public RecoverPassForm()
        {
            this.Icon = PoliHackV4.Properties.Resources.Icons_Land_Medical_People_Doctor_Male__2_;
            InitializeComponent();
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void recprlbtn_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != textBox2.Text)
                MessageBox.Show("Parolele nu coincid", "Eroare");
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\b\s]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\b\s]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\b\s]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }
    }
}
