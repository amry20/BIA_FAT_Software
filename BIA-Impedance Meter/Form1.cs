using Antlr.Runtime;
using Cyotek.Collections.Generic;
using ScottPlot;
using System.Globalization;
using System.IO.Ports;
using System.Management;
using System.Windows.Forms;
using NCalc;
using System.Text;
using NCalc.Domain;

namespace BIA_Impedance_Meter
{
    public partial class Form1 : Form
    {
        const string def_FFM_Eq = "(0.513*(Pow(h,2)/R))+(0.359*h)+(0.392*w)-(2.6851*a)+16.22";
        const string def_FM_Eq = "w-FFM";
        const string def_BF_Eq = "(FM/w)*100.0";

        public double[] FatDataBuffer = new double[30];
        public double[] TimeDataBuffer = new double[30];
        CircularBuffer<double> FatMass_FIFO = new CircularBuffer<double>(30);
        CircularBuffer<string> SerialMsgFIFO = new CircularBuffer<string>(100);
        public bool IsRunning = false;
        bool Use_ModZ = true;

        static CancellationTokenSource MainTaskTokenSrc = new CancellationTokenSource();
        CancellationToken MainTaskToken = MainTaskTokenSrc.Token;

        double FFMValue = 0.0, FMValue = 0.0, BFValue = 0.0;

        public SerialPort _SerialPort = new SerialPort();

        string Current_FFMEquation, Current_FMEquation, Current_BFEquation;
        bool UpdateEquation = false;

        double ModZ, PointZ, ModV, PointV;
        double PatientWeight, PatientHeigh, PatientAge;
        double ImpedanceValue = 0.0;

        bool DoRecord = false;
        System.IO.StreamWriter CSVWriter;
        StringBuilder DataString;
        String CSVFileName;
        String CSVSeparator = ";";
        String CSVFullPath;

        int data_record_index = 0;
        public Form1()
        {
            InitializeComponent();
            string folderPath = Path.Combine(Environment.CurrentDirectory, "data");

            // Cek apakah folder "data" sudah ada
            if (!Directory.Exists(folderPath))
            {
                // Jika belum ada, buat folder tersebut
                Directory.CreateDirectory(folderPath);
            }
            // Menggunakan warna hitam pekat untuk background figure
            System.Drawing.Color glossyBlack = System.Drawing.Color.FromArgb(30, 30, 30); // Warna hitam glossy dengan gradasi abu-abu

            formsPlot1.Plot.Style(figureBackground: glossyBlack, glossyBlack);


            // Mengubah warna teks judul dan label sumbu
            formsPlot1.Plot.Title("BODY FAT PERCENTAGE", color: System.Drawing.Color.White, fontName: "Segoe UI", size: 15);

            // Mengubah warna garis tepi (sumbu) agar terlihat
            formsPlot1.Plot.XAxis.Line(color: System.Drawing.Color.White); // Garis tepi sumbu X
            formsPlot1.Plot.XAxis2.Line(color: System.Drawing.Color.White); // Garis tepi sumbu X
            formsPlot1.Plot.YAxis.Line(color: System.Drawing.Color.White); // Garis tepi sumbu Y
            formsPlot1.Plot.YAxis2.Line(color: System.Drawing.Color.White); // Garis tepi sumbu Y

            // Mengubah warna angka pada sumbu menjadi putih
            formsPlot1.Plot.XAxis.TickLabelStyle(color: System.Drawing.Color.White);
            formsPlot1.Plot.YAxis.TickLabelStyle(color: System.Drawing.Color.White);


            // Mengubah warna garis tick marks (penunjuk angka pada sumbu)
            formsPlot1.Plot.XAxis.TickMarkColor(color: System.Drawing.Color.White);
            formsPlot1.Plot.YAxis.TickMarkColor(color: System.Drawing.Color.White);

            formsPlot1.Plot.XAxis.MajorGrid(true, color: Color.White, lineStyle: LineStyle.Dot);
            formsPlot1.Plot.YAxis.MajorGrid(true, color: Color.White, lineStyle: LineStyle.Dot);

            // Mengatur rentang sumbu X dan increment
            formsPlot1.Plot.XAxis.ManualTickSpacing(5);
            formsPlot1.Plot.SetAxisLimitsX(0, 29);
            formsPlot1.Plot.SetAxisLimitsY(0, 100);
            formsPlot1.Plot.XAxis.Label("Time (s)", Color.White, 13);
            formsPlot1.Plot.YAxis.Label("BF (%)", Color.White, 13);

            for (int i = 0; i < TimeDataBuffer.Length; i++)
            {
                TimeDataBuffer[i] = i;
                FatDataBuffer[i] = 0;
            }

            formsPlot1.Refresh();
            formsPlot1.Render();
            string[] ports = SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; i++)
            {
                PortSelect.Items.Add(ports[i]);
            }
            LoadEquationFromFile("equation.dat");
            Current_FFMEquation = FFMEqText.Text;
            Current_FMEquation = FMEqText.Text;
            Current_BFEquation = BFEqText.Text;
        }

        private void StartStopBtn_MouseEnter(object sender, EventArgs e)
        {
            StartStopBtn.BackColor = System.Drawing.Color.Lime; // Warna saat hover
        }

        private void StartStopBtn_MouseLeave(object sender, EventArgs e)
        {
            StartStopBtn.BackColor = System.Drawing.Color.LimeGreen; // Warna saat hover
        }

        private void StartStopBtn_Click(object sender, EventArgs e)
        {
            if (!IsRunning)
            {
                if (PortSelect.Text != "")
                {
                    _SerialPort.PortName = PortSelect.Text;
                    _SerialPort.BaudRate = 115200;
                    try
                    {
                        Logit("Opeing serial port...");
                        StartStopBtn.Enabled = false;
                        _SerialPort.Open();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Unable to open serial port, error: {ex.Message}");
                        StartStopBtn.Enabled = true;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Serial port shouldn't be blank, please select correct serial port!");
                    return;
                }
                StartStopBtn.Enabled = true;
                if (_SerialPort.IsOpen)
                {
                    IsRunning = true;
                    Logit("Serial port has been successfuly opened");
                    StartStopBtn.Text = "Stop";
                    MainTaskTokenSrc = new CancellationTokenSource();
                    MainTaskToken = MainTaskTokenSrc.Token;
                    ConnStatusLabel.Text = "Device: Connected";
                    Task.Run(() => MainTask(MainTaskToken), MainTaskToken);
                }
                else
                {
                    Task.Run(() =>
                    {
                        MessageBox.Show($"Unable to open serial port at {PortSelect.Text}");
                    });
                }

            }
            else
            {
                IsRunning = false;
                try
                {
                    _SerialPort.Close();
                    ConnStatusLabel.Text = "Device: Disconnected";
                }
                catch (Exception ex)
                {
                    Task.Run(() =>
                    {
                        MessageBox.Show($"Unable to close serial port, error: {ex.Message}");
                    });
                }

                StartStopBtn.Text = "Start";
                MainTaskTokenSrc.Cancel();
                FWVersionLabel.Text = "Firmware Version: Unknown";
            }
        }
        private async void SerialReadTask(CancellationToken token)
        {
            _SerialPort.WriteLine("FIRMWARE");
            while (_SerialPort.IsOpen && !token.IsCancellationRequested)
            {
                if (_SerialPort.BytesToRead > 0)
                {
                    string str = _SerialPort.ReadLine();
                    if (str != "")
                    {
                        SerialMsgFIFO.Put(str);
                    }
                }
                else
                {
                    await Task.Delay(1);
                }
            }
        }
        private async void MainTask(CancellationToken token)
        {

            formsPlot1.Plot.Clear();
            var leg = formsPlot1.Plot.Legend(true);
            leg.Location = Alignment.UpperRight;
            FatMass_FIFO = new CircularBuffer<double>(30);
            var FatMassPlot = formsPlot1.Plot.AddScatter(TimeDataBuffer, FatDataBuffer, Color.Red, 2, label: "Fat Mass %", markerSize: 8, markerShape: MarkerShape.filledCircle);
            FatMassPlot.MaxRenderIndex = FatMass_FIFO.Size;
            formsPlot1.Plot.SetAxisLimitsX(0, 29);
            formsPlot1.Plot.SetAxisLimitsY(0, 100);
            formsPlot1.Plot.Render();
            formsPlot1.Refresh();
            Current_FFMEquation = FFMEqText.Text;
            Current_FMEquation = FMEqText.Text;
            Current_BFEquation = BFEqText.Text;

            PatientHeigh = Convert.ToDouble(HeightText.Text);
            PatientWeight = Convert.ToDouble(WeighText.Text);
            PatientAge = Convert.ToDouble(AgeText.Text);
            int data_count = 0;

            CancellationTokenSource SerialTaskTokenSrc = new CancellationTokenSource();
            CancellationToken SerialTaskToken = SerialTaskTokenSrc.Token;
            SerialMsgFIFO = new CircularBuffer<string>(100);
            SerialMsgFIFO.Clear();
            _SerialPort.ReadTimeout = 1000;
            Task.Run(() => SerialReadTask(SerialTaskToken), SerialTaskToken);
            bool NewArrivalData = false;
            string fw_version;
            Logit("Starting data monitor thread...");
            try
            {
                while (!token.IsCancellationRequested)
                {
                    if (SerialMsgFIFO.Size > 0)
                    {
                        string msg = SerialMsgFIFO.Get();
                        msg = msg.Trim('\n', '\r');
                        string[] data_parts = msg.Split(',');
                        if (data_parts[0] == "D")
                        {
                            NewArrivalData = true;
                            PointV = Convert.ToDouble(data_parts[1]);
                            ModV = Convert.ToDouble(data_parts[2]);
                            PointZ = Convert.ToDouble(data_parts[3]);
                            ModZ = Convert.ToDouble(data_parts[4]);
                        }
                        else if (data_parts[0] == "FW")
                        {
                            fw_version = data_parts[1];
                            FWVersionLabel.Text = $"Firmware Version: {fw_version}";
                            Logit($"Connected to the device, firmware version: {fw_version}");
                        }
                    }

                    if (UpdateEquation)
                    {
                        UpdateEquation = false;
                        Current_FFMEquation = FFMEqText.Text;
                        Current_FMEquation = FMEqText.Text;
                        Current_BFEquation = BFEqText.Text;

                        PatientHeigh = Convert.ToDouble(HeightText.Text);
                        PatientWeight = Convert.ToDouble(WeighText.Text);
                        PatientAge = Convert.ToDouble(AgeText.Text);
                    }
                    if (NewArrivalData)
                    {
                        NewArrivalData = false;
                        ModV_Text.Text = ModV.ToString("0.000", CultureInfo.InvariantCulture);
                        ModZ_Text.Text = ModZ.ToString("0.000", CultureInfo.InvariantCulture);
                        PointV_Text.Text = PointV.ToString("0.000", CultureInfo.InvariantCulture);
                        PointZ_Text.Text = PointZ.ToString("0.000", CultureInfo.InvariantCulture);
                        if (Use_ModZ)
                        {
                            ImpedanceValue = ModZ;
                        }
                        else
                        {
                            ImpedanceValue = PointZ;
                        }
                        if (Current_FFMEquation != "")
                        {
                            try
                            {
                                Expression Ex_FFMEquation = new Expression(Current_FFMEquation);

                                Ex_FFMEquation.Parameters["h"] = PatientHeigh;
                                Ex_FFMEquation.Parameters["H"] = PatientHeigh;

                                Ex_FFMEquation.Parameters["R"] = ImpedanceValue;
                                Ex_FFMEquation.Parameters["r"] = ImpedanceValue;
                                Ex_FFMEquation.Parameters["Z"] = ImpedanceValue;
                                Ex_FFMEquation.Parameters["z"] = ImpedanceValue;

                                Ex_FFMEquation.Parameters["w"] = PatientWeight;
                                Ex_FFMEquation.Parameters["W"] = PatientWeight;

                                Ex_FFMEquation.Parameters["a"] = PatientAge;
                                Ex_FFMEquation.Parameters["A"] = PatientAge;

                                Ex_FFMEquation.EvaluateParameter += delegate (string name, ParameterArgs args)
                                {
                                    if (name == "Pi")
                                        args.Result = Math.PI;
                                };
                                FFMValue = (double)Convert.ToDouble(Ex_FFMEquation.Evaluate());
                                FFMLabel.Text = FFMValue.ToString("0.000", CultureInfo.InvariantCulture) + " kg";
                            }
                            catch (Exception ex)
                            {
                                FFMLabel.Text = "Error";
                                Logit($"FFM Error ->{ex.Message}");
                            }
                        }
                        if (Current_FMEquation != "")
                        {
                            try
                            {
                                Expression Ex_FMEquation = new Expression(Current_FMEquation);
                                Ex_FMEquation.Parameters["h"] = PatientHeigh;
                                Ex_FMEquation.Parameters["H"] = PatientHeigh;

                                Ex_FMEquation.Parameters["R"] = ImpedanceValue;
                                Ex_FMEquation.Parameters["r"] = ImpedanceValue;
                                Ex_FMEquation.Parameters["Z"] = ImpedanceValue;
                                Ex_FMEquation.Parameters["z"] = ImpedanceValue;

                                Ex_FMEquation.Parameters["w"] = PatientWeight;
                                Ex_FMEquation.Parameters["W"] = PatientWeight;

                                Ex_FMEquation.Parameters["a"] = PatientAge;
                                Ex_FMEquation.Parameters["A"] = PatientAge;

                                Ex_FMEquation.Parameters["FFM"] = FFMValue;
                                Ex_FMEquation.Parameters["ffm"] = FFMValue;

                                Ex_FMEquation.EvaluateParameter += delegate (string name, ParameterArgs args)
                                {
                                    if (name == "Pi")
                                        args.Result = Math.PI;
                                };
                                FMValue = (double)Convert.ToDouble(Ex_FMEquation.Evaluate());
                                FMLabel.Text = FMValue.ToString("0.000", CultureInfo.InvariantCulture) + " kg";
                            }
                            catch (Exception ex)
                            {
                                FMLabel.Text = "Error";
                                Logit($"FM Error ->{ex.Message}");
                            }
                        }
                        if (Current_BFEquation != "")
                        {
                            try
                            {
                                Expression ExBFEquation = new Expression(Current_BFEquation);
                                ExBFEquation.Parameters["h"] = PatientHeigh;
                                ExBFEquation.Parameters["H"] = PatientHeigh;

                                ExBFEquation.Parameters["R"] = ImpedanceValue;
                                ExBFEquation.Parameters["r"] = ImpedanceValue;
                                ExBFEquation.Parameters["Z"] = ImpedanceValue;
                                ExBFEquation.Parameters["z"] = ImpedanceValue;

                                ExBFEquation.Parameters["w"] = PatientWeight;
                                ExBFEquation.Parameters["W"] = PatientWeight;

                                ExBFEquation.Parameters["a"] = PatientAge;
                                ExBFEquation.Parameters["A"] = PatientAge;

                                ExBFEquation.Parameters["FFM"] = FFMValue;
                                ExBFEquation.Parameters["ffm"] = FFMValue;

                                ExBFEquation.Parameters["FM"] = FMValue;
                                ExBFEquation.Parameters["fm"] = FMValue;

                                ExBFEquation.EvaluateParameter += delegate (string name, ParameterArgs args)
                                {
                                    if (name == "Pi")
                                        args.Result = Math.PI;
                                };
                                BFValue = (double)Convert.ToDouble(ExBFEquation.Evaluate());
                                if (BFValue <= 100.0)
                                {
                                    FatPercentageLabel.Text = BFValue.ToString("0.000", CultureInfo.InvariantCulture) + " %";
                                    FatPercentageLabel.ForeColor = Color.Black;
                                }
                                else
                                {
                                    FatPercentageLabel.Text = "Overload";
                                    FatPercentageLabel.ForeColor = Color.Red;
                                    Logit($"Body Fat (BF) calculation is overload.BF value = {BFValue.ToString("0.000", CultureInfo.InvariantCulture)} %");
                                }
                            }
                            catch (Exception ex)
                            {
                                FMLabel.Text = "Error";
                                Logit($"FM Error ->{ex.Message}");
                            }
                        }

                        FatMass_FIFO.Put(BFValue);
                        FatMass_FIFO.CopyTo(FatDataBuffer);
                        FatMassPlot.MaxRenderIndex = FatMass_FIFO.Size - 1;
                        FatMassPlot.Update(TimeDataBuffer, FatDataBuffer);
                        formsPlot1.Refresh(false);
                        data_count++;
                        if (DoRecord)
                        {
                            String[] newLine = { "#",data_record_index.ToString(), ImpedanceValue.ToString("0.000", CultureInfo.InvariantCulture), FFMValue.ToString("0.000", CultureInfo.InvariantCulture),
                                FMValue.ToString("0.000", CultureInfo.InvariantCulture), BFValue.ToString("0.000", CultureInfo.InvariantCulture)};
                            DataString = new StringBuilder();
                            DataString.AppendLine(string.Join(CSVSeparator, newLine));
                            CSVWriter.Write(DataString.ToString());
                            data_record_index++;
                            DataCountLabel.Text = data_record_index.ToString();
                        }
                    }
                    else
                    {
                        await Task.Delay(1);
                    }

                }

            }
            catch (Exception ex)
            {

            }
            SerialTaskTokenSrc.Cancel();
            Logit("Data monitor thread has been ended");

        }
        public void Logit(string msg)
        {
            LogText.Invoke(new Action(() =>
            {
                if (LogText.Lines.Count() >= 500)
                {
                    LogText.Clear();
                }
                LogText.AppendText(DateTime.Now.ToString("HH:mm:ss.fff") + " " + msg + Environment.NewLine);
                LogText.ScrollToCaret();
            }));
        }
        // Method untuk mendapatkan informasi perangkat menggunakan WMI
        private string GetSerialPortDeviceInfo(string portName)
        {
            string deviceInfo = "Unknown device";

            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption LIKE '%(" + portName + ")%'"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        deviceInfo = obj["Caption"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return deviceInfo;
        }

        private void EquationText_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateEqBtn_Click(object sender, EventArgs e)
        {
            if (FFMEqText.Text != "" && FMEqText.Text != "" && BFEqText.Text != "")
            {
                string new_equations = $"FFM={FFMEqText.Text}\nFM={FMEqText.Text}\nBF={BFEqText.Text}";
                SaveEquationToFile("equation.dat", new_equations);
                UpdateEquation = true;
            }
            else
            {
                Task.Run(() =>
                {
                    MessageBox.Show("The equation shouldn't be blank, please input correct equation");
                });
            }
        }
        // Method untuk menyimpan string ke file
        void SaveEquationToFile(string filePath, string equation)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLineAsync(equation);
            }
        }

        // Method untuk memuat string dari file
        void LoadEquationFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        while (true)
                        {
                            string eq = reader.ReadLine();
                            if (eq != null)
                            {
                                eq = eq.Trim();
                                string[] eq_parts = eq.Split('=');
                                if (eq_parts[0] == "FFM")
                                {
                                    FFMEqText.Text = eq_parts[1];
                                }
                                else if (eq_parts[0] == "FM")
                                {
                                    FMEqText.Text = eq_parts[1];
                                }
                                else if (eq_parts[0] == "BF")
                                {
                                    BFEqText.Text = eq_parts[1];
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    Logit($"Error: {ex.Message}");
                }
            }
        }
        private void ModZSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (ModZSelect.Checked)
            {
                PointZSelect.Checked = false;
                Use_ModZ = true;
            }
            if (!ModZSelect.Checked && !PointZSelect.Checked)
            {
                ModZSelect.Checked = true;
                Use_ModZ = true;
            }
        }

        private void PointZSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (PointZSelect.Checked)
            {
                ModZSelect.Checked = false;
                Use_ModZ = false;
            }
            if (!ModZSelect.Checked && !PointZSelect.Checked)
            {
                PointZSelect.Checked = true;
                Use_ModZ = false;
            }
        }

        private void RecordBtn_Click(object sender, EventArgs e)
        {
            if (!DoRecord)
            {
                if (IsRunning)
                {
                    if (FilenameText.Text != "")
                    {
                        DataString = new StringBuilder();
                        CSVFileName = "BIA_" + FilenameText.Text + ".csv";
                        String header1 = $"Data Pasien:\nUsia (a) = {PatientAge} tahun\nTinggi Badan (h) = {PatientHeigh} cm\nBerat Tubuh (w) = {PatientWeight} kg.\n";
                        String header2 = $"FFM={Current_FFMEquation}\nFM={Current_FMEquation}\nBF={Current_BFEquation}\n";
                        String[] header3 = { "#", "Index", "Impedance (Ohm)", "FFM (kg)", "FM (kg)", "BF (%)" };

                        DataString.AppendLine(header1);
                        DataString.AppendLine(header2);

                        DataString.AppendLine(string.Join(CSVSeparator, header3));
                        CSVFullPath = String.Format(@"{0}data\" + CSVFileName, Application.StartupPath);
                        CSVWriter = new System.IO.StreamWriter(CSVFullPath);
                        CSVWriter.Write(DataString.ToString());
                        data_record_index = 0;
                        DoRecord = true;
                        RecordBtn.Text = "Stop Record";
                        Logit($"Recording data with filename: {CSVFileName}");
                    }
                    else
                    {
                        Task.Run(() =>
                        {
                            MessageBox.Show("Filename shouldn't be blank, please input correct filename!");
                        });
                    }
                }
            }
            else
            {
                DoRecord = false;
                try
                {
                    if (CSVWriter != null)
                    {
                        CSVWriter.Close();
                        Thread.Sleep(100);
                    }

                }
                catch (Exception ex)
                {
                    Logit($"Error: {ex.Message}");
                }

                RecordBtn.Text = "Record";
                DataCountLabel.Text = "0";
                Logit("Data record done!");
            }
        }

        private void ResetEqBtn_Click(object sender, EventArgs e)
        {
            FFMEqText.Text = def_FFM_Eq;
            FMEqText.Text = def_FM_Eq;
            BFEqText.Text = def_BF_Eq;

            if (FFMEqText.Text != "" && FMEqText.Text != "" && BFEqText.Text != "")
            {
                string new_equations = $"FFM={FFMEqText.Text}\nFM={FMEqText.Text}\nBF={BFEqText.Text}";
                SaveEquationToFile("equation.dat", new_equations);
                UpdateEquation = true;
            }
            else
            {
                Task.Run(() =>
                {
                    MessageBox.Show("The equation shouldn't be blank, please input correct equation");
                });
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Memastikan form ditutup tanpa membatalkan proses penutupan
            if (CSVWriter != null)
            {
                CSVWriter.Close();
                Thread.Sleep(100);
            }
            e.Cancel = false;  // Pastikan ini di-set ke false untuk memaksa form ditutup
            Application.Exit();  // Ini akan menutup semua form dan keluar dari aplikasi
        }

        private void ClearLogBtn_Click(object sender, EventArgs e)
        {
            LogText.Clear();
        }
    }
}
