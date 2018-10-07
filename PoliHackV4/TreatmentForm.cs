using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

using System.Diagnostics;

namespace PoliHackV4
{
    public partial class TreatmentForm : Form
    {


        public Socket sck;
        EndPoint epRemote, epLocal;
        byte[] buffer;
        public int cnt1 = 0;

        public TreatmentForm(EndPoint localEp, EndPoint remoteEp, int cnt)
        {
            this.Icon = PoliHackV4.Properties.Resources.Icons_Land_Medical_People_Doctor_Male__2_;
            InitializeComponent();
            cnt1 = cnt;
            epRemote = remoteEp;
            epLocal = localEp;
            this.Visible = true;

            try
            {
                sck = new Socket(AddressFamily.InterNetwork,
                            SocketType.Dgram, ProtocolType.Udp);
                sck.SetSocketOption(SocketOptionLevel.Socket,
                                    SocketOptionName.ReuseAddress, true);
                // bind socket                        
                sck.Bind(epLocal);

                // connect to remote ip and port

                sck.Connect(epRemote);

                // starts to listen to an specific port
                buffer = new byte[1464];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length,
                                         SocketFlags.None, ref epRemote,
                                new AsyncCallback(MessageCallBack), buffer);

            }
            catch (Exception e1)
            {
                this.FormReset();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Parent.Visible = true;
            this.Visible = false;
            
            string baseDir = System.AppDomain.CurrentDomain.BaseDirectory;
            var s = baseDir + "Conversatii";
            string nume1 = "Conversatie";
            string numeFinal = nume1 + cnt1.ToString() + ".rtf";
            var path = s + @"\" + numeFinal;
            richTextBox1.SaveFile(path);
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length % 10 == 0)
            {
                richTextBox1.SaveFile("Asa_se_salveaza.rtf");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string baseDir = System.AppDomain.CurrentDomain.BaseDirectory;
            /*
            var s = System.IO.Path.Combine(baseDir, @"\\Conversatii");
            */
            var s = baseDir + "Conversatii";
            //MessageBox.Show(s);
            string nume1 = "Conversatie";
            string numeFinal = nume1 + cnt1.ToString() + ".rtf";
            var path = s + @"\" + numeFinal;
            richTextBox1.SaveFile(path);
            try
            {
                //var path = System.IO.Path.Combine(s, "Asa_se_salveaza.rtf");
                path = s + @"\"+ numeFinal;
                //MessageBox.Show(path);
                //string[] email = null;
                /*
                var reader = new StreamReader(path);
                var content = reader.ReadToEnd();
                reader.Close();
                Trace.WriteLine(content.ToString());
                */
                try
                {
                    System.Text.ASCIIEncoding enc =
                    new System.Text.ASCIIEncoding();
                    byte[] msg = new byte[1464];
                    msg = enc.GetBytes(richTextSend.Text);

                    // sending the message
                    sck.Send(msg);

                    // add to listbox

                    richTextBox1.AppendText('\n' + "You: " + richTextSend.Text + '\n');
                    // clear txtMessage
                    richTextSend.Clear();

                }
                catch (Exception e2)
                {
                    this.FormReset();
                }

            }
            catch (Exception exception1)
            {
                MessageBox.Show("There was an error" + exception1.ToString());
            }

        }

        private void MessageCallBack(IAsyncResult aResult)
        {
            try
            {
                int size = 0;
                try
                {
                    size = sck.EndReceiveFrom(aResult, ref epRemote);
                }
                catch (Exception e)
                {
                    this.FormReset();
                    sck.Close();
                }
                // check if theres actually information
                if (size > 0)
                {
                    // used to help us on getting the data
                    byte[] aux = new byte[1464];

                    // gets the data
                    aux = (byte[])aResult.AsyncState;

                    // converts from data[] to string
                    System.Text.ASCIIEncoding enc =
                                            new System.Text.ASCIIEncoding();
                    string msg = enc.GetString(aux);

                    // adds to listbox
                    
                    Invoke(new Action(() =>
                    {
                        richTextBox1.AppendText('\n' + "Pacient: " + msg.ToString() + '\n');
                    }));
                    // msg = "1";
                    //listMessage.Items.Add(msg);
                    /*
                    if (listMessage.Items[listMessage.Items.Count - 1].ToString() == "Connection closed")
                    {
                        MessageBox.Show("SFINTI");
                        listMessage.Items.Add("ok");
                        this.FormReset();
                        sck.Close();
                    }
                    */
                }

                // starts to listen again
                try
                {
                    buffer = new byte[1464];
                    sck.BeginReceiveFrom(buffer, 0,
                                        buffer.Length, SocketFlags.None,
                        ref epRemote, new AsyncCallback(MessageCallBack), buffer);
                }
                catch (Exception e)
                {
                    try
                    {
                        int a = sck.EndReceiveFrom(aResult, ref epRemote);
                    }
                    catch (Exception e3)
                    {
                        this.FormReset();
                        sck.Close();
                    }
                    this.FormReset();
                    sck.Close();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextSend_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormReset()
        {
            sck = new Socket(AddressFamily.InterNetwork,
                        SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket,
                                SocketOptionName.ReuseAddress, true);

        }
    }
}
