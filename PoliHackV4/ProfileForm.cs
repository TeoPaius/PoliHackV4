using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace PoliHackV4
{
    public partial class ProfileForm : Form
    {
        private string name;
        public ProfileForm(string userName)
        {
            this.Icon = PoliHackV4.Properties.Resources.Icons_Land_Medical_People_Doctor_Male__2_;
            InitializeComponent();
            name = userName;
            try
            {
                SqlConnection conn = new SqlConnection();
                //conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + "C:\\Users\\Horatiu\\Desktop\\PoliHack5\\PoliHackV4\\DatabaseApp.mdf;" + "Integrated Security = True";
                //conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + "D:\\C#\\PoliHack6\\PoliHackV4\\DatabaseApp.mdf;" + "Integrated Security = True";
                conn.ConnectionString = PoliHackV4.Properties.Resources.ConnectionStringLogin;
                SqlDataReader rd = null;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Pacients WHERE Username = @Username", conn);
                cmd.Parameters.AddWithValue("Username", userName);
                Debug.WriteLine(userName);
                rd = cmd.ExecuteReader();
                MessageBox.Show(cmd.CommandText);
                
                while (rd.Read())
                {
                    utillbl.Text = rd["Username"].ToString();
                    numelbl.Text = rd["Nume"].ToString();
                    prenumelbl.Text = rd["Prenume"].ToString();
                    judetlbl.Text = rd["Judet"].ToString();
                    locallbl.Text = rd["Localitate"].ToString();
                    datalbl.Text = rd["Data nasterii"].ToString();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            try
            {
                SqlConnection conn1 = new SqlConnection();
                //conn1.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + "C:\\Users\\Horatiu\\Desktop\\PoliHack5\\PoliHackV4\\DatabaseApp.mdf;" + "Integrated Security = True";
                //conn1.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + "D:\\C#\\PoliHack6\\PoliHackV4\\DatabaseApp.mdf;" + "Integrated Security = True";
                conn1.ConnectionString = PoliHackV4.Properties.Resources.ConnectionStringLogin;
                SqlDataReader rd1 = null;
                conn1.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT Password FROM Login WHERE Username = @Username", conn1);
                cmd1.Parameters.AddWithValue("Username", userName);
                rd1 = cmd1.ExecuteReader();


                while (rd1.Read())
                {
                    prllbl.Text = rd1["Password"].ToString();
                }
            }
            catch ( Exception e )
            {

            }
}

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeForm cngform = new ChangeForm(name);
            cngform.ShowDialog();
            
        }
    }
}
