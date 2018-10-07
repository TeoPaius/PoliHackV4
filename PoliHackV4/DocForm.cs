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
using System.Net;

namespace PoliHackV4
{
    public partial class DocForm : Form
    {
        private int cntTreat = 1;
        public DocForm()
        {
            
            using (SqlConnection conn = new SqlConnection())
            {
                this.Icon = PoliHackV4.Properties.Resources.Icons_Land_Medical_People_Doctor_Male__2_;
                InitializeComponent();
                label2.Text = "Bine ati venit!";
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
                SqlCommand command2 = new SqlCommand("SELECT * FROM Login", conn);
                SqlCommand command3 = new SqlCommand("Select * FROM Pacients", conn);
                SqlDataReader dataReader = null;
                SqlDataReader dataReaderPacients = null;
                try
                {
                    
                    dataReader = command2.ExecuteReader();
                    
                }
                catch (SqlException oError)
                {
                    Debug.WriteLine(oError.ToString());
                    MessageBox.Show(oError.ToString());
                }
                int cnt = 0;
                while (dataReader.Read())
                {
                 
                    cnt++;
                }
                dataReader.Close();
                dataReader = command2.ExecuteReader();
                string Type = "Medic";
                string Username = null;
                string Nume = null;
                string Prenume = null;
                string[] allNames = new string[cnt];
                int cnt2 = 0;
                while(dataReader.Read())
                {
                    Username = dataReader["Username"].ToString();
                    allNames[cnt2] = Username;
                    cnt2++;
                }
                dataReader.Close();
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
                    for (int i = 0; i < cnt; ++i)
                    {
                        if(dataReaderPacients["Username"].ToString() == allNames[i])
                        {
                            Nume = dataReaderPacients["Nume"].ToString();
                            Prenume = dataReaderPacients["Prenume"].ToString();
                            comboBox2.Items.Add(Nume + " " + Prenume);
                            break;
                        }
                    }
                }
                comboBox2.SelectedIndex = 0;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string numeFinal = null;
            string ipAdress = null;
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
                SqlCommand command2 = new SqlCommand("SELECT * FROM Login", conn);
                SqlCommand command3 = new SqlCommand("Select * FROM Pacients", conn);
                SqlDataReader dataReader = null;
                SqlDataReader dataReaderPacients = null;
                string s = null;
                if (comboBox2.SelectedItem.ToString() != "")
                {
                    s = comboBox2.SelectedItem.ToString();
                }
                else
                {
                    MessageBox.Show("Te rog selecteaza un pacient");
                    return;
                }

                string[] numePrenume = s.Split(' ');
                
                //dataReaderPacients = command3.ExecuteReader();
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
                    if (dataReaderPacients["Nume"].ToString() == numePrenume[0])
                    {
                        numeFinal = dataReaderPacients["Username"].ToString();
                        break;
                    }
                }
                dataReaderPacients.Close();
                try
                {

                    dataReader = command2.ExecuteReader();

                }
                catch (SqlException oError)
                {
                    Debug.WriteLine(oError.ToString());
                    MessageBox.Show(oError.ToString());
                }
                while (dataReader.Read())
                {
                    if (numeFinal == dataReader["Username"].ToString())
                    {
                        ipAdress = dataReader["IP"].ToString();
                        break;
                    }
                }
                dataReader.Close();
                Debug.WriteLine(ipAdress);
            }
            try
            {
                EndPoint epRemote = new IPEndPoint(IPAddress.Parse(ipAdress),
                                            Convert.ToInt32("8000"));
                EndPoint epLocal = new IPEndPoint(IPAddress.Parse("192.168.0.117"),
                                            Convert.ToInt32("8000"));
                TreatmentForm formTreat = new TreatmentForm(epLocal, epRemote, cntTreat);

                cntTreat++;
                formTreat.Show();
                comboBox1.Items.Clear();
                string baseDir = System.AppDomain.CurrentDomain.BaseDirectory;
                /*
                var s = System.IO.Path.Combine(baseDir, @"\\Conversatii");
                */
                var s = baseDir + "Conversatii";
                string[] files = System.IO.Directory.GetFiles(s);

                comboBox1.Items.AddRange(files);
                //comboBox1.SelectedItem = 1;
                this.Visible = true;
            }
            catch(Exception e6)
            {
                MessageBox.Show(e6.Message);
            }
        }

        private void DocForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string baseDir = System.AppDomain.CurrentDomain.BaseDirectory;
            /*
            var s = System.IO.Path.Combine(baseDir, @"\\Conversatii");
            */
            var s = baseDir + "Conversatii";
            string[] files = System.IO.Directory.GetFiles(s);
            
            comboBox1.Items.AddRange(files);
            comboBox1.SelectedItem = 1;
            //button2.Text = "Exit";
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string baseDir = System.AppDomain.CurrentDomain.BaseDirectory;
            /*
            var s = System.IO.Path.Combine(baseDir, @"\\Conversatii");
            */
            var s = baseDir + "Conversatii";
            string[] files = System.IO.Directory.GetFiles(s);

            comboBox1.Items.AddRange(files);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.LoadFile(comboBox1.SelectedItem.ToString());
        }
    }
}
/*
 * 
                    dataReaderPacients = command3.ExecuteReader();
                    while (dataReaderPacients.Read())
                    {
                        if (dataReaderPacients["Username"].ToString() == Username)
                        {
                            Nume = dataReaderPacients["Nume"].ToString();
                            Prenume = dataReaderPacients["Prenume"].ToString();
                        }
                    }
                    comboBox2.Items.Add(Nume + " " + Prenume);
 */
