namespace WindowsFormsKrav1_03
{
    partial class SoftSensConf
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox1COM = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2BitRate = new System.Windows.Forms.ComboBox();
            this.button1Disconnect = new System.Windows.Forms.Button();
            this.button1Connect = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.OpenFile = new System.Windows.Forms.Button();
            this.buttonSaveToFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.serialData = new System.Windows.Forms.RichTextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Configuration = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBoxName1 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxName11 = new System.Windows.Forms.TextBox();
            this.textBoxURV = new System.Windows.Forms.TextBox();
            this.textBoxLRV = new System.Windows.Forms.TextBox();
            this.textBoxAH = new System.Windows.Forms.TextBox();
            this.textBoxAL = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonFetch = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxLowerLimit = new System.Windows.Forms.TextBox();
            this.textBoxUpperLinit = new System.Windows.Forms.TextBox();
            this.textBoxAlarmLow = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAlarmHigh = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.Configuration.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.Configuration);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(756, 404);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox1COM);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.comboBox2BitRate);
            this.tabPage1.Controls.Add(this.button1Disconnect);
            this.tabPage1.Controls.Add(this.button1Connect);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(748, 378);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Serial Connection";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox1COM
            // 
            this.comboBox1COM.FormattingEnabled = true;
            this.comboBox1COM.Location = new System.Drawing.Point(116, 34);
            this.comboBox1COM.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1COM.Name = "comboBox1COM";
            this.comboBox1COM.Size = new System.Drawing.Size(160, 21);
            this.comboBox1COM.TabIndex = 11;
            this.comboBox1COM.MouseClick += new System.Windows.Forms.MouseEventHandler(this.updateComoBox1_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Com port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Bit rate";
            // 
            // comboBox2BitRate
            // 
            this.comboBox2BitRate.FormattingEnabled = true;
            this.comboBox2BitRate.Location = new System.Drawing.Point(116, 113);
            this.comboBox2BitRate.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2BitRate.Name = "comboBox2BitRate";
            this.comboBox2BitRate.Size = new System.Drawing.Size(160, 21);
            this.comboBox2BitRate.TabIndex = 13;
            // 
            // button1Disconnect
            // 
            this.button1Disconnect.Location = new System.Drawing.Point(178, 246);
            this.button1Disconnect.Margin = new System.Windows.Forms.Padding(4);
            this.button1Disconnect.Name = "button1Disconnect";
            this.button1Disconnect.Size = new System.Drawing.Size(100, 28);
            this.button1Disconnect.TabIndex = 14;
            this.button1Disconnect.Text = "Disconnect";
            this.button1Disconnect.UseVisualStyleBackColor = true;
            this.button1Disconnect.Click += new System.EventHandler(this.button1Disconnect_Click);
            // 
            // button1Connect
            // 
            this.button1Connect.Location = new System.Drawing.Point(178, 197);
            this.button1Connect.Margin = new System.Windows.Forms.Padding(4);
            this.button1Connect.Name = "button1Connect";
            this.button1Connect.Size = new System.Drawing.Size(100, 28);
            this.button1Connect.TabIndex = 12;
            this.button1Connect.Text = "Connect";
            this.button1Connect.UseVisualStyleBackColor = true;
            this.button1Connect.Click += new System.EventHandler(this.button1Connect_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.buttonStop);
            this.tabPage2.Controls.Add(this.OpenFile);
            this.tabPage2.Controls.Add(this.buttonSaveToFile);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.serialData);
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(748, 378);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sensor Data";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(26, 315);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Start Scaled Reading";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(339, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 9;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(26, 344);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(123, 23);
            this.buttonStop.TabIndex = 8;
            this.buttonStop.Text = "Stop Reading";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(198, 338);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(75, 23);
            this.OpenFile.TabIndex = 7;
            this.OpenFile.Text = "Open File";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // buttonSaveToFile
            // 
            this.buttonSaveToFile.Location = new System.Drawing.Point(198, 309);
            this.buttonSaveToFile.Name = "buttonSaveToFile";
            this.buttonSaveToFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveToFile.TabIndex = 6;
            this.buttonSaveToFile.Text = "Save To File";
            this.buttonSaveToFile.UseVisualStyleBackColor = true;
            this.buttonSaveToFile.Click += new System.EventHandler(this.buttonSaveToFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data stream:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start Raw Reading";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonAutoRead_Click);
            // 
            // serialData
            // 
            this.serialData.Location = new System.Drawing.Point(26, 45);
            this.serialData.Name = "serialData";
            this.serialData.Size = new System.Drawing.Size(247, 235);
            this.serialData.TabIndex = 1;
            this.serialData.Text = "";
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(299, 23);
            this.chart1.Name = "chart1";
            this.chart1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Light level";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(444, 355);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // Configuration
            // 
            this.Configuration.Controls.Add(this.label16);
            this.Configuration.Controls.Add(this.button3);
            this.Configuration.Controls.Add(this.textBoxName1);
            this.Configuration.Controls.Add(this.textBox6);
            this.Configuration.Controls.Add(this.label15);
            this.Configuration.Controls.Add(this.label14);
            this.Configuration.Controls.Add(this.label13);
            this.Configuration.Controls.Add(this.label12);
            this.Configuration.Controls.Add(this.label11);
            this.Configuration.Controls.Add(this.textBoxName11);
            this.Configuration.Controls.Add(this.textBoxURV);
            this.Configuration.Controls.Add(this.textBoxLRV);
            this.Configuration.Controls.Add(this.textBoxAH);
            this.Configuration.Controls.Add(this.textBoxAL);
            this.Configuration.Controls.Add(this.label9);
            this.Configuration.Controls.Add(this.textBoxName);
            this.Configuration.Controls.Add(this.buttonFetch);
            this.Configuration.Controls.Add(this.label8);
            this.Configuration.Controls.Add(this.textBoxLowerLimit);
            this.Configuration.Controls.Add(this.textBoxUpperLinit);
            this.Configuration.Controls.Add(this.textBoxAlarmLow);
            this.Configuration.Controls.Add(this.label7);
            this.Configuration.Controls.Add(this.label6);
            this.Configuration.Controls.Add(this.label5);
            this.Configuration.Controls.Add(this.label4);
            this.Configuration.Controls.Add(this.textBoxAlarmHigh);
            this.Configuration.Location = new System.Drawing.Point(4, 22);
            this.Configuration.Name = "Configuration";
            this.Configuration.Size = new System.Drawing.Size(748, 378);
            this.Configuration.TabIndex = 2;
            this.Configuration.Text = "Configuration";
            this.Configuration.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(56, 200);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "Password:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(121, 237);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 23);
            this.button3.TabIndex = 26;
            this.button3.Text = "Send new parmeter";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBoxName1
            // 
            this.textBoxName1.Location = new System.Drawing.Point(121, 197);
            this.textBoxName1.Name = "textBoxName1";
            this.textBoxName1.Size = new System.Drawing.Size(100, 20);
            this.textBoxName1.TabIndex = 25;
            // 
            // textBox6
            // 
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(121, 29);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(107, 33);
            this.textBox6.TabIndex = 23;
            this.textBox6.Text = "Enter new parameter here:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(65, 70);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 21;
            this.label15.Text = "Name:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 148);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Upper Range Value:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 174);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Lower Range Value:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(56, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Alarm high:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(60, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Alarm low:";
            // 
            // textBoxName11
            // 
            this.textBoxName11.Location = new System.Drawing.Point(121, 67);
            this.textBoxName11.Name = "textBoxName11";
            this.textBoxName11.Size = new System.Drawing.Size(100, 20);
            this.textBoxName11.TabIndex = 16;
            // 
            // textBoxURV
            // 
            this.textBoxURV.Location = new System.Drawing.Point(121, 145);
            this.textBoxURV.Name = "textBoxURV";
            this.textBoxURV.Size = new System.Drawing.Size(100, 20);
            this.textBoxURV.TabIndex = 15;
            // 
            // textBoxLRV
            // 
            this.textBoxLRV.Location = new System.Drawing.Point(121, 171);
            this.textBoxLRV.Name = "textBoxLRV";
            this.textBoxLRV.Size = new System.Drawing.Size(100, 20);
            this.textBoxLRV.TabIndex = 14;
            // 
            // textBoxAH
            // 
            this.textBoxAH.Location = new System.Drawing.Point(121, 93);
            this.textBoxAH.Name = "textBoxAH";
            this.textBoxAH.Size = new System.Drawing.Size(100, 20);
            this.textBoxAH.TabIndex = 13;
            // 
            // textBoxAL
            // 
            this.textBoxAL.Location = new System.Drawing.Point(121, 119);
            this.textBoxAL.Name = "textBoxAL";
            this.textBoxAL.Size = new System.Drawing.Size(100, 20);
            this.textBoxAL.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(397, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Name:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(458, 71);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 10;
            // 
            // buttonFetch
            // 
            this.buttonFetch.Location = new System.Drawing.Point(458, 218);
            this.buttonFetch.Name = "buttonFetch";
            this.buttonFetch.Size = new System.Drawing.Size(100, 42);
            this.buttonFetch.TabIndex = 9;
            this.buttonFetch.Text = "Fetch current parameter";
            this.buttonFetch.UseVisualStyleBackColor = true;
            this.buttonFetch.Click += new System.EventHandler(this.buttonFetch_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(455, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Current parameter:";
            // 
            // textBoxLowerLimit
            // 
            this.textBoxLowerLimit.Location = new System.Drawing.Point(458, 175);
            this.textBoxLowerLimit.Name = "textBoxLowerLimit";
            this.textBoxLowerLimit.Size = new System.Drawing.Size(100, 20);
            this.textBoxLowerLimit.TabIndex = 7;
            // 
            // textBoxUpperLinit
            // 
            this.textBoxUpperLinit.Location = new System.Drawing.Point(458, 149);
            this.textBoxUpperLinit.Name = "textBoxUpperLinit";
            this.textBoxUpperLinit.Size = new System.Drawing.Size(100, 20);
            this.textBoxUpperLinit.TabIndex = 6;
            // 
            // textBoxAlarmLow
            // 
            this.textBoxAlarmLow.Location = new System.Drawing.Point(458, 123);
            this.textBoxAlarmLow.Name = "textBoxAlarmLow";
            this.textBoxAlarmLow.Size = new System.Drawing.Size(100, 20);
            this.textBoxAlarmLow.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(397, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Lower Limit:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(397, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Upper Limit:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(397, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Alarm Low:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(397, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Alarm High:";
            // 
            // textBoxAlarmHigh
            // 
            this.textBoxAlarmHigh.Location = new System.Drawing.Point(458, 97);
            this.textBoxAlarmHigh.Name = "textBoxAlarmHigh";
            this.textBoxAlarmHigh.Size = new System.Drawing.Size(100, 20);
            this.textBoxAlarmHigh.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(4, 407);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(253, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // SoftSensConf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 428);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "SoftSensConf";
            this.Text = "SoftSensConf1.0";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.Configuration.ResumeLayout(false);
            this.Configuration.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBox1COM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2BitRate;
        private System.Windows.Forms.Button button1Disconnect;
        private System.Windows.Forms.Button button1Connect;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.RichTextBox serialData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSaveToFile;
        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TabPage Configuration;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxLowerLimit;
        private System.Windows.Forms.TextBox textBoxUpperLinit;
        private System.Windows.Forms.TextBox textBoxAlarmLow;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAlarmHigh;
        private System.Windows.Forms.Button buttonFetch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxName11;
        private System.Windows.Forms.TextBox textBoxURV;
        private System.Windows.Forms.TextBox textBoxLRV;
        private System.Windows.Forms.TextBox textBoxAH;
        private System.Windows.Forms.TextBox textBoxAL;
        private System.Windows.Forms.TextBox textBoxName1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button3;
    }
}

