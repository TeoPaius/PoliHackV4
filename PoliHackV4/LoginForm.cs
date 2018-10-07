using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading;

namespace PoliHackV4
{
    public partial class LoginForm : Form
    {

        private bool fail = false;


        public LoginForm()
        {

            this.Icon = PoliHackV4.Properties.Resources.Icons_Land_Medical_People_Doctor_Male__2_;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
        }
        public void SplashStart()
        {
            Application.Run(new SplashScreen());
        }

        private void logbtn_Click(object sender, EventArgs e)
        {
            
            Thread t = new Thread(new ThreadStart(SplashStart));
            t.Start();
            Thread.Sleep(1300);
            this.Visible = false;
            using (SqlConnection conn = new SqlConnection())
            {
                //Init
                string userName = textBoxUser.Text;
                string passWord = textBoxPassword.Text;


                try
                {
                    //conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + "C:\\Users\\Horatiu\\Desktop\\PoliHack5\\PoliHackV4\\DatabaseApp.mdf;" + "Integrated Security = True";
                    //conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + "D:\\C#\\PoliHack6\\PoliHackV4\\DatabaseApp.mdf;" + "Integrated Security = True";
                    conn.ConnectionString = PoliHackV4.Properties.Resources.ConnectionStringLogin;
                    //conn.Open();
                }
                catch { }
                
                //conn.ConnectionString = Properties.Resources.ConnectionStringLogin;
                //conn.Open();
               
                try
                {
                    conn.Open();
                }
                catch(Exception exception1)
                {
                    Debug.WriteLine(exception1.ToString());
                    MessageBox.Show("There was an error at connection LoginForm!" + exception1.ToString());
                    
                    return;
                }
                
                SqlCommand command1 = new SqlCommand("SELECT * FROM Login WHERE Username = @Username", conn); // SqlCommand command1 = new SqlCommand("SELECT * FROM Login WHERE Username = @Username", conn);
                SqlCommand command2 = new SqlCommand("SELECT * FROM Login", conn);
                command1.Parameters.AddWithValue("Username", userName);
                //command1.ExecuteNonQuery();
                Trace.WriteLine("1");//write in output
                //MessageBox.Show("totul nu merge");
                SqlDataReader dataReader = null;
                try
                {
                    dataReader = command2.ExecuteReader();
                    
                }
                catch(SqlException oError)
                {
                    Debug.WriteLine(oError.ToString());
                    MessageBox.Show(oError.ToString());
                }
                //The ones from the database
                string Password;
                string Username;
                string Type;
                int id;
               //Debug.WriteLine("1");
                while (dataReader.Read())
                {
                    Debug.WriteLine("1");//write in output -> debug
                    Password = dataReader["Password"].ToString(); //working wohoooo // This will be the password to be parsed and salted 
                    Username = dataReader["Username"].ToString();
                    Type = dataReader["Type"].ToString();
                    //also to be checked 
                    id = Convert.ToInt32(dataReader["id"]);
                    if (passWord == Password && userName == Username && Type == "Patient")
                    {
                        this.Visible = false;
                        PoliHackV4.PacientForm PacientForm1 = new PoliHackV4.PacientForm(userName, id);
                        textBoxUser.Text = "";
                        textBoxPassword.Text = "";
                        textBoxPassword.ForeColor = Color.Black;
                        PacientForm1.ShowDialog();
                        this.Close();
                    }
                    else if (passWord == Password && userName == Username && Type == "Medic")
                    {
                        DocForm doctor = new DocForm();
                        this.Visible = false;
                        doctor.ShowDialog();
                        textBoxUser.Text = "";
                        textBoxPassword.Text = "";
                        textBoxPassword.ForeColor = Color.Black;
                        this.Close();
                        continue;
                    }
                    else
                    {
                        textBoxPassword.Text = "Wrong password!";
                        textBoxPassword.ForeColor = Color.Red;
                        textBoxPassword.PasswordChar = '\0';
                        fail = true;
                    }

                    Debug.WriteLine("This was introduced: " + userName + " " + passWord);
                    Debug.WriteLine(Username + " " + Password);
                }
            }
            // Open a patient form OR a doctor form
            
           
        }

        private void contbtn_Click(object sender, EventArgs e)
        {
            NewAccForm f2 = new NewAccForm();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RecoverPassForm f3 = new RecoverPassForm();
            f3.Show();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) // e textBoxPassword
        {
            var regex = new Regex(@"^[A-Za-z]{2,}[_-]?[A-Za-z0-9]{2,}$");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Return))
                logbtn_Click(sender, e);


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) // e textBoxUsername
        {
            var regex = new Regex(@"^[A-Za-z]{2,}[_-]?[A-Za-z0-9]{2,}$");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //null
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (fail == true)
            {
                textBoxPassword.ForeColor = Color.Black;
                textBoxPassword.PasswordChar = '*';
                textBoxPassword.Text = "";
                fail = false;
            }
        }

        private void textBoxPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (fail == true)
            {
                textBoxPassword.ForeColor = Color.Black;
                textBoxPassword.PasswordChar = '*';
                textBoxPassword.Text = "";
                fail = false;
            }
        }
    }
}
