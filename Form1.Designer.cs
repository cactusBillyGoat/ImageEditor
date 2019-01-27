using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Windows.Forms.DataVisualization.Charting;

namespace Image_Editor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            openFileDialog1 = new OpenFileDialog();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            DramaticButton = new RoundButton();
            SujiButton = new RoundButton();
            FrozenButton = new RoundButton();
            FlashButton = new RoundButton();
            SpikeButton = new RoundButton();
            GrayButton = new RoundButton();
            ArtisticButton = new RoundButton();
            SepiaButton = new RoundButton();
            NoneButton = new RoundButton();
            FiltersExpander = new Button();
            ResizeExpander = new Button();
            UndoRedoExpander = new Button();
            HistogramButton = new Button();
            UndoButton = new RoundButton();
            RedoButton = new RoundButton();
            tableLayoutPanel2 = new TableLayoutPanel();
            OpenButton = new Button();
            SaveButton = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            label1 = new Label();
            redbar = new TrackBar();
            greenbar = new TrackBar();
            bluebar = new TrackBar();
            label3 = new Label();
            label2 = new Label();
            redvalue = new Label();
            bluevalue = new Label();
            greenvalue = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            timer1 = new Timer(components);
            KakaoButton = new RoundButton();
            VerticalTextBox = new TextBox();
            HorizontalTextBox = new TextBox();
            ResizeButton = new RoundButton();
            Histogram = new Chart();
            ((ISupportInitialize)(pictureBox1)).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((ISupportInitialize)(redbar)).BeginInit();
            ((ISupportInitialize)(greenbar)).BeginInit();
            ((ISupportInitialize)(bluebar)).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "JPG|*.jpg|BMP|*.bmp|PNG|*.png|GIF|*.gif";
            openFileDialog1.FileOk += new CancelEventHandler(openFileDialog1_FileOk);
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.DarkGray;

            try
            {
                pictureBox1.Image = new Bitmap(BackgroundPath);
            }
            catch
            {
                //do nothing the background color will appear
            }

            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(3, 36);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(865, 678);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.DragOver += new DragEventHandler(pictureBox1_DragOver);
            pictureBox1.DoubleClick += new EventHandler(pictureBox1_DoubleClick);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 87.09677F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.90323F));
            tableLayoutPanel1.Controls.Add(panel1, 1, 1);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 3);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 3);
            tableLayoutPanel1.Controls.Add(label4, 0, 2);
            tableLayoutPanel1.Controls.Add(label5, 1, 0);
            tableLayoutPanel1.Controls.Add(label6, 0, 0);
            tableLayoutPanel1.Controls.Add(label7, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 86.75373F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.24627F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1001, 860);
            tableLayoutPanel1.TabIndex = 7;
            tableLayoutPanel1.Paint += new PaintEventHandler(tableLayoutPanel1_Paint);
            // 
            // panel1
            // 
            panel1.Controls.Add(ResizeButton);
            panel1.Controls.Add(HorizontalTextBox);
            panel1.Controls.Add(VerticalTextBox);
            panel1.Controls.Add(ResizeExpander);
            panel1.Controls.Add(KakaoButton);
            panel1.Controls.Add(DramaticButton);
            panel1.Controls.Add(SujiButton);
            panel1.Controls.Add(FrozenButton);
            panel1.Controls.Add(FlashButton);
            panel1.Controls.Add(SpikeButton);
            panel1.Controls.Add(GrayButton);
            panel1.Controls.Add(ArtisticButton);
            panel1.Controls.Add(SepiaButton);
            panel1.Controls.Add(NoneButton);
            panel1.Controls.Add(FiltersExpander);
            panel1.Controls.Add(HistogramButton);
            panel1.Controls.Add(UndoButton);
            panel1.Controls.Add(RedoButton);
            panel1.Controls.Add(UndoRedoExpander);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(874, 36);
            panel1.Name = "panel1";
            panel1.Size = new Size(124, 678);
            panel1.TabIndex = 14;
            panel1.Enabled = false;
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            //
            // ResizeButton
            //
            ResizeButton.Dock = DockStyle.Top;
            ResizeButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            ResizeButton.Location = new Point(131, 520);
            ResizeButton.Name = "ResizeButton";
            ResizeButton.Size = new Size(124, 65);
            ResizeButton.TabIndex = 11;
            ResizeButton.Visible = false;
            ResizeButton.ForeColor = MidnightBlue;
            ResizeButton.Name = "ResizeButton";
            ResizeButton.Size = new Size(62, 32);
            ResizeButton.Text = "Set";
            ResizeButton.UseVisualStyleBackColor = true;
            ResizeButton.Visible = false;
            ResizeButton.Click += new EventHandler(ResizeButton_Click);
            ResizeButton.Enter += new EventHandler(ResizeButton_Click);
            //
            // HorizontalTextBox
            //
            HorizontalTextBox.Dock = DockStyle.Top;
            HorizontalTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            HorizontalTextBox.Location = new Point(0, 520);
            HorizontalTextBox.Name = "HorizontalTextBox";
            HorizontalTextBox.Size = new Size(124, 65);
            HorizontalTextBox.TabIndex = 11;
            HorizontalTextBox.Visible = false;
            //
            // VerticalTextBox
            //
            VerticalTextBox.Dock = DockStyle.Top;
            VerticalTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            VerticalTextBox.Location = new Point(0, 520);
            VerticalTextBox.Name = "VerticalTextBox";
            VerticalTextBox.Size = new Size(124, 65);
            VerticalTextBox.TabIndex = 11;
            VerticalTextBox.Visible = false;
            // 
            // DramaticButton
            // 
            DramaticButton.Dock = DockStyle.Top;
            DramaticButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            DramaticButton.ForeColor = MidnightBlue;
            DramaticButton.Location = new Point(0, 520);
            DramaticButton.Name = "DramaticButton";
            DramaticButton.Size = new Size(124, 65);
            DramaticButton.TabIndex = 11;
            DramaticButton.Text = "Dramatic";
            DramaticButton.UseVisualStyleBackColor = true;
            DramaticButton.Visible = false;
            DramaticButton.Click += new EventHandler(DramaticButton_Click);
            // 
            // SujiButton
            // 
            SujiButton.Dock = DockStyle.Top;
            SujiButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            SujiButton.ForeColor = MidnightBlue;
            SujiButton.Location = new Point(0, 455);
            SujiButton.Name = "SujiButton";
            SujiButton.Size = new Size(124, 65);
            SujiButton.TabIndex = 10;
            SujiButton.Text = "Suji";
            SujiButton.UseVisualStyleBackColor = true;
            SujiButton.Visible = false;
            SujiButton.Click += new EventHandler(SujiButton_Click_1);
            // 
            // FrozenButton
            // 
            FrozenButton.Dock = DockStyle.Top;
            FrozenButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            FrozenButton.ForeColor = MidnightBlue;
            FrozenButton.Location = new Point(0, 390);
            FrozenButton.Name = "FrozenButton";
            FrozenButton.Size = new Size(124, 65);
            FrozenButton.TabIndex = 9;
            FrozenButton.Text = "Frozen";
            FrozenButton.UseVisualStyleBackColor = true;
            FrozenButton.Visible = false;
            FrozenButton.Click += new EventHandler(FrozenButton_Click);
            // 
            // FlashButton
            // 
            FlashButton.Dock = DockStyle.Top;
            FlashButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            FlashButton.ForeColor = MidnightBlue;
            FlashButton.Location = new Point(0, 325);
            FlashButton.Name = "FlashButton";
            FlashButton.Size = new Size(124, 65);
            FlashButton.TabIndex = 8;
            FlashButton.Text = "Flash";
            FlashButton.UseVisualStyleBackColor = true;
            FlashButton.Visible = false;
            FlashButton.Click += new EventHandler(FlashButton_Click);
            // 
            // SpikeButton
            // 
            SpikeButton.Dock = DockStyle.Top;
            SpikeButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            SpikeButton.ForeColor = MidnightBlue;
            SpikeButton.Location = new Point(0, 260);
            SpikeButton.Name = "SpikeButton";
            SpikeButton.Size = new Size(124, 65);
            SpikeButton.TabIndex = 7;
            SpikeButton.Text = "Spike";
            SpikeButton.UseVisualStyleBackColor = true;
            SpikeButton.Visible = false;
            SpikeButton.Click += new EventHandler(SpikeButton_Click_1);
            // 
            // GrayButton
            // 
            GrayButton.Dock = DockStyle.Top;
            GrayButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            GrayButton.ForeColor = MidnightBlue;
            GrayButton.Location = new Point(0, 195);
            GrayButton.Name = "GrayButton";
            GrayButton.Size = new Size(124, 65);
            GrayButton.TabIndex = 1;
            GrayButton.Text = "Gray";
            GrayButton.UseVisualStyleBackColor = true;
            GrayButton.Visible = false;
            GrayButton.Click += new EventHandler(GrayButton_Click_1);
            // 
            // ArtisticButton
            // 
            ArtisticButton.Dock = DockStyle.Top;
            ArtisticButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            ArtisticButton.ForeColor = MidnightBlue;
            ArtisticButton.Location = new Point(0, 130);
            ArtisticButton.Name = "ArtisticButton";
            ArtisticButton.Size = new Size(124, 65);
            ArtisticButton.TabIndex = 6;
            ArtisticButton.Text = "Artistic";
            ArtisticButton.UseVisualStyleBackColor = true;
            ArtisticButton.Visible = false;
            ArtisticButton.Click += new EventHandler(ArtisticButton_Click_1);
            // 
            // SepiaButton
            // 
            SepiaButton.Dock = DockStyle.Top;
            SepiaButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            SepiaButton.ForeColor = MidnightBlue;
            SepiaButton.Location = new Point(0, 65);
            SepiaButton.Name = "SepiaButton";
            SepiaButton.Size = new Size(124, 65);
            SepiaButton.TabIndex = 2;
            SepiaButton.Text = "Sepia";
            SepiaButton.UseVisualStyleBackColor = true;
            SepiaButton.Visible = false;
            SepiaButton.Click += new EventHandler(SepiaButton_Click_1);
            // 
            // NoneButton
            // 
            NoneButton.Dock = DockStyle.Top;
            NoneButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            NoneButton.ForeColor = MidnightBlue;
            NoneButton.Location = new Point(0, 0);
            NoneButton.Name = "NoneButton";
            NoneButton.Size = new Size(124, 65);
            NoneButton.TabIndex = 5;
            NoneButton.Text = "None";
            NoneButton.UseVisualStyleBackColor = true;
            NoneButton.Visible = false;
            NoneButton.Click += new EventHandler(NoneButton_Click_1);
            //
            // RedoButton
            // 
            RedoButton.Dock = DockStyle.Top;
            RedoButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            RedoButton.BackColor = Color.White;
            RedoButton.ForeColor = MidnightBlue;
            RedoButton.Location = new Point(3, 3);
            RedoButton.Name = "RedoButton";
            RedoButton.Size = new Size(62, 65);
            RedoButton.TabIndex = 5;
            RedoButton.Text = "Redo";
            RedoButton.AutoSize = true;
            RedoButton.Visible = false;
            RedoButton.Enabled = false;
            RedoButton.Click += new EventHandler(RedoButton_Click);
            //
            // UndoButton
            // 
            UndoButton.Dock = DockStyle.Top;
            UndoButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            UndoButton.BackColor = Color.White;
            RedoButton.ForeColor = MidnightBlue;
            UndoButton.Location = new Point(3, 3);
            UndoButton.Name = "UndoButton";
            UndoButton.Size = new Size(62, 65);
            UndoButton.TabIndex = 5;
            UndoButton.Text = "Undo";
            UndoButton.AutoSize = true;
            UndoButton.Visible = false;
            UndoButton.Enabled = false;
            UndoButton.Click += new EventHandler(UndoButton_Click);
            // 
            // ResizeExpander
            // 
            ResizeExpander.Dock = DockStyle.Top;
            ResizeExpander.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            ResizeExpander.BackColor = MidnightBlue;
            ResizeExpander.ForeColor = Color.White;
            ResizeExpander.Location = new Point(0, 500);
            ResizeExpander.Name = "ResizeExpander";
            ResizeExpander.Size = new Size(124, 65);
            ResizeExpander.TabIndex = 5;
            ResizeExpander.Text = "Resize";
            ResizeExpander.Click += new EventHandler(ResizeExpander_Click);
            // 
            // FiltersExpander
            // 
            FiltersExpander.Dock = DockStyle.Top;
            FiltersExpander.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            FiltersExpander.BackColor = MidnightBlue;
            FiltersExpander.ForeColor = Color.White;
            FiltersExpander.Location = new Point(0, 500);
            FiltersExpander.Name = "FiltersExpander";
            FiltersExpander.Size = new Size(124, 65);
            FiltersExpander.TabIndex = 5;
            FiltersExpander.Text = "Filters";
            FiltersExpander.Click += new EventHandler(FiltersExpander_Click_1);
            // 
            // HistogramButton
            // 
            HistogramButton.Dock = DockStyle.Top;
            HistogramButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            HistogramButton.BackColor = MidnightBlue;
            HistogramButton.ForeColor = Color.White;
            HistogramButton.Location = new Point(1, 0);
            HistogramButton.Name = "HistogramButton";
            HistogramButton.Size = new Size(124, 65);
            HistogramButton.TabIndex = 5;
            HistogramButton.Text = "Histogram";
            HistogramButton.Click += new EventHandler(HistogramButton_Click);
            // 
            // UndoRedoExpander
            // 
            UndoRedoExpander.Dock = DockStyle.Top;
            UndoRedoExpander.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            UndoRedoExpander.BackColor = MidnightBlue;
            UndoRedoExpander.ForeColor = Color.White;
            UndoRedoExpander.Location = new Point(1, 0);
            UndoRedoExpander.Name = "UndoRedoExpander";
            UndoRedoExpander.Size = new Size(124, 65);
            UndoRedoExpander.TabIndex = 5;
            UndoRedoExpander.Text = "Undo/Redo";
            UndoRedoExpander.Click += new EventHandler(UndoRedoExpander_Click_1);
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.3937F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.6063F));
            tableLayoutPanel2.Controls.Add(OpenButton, 0, 0);
            tableLayoutPanel2.Controls.Add(SaveButton, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(874, 758);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(124, 99);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // OpenButton
            // 
            OpenButton.BackColor = MidnightBlue;
            OpenButton.Dock = DockStyle.Fill;
            OpenButton.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            OpenButton.ForeColor = Color.White;
            OpenButton.Location = new Point(3, 3);
            OpenButton.Name = "OpenButton";
            OpenButton.Size = new Size(56, 93);
            OpenButton.TabIndex = 8;
            OpenButton.Text = "Open";
            OpenButton.UseVisualStyleBackColor = false;
            OpenButton.Click += new EventHandler(OpenButton_Click_1);
            // 
            // SaveButton
            // 
            SaveButton.BackColor = Color.DarkGray;
            SaveButton.Dock = DockStyle.Fill;
            SaveButton.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            SaveButton.ForeColor = Color.White;
            SaveButton.Location = new Point(65, 3);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(56, 93);
            SaveButton.TabIndex = 9;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = false;
            SaveButton.Click += new EventHandler(SaveButton_Click);
            SaveButton.Enabled = false;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.213483F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 62F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90.78651F));
            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Controls.Add(redbar, 2, 0);
            tableLayoutPanel3.Controls.Add(greenbar, 2, 1);
            tableLayoutPanel3.Controls.Add(bluebar, 2, 2);
            tableLayoutPanel3.Controls.Add(label3, 0, 1);
            tableLayoutPanel3.Controls.Add(label2, 0, 2);
            tableLayoutPanel3.Controls.Add(redvalue, 1, 0);
            tableLayoutPanel3.Controls.Add(bluevalue, 1, 1);
            tableLayoutPanel3.Controls.Add(greenvalue, 1, 2);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 758);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(865, 99);
            tableLayoutPanel3.Enabled = false;
            tableLayoutPanel3.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = MidnightBlue;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(40, 29);
            label1.TabIndex = 7;
            label1.Text = "Red";
            // 
            // redbar
            // 
            redbar.Dock = DockStyle.Left;
            redbar.Location = new Point(136, 1);
            redbar.Margin = new Padding(1);
            redbar.Maximum = 50;
            redbar.Name = "redbar";
            redbar.Size = new Size(524, 34);
            redbar.TabIndex = 10;
            redbar.Scroll += new EventHandler(trackBar2_Scroll);
            redbar.ValueChanged += new EventHandler(trackBar2_ValueChanged);
            // 
            // greenbar
            // 
            greenbar.Location = new Point(136, 37);
            greenbar.Margin = new Padding(1);
            greenbar.Maximum = 50;
            greenbar.Name = "greenbar";
            greenbar.Size = new Size(524, 34);
            greenbar.TabIndex = 11;
            greenbar.ValueChanged += new EventHandler(trackBar1_ValueChanged);
            // 
            // bluebar
            // 
            bluebar.Location = new Point(136, 73);
            bluebar.Margin = new Padding(1);
            bluebar.Maximum = 50;
            bluebar.Name = "bluebar";
            bluebar.Size = new Size(524, 25);
            bluebar.TabIndex = 12;
            bluebar.Scroll += new EventHandler(trackBar3_Scroll_1);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label3.ForeColor = MidnightBlue;
            label3.Location = new Point(3, 36);
            label3.Name = "label3";
            label3.Size = new Size(56, 29);
            label3.TabIndex = 14;
            label3.Text = "Green";
            label3.Click += new EventHandler(label3_Click);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label2.ForeColor = MidnightBlue;
            label2.Location = new Point(3, 72);
            label2.Name = "label2";
            label2.Size = new Size(47, 27);
            label2.TabIndex = 13;
            label2.Text = "Blue";
            // 
            // redvalue
            // 
            redvalue.AutoSize = true;
            redvalue.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            redvalue.ForeColor = MidnightBlue;
            redvalue.Location = new Point(76, 0);
            redvalue.Name = "redvalue";
            redvalue.Size = new Size(35, 26);
            redvalue.TabIndex = 15;
            redvalue.Text = "0.0";
            // 
            // bluevalue
            // 
            bluevalue.AutoSize = true;
            bluevalue.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            bluevalue.ForeColor = MidnightBlue;
            bluevalue.Location = new Point(76, 36);
            bluevalue.Name = "bluevalue";
            bluevalue.Size = new Size(35, 26);
            bluevalue.TabIndex = 16;
            bluevalue.Text = "0.0";
            // 
            // greenvalue
            // 
            greenvalue.AutoSize = true;
            greenvalue.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            greenvalue.ForeColor = MidnightBlue;
            greenvalue.Location = new Point(76, 72);
            greenvalue.Name = "greenvalue";
            greenvalue.Size = new Size(35, 26);
            greenvalue.TabIndex = 17;
            greenvalue.Text = "0.0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = MidnightBlue;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 717);
            label4.Name = "label4";
            label4.Size = new Size(865, 38);
            label4.TabIndex = 11;
            label4.Text = "Adjust Custom RGB";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = MidnightBlue;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label5.ForeColor = Color.White;
            label5.Location = new Point(874, 0);
            label5.Name = "label5";
            label5.Size = new Size(124, 33);
            label5.TabIndex = 12;
            label5.Text = "Operations";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = MidnightBlue;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label6.ForeColor = Color.White;
            label6.Location = new Point(3, 0);
            label6.Name = "label6";
            label6.Size = new Size(865, 33);
            label6.TabIndex = 13;
            label6.Text = "Image Editor";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = MidnightBlue;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label7.ForeColor = Color.White;
            label7.Location = new Point(874, 717);
            label7.Name = "label7";
            label7.Size = new Size(124, 38);
            label7.TabIndex = 15;
            label7.UseCompatibleTextRendering = true;
            label7.Text = "Image operations";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += new EventHandler(timer1_Tick);
            // 
            // KakaoButton
            // 
            KakaoButton.Dock = DockStyle.Top;
            KakaoButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            KakaoButton.ForeColor = MidnightBlue;
            KakaoButton.Location = new Point(0, 585);
            KakaoButton.Name = "KakaoButton";
            KakaoButton.Size = new Size(124, 65);
            KakaoButton.TabIndex = 12;
            KakaoButton.Text = "Kakao";
            KakaoButton.UseVisualStyleBackColor = true;
            KakaoButton.Visible = false;
            KakaoButton.Click += new EventHandler(button12_Click);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            WindowState = FormWindowState.Normal;
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(1001, 860);
            Controls.Add(tableLayoutPanel1);
            Icon = ((Icon)(resources.GetObject("$Icon")));
            MinimumSize = new Size(1015, 748);
            Name = "Form1";
            Text = "Image Editor";
            Load += new EventHandler(Form1_Load);
            ((ISupportInitialize)(pictureBox1)).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((ISupportInitialize)(redbar)).EndInit();
            ((ISupportInitialize)(greenbar)).EndInit();
            ((ISupportInitialize)(bluebar)).EndInit();
            ResumeLayout(false);
        }

        #endregion

        #region Definitions
        
        private OpenFileDialog openFileDialog1;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Timer timer1;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label1;
        private TrackBar redbar;
        private TrackBar greenbar;
        private TrackBar bluebar;
        private Label label3;
        private Label label2;
        private Label redvalue;
        private Label bluevalue;
        private Label greenvalue;
        private Label label4;
        private Label label6;
        private Panel panel1;
        private RoundButton GrayButton;
        private RoundButton ArtisticButton;
        private RoundButton SepiaButton;
        private RoundButton NoneButton;
        private Button FiltersExpander;
        private Button ResizeExpander;
        private Button UndoRedoExpander;
        private Button HistogramButton;
        private RoundButton UndoButton;
        private RoundButton RedoButton;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label5;
        private RoundButton SpikeButton;
        private Button OpenButton;
        private Button SaveButton;
        private Label label7;
        private RoundButton FlashButton;
        private RoundButton FrozenButton;
        private RoundButton DramaticButton;
        private RoundButton SujiButton;
        private RoundButton KakaoButton;
        private TextBox HorizontalTextBox;
        private TextBox VerticalTextBox;
        private RoundButton ResizeButton;
        private Chart Histogram;

        #endregion Definitions

        #region Helper properties

        /// <summary>
        /// Gets the midnight blue clor.
        /// </summary>
        /// <value>
        /// The midnight blue.
        /// </value>
        private Color MidnightBlue => Color.MidnightBlue;

        #endregion
    }
}

