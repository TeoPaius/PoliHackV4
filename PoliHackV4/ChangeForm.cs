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
    public partial class ChangeForm : Form
    {
        private string name;
        public ChangeForm(string userName)
        {
            this.Icon = PoliHackV4.Properties.Resources.Icons_Land_Medical_People_Doctor_Male__2_;
            InitializeComponent();
            name = userName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlConnection conn = new SqlConnection();
                //conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + "C:\\Users\\Horatiu\\Desktop\\PoliHack5\\PoliHackV4\\DatabaseApp.mdf;" + "Integrated Security = True";
                //SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + "D:\\C#\\PoliHack6\\PoliHackV4\\DatabaseApp.mdf;" + "Integrated Security = True");
                SqlConnection conn = new SqlConnection(PoliHackV4.Properties.Resources.ConnectionStringLogin);
                SqlDataReader rd = null;
                conn.Open();
                string query1, query2, query3, query4, query5, query6, query7;
                query1 = "UPDATE Pacients SET Username=@Username WHERE Username=@Username";
                query2 = "UPDATE Pacients SET Nume=@Nume WHERE Username=@Username";
                query3 = "UPDATE Pacients SET Prenume=@Prenume WHERE Username=@Username";
                query4 = "UPDATE Pacients SET Judet=@Judet WHERE Username=@Username";
                query5 = "UPDATE Pacients SET Localitate=@Localitate WHERE Username=@Username";
                query6 = "UPDATE Pacients SET [Data nasterii]=@Data WHERE Username=@Username";
                query7 = "UPDATE Login SET Password=@Password WHERE Username=@Username";
                SqlCommand cmd1 = new SqlCommand(query1, conn);
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                SqlCommand cmd3 = new SqlCommand(query3, conn);
                SqlCommand cmd4 = new SqlCommand(query4, conn);
                SqlCommand cmd5 = new SqlCommand(query5, conn);
                SqlCommand cmd6 = new SqlCommand(query6, conn);
                SqlCommand cmd7 = new SqlCommand(query7, conn);
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    cmd1.Parameters.AddWithValue("Username", textBox1.Text);
                    cmd2.Parameters.AddWithValue("Username", name);
                    cmd1.ExecuteNonQuery();
                }
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    cmd7.Parameters.AddWithValue("Password", textBox2.Text);
                    cmd7.Parameters.AddWithValue("Username", name);
                    cmd7.ExecuteNonQuery();
                }
                if (!string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    cmd2.Parameters.AddWithValue("Nume", textBox3.Text);
                    cmd2.Parameters.AddWithValue("Username", name);
                    cmd2.ExecuteNonQuery();
                }
                if (!string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    cmd3.Parameters.AddWithValue("Prenume", textBox4.Text);
                    cmd3.Parameters.AddWithValue("Username", name);
                    cmd3.ExecuteNonQuery();
                }
                if (!string.IsNullOrWhiteSpace(comboBox1.Text))
                {
                    cmd4.Parameters.AddWithValue("Judet", comboBox1.Text);
                    cmd4.Parameters.AddWithValue("Username", name);
                    cmd4.ExecuteNonQuery();
                }
                if (!string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    cmd5.Parameters.AddWithValue("Localitate", textBox5.Text);
                    cmd5.Parameters.AddWithValue("Username", name);
                    cmd5.ExecuteNonQuery();
                }
                if (!string.IsNullOrWhiteSpace(dateTimePicker1.Text))
                {
                    cmd6.Parameters.AddWithValue("Data", dateTimePicker1.Value);
                    cmd6.Parameters.AddWithValue("Username", name);
                    cmd6.ExecuteNonQuery();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
