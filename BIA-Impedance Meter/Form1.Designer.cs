namespace BIA_Impedance_Meter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            statusStrip1 = new StatusStrip();
            ConnStatusLabel = new ToolStripStatusLabel();
            FWVersionLabel = new ToolStripStatusLabel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel1 = new Panel();
            PortSelect = new ComboBox();
            label13 = new Label();
            StartStopBtn = new Button();
            panel2 = new Panel();
            LoadEquationBtn = new Button();
            label28 = new Label();
            DataCountLabel = new Label();
            label24 = new Label();
            RecordBtn = new Button();
            FilenameText = new TextBox();
            label26 = new Label();
            ResetEqBtn = new Button();
            UpdateEqBtn = new Button();
            groupBox2 = new GroupBox();
            label17 = new Label();
            label22 = new Label();
            HeightText = new TextBox();
            label21 = new Label();
            AgeText = new TextBox();
            label20 = new Label();
            label19 = new Label();
            WeighText = new TextBox();
            label18 = new Label();
            label11 = new Label();
            PointZSelect = new CheckBox();
            ModZSelect = new CheckBox();
            BFEqText = new TextBox();
            label16 = new Label();
            FMEqText = new TextBox();
            label15 = new Label();
            label12 = new Label();
            label9 = new Label();
            PointZ_Text = new TextBox();
            label10 = new Label();
            label7 = new Label();
            PointV_Text = new TextBox();
            label8 = new Label();
            label6 = new Label();
            label5 = new Label();
            ModZ_Text = new TextBox();
            label4 = new Label();
            ModV_Text = new TextBox();
            label3 = new Label();
            label2 = new Label();
            FFMEqText = new TextBox();
            label1 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            formsPlot1 = new ScottPlot.FormsPlot();
            panel3 = new Panel();
            groupBox4 = new GroupBox();
            FMLabel = new Label();
            label25 = new Label();
            groupBox3 = new GroupBox();
            FFMLabel = new Label();
            label23 = new Label();
            groupBox1 = new GroupBox();
            FatPercentageLabel = new Label();
            label14 = new Label();
            panel4 = new Panel();
            ClearLogBtn = new Button();
            LogText = new RichTextBox();
            label27 = new Label();
            label29 = new Label();
            label30 = new Label();
            DDSFreqText = new TextBox();
            button1 = new Button();
            statusStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { ConnStatusLabel, FWVersionLabel });
            statusStrip1.Location = new Point(0, 672);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1052, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // ConnStatusLabel
            // 
            ConnStatusLabel.BackColor = Color.Transparent;
            ConnStatusLabel.Name = "ConnStatusLabel";
            ConnStatusLabel.Size = new Size(120, 17);
            ConnStatusLabel.Text = "Device: Disconnected";
            // 
            // FWVersionLabel
            // 
            FWVersionLabel.BackColor = Color.Transparent;
            FWVersionLabel.Name = "FWVersionLabel";
            FWVersionLabel.Size = new Size(154, 17);
            FWVersionLabel.Text = "Firmware Version: Unknown";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel1.Controls.Add(panel4, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 52.38095F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 23.8095245F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 23.8095245F));
            tableLayoutPanel1.Size = new Size(1052, 672);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.FromArgb(215, 211, 191);
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Controls.Add(panel2, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 355);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1046, 154);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(PortSelect);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(StartStopBtn);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(98, 148);
            panel1.TabIndex = 0;
            // 
            // PortSelect
            // 
            PortSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            PortSelect.FormattingEnabled = true;
            PortSelect.Location = new Point(6, 24);
            PortSelect.Name = "PortSelect";
            PortSelect.Size = new Size(82, 23);
            PortSelect.TabIndex = 21;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(3, 6);
            label13.Name = "label13";
            label13.Size = new Size(60, 15);
            label13.TabIndex = 2;
            label13.Text = "Serial Port";
            // 
            // StartStopBtn
            // 
            StartStopBtn.BackColor = Color.LimeGreen;
            StartStopBtn.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StartStopBtn.Location = new Point(3, 56);
            StartStopBtn.Name = "StartStopBtn";
            StartStopBtn.Size = new Size(87, 73);
            StartStopBtn.TabIndex = 1;
            StartStopBtn.Text = "Start";
            StartStopBtn.UseVisualStyleBackColor = false;
            StartStopBtn.Click += StartStopBtn_Click;
            StartStopBtn.MouseEnter += StartStopBtn_MouseEnter;
            StartStopBtn.MouseLeave += StartStopBtn_MouseLeave;
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Controls.Add(DDSFreqText);
            panel2.Controls.Add(label30);
            panel2.Controls.Add(label29);
            panel2.Controls.Add(LoadEquationBtn);
            panel2.Controls.Add(label28);
            panel2.Controls.Add(DataCountLabel);
            panel2.Controls.Add(label24);
            panel2.Controls.Add(RecordBtn);
            panel2.Controls.Add(FilenameText);
            panel2.Controls.Add(label26);
            panel2.Controls.Add(ResetEqBtn);
            panel2.Controls.Add(UpdateEqBtn);
            panel2.Controls.Add(groupBox2);
            panel2.Controls.Add(BFEqText);
            panel2.Controls.Add(label16);
            panel2.Controls.Add(FMEqText);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(PointZ_Text);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(PointV_Text);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(ModZ_Text);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(ModV_Text);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(FFMEqText);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(107, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(936, 148);
            panel2.TabIndex = 1;
            // 
            // LoadEquationBtn
            // 
            LoadEquationBtn.Location = new Point(6, 124);
            LoadEquationBtn.Name = "LoadEquationBtn";
            LoadEquationBtn.Size = new Size(222, 23);
            LoadEquationBtn.TabIndex = 41;
            LoadEquationBtn.Text = "Load Equation";
            LoadEquationBtn.UseVisualStyleBackColor = true;
            LoadEquationBtn.Click += LoadEquationBtn_Click;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(457, 105);
            label28.Name = "label28";
            label28.Size = new Size(55, 15);
            label28.TabIndex = 40;
            label28.Text = "Filename";
            // 
            // DataCountLabel
            // 
            DataCountLabel.AutoSize = true;
            DataCountLabel.Location = new Point(525, 127);
            DataCountLabel.Name = "DataCountLabel";
            DataCountLabel.Size = new Size(13, 15);
            DataCountLabel.TabIndex = 39;
            DataCountLabel.Text = "0";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(457, 127);
            label24.Name = "label24";
            label24.Size = new Size(73, 15);
            label24.TabIndex = 38;
            label24.Text = "Data Count: ";
            // 
            // RecordBtn
            // 
            RecordBtn.Location = new Point(692, 100);
            RecordBtn.Name = "RecordBtn";
            RecordBtn.Size = new Size(98, 26);
            RecordBtn.TabIndex = 37;
            RecordBtn.Text = "Record";
            RecordBtn.UseVisualStyleBackColor = true;
            RecordBtn.Click += RecordBtn_Click;
            // 
            // FilenameText
            // 
            FilenameText.Location = new Point(518, 101);
            FilenameText.Name = "FilenameText";
            FilenameText.Size = new Size(168, 23);
            FilenameText.TabIndex = 36;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label26.Location = new Point(457, 81);
            label26.Name = "label26";
            label26.Size = new Size(76, 15);
            label26.TabIndex = 35;
            label26.Text = "Data Record";
            // 
            // ResetEqBtn
            // 
            ResetEqBtn.Location = new Point(122, 99);
            ResetEqBtn.Name = "ResetEqBtn";
            ResetEqBtn.Size = new Size(106, 26);
            ResetEqBtn.TabIndex = 34;
            ResetEqBtn.Text = "Reset Equation";
            ResetEqBtn.UseVisualStyleBackColor = true;
            ResetEqBtn.Click += ResetEqBtn_Click;
            // 
            // UpdateEqBtn
            // 
            UpdateEqBtn.Location = new Point(6, 99);
            UpdateEqBtn.Name = "UpdateEqBtn";
            UpdateEqBtn.Size = new Size(110, 26);
            UpdateEqBtn.TabIndex = 33;
            UpdateEqBtn.Text = "Update Equation";
            UpdateEqBtn.UseVisualStyleBackColor = true;
            UpdateEqBtn.Click += UpdateEqBtn_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(label22);
            groupBox2.Controls.Add(HeightText);
            groupBox2.Controls.Add(label21);
            groupBox2.Controls.Add(AgeText);
            groupBox2.Controls.Add(label20);
            groupBox2.Controls.Add(label19);
            groupBox2.Controls.Add(WeighText);
            groupBox2.Controls.Add(label18);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(PointZSelect);
            groupBox2.Controls.Add(ModZSelect);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(234, 46);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 99);
            groupBox2.TabIndex = 32;
            groupBox2.TabStop = false;
            groupBox2.Text = "Parameters";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9F);
            label17.Location = new Point(170, 50);
            label17.Name = "label17";
            label17.Size = new Size(20, 15);
            label17.TabIndex = 43;
            label17.Text = "yo";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 9F);
            label22.Location = new Point(170, 74);
            label22.Name = "label22";
            label22.Size = new Size(24, 15);
            label22.TabIndex = 42;
            label22.Text = "cm";
            // 
            // HeightText
            // 
            HeightText.Font = new Font("Segoe UI", 9F);
            HeightText.Location = new Point(111, 73);
            HeightText.Name = "HeightText";
            HeightText.Size = new Size(53, 23);
            HeightText.TabIndex = 41;
            HeightText.Text = "165";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 9F);
            label21.Location = new Point(84, 74);
            label21.Name = "label21";
            label21.Size = new Size(31, 15);
            label21.TabIndex = 40;
            label21.Text = "h  = ";
            // 
            // AgeText
            // 
            AgeText.Font = new Font("Segoe UI", 9F);
            AgeText.Location = new Point(111, 47);
            AgeText.Name = "AgeText";
            AgeText.Size = new Size(53, 23);
            AgeText.TabIndex = 39;
            AgeText.Text = "30";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 9F);
            label20.Location = new Point(85, 49);
            label20.Name = "label20";
            label20.Size = new Size(30, 15);
            label20.TabIndex = 38;
            label20.Text = "a  = ";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 9F);
            label19.Location = new Point(170, 25);
            label19.Name = "label19";
            label19.Size = new Size(20, 15);
            label19.TabIndex = 37;
            label19.Text = "kg";
            // 
            // WeighText
            // 
            WeighText.Font = new Font("Segoe UI", 9F);
            WeighText.Location = new Point(111, 22);
            WeighText.Name = "WeighText";
            WeighText.Size = new Size(53, 23);
            WeighText.TabIndex = 36;
            WeighText.Text = "53";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 9F);
            label18.Location = new Point(85, 25);
            label18.Name = "label18";
            label18.Size = new Size(30, 15);
            label18.TabIndex = 35;
            label18.Text = "w = ";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F);
            label11.Location = new Point(2, 22);
            label11.Name = "label11";
            label11.Size = new Size(69, 15);
            label11.TabIndex = 34;
            label11.Text = "Z Reference";
            // 
            // PointZSelect
            // 
            PointZSelect.AutoSize = true;
            PointZSelect.Font = new Font("Segoe UI", 9F);
            PointZSelect.Location = new Point(4, 57);
            PointZSelect.Name = "PointZSelect";
            PointZSelect.Size = new Size(64, 19);
            PointZSelect.TabIndex = 33;
            PointZSelect.Text = "Point Z";
            PointZSelect.UseVisualStyleBackColor = true;
            PointZSelect.CheckedChanged += PointZSelect_CheckedChanged;
            // 
            // ModZSelect
            // 
            ModZSelect.AutoSize = true;
            ModZSelect.Checked = true;
            ModZSelect.CheckState = CheckState.Checked;
            ModZSelect.Font = new Font("Segoe UI", 9F);
            ModZSelect.Location = new Point(4, 39);
            ModZSelect.Name = "ModZSelect";
            ModZSelect.Size = new Size(61, 19);
            ModZSelect.TabIndex = 32;
            ModZSelect.Text = "Mod Z";
            ModZSelect.UseVisualStyleBackColor = true;
            ModZSelect.CheckedChanged += ModZSelect_CheckedChanged;
            // 
            // BFEqText
            // 
            BFEqText.Location = new Point(53, 74);
            BFEqText.Name = "BFEqText";
            BFEqText.Size = new Size(175, 23);
            BFEqText.TabIndex = 22;
            BFEqText.Text = "(FM/w)*100.0";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(6, 76);
            label16.Name = "label16";
            label16.Size = new Size(40, 15);
            label16.TabIndex = 21;
            label16.Text = "BF    =";
            // 
            // FMEqText
            // 
            FMEqText.Location = new Point(53, 49);
            FMEqText.Name = "FMEqText";
            FMEqText.Size = new Size(175, 23);
            FMEqText.TabIndex = 20;
            FMEqText.Text = "w-FFM";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(6, 49);
            label15.Name = "label15";
            label15.Size = new Size(41, 15);
            label15.TabIndex = 19;
            label15.Text = "FM   =";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 24);
            label12.Name = "label12";
            label12.Size = new Size(41, 15);
            label12.TabIndex = 18;
            label12.Text = "FFM =";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(796, 58);
            label9.Name = "label9";
            label9.Size = new Size(34, 15);
            label9.TabIndex = 14;
            label9.Text = "Ohm";
            // 
            // PointZ_Text
            // 
            PointZ_Text.Location = new Point(697, 55);
            PointZ_Text.Name = "PointZ_Text";
            PointZ_Text.ReadOnly = true;
            PointZ_Text.Size = new Size(93, 23);
            PointZ_Text.TabIndex = 13;
            PointZ_Text.TextAlign = HorizontalAlignment.Center;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(649, 58);
            label10.Name = "label10";
            label10.Size = new Size(45, 15);
            label10.TabIndex = 12;
            label10.Text = "Point Z";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(796, 29);
            label7.Name = "label7";
            label7.Size = new Size(27, 15);
            label7.TabIndex = 11;
            label7.Text = "Volt";
            // 
            // PointV_Text
            // 
            PointV_Text.Location = new Point(697, 26);
            PointV_Text.Name = "PointV_Text";
            PointV_Text.ReadOnly = true;
            PointV_Text.Size = new Size(93, 23);
            PointV_Text.TabIndex = 10;
            PointV_Text.TextAlign = HorizontalAlignment.Center;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(649, 30);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 9;
            label8.Text = "Point V";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(604, 57);
            label6.Name = "label6";
            label6.Size = new Size(34, 15);
            label6.TabIndex = 8;
            label6.Text = "Ohm";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(604, 29);
            label5.Name = "label5";
            label5.Size = new Size(27, 15);
            label5.TabIndex = 7;
            label5.Text = "Volt";
            // 
            // ModZ_Text
            // 
            ModZ_Text.Location = new Point(504, 55);
            ModZ_Text.Name = "ModZ_Text";
            ModZ_Text.ReadOnly = true;
            ModZ_Text.Size = new Size(93, 23);
            ModZ_Text.TabIndex = 6;
            ModZ_Text.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(457, 57);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 5;
            label4.Text = "Mod Z";
            // 
            // ModV_Text
            // 
            ModV_Text.Location = new Point(504, 26);
            ModV_Text.Name = "ModV_Text";
            ModV_Text.ReadOnly = true;
            ModV_Text.Size = new Size(93, 23);
            ModV_Text.TabIndex = 4;
            ModV_Text.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(457, 30);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 3;
            label3.Text = "Mod V";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(457, 6);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 2;
            label2.Text = "Electrical Values";
            // 
            // FFMEqText
            // 
            FFMEqText.Location = new Point(53, 21);
            FFMEqText.Name = "FFMEqText";
            FFMEqText.Size = new Size(381, 23);
            FFMEqText.TabIndex = 1;
            FFMEqText.Text = "(0.513*(Pow(h,2)/R))+(0.359*h)+(0.392*w)-(2.6851*a)+16.22";
            FFMEqText.TextChanged += EquationText_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 6);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "Equations";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            tableLayoutPanel3.Controls.Add(formsPlot1, 0, 0);
            tableLayoutPanel3.Controls.Add(panel3, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(1046, 346);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // formsPlot1
            // 
            formsPlot1.BackColor = SystemColors.ButtonFace;
            formsPlot1.BorderStyle = BorderStyle.Fixed3D;
            formsPlot1.Dock = DockStyle.Fill;
            formsPlot1.ForeColor = SystemColors.ControlLightLight;
            formsPlot1.Location = new Point(4, 3);
            formsPlot1.Margin = new Padding(4, 3, 4, 3);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(849, 340);
            formsPlot1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ScrollBar;
            panel3.Controls.Add(groupBox4);
            panel3.Controls.Add(groupBox3);
            panel3.Controls.Add(groupBox1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(860, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(183, 340);
            panel3.TabIndex = 2;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(FMLabel);
            groupBox4.Controls.Add(label25);
            groupBox4.Location = new Point(4, 109);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(173, 100);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            // 
            // FMLabel
            // 
            FMLabel.AutoSize = true;
            FMLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FMLabel.Location = new Point(1, 48);
            FMLabel.Name = "FMLabel";
            FMLabel.Size = new Size(119, 37);
            FMLabel.TabIndex = 3;
            FMLabel.Text = "0.000 kg";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label25.Location = new Point(1, 16);
            label25.Name = "label25";
            label25.Size = new Size(161, 32);
            label25.TabIndex = 2;
            label25.Text = "Fat Mass (FM)";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(FFMLabel);
            groupBox3.Controls.Add(label23);
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(174, 100);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            // 
            // FFMLabel
            // 
            FFMLabel.AutoSize = true;
            FFMLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FFMLabel.Location = new Point(1, 48);
            FFMLabel.Name = "FFMLabel";
            FFMLabel.Size = new Size(119, 37);
            FFMLabel.TabIndex = 3;
            FFMLabel.Text = "0.000 kg";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label23.Location = new Point(1, 16);
            label23.Name = "label23";
            label23.Size = new Size(60, 32);
            label23.TabIndex = 2;
            label23.Text = "FFM";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(FatPercentageLabel);
            groupBox1.Controls.Add(label14);
            groupBox1.Location = new Point(3, 215);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(174, 100);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // FatPercentageLabel
            // 
            FatPercentageLabel.AutoSize = true;
            FatPercentageLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FatPercentageLabel.Location = new Point(1, 48);
            FatPercentageLabel.Name = "FatPercentageLabel";
            FatPercentageLabel.Size = new Size(112, 37);
            FatPercentageLabel.TabIndex = 3;
            FatPercentageLabel.Text = "0.000 %";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(1, 16);
            label14.Name = "label14";
            label14.Size = new Size(153, 32);
            label14.TabIndex = 2;
            label14.Text = "Body Fat (BF)";
            // 
            // panel4
            // 
            panel4.Controls.Add(ClearLogBtn);
            panel4.Controls.Add(LogText);
            panel4.Controls.Add(label27);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 515);
            panel4.Name = "panel4";
            panel4.Size = new Size(1046, 154);
            panel4.TabIndex = 3;
            // 
            // ClearLogBtn
            // 
            ClearLogBtn.Location = new Point(36, 2);
            ClearLogBtn.Name = "ClearLogBtn";
            ClearLogBtn.Size = new Size(75, 22);
            ClearLogBtn.TabIndex = 2;
            ClearLogBtn.Text = "Clear";
            ClearLogBtn.UseVisualStyleBackColor = true;
            ClearLogBtn.Click += ClearLogBtn_Click;
            // 
            // LogText
            // 
            LogText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LogText.Location = new Point(9, 28);
            LogText.Name = "LogText";
            LogText.Size = new Size(1034, 123);
            LogText.TabIndex = 1;
            LogText.Text = "";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(5, 5);
            label27.Name = "label27";
            label27.Size = new Size(30, 15);
            label27.TabIndex = 0;
            label27.Text = "Log:";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label29.Location = new Point(836, 6);
            label29.Name = "label29";
            label29.Size = new Size(32, 15);
            label29.TabIndex = 42;
            label29.Text = "DDS";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(834, 29);
            label30.Name = "label30";
            label30.Size = new Size(87, 15);
            label30.TabIndex = 43;
            label30.Text = "Frequency (Hz)";
            // 
            // DDSFreqText
            // 
            DDSFreqText.Location = new Point(836, 49);
            DDSFreqText.Name = "DDSFreqText";
            DDSFreqText.Size = new Size(94, 23);
            DDSFreqText.TabIndex = 44;
            DDSFreqText.Text = "10000.0";
            // 
            // button1
            // 
            button1.Location = new Point(834, 75);
            button1.Name = "button1";
            button1.Size = new Size(97, 23);
            button1.TabIndex = 45;
            button1.Text = "Set DDS";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1052, 694);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(statusStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "BIA-Fat Mass Measurement v0.0.1";
            FormClosing += Form1_FormClosing;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            panel3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel ConnStatusLabel;
        private ToolStripStatusLabel FWVersionLabel;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private Button StartStopBtn;
        private Panel panel2;
        private Label label2;
        private TextBox FFMEqText;
        private Label label1;
        private TextBox ModV_Text;
        private Label label3;
        private Label label6;
        private Label label5;
        private TextBox ModZ_Text;
        private Label label4;
        private Label label9;
        private TextBox PointZ_Text;
        private Label label10;
        private Label label7;
        private TextBox PointV_Text;
        private Label label8;
        private ComboBox PortSelect;
        private Label label13;
        private TableLayoutPanel tableLayoutPanel3;
        private ScottPlot.FormsPlot formsPlot1;
        private Panel panel3;
        private GroupBox groupBox1;
        private Label FatPercentageLabel;
        private Label label14;
        private Label label12;
        private TextBox BFEqText;
        private Label label16;
        private TextBox FMEqText;
        private Label label15;
        private GroupBox groupBox2;
        private Label label22;
        private TextBox HeightText;
        private Label label21;
        private TextBox AgeText;
        private Label label20;
        private Label label19;
        private TextBox WeighText;
        private Label label18;
        private Label label11;
        private CheckBox PointZSelect;
        private CheckBox ModZSelect;
        private GroupBox groupBox4;
        private Label FMLabel;
        private Label label25;
        private GroupBox groupBox3;
        private Label FFMLabel;
        private Label label23;
        private Label label17;
        private Button ResetEqBtn;
        private Button UpdateEqBtn;
        private Label label26;
        private Button RecordBtn;
        private TextBox FilenameText;
        private Panel panel4;
        private RichTextBox LogText;
        private Label label27;
        private Label label24;
        private Label DataCountLabel;
        private Label label28;
        private Button ClearLogBtn;
        private Button LoadEquationBtn;
        private Button button1;
        private TextBox DDSFreqText;
        private Label label30;
        private Label label29;
    }
}
