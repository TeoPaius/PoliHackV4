using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Data.SqlClient;

namespace PoliHackV4
{
    public partial class PacientForm : Form
    {
        private int ImgCnt = 1;
        private int Id;
        private string name;
        private string usernameProfileForm;
        decimal vals = 0.1m;
        decimal minute = 60m;
        private int numar = 60;
        public int cntTreatmentForm = 1;
        public PacientForm(string nume, int id)
        {
            this.Icon = PoliHackV4.Properties.Resources.Icons_Land_Medical_People_Doctor_Male__2_;
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Start();




            usernameProfileForm = nume;

            //MessageBox.Show(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName);
            //richTextBox1.LoadFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Text.rtf");
            name = nume;
            Id = id;
            lblName.Text = "Bine ai venit, \n";
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    //conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + "C:\\Users\\Horatiu\\Desktop\\PoliHack5\\PoliHackV4\\DatabaseApp.mdf;" + "Integrated Security = True";
                    //conn.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + "D:\\C#\\PoliHack6\\PoliHackV4\\DatabaseApp.mdf;" + "Integrated Security = True";
                    conn.ConnectionString = PoliHackV4.Properties.Resources.ConnectionStringLogin;
                }
                catch (Exception exception1)
                {
                    Debug.WriteLine(exception1.ToString());
                    MessageBox.Show("There was an error at connection LoginForm!" + exception1.ToString());

                    return;
                }
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
                SqlCommand command3 = new SqlCommand("Select * FROM Pacients", conn);
                SqlDataReader dataReaderPacients = null;
                try
                {

                    dataReaderPacients = command3.ExecuteReader();

                }
                catch (SqlException oError)
                {
                    Debug.WriteLine(oError.ToString());
                    MessageBox.Show(oError.ToString());
                }
                while (dataReaderPacients.Read())
                {
                    //Debug.WriteLine("AAAA :    " + dataReaderPacients["Username"].ToString() + "     " + name);
                    if (dataReaderPacients["Username"].ToString() == name)
                    {
                        name = dataReaderPacients["Nume"].ToString();
                        break;
                    }
                    
                }
            }
            lblName.Text += name;
            richTextBox1.ReadOnly = true;
            richTextBox1.BackColor = Color.White;
           
            btnLang.BackgroundImage = PoliHackV4.Properties.Resources.romania;
            btnLang.BackgroundImageLayout = ImageLayout.Center;

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLang_Click(object sender, EventArgs e)
        {
            if (ImgCnt == 1)
                TranslateUK();
            else
                TranslateRO();

            if (ImgCnt == 0)
            {
                ImgCnt = 1;
                btnLang.BackgroundImage = PoliHackV4.Properties.Resources.romania;
                btnLang.BackgroundImageLayout = ImageLayout.Center;
            }
            else
            {
                ImgCnt = 0;
                btnLang.BackgroundImage = PoliHackV4.Properties.Resources.uk;
                btnLang.BackgroundImageLayout = ImageLayout.Center;
            }


        }

        private void btnDoctorForm_Click(object sender, EventArgs e)
        {

            EndPoint epRemote = new IPEndPoint(IPAddress.Parse("192.168.0.117"),
                                        Convert.ToInt32("8000"));


            SqlConnection conn = new SqlConnection();// ("Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + "D:\\C#\\PoliHack6\\PoliHackV4\\DatabaseApp.mdf;" + "Integrated Security = True");
            conn.ConnectionString = PoliHackV4.Properties.Resources.ConnectionStringLogin;
            try
            {
                conn.Open();
            }
            catch(Exception ex)
            {
                Debug.WriteLine("There was an error" + ex.ToString());
            }
            SqlDataReader rd = null;
            SqlCommand cmd = new SqlCommand("SELECT IP FROM Login where Username = @Username", conn);
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM Login", conn);
            cmd.Parameters.AddWithValue("Username", name);

            rd = cmd2.ExecuteReader();
            Trace.WriteLine("Asta e numele" + name);
            string ip = null;
            while (rd.Read())
            {
                if (rd["Username"].ToString() == name)
                {
                    ip = rd["IP"].ToString();
                }
            }
            //string ip = "111";
            Trace.WriteLine(ip);
            try
            {
                EndPoint epLocal = new IPEndPoint(IPAddress.Parse(ip),
                                            Convert.ToInt32("8000"));

                //EndPoint epLocal = new IPEndPoint(IPAddress.Parse("192.168.0.140"),
                //Convert.ToInt32("8000"));
                TreatmentForm formTreat = new TreatmentForm(epLocal, epRemote, cntTreatmentForm);
                cntTreatmentForm++;
                //formTreat.Parent = this;
                formTreat.Show();
                //this.Hide();
                //while(formTreat.Visible == true)
                // {
                //    this.Visible = false;
                //}
                this.Visible = true;
            }
            catch
            {
                Trace.WriteLine("This is the ip!!!!" + ip);
                this.Close();

            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            richTextBox1.LoadFile(comboBox1.SelectedItem.ToString());
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, 10);
            /*
            PasswordHash hash1 = new PasswordHash("Alex");
            byte[] hashBytes = hash1.ToArray();
             
            string s = "Alex";
            Debug.WriteLine(s);
            Debug.WriteLine("");
            foreach (byte elem in hashBytes)
            {
                Debug.Write(elem);
            }
            Debug.WriteLine("");

            //1922401432351962014825216306114232492061557319424149198112107175719059112174207201115329625353
            */
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ProfileForm profform = new ProfileForm(usernameProfileForm);
            profform.ShowDialog();
        }

        private void btnRoutine_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            ChangeRoutine routine = new ChangeRoutine();
            routine.ShowDialog();
            numar = routine.PacientForm;
            //timer1.Stop();
            minute = (decimal)numar;
            string s = minute.ToString();
            timerlbl.Text = s;
            timer1.Start();
            routine.Close();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            //timerlbl.Text = timer1.Tick();
            minute = minute - vals;
            string s = minute.ToString();
            timerlbl.Text = s;
            if (minute == 0)
            {
                try
                {
                    notifyIcon1.Icon = SystemIcons.Exclamation;
                    notifyIcon1.Visible = true;
                    notifyIcon1.Text = "Este timpul sa te ridici si sa faci miscare!";
                    notifyIcon1.BalloonTipText = "Este timpul sa te ridici si sa faci miscare!";
                    notifyIcon1.BalloonTipTitle = "Este momenul!";
                    notifyIcon1.ShowBalloonTip(1000);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.ToString());
                }
                minute = (decimal)numar;
            }
        }

        private void PacientForm_Load(object sender, EventArgs e)
        {
            string baseDir = System.AppDomain.CurrentDomain.BaseDirectory;
            /*
            var s = System.IO.Path.Combine(baseDir, @"\\Conversatii");
            */
            var s = baseDir + "Conversatii";
            string[] files = System.IO.Directory.GetFiles(s);

            comboBox1.Items.AddRange(files);
            comboBox1.SelectedItem = 0;
        }
        private void TranslateUK()
        {
            btnDoctorForm.Text = "Ask a medic for help";
            btnRoutine.Text = "Change routine";
            btnSettings.Text = "Load";
            btnProfile.Text = "My Profile";
            label1.Text = "Last recipes";
        }
        private void TranslateRO()
        {
            btnDoctorForm.Text = "Cereti ajutor unui medic";
            btnRoutine.Text = "Modifica rutina";
            btnSettings.Text = "Incarca";
            btnProfile.Text = "Profilul meu";
            label1.Text = "Ultimele retete";
        }
    }
}