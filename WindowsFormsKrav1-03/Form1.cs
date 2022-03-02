﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rtChart;
using System.IO.Ports;
using System.IO;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsKrav1_03
{
    public partial class SoftSensConf : Form
    {
        List<int> analogReading = new List<int>();
        List<DateTime> timeStamp = new List<DateTime>();
 
        public SoftSensConf()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "Not connected";
            toolStripStatusLabel2.Text = "Not active";
            toolStripStatusLabel1.BackColor = Color.Red;
            comboBox1COM.Items.AddRange(SerialPort.GetPortNames());
            comboBox1COM.Text = "--Select--";
            string[] bitRate = new string[] { "1200", "2400", "4800t", "9600",
                                              "19200", "38400", "57600", "115200" };
            comboBox2BitRate.Items.AddRange(bitRate);
            comboBox2BitRate.SelectedIndex = comboBox2BitRate.Items.IndexOf("9600");
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataRecievedHandler);

            timer1.Interval = 5000;
            timer1.Tick += new EventHandler(timer1_Tick);

            timer2.Interval = 4000;
            timer2.Tick += new EventHandler(timer2_Tick);
        }
        
        string xLabel = string.Empty;
        string yLabel = string.Empty;
        List<double> Xvalues = new List<double>();
        List<double> Yvalues = new List<double>();
        private void timer1_Tick(object sender, EventArgs e)
        {
            serialPort1.WriteLine("readraw");
        }
        private void timer2_Tick(object sender,EventArgs e)
        {
            serialPort1.WriteLine("readstatus");
        }
        void DataRecievedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            //SerialPort sData = sender as SerialPort;
            //string recvData = sData.ReadLine();
            // serialData.Invoke((MethodInvoker)delegate 
            //{ serialData.AppendText(recvData); });

            int iVab;

            string RecievedData = ((SerialPort)sender).ReadLine();
            serialData.Invoke((MethodInvoker)delegate { serialData.AppendText("\n Recieved: " + RecievedData + "\r\n"); });
            string[] separateParts = RecievedData.Split(';');
            if (separateParts[0] == "readraw" & int.TryParse(separateParts[1], out iVab))
            {
                this.BeginInvoke((Action)delegate ()
                    {
                        analogReading.Add(iVab);
                        timeStamp.Add(DateTime.Now);
                        chart1.Series["Vba"].Points.DataBindXY(timeStamp, analogReading);
                        chart1.Invalidate();
                    });
            }
            else if (separateParts[0] == "readconf")
            {

                this.BeginInvoke((Action)delegate ()
                {
                    textBoxName.Text = String.Empty;
                    textBoxName.AppendText(separateParts[1]);
                    textBoxLowerLimit.Text = String.Empty;
                    textBoxLowerLimit.AppendText(separateParts[2]);
                    textBoxUpperLinit.Text = String.Empty;
                    textBoxUpperLinit.AppendText(separateParts[3]);
                    textBoxAlarmLow.Text = String.Empty;
                    textBoxAlarmLow.AppendText(separateParts[4]);
                    textBoxAlarmHigh.Text = String.Empty;
                    textBoxAlarmHigh.AppendText(separateParts[5]);
                });
            }
            else if (separateParts[0] == "readstatus")
            {
                this.BeginInvoke((Action)delegate ()
                {
                    string[] tall1 = new string[] {"0", "1", "2", "3"};
                    if (separateParts[1].Contains(tall1[0]))
                    {
                        toolStripStatusLabel2.Text = "System OK";
                        toolStripStatusLabel2.BackColor = Color.Green;
                    }

                    else if (separateParts[1].Contains(tall1[1]))
                    {
                        toolStripStatusLabel2.Text = ("Sysyem fail!");
                        toolStripStatusLabel2.BackColor = Color.Red;
                    }

                    else if (separateParts[1].Contains(tall1[2]))
                    {
                        toolStripStatusLabel2.Text = ("ALARM Low value");
                        toolStripStatusLabel2.BackColor = Color.Orange;
                    }

                    else if (separateParts[1].Contains(tall1[3]))
                    {
                        toolStripStatusLabel2.Text = ("ALARM High Value");
                        toolStripStatusLabel2.BackColor = Color.Orange;
                    }
                });
            }

            else
            {
                //MessageBox.Show("Gikk Ikke.");
            }
        }
        private void buttonAutoRead_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialData.Text = "";
                serialData.ReadOnly = true;
                timer1.Start();
            }
            else
            {
                MessageBox.Show("Porten er ikke åpen!");
            }
        }
        private void buttonManuellRead_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialData.ReadOnly = false;
                timer1.Stop();
            }
            else
            {
                MessageBox.Show("Porten er ikke åpen!");
            }
        }
        private void updateComoBox1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1COM.Items.Clear();
            comboBox1COM.Items.AddRange(SerialPort.GetPortNames());
        }
        private void button1Connect_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                serialPort1.PortName = comboBox1COM.Text;
                while (serialPort1.IsOpen) ;
                serialPort1.Open();
                MessageBox.Show("Tilkoblet " + comboBox1COM.Text);
                toolStripStatusLabel1.Text = "Conneted to device";
                toolStripStatusLabel1.BackColor = Color.Green;
                timer2.Start();
            }
            catch (Exception ex)
            {
                serialPort1.Close();
                if (ex is ArgumentException)
                {
                    MessageBox.Show("Ikke gyldig port valgt!");
                }
                else if (ex is UnauthorizedAccessException)
                {
                    MessageBox.Show("Ikke tilkoblet. Porten kan være i bruk.");
                }
                else
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void button1Disconnect_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Not connected";
            toolStripStatusLabel1.BackColor = Color.Red;
            timer2.Stop();
            serialPort1.Close();
            MessageBox.Show("Frakoblet!");
        }
        private void buttonSaveToFile_Click(object sender, EventArgs e)
        {
            string[] lines2 = { "Xvalue; Yvalue", xLabel,  yLabel };
            File.WriteAllLines(@"C:\tmp\Text2.tmp", lines2);
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                StreamReader inputFile = new StreamReader(@fileName);
                string inputFileRead = inputFile.ReadToEnd();
                string[] fileElements = inputFileRead.Split('\n');
                string[] splitElements = fileElements[0].Split(';');
                xLabel = splitElements[0];
                yLabel = splitElements[1];
                for (int i = 1; i < fileElements.Length - 1; i++)
                {
                    splitElements = fileElements[i].Split(';');
                    Xvalues.Add(double.Parse(splitElements[0], CultureInfo.InvariantCulture));
                    Yvalues.Add(double.Parse(splitElements[1], CultureInfo.InvariantCulture));
                    serialData.AppendText(splitElements[0]);
                    serialData.AppendText(" : ");
                    serialData.AppendText(splitElements[1]);
                    serialData.AppendText("\r\n");
                }
                inputFile.Close();

            }
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void buttonFetch_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("readconf");

        }




        /* private void buttonRead_Click(object sender, EventArgs e)
         {
             int alarm;
             string RecievedData = ((SerialPort)sender).ReadLine();
             string[] separateParts = RecievedData.Split(';');
             if (int.TryParse(separateParts[1], out alarm))
             { 
             TextBox[] textboxes = { textBoxLowerLimit,
                                     textBoxUpperLinit,
                                     textBoxAlarmHigh,
                                     textBoxAlarmLow,
             };
                 textboxes[0].Text = iConfigs[0];
                 textBoxLowerLimit.Text = iConfigs[1];
                 textBoxUpperLinit.Text = iConfigs[2];
                 textBoxAlarmLow.Text = iConfigs[3];
                 textBoxAlarmHigh.Text = iConfigs[4];
             }
         }
         private void buttonUpdate_Click(object sender, EventArgs e)
         {
             for (int i = 0; i < iConfigs.Length; i++)
             {
                 switch (i)
                 {
                     case 0:
                         if (textBoxLowerLimit.Text == "")
                         {
                             MessageBox.Show("Configuration empty");
                             textBoxLowerLimit.Focus();
                         }
                         break;

                     case 1:
                         if (textBoxUpperLinit.Text == "")
                         {
                             MessageBox.Show("Configuration empty");
                             textBoxUpperLinit.Focus();
                         }
                         break;
                     case 2:
                         if (textBoxAlarmLow.Text == "")
                         {
                             MessageBox.Show("Configuration empty");
                             textBoxAlarmLow.Focus();
                         }
                         break;
                     case 3:
                         if (textBoxAlarmHigh.Text == "")
                         {
                             MessageBox.Show("Configuration empty");
                             textBoxAlarmHigh.Focus();
                         }
                         break;

                     default:
                         iConfigs[i] = textBoxLowerLimit.Text;
                         iConfigs[i] = textBoxUpperLinit.Text;
                         iConfigs[i] = textBoxAlarmLow.Text;
                         iConfigs[i] = textBoxAlarmHigh.Text;
                         break;
                 }
             }
         }*/
    }
}