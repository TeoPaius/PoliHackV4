namespace PoliHackV4
{
    partial class PacientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLang = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelIMAGE = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnDoctorForm = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnRoutine = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.timerlbl = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.richTextBox1, 6);
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(27, 207);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(7);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1028, 282);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnLang, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelIMAGE, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblName, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnDoctorForm, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.button2, 5, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnRoutine, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnProfile, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.timerlbl, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnSettings, 5, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1082, 616);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // btnLang
            // 
            this.btnLang.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLang.Location = new System.Drawing.Point(23, 569);
            this.btnLang.Name = "btnLang";
            this.tableLayoutPanel1.SetRowSpan(this.btnLang, 2);
            this.btnLang.Size = new System.Drawing.Size(64, 35);
            this.btnLang.TabIndex = 1;
            this.btnLang.UseVisualStyleBackColor = true;
            this.btnLang.Click += new System.EventHandler(this.btnLang_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 167);
            this.label1.Margin = new System.Windows.Forms.Padding(7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ultimele conversatii:";
            // 
            // comboBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comboBox1, 2);
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(247, 168);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(558, 24);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelIMAGE
            // 
            this.labelIMAGE.AutoSize = true;
            this.labelIMAGE.Location = new System.Drawing.Point(23, 20);
            this.labelIMAGE.Name = "labelIMAGE";
            this.labelIMAGE.Size = new System.Drawing.Size(35, 13);
            this.labelIMAGE.TabIndex = 5;
            this.labelIMAGE.Text = "label2";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(93, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(59, 17);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "lblName";
            // 
            // btnDoctorForm
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnDoctorForm, 2);
            this.btnDoctorForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoctorForm.Location = new System.Drawing.Point(23, 499);
            this.btnDoctorForm.Name = "btnDoctorForm";
            this.btnDoctorForm.Size = new System.Drawing.Size(214, 35);
            this.btnDoctorForm.TabIndex = 7;
            this.btnDoctorForm.Text = "Cereti ajutor unui medic";
            this.btnDoctorForm.UseVisualStyleBackColor = true;
            this.btnDoctorForm.Click += new System.EventHandler(this.btnDoctorForm_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(815, 569);
            this.button2.Name = "button2";
            this.tableLayoutPanel1.SetRowSpan(this.button2, 2);
            this.button2.Size = new System.Drawing.Size(138, 35);
            this.button2.TabIndex = 4;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnRoutine
            // 
            this.btnRoutine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoutine.Location = new System.Drawing.Point(815, 93);
            this.btnRoutine.Name = "btnRoutine";
            this.btnRoutine.Size = new System.Drawing.Size(138, 35);
            this.btnRoutine.TabIndex = 9;
            this.btnRoutine.Text = "Modifica timerul";
            this.btnRoutine.UseVisualStyleBackColor = true;
            this.btnRoutine.Click += new System.EventHandler(this.btnRoutine_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.Location = new System.Drawing.Point(93, 93);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(138, 35);
            this.btnProfile.TabIndex = 8;
            this.btnProfile.Text = "Profilul meu";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // timerlbl
            // 
            this.timerlbl.AutoSize = true;
            this.timerlbl.Location = new System.Drawing.Point(243, 496);
            this.timerlbl.Name = "timerlbl";
            this.timerlbl.Size = new System.Drawing.Size(0, 13);
            this.timerlbl.TabIndex = 11;
            // 
            // btnSettings
            // 
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(815, 163);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(138, 34);
            this.btnSettings.TabIndex = 10;
            this.btnSettings.Text = "Incarca";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // PacientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 616);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PacientForm";
            this.Text = "MedTalk Pacient";
            this.Load += new System.EventHandler(this.PacientForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelIMAGE;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnDoctorForm;
        private System.Windows.Forms.Button btnLang;
        private System.Windows.Forms.Button btnRoutine;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label timerlbl;
    }
}

