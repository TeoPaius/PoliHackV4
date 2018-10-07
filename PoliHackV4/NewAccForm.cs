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
// connection string = Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename="C:\Users\Alex-PC\Documents\Visual Studio 2015\Projects\PoliHackV4\PoliHackV4\DatabaseApp.mdf";Integrated Security = True


namespace PoliHackV4
{
    public partial class NewAccForm : Form
    {
        public NewAccForm()
        {
            this.Icon = PoliHackV4.Properties.Resources.Icons_Land_Medical_People_Doctor_Male__2_;
            InitializeComponent();
            int i = 1;
            textBox2.PasswordChar = '*';
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory() + "\\judete.txt");
                Trace.WriteLine(path.ToString());
                string[] lines = System.IO.File.ReadAllLines(path); //Change not hard coded // Changed
                foreach (string line in lines)
                {
                    ++i;
                    comboBox1.Items.Add(line);
                }
                Console.WriteLine("Press any key to exit.");

                System.Console.ReadKey();
            }
            catch { }

        }

        private void creebtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                string username = textBox1.Text;
                string pass = textBox2.Text;
                string nume = textBox3.Text;
                string prenume = textBox4.Text;
                string judet = comboBox1.GetItemText(comboBox1.SelectedItem);
                string localitate = textBox5.Text;
                DateTime date = dateTimePicker1.Value;


               // conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + "C:\\Users\\Horatiu\\Desktop\\PoliHack5\\PoliHackV4\\DatabaseApp.mdf;" + "Integrated Security = True";
                conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + "D:\\C#\\PoliHack6\\PoliHackV4\\DatabaseApp.mdf;" + "Integrated Security = True";

                try
                {
                    conn.Open();
                }
                catch (Exception exception1)
                {
                    Debug.WriteLine(exception1.ToString());
                    MessageBox.Show("There was an error at connection LoginForm!" + exception1.ToString());

                    return;
                }
                SqlCommand check = new SqlCommand("SELECT Username FROM Pacients where Username = @name", conn);
                check.Parameters.AddWithValue("name", username);
                SqlDataReader rd = check.ExecuteReader();
                if (rd.HasRows)
                    MessageBox.Show("Existent User");
                else
                {
                    rd.Close();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Login (Type, Username, Password, IP) VALUES (@type, @username, @pass, @IP)", conn);
                    cmd.Parameters.AddWithValue("type", "Patient");
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("pass", pass);
                    cmd.Parameters.AddWithValue("IP", GetLocalIP());
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("INSERT INTO Pacients (Username, Nume, Prenume, Judet, Localitate, [Data Nasterii]) VALUES (@username, @nume, @prenume, @judet, @localitate, @data)", conn);
                    cmd2.Parameters.AddWithValue("username", username);
                    cmd2.Parameters.AddWithValue("nume", nume);
                    cmd2.Parameters.AddWithValue("prenume", prenume);
                    cmd2.Parameters.AddWithValue("judet", judet);
                    cmd2.Parameters.AddWithValue("localitate", localitate);
                    cmd2.Parameters.AddWithValue("data", date);

                    cmd2.ExecuteNonQuery();
                }
                rd.Close();


            }
        }
        private string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            var regex = new Regex(@"^[A-Za-z]{2,}[_-]?[A-Za-z0-9]{2,}$"); //
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            var regex = new Regex(@"^[A-Za-z]{2,}[_-]?[A-Za-z0-9]{2,}$");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

            var regex = new Regex(@"[^a-zA-Z\b\s]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z\b\s]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z\b\s]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }
        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
                creebtn_Click(sender, e);
        }
    }
}
