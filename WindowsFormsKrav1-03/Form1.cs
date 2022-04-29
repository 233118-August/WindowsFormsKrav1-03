using System;
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
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsKrav1_03
{
    public partial class SoftSensConf : Form
    {
        List<int> analogReading = new List<int>();
        List<int> scaledReading = new List<int>();
        List<DateTime> timeStamp = new List<DateTime>();
        string conAreidskrav2 = ConfigurationManager.ConnectionStrings["conAreidskrav2"].ConnectionString;
        List<string> ScaledValueValues = new List<string>();
        List<string> RawValueValues = new List<string>();
        List<string> TimeStampValues = new List<string>();

        Conf updatefreq = new Conf();
        public SoftSensConf()
        {
            InitializeComponent();
            ImportToComboBoxFreqSelect();
            toolStripStatusLabel1.Text = "Not connected";
            toolStripStatusLabel2.Text = "Not active";
            firstContact();
            toolStripStatusLabel2.BackColor = Color.White;
            toolStripStatusLabel1.BackColor = Color.Red;
            comboBox1COM.Items.AddRange(SerialPort.GetPortNames());
            comboBox1COM.Text = "--Select--";     
            string[] bitRate = new string[] { "1200", "2400", "4800turbo", "9600",
                                              "19200", "38400", "57600", "115200" };
            comboBox2BitRate.Items.AddRange(bitRate);
            comboBox2BitRate.SelectedIndex = comboBox2BitRate.Items.IndexOf("9600");
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataRecievedHandler);

            timer1.Interval = updatefreq.frequenz;
            timer1.Tick += new EventHandler(timer1_Tick);

            timer2.Interval = updatefreq.frequenz;
            timer2.Tick += new EventHandler(timer2_Tick);

            timer3.Interval = updatefreq.frequenz;
            timer3.Tick += new EventHandler(timer3_Tick);
        }
        
        string xLabel = string.Empty;
        string yLabel = string.Empty;
        List<double> Xvalues = new List<double>();
        List<double> Yvalues = new List<double>();
        private void firstContact()
        {
            if (toolStripStatusLabel2.Text == "Not active")

            {
                richTextBoxSelectedData.Text = String.Empty;
                int startFreq = 5000;
                toolStripStatusLabel2.BackColor = Color.Black;
                int boxtest = startFreq;
                string boxteststring = boxtest.ToString();
                richTextBoxSelectedData.Text = boxteststring;

                //this.updatefreq = startFreq;
                updatefreq.frequenz = startFreq;
                
                //toolStripStatusLabel2.BackColor = Color.Blue;
                //richTextBoxSelectedData.Text = "second contact";
            }

            else
            {
                richTextBoxSelectedData.Text = "third";
                return;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine("readraw");

            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine("readstatus");
            }
            else
            {
                toolStripStatusLabel1.Text = ("No connection to device");
                toolStripStatusLabel1.BackColor = Color.Red;
                toolStripStatusLabel2.Text = ("Not active");
                toolStripStatusLabel2.BackColor = Color.Red;
                timer2.Stop();
                timer1.Stop();
                timer3.Stop();
                MessageBox.Show("No connection to device");
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine("readscaled");

            }
        }
        void DataRecievedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            int iVab;
            float Scaled;

            string RecievedData = ((SerialPort)sender).ReadLine().Replace("\r", "");
            serialData.Invoke((MethodInvoker)delegate { serialData.AppendText("\n Recieved: " + RecievedData + "\r\n"); });
            string[] separateParts = RecievedData.Split(';');

            if (separateParts.Length == 1) 
                { 
                return; 
                }

            if (separateParts[0] == "readraw" & int.TryParse(separateParts[1], out iVab))
            {
                this.BeginInvoke((Action)delegate ()
                    {
                        label21.Text = "Raw value, live data:";
                        analogReading.Add(iVab);
                        timeStamp.Add(DateTime.Now);
                        chart1.Series["Light level"].Points.DataBindXY(timeStamp, analogReading);
                        chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
                        chart1.ChartAreas[0].AxisX.Title = "Time:";
                        chart1.ChartAreas[0].AxisY.Title = "Light inensity:";
                        chart1.Invalidate();

                        SqlConnection con = new SqlConnection(conAreidskrav2);
                        //hentes fra combobox og lagres i carMake-variabelen
                        string preparedStatement = "INSERT INTO DataInput (TagNumber, RawValue) VALUES (@tagNumber, @rawValue)";
                        con.Open();
                        SqlCommand command = new SqlCommand(preparedStatement, con);
                        command.Parameters.Add("@tagNumber", SqlDbType.Char).Value = textBoxInstID.Text;
                        command.Parameters.Add("@rawValue", SqlDbType.Float).Value = separateParts[1];
                        command.ExecuteNonQuery();
                        con.Close();
                    });
            }
            else if (separateParts[0] == "readscaled" & float.TryParse(separateParts[1], out Scaled))
            {
                this.BeginInvoke((Action)delegate ()
                {
                    label21.Text = "Scaled value, live data:";
                    int gh = (int)Scaled;
                    scaledReading.Add(gh);
                    timeStamp.Add(DateTime.Now);
                    chart1.Series["Light level"].Points.DataBindXY(timeStamp, scaledReading);
                    chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
                    chart1.ChartAreas[0].AxisX.Title = "Time:";
                    chart1.ChartAreas[0].AxisY.Title = "Light inensity:";
                    chart1.Invalidate();

                    SqlConnection con = new SqlConnection(conAreidskrav2);
                    //hentes fra combobox og lagres i carMake-variabelen
                    string preparedStatement2 = "INSERT INTO DataInput (TagNumber, ScaledValue) VALUES (@tagNumber, @scaledValue)";
                    con.Open();
                    SqlCommand command = new SqlCommand(preparedStatement2, con);
                    command.Parameters.Add("@tagNumber", SqlDbType.Char).Value = textBoxInstID.Text;
                    command.Parameters.Add("@scaledValue", SqlDbType.Float).Value = separateParts[1];
                    command.ExecuteNonQuery();
                    con.Close();

                    /*SqlConnection con = new SqlConnection(conAreidskrav2);
                                                 //hentes fra combobox og lagres i carMake-variabelen
                    sqlQuery = String.Concat(@"INSERT INTO DataInput (ScaledValue)
                        VALUES ('", separateParts[1], "')"); //Setter variabelen readscaled inn i sql-spørringen
                    con.Open();
                    SqlCommand command = new SqlCommand(sqlQuery, con);
                    command.ExecuteNonQuery();
                    con.Close();*/
                });
            }
            else if (separateParts[0] == "readconf")
            {
                this.BeginInvoke((Action)delegate ()
                {
                    textBoxName.Text = String.Empty;
                    textBoxName.AppendText(separateParts[1]);
                    textBoxName11.Text = String.Empty;
                    textBoxName11.AppendText(separateParts[1]);

                    textBoxInstID.Text = String.Empty;
                    textBoxInstID.AppendText(separateParts[1]);

                    textBoxLowerLimit.Text = String.Empty;
                    textBoxLowerLimit.AppendText(separateParts[2]);
                    textBoxLRV.Text = String.Empty;
                    textBoxLRV.AppendText(separateParts[2]);

                    textBoxUpperLinit.Text = String.Empty;
                    textBoxUpperLinit.AppendText(separateParts[3]);
                    textBoxURV.Text = String.Empty;
                    textBoxURV.AppendText(separateParts[3]);

                    textBoxAlarmLow.Text = String.Empty;
                    textBoxAlarmLow.AppendText(separateParts[4]);
                    textBoxAL.Text = String.Empty;
                    textBoxAL.AppendText(separateParts[4]);

                    textBoxAlarmHigh.Text = String.Empty;
                    textBoxAlarmHigh.AppendText(separateParts[5]);
                    textBoxAH.Text = String.Empty;
                    textBoxAH.AppendText(separateParts[5]);

                    textBoxCurrentFrequency.Text = String.Empty;
                    textBoxCurrentFrequency.AppendText(separateParts[6]);
                    comboBoxFreqSelect.Text = String.Empty;
                    comboBoxFreqSelect.Text = separateParts[6];
                    //comboBoxFreqSelect.Add(separateParts[6]);

                    textBoxArea.Text = "6";

                    SqlConnection connection = new SqlConnection(conAreidskrav2);
                    connection.Open();
                    string query = "SELECT InstrumentService, InstrumentType, InstrumentMakerModel, AreaID FROM Instrument WHERE TagNumber = @tagNumber";
                    SqlCommand command66 = new SqlCommand(query, connection);
                    command66.Parameters.Add("@tagNumber", SqlDbType.Char, 50).Value = textBoxInstID.Text;

                    command66.Prepare();

                    SqlDataReader rdr = command66.ExecuteReader();
                    while (rdr.Read()) 
                    {
                        textBoxServiceIn.Text = rdr["InstrumentService"].ToString();
                        textBoxService.Text = rdr["InstrumentService"].ToString();

                        textBoxTypeIn.Text = rdr["InstrumentType"].ToString();
                        Type.Text = rdr["InstrumentType"].ToString();

                        textBoxAreaIn.Text = rdr["AreaID"].ToString();
                        textBoxArea.Text = rdr["AreaID"].ToString();

                        textBoxMakerIn.Text = rdr["InstrumentMakerModel"].ToString();
                        textBoxMaker.Text = rdr["InstrumentMakerModel"].ToString();

                    }
                    connection.Close();

                    if (separateParts[1] == textBoxInstID.Text)
                    {
                        int myAreaInt = int.Parse(textBoxArea.Text);

                        SqlConnection con = new SqlConnection(conAreidskrav2);
                        //hentes fra combobox og lagres i carMake-variabelen
                        string preparedStatement = "UPDATE Instrument SET LRV = @LRV, URV = @URV, AlarmL = @AlarmL, AlarmH = @AlarmH, InstrumentService = @InstrumentService," +
                        " InstScanningFreq = @InstScanningFreq, InstrumentMakerModel = @InstrumentMakerModel, InstrumentType = @InstrumentType, AreaID = @AreaID where TagNumber = @tagNumber";
                        con.Open();
                        SqlCommand command = new SqlCommand(preparedStatement, con);
                        command.Parameters.Add("@tagNumber", SqlDbType.Char).Value = separateParts[1];
                        command.Parameters.Add("@LRV", SqlDbType.Float).Value = separateParts[2];
                        command.Parameters.Add("@URV", SqlDbType.Float).Value = separateParts[3];
                        command.Parameters.Add("@AlarmL", SqlDbType.Float).Value = separateParts[4];
                        command.Parameters.Add("@AlarmH", SqlDbType.Float).Value = separateParts[5];
                        command.Parameters.Add("@InstScanningFreq", SqlDbType.SmallInt).Value = separateParts[6];
                        command.Parameters.Add("@InstrumentService", SqlDbType.Char).Value = textBoxService.Text;
                        command.Parameters.Add("@InstrumentMakerModel", SqlDbType.Char).Value = textBoxMaker.Text;
                        command.Parameters.Add("@InstrumentType", SqlDbType.Char).Value = Type.Text;
                        command.Parameters.Add("@AreaID", SqlDbType.Int).Value = myAreaInt;
                        command.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        SqlConnection con = new SqlConnection(conAreidskrav2);
                        //hentes fra combobox og lagres i carMake-variabelen
                        string preparedStatement = "INSERT INTO Instrument (TagNumber, LRV, URV, AlarmL, AlarmH, InstScanningFreq, InstrumentMakerModel, InstrumentType, AreaID) VALUES (@TagNumber,  @LRV, @URV, @AlarmL, " +
                        "@AlarmH, @InstScanningFreq, @InstrumentMakerModel, @InstrumentType, @AreaID)";
                        con.Open();
                        SqlCommand command = new SqlCommand(preparedStatement, con);
                        command.Parameters.Add("@TagNumber",SqlDbType.Char).Value = separateParts[1];
                        command.Parameters.Add("@LRV", SqlDbType.Float).Value = separateParts[2];
                        command.Parameters.Add("@URV", SqlDbType.Float).Value = separateParts[3];
                        command.Parameters.Add("@AlarmL", SqlDbType.Float).Value = separateParts[4];
                        command.Parameters.Add("@AlarmH", SqlDbType.Float).Value = separateParts[5];
                        command.Parameters.Add("@InstScanningFreq", SqlDbType.SmallInt).Value = separateParts[6];
                        command.Parameters.Add("@InstScanningFreq", SqlDbType.SmallInt).Value = separateParts[6];
                        command.Parameters.Add("@InstrumentService", SqlDbType.Char).Value = textBoxService.Text;
                        command.Parameters.Add("@InstrumentMakerModel", SqlDbType.Char).Value = textBoxMaker.Text;
                        command.Parameters.Add("@InstrumentType", SqlDbType.Char).Value = Type.Text;
                        command.Parameters.Add("@AreaID", SqlDbType.Int).Value = textBoxArea.Text;
                        command.ExecuteNonQuery();
                        con.Close();
                    }
                });
            }
            else if (separateParts[0] == "readstatus")
            {
                this.BeginInvoke((Action)delegate ()
                {
                    string[] tall1 = new string[] { "0", "1", "2", "3" };
                    if (separateParts[1].Contains(tall1[0]))
                    {
                        toolStripStatusLabel2.Text = "System OK";
                        toolStripStatusLabel2.BackColor = Color.Green;

                        /*
                         * SqlConnection con = new SqlConnection(conAreidskrav2);
                        string errorMsg = "INSERT INTO DataInput (Error) VALUES (@Error)";
                        con.Open();
                        SqlCommand command = new SqlCommand(errorMsg, con);
                        command.Parameters.Add("@Error", SqlDbType.Char).Value = toolStripStatusLabel2.Text;
                        command.ExecuteNonQuery();
                        con.Close();*/
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
            else if (separateParts[1] == "DeviceID")
            {
                this.BeginInvoke((Action)delegate ()
                {
                    textBoxInstID.Text = separateParts[1];

                    string InstID, sqlQuery;
                    try
                    {
                        //Oppretter en connection mot databasen med string definert i App.config:
                        SqlConnection con = new SqlConnection(conAreidskrav2);
                        InstID = textBoxInstID.Text; 
                        sqlQuery = "INSERT INTO Instrument (TagNumber) VALUES (@tagNumber)";
                        con.Open();
                        SqlCommand command = new SqlCommand(sqlQuery, con);
                        command.Parameters.Add("@tagNumber", SqlDbType.Char).Value = InstID;
                        command.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
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
                timer3.Stop();
                serialData.Text = "";
                serialData.ReadOnly = true;

                timer1.Interval = Convert.ToInt32(comboBoxFreqSelect.Text);
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
                textBoxInstID.Text = textBoxName11.Text;

                if (serialPort1.IsOpen)
                {
                    serialPort1.WriteLine("DeviceID");
                    System.Threading.Thread.Sleep(1200);
                    serialPort1.WriteLine("readconf");
                    
                }
            }
            catch (Exception ex)
            {
                serialPort1.Close();
                if (ex is ArgumentException)
                {
                    MessageBox.Show("Port not valid");
                }
                else if (ex is UnauthorizedAccessException)
                {
                    MessageBox.Show("Not connected, port may be in use");
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
            toolStripStatusLabel2.Text = "Not active";
            toolStripStatusLabel2.BackColor = Color.White;

            timer2.Stop();
            serialPort1.Close();
            MessageBox.Show("Disconnected!");
        }
        private void buttonSaveToFile_Click(object sender, EventArgs e)
        {
            //string[] lines2 = { "Xvalue; Yvalue", xLabel,  yLabel };
            //File.WriteAllLines(@"C:\tmp\Text2.tmp", lines2);
            int boxtest11 = updatefreq.frequenz;
            string boxtest22 = boxtest11.ToString();
            richTextBoxSelectedData.Text = boxtest22;

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
            if (serialPort1.IsOpen)
            {
                timer1.Stop();  
                timer3.Stop(); 
                //serialData.Text = "";
                serialData.ReadOnly = true;
            }

            else
            {
                MessageBox.Show("Port not open");
            }
        }   
        private void buttonFetch_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("readconf");

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                timer1.Stop();
                serialData.Text = "";
                serialData.ReadOnly = true;
                timer3.Interval = Convert.ToInt32(comboBoxFreqSelect.Text);
                timer3.Start();
            }
            else
            {
                MessageBox.Show("Port not open");
            }
        }
        public void button3_Click(object sender, EventArgs e)
        {
            //string updatefreqInFunc;
            string[] write = new string[] {textBoxName11.Text, textBoxLRV.Text,
                                            textBoxURV.Text, textBoxAL.Text, textBoxAH.Text, comboBoxFreqSelect.Text };
            string passwordString = textBoxName1.Text;
            serialPort1.WriteLine ("writeconf>" + passwordString + ">" + string.Join(";", write));
            //updatefreqInFunc = comboBoxFreqSelect.Text;
            updatefreq.frequenz = int.Parse(comboBoxFreqSelect.SelectedItem.ToString());


            string InstServ, InstType, InstMaker, sqlQuery, ChanNr;
            int InstArea;
            try
            {
                //Oppretter en connection mot databasen med string definert i App.config:
                SqlConnection con = new SqlConnection(conAreidskrav2);
                 //Verdien som skal inn i databasen
                InstServ = textBoxService.Text;
                InstType = Type.Text;
                InstArea = int.Parse(textBoxArea.Text);
                InstMaker = textBoxMaker.Text;
                ChanNr = comboBox1COM.Text;
                //hentes fra combobox og lagres i carMake-variabelen
                /* Lagrer spørringen legger en ny "CarMake"-verdi i CARMAKER-tabellen */
                sqlQuery = "UPDATE Instrument SET ChannelNumber = @ChannelNumber, InstrumentService = @InstrumentService, InstrumentMakerModel = @InstrumentMakerModel, InstrumentType = @InstrumentType, AreaID = @AreaID where TagNumber = @tagNumber";
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.Add("@TagNumber", SqlDbType.Char).Value = textBoxName11.Text;
                command.Parameters.Add("@InstrumentService", SqlDbType.Char).Value = InstServ;
                command.Parameters.Add("@InstrumentType", SqlDbType.Char).Value = InstType;
                command.Parameters.Add("@InstrumentMakerModel", SqlDbType.Char).Value = InstMaker;
                command.Parameters.Add("@AreaID", SqlDbType.Int).Value = InstArea;
                command.Parameters.Add("@ChannelNumber", SqlDbType.Char).Value = ChanNr;

                 

                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }


            //updatefreq = int.Parse(comboBoxFreqSelect.SelectedItem.ToString());
            //timer1.Interval = updatefreq;
            //timer3.Interval = updatefreq;
            //textBoxInstID.Text = textBoxName11.Text;

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void ViewSqlResultInDataGridView(string sqlQuery)
        {
            try
            {
                SqlConnection con = new SqlConnection(conAreidskrav2);
                SqlDataAdapter sda;
                DataTable dt;
                con.Open();
                sda = new SqlDataAdapter(sqlQuery, con);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void buttonShowCurrentInstrumentHistory_Click(object sender, EventArgs e)
        {
            string sqlQuery = @"SELECT * FROM Instrument ORDER BY TagNumber ASC";

            ViewSqlResultInDataGridView(sqlQuery);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conAreidskrav2);
                string sqlQuery = "SELECT * FROM DataInput ORDER BY TimeStamp ASC";
                SqlCommand sql = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read() == true)
                {
                    sqlQuery = dr[0].ToString();
                    ScaledValueValues.Add(sqlQuery);
                    sqlQuery = dr[1].ToString();
                    RawValueValues.Add(sqlQuery);
                    sqlQuery = dr[2].ToString();
                    TimeStampValues.Add(sqlQuery);
                }
                con.Close();
                richTextBoxSelectedData.Clear(); //Fjerner eventuelt tekstboksinnhold før start

                foreach (string x in ScaledValueValues) //Skriver ut alle x1-verdiene
                {
                    richTextBoxSelectedData.AppendText(x + "\t\t\t");
                }
                richTextBoxSelectedData.AppendText("\r\n"); //Linjeskift

                foreach (string x in RawValueValues)//Skriver ut alle y1-verdiene
                {
                    richTextBoxSelectedData.AppendText(x + "\t");
                }
                //ScaledValueValues.Clear();
                //TimeStampValues.Clear();

                foreach (string y in TimeStampValues)//Skriver ut alle y1-verdiene
                {
                    richTextBoxSelectedData.AppendText(y + "\t");
                }
                //ScaledValueValues.Clear();
                //TimeStampValues.Clear();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        void ImportToComboBoxFreqSelect()
        {

            SqlConnection con = new SqlConnection(conAreidskrav2);
            string sqlQuery = "SELECT FreqScanInstrument FROM InstFreqSelect ORDER BY FreqScanInstrument ASC";
            SqlCommand sql = new SqlCommand(sqlQuery, con);
            con.Open();
            SqlDataReader dr = sql.ExecuteReader();
            while (dr.Read() == true)
            {
                sqlQuery = dr[0].ToString();
                comboBoxFreqSelect.Items.Add(sqlQuery);
            }
            con.Close();
        }
        private void buttonDataInput_Click(object sender, EventArgs e)
        {
            string sqlQuery = @"SELECT * FROM DataInput ORDER BY TimeStamp DESC";

            ViewSqlResultInDataGridView(sqlQuery);
        }
    }
}
