using System;

namespace WindowsFormsApp1
{
    partial class ValueAdjustmentFactor
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
        public void InitializeComponent()
        {
            this.label_heading = new System.Windows.Forms.Label();
            this.label_vaf1 = new System.Windows.Forms.Label();
            this.label_vaf2 = new System.Windows.Forms.Label();
            this.label_vaf3 = new System.Windows.Forms.Label();
            this.label_vaf4 = new System.Windows.Forms.Label();
            this.label_vaf5 = new System.Windows.Forms.Label();
            this.label_vaf6 = new System.Windows.Forms.Label();
            this.label_vaf7 = new System.Windows.Forms.Label();
            this.label_vaf8 = new System.Windows.Forms.Label();
            this.label_vaf9 = new System.Windows.Forms.Label();
            this.label_vaf10 = new System.Windows.Forms.Label();
            this.label_vaf11 = new System.Windows.Forms.Label();
            this.label_vaf12 = new System.Windows.Forms.Label();
            this.label_vaf13 = new System.Windows.Forms.Label();
            this.label_vaf14 = new System.Windows.Forms.Label();
            this.comboBox_vaf1 = new System.Windows.Forms.ComboBox();
            this.comboBox_vaf2 = new System.Windows.Forms.ComboBox();
            this.comboBox_vaf4 = new System.Windows.Forms.ComboBox();
            this.comboBox_vaf3 = new System.Windows.Forms.ComboBox();
            this.comboBox_vaf8 = new System.Windows.Forms.ComboBox();
            this.comboBox_vaf7 = new System.Windows.Forms.ComboBox();
            this.comboBox_vaf6 = new System.Windows.Forms.ComboBox();
            this.comboBox_vaf5 = new System.Windows.Forms.ComboBox();
            this.comboBox_vaf14 = new System.Windows.Forms.ComboBox();
            this.comboBox_vaf13 = new System.Windows.Forms.ComboBox();
            this.comboBox_vaf12 = new System.Windows.Forms.ComboBox();
            this.comboBox_vaf11 = new System.Windows.Forms.ComboBox();
            this.comboBox_vaf10 = new System.Windows.Forms.ComboBox();
            this.comboBox_vaf9 = new System.Windows.Forms.ComboBox();
            this.button_done = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_heading
            // 
            this.label_heading.AutoSize = true;
            this.label_heading.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_heading.Location = new System.Drawing.Point(13, 13);
            this.label_heading.Name = "label_heading";
            this.label_heading.Size = new System.Drawing.Size(558, 21);
            this.label_heading.TabIndex = 0;
            this.label_heading.Text = "Assign a value from 0 to 5 for each of the following Value Adjustment Factors:\r\n";
            // 
            // label_vaf1
            // 
            this.label_vaf1.AutoSize = true;
            this.label_vaf1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vaf1.Location = new System.Drawing.Point(13, 57);
            this.label_vaf1.Name = "label_vaf1";
            this.label_vaf1.Size = new System.Drawing.Size(462, 21);
            this.label_vaf1.TabIndex = 1;
            this.label_vaf1.Text = "Does the system require reliable backup and recovery processes?";
            // 
            // label_vaf2
            // 
            this.label_vaf2.AutoSize = true;
            this.label_vaf2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vaf2.Location = new System.Drawing.Point(12, 88);
            this.label_vaf2.Name = "label_vaf2";
            this.label_vaf2.Size = new System.Drawing.Size(685, 21);
            this.label_vaf2.TabIndex = 2;
            this.label_vaf2.Text = "Are specialized data communications required to transfer information to or from t" +
    "he application?\r\n";
            // 
            // label_vaf3
            // 
            this.label_vaf3.AutoSize = true;
            this.label_vaf3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vaf3.Location = new System.Drawing.Point(13, 120);
            this.label_vaf3.Name = "label_vaf3";
            this.label_vaf3.Size = new System.Drawing.Size(310, 21);
            this.label_vaf3.TabIndex = 3;
            this.label_vaf3.Text = "Are there distributed processing functions?\r\n";
            // 
            // label_vaf4
            // 
            this.label_vaf4.AutoSize = true;
            this.label_vaf4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vaf4.Location = new System.Drawing.Point(13, 153);
            this.label_vaf4.Name = "label_vaf4";
            this.label_vaf4.Size = new System.Drawing.Size(171, 21);
            this.label_vaf4.TabIndex = 4;
            this.label_vaf4.Text = "Is performance critical?\r\n";
            // 
            // label_vaf5
            // 
            this.label_vaf5.AutoSize = true;
            this.label_vaf5.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vaf5.Location = new System.Drawing.Point(12, 184);
            this.label_vaf5.Name = "label_vaf5";
            this.label_vaf5.Size = new System.Drawing.Size(536, 21);
            this.label_vaf5.TabIndex = 5;
            this.label_vaf5.Text = "Will the system run in an existing, heavily utilized operational environment?";
            // 
            // label_vaf6
            // 
            this.label_vaf6.AutoSize = true;
            this.label_vaf6.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vaf6.Location = new System.Drawing.Point(12, 216);
            this.label_vaf6.Name = "label_vaf6";
            this.label_vaf6.Size = new System.Drawing.Size(310, 21);
            this.label_vaf6.TabIndex = 6;
            this.label_vaf6.Text = "Does the system require online data entry?";
            // 
            // label_vaf7
            // 
            this.label_vaf7.AutoSize = true;
            this.label_vaf7.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vaf7.Location = new System.Drawing.Point(13, 250);
            this.label_vaf7.Name = "label_vaf7";
            this.label_vaf7.Size = new System.Drawing.Size(731, 21);
            this.label_vaf7.TabIndex = 7;
            this.label_vaf7.Text = "Does the online data entry require the input transaction to be built over multipl" +
    "e screens or operations?";
            // 
            // label_vaf8
            // 
            this.label_vaf8.AutoSize = true;
            this.label_vaf8.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vaf8.Location = new System.Drawing.Point(13, 283);
            this.label_vaf8.Name = "label_vaf8";
            this.label_vaf8.Size = new System.Drawing.Size(316, 21);
            this.label_vaf8.TabIndex = 8;
            this.label_vaf8.Text = "Are the internal logical files updated online?";
            // 
            // label_vaf9
            // 
            this.label_vaf9.AutoSize = true;
            this.label_vaf9.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vaf9.Location = new System.Drawing.Point(12, 315);
            this.label_vaf9.Name = "label_vaf9";
            this.label_vaf9.Size = new System.Drawing.Size(347, 21);
            this.label_vaf9.TabIndex = 9;
            this.label_vaf9.Text = "Are the input, output, files or inquiries complex?";
            // 
            // label_vaf10
            // 
            this.label_vaf10.AutoSize = true;
            this.label_vaf10.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vaf10.Location = new System.Drawing.Point(12, 346);
            this.label_vaf10.Name = "label_vaf10";
            this.label_vaf10.Size = new System.Drawing.Size(254, 21);
            this.label_vaf10.TabIndex = 10;
            this.label_vaf10.Text = "Is the internal processing complex?";
            // 
            // label_vaf11
            // 
            this.label_vaf11.AutoSize = true;
            this.label_vaf11.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vaf11.Location = new System.Drawing.Point(12, 379);
            this.label_vaf11.Name = "label_vaf11";
            this.label_vaf11.Size = new System.Drawing.Size(262, 21);
            this.label_vaf11.TabIndex = 11;
            this.label_vaf11.Text = "Is the code designed to be reusable?";
            // 
            // label_vaf12
            // 
            this.label_vaf12.AutoSize = true;
            this.label_vaf12.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vaf12.Location = new System.Drawing.Point(12, 410);
            this.label_vaf12.Name = "label_vaf12";
            this.label_vaf12.Size = new System.Drawing.Size(362, 21);
            this.label_vaf12.TabIndex = 12;
            this.label_vaf12.Text = "Are conversion and installation included in design?";
            // 
            // label_vaf13
            // 
            this.label_vaf13.AutoSize = true;
            this.label_vaf13.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vaf13.Location = new System.Drawing.Point(12, 443);
            this.label_vaf13.Name = "label_vaf13";
            this.label_vaf13.Size = new System.Drawing.Size(527, 21);
            this.label_vaf13.TabIndex = 13;
            this.label_vaf13.Text = "Is the system designed for multiple installations in different organizations?";
            // 
            // label_vaf14
            // 
            this.label_vaf14.AutoSize = true;
            this.label_vaf14.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vaf14.Location = new System.Drawing.Point(12, 476);
            this.label_vaf14.Name = "label_vaf14";
            this.label_vaf14.Size = new System.Drawing.Size(555, 21);
            this.label_vaf14.TabIndex = 14;
            this.label_vaf14.Text = "Is the application designed to facilitate change and for ease of use by the user?";
            // 
            // comboBox_vaf1
            // 
            this.comboBox_vaf1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_vaf1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_vaf1.FormattingEnabled = true;
            this.comboBox_vaf1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox_vaf1.Location = new System.Drawing.Point(818, 56);
            this.comboBox_vaf1.Name = "comboBox_vaf1";
            this.comboBox_vaf1.Size = new System.Drawing.Size(45, 26);
            this.comboBox_vaf1.TabIndex = 15;
            this.comboBox_vaf1.Text = 0.ToString();
            this.comboBox_vaf1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox_vaf2
            // 
            this.comboBox_vaf2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_vaf2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_vaf2.FormattingEnabled = true;
            this.comboBox_vaf2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox_vaf2.Location = new System.Drawing.Point(818, 87);
            this.comboBox_vaf2.Name = "comboBox_vaf2";
            this.comboBox_vaf2.Size = new System.Drawing.Size(45, 26);
            this.comboBox_vaf2.TabIndex = 16;
            this.comboBox_vaf2.Text = 0.ToString();
            this.comboBox_vaf2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox_vaf4
            // 
            this.comboBox_vaf4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_vaf4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_vaf4.FormattingEnabled = true;
            this.comboBox_vaf4.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox_vaf4.Location = new System.Drawing.Point(818, 148);
            this.comboBox_vaf4.Name = "comboBox_vaf4";
            this.comboBox_vaf4.Size = new System.Drawing.Size(45, 26);
            this.comboBox_vaf4.TabIndex = 18;
            this.comboBox_vaf4.Text = 0.ToString();
            this.comboBox_vaf4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // comboBox_vaf3
            // 
            this.comboBox_vaf3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_vaf3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_vaf3.FormattingEnabled = true;
            this.comboBox_vaf3.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox_vaf3.Location = new System.Drawing.Point(818, 118);
            this.comboBox_vaf3.Name = "comboBox_vaf3";
            this.comboBox_vaf3.Size = new System.Drawing.Size(45, 26);
            this.comboBox_vaf3.TabIndex = 17;
            this.comboBox_vaf3.Text = 0.ToString();
            this.comboBox_vaf3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // comboBox_vaf8
            // 
            this.comboBox_vaf8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_vaf8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_vaf8.FormattingEnabled = true;
            this.comboBox_vaf8.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox_vaf8.Location = new System.Drawing.Point(818, 276);
            this.comboBox_vaf8.Name = "comboBox_vaf8";
            this.comboBox_vaf8.Size = new System.Drawing.Size(45, 26);
            this.comboBox_vaf8.TabIndex = 22;
            this.comboBox_vaf8.Text = 0.ToString();
            this.comboBox_vaf8.SelectedIndexChanged += new System.EventHandler(this.comboBox8_SelectedIndexChanged);
            // 
            // comboBox_vaf7
            // 
            this.comboBox_vaf7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_vaf7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_vaf7.FormattingEnabled = true;
            this.comboBox_vaf7.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox_vaf7.Location = new System.Drawing.Point(818, 245);
            this.comboBox_vaf7.Name = "comboBox_vaf7";
            this.comboBox_vaf7.Size = new System.Drawing.Size(45, 26);
            this.comboBox_vaf7.TabIndex = 21;
            this.comboBox_vaf7.Text = 0.ToString();
            this.comboBox_vaf7.SelectedIndexChanged += new System.EventHandler(this.comboBox7_SelectedIndexChanged);
            // 
            // comboBox_vaf6
            // 
            this.comboBox_vaf6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_vaf6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_vaf6.FormattingEnabled = true;
            this.comboBox_vaf6.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox_vaf6.Location = new System.Drawing.Point(818, 211);
            this.comboBox_vaf6.Name = "comboBox_vaf6";
            this.comboBox_vaf6.Size = new System.Drawing.Size(45, 26);
            this.comboBox_vaf6.TabIndex = 20;
            this.comboBox_vaf6.Text = 0.ToString();
            this.comboBox_vaf6.SelectedIndexChanged += new System.EventHandler(this.comboBox6_SelectedIndexChanged);
            // 
            // comboBox_vaf5
            // 
            this.comboBox_vaf5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_vaf5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_vaf5.FormattingEnabled = true;
            this.comboBox_vaf5.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox_vaf5.Location = new System.Drawing.Point(818, 180);
            this.comboBox_vaf5.Name = "comboBox_vaf5";
            this.comboBox_vaf5.Size = new System.Drawing.Size(45, 26);
            this.comboBox_vaf5.TabIndex = 19;
            this.comboBox_vaf5.Text = 0.ToString();
            this.comboBox_vaf5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // comboBox_vaf14
            // 
            this.comboBox_vaf14.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_vaf14.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_vaf14.FormattingEnabled = true;
            this.comboBox_vaf14.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox_vaf14.Location = new System.Drawing.Point(818, 469);
            this.comboBox_vaf14.Name = "comboBox_vaf14";
            this.comboBox_vaf14.Size = new System.Drawing.Size(45, 26);
            this.comboBox_vaf14.TabIndex = 28;
            this.comboBox_vaf14.Text = 0.ToString();
            this.comboBox_vaf14.SelectedIndexChanged += new System.EventHandler(this.comboBox14_SelectedIndexChanged);
            // 
            // comboBox_vaf13
            // 
            this.comboBox_vaf13.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_vaf13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_vaf13.FormattingEnabled = true;
            this.comboBox_vaf13.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox_vaf13.Location = new System.Drawing.Point(818, 435);
            this.comboBox_vaf13.Name = "comboBox_vaf13";
            this.comboBox_vaf13.Size = new System.Drawing.Size(45, 26);
            this.comboBox_vaf13.TabIndex = 27;
            this.comboBox_vaf13.Text = 0.ToString();
            this.comboBox_vaf13.SelectedIndexChanged += new System.EventHandler(this.comboBox13_SelectedIndexChanged);
            // 
            // comboBox_vaf12
            // 
            this.comboBox_vaf12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_vaf12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_vaf12.FormattingEnabled = true;
            this.comboBox_vaf12.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox_vaf12.Location = new System.Drawing.Point(818, 404);
            this.comboBox_vaf12.Name = "comboBox_vaf12";
            this.comboBox_vaf12.Size = new System.Drawing.Size(45, 26);
            this.comboBox_vaf12.TabIndex = 26;
            this.comboBox_vaf12.Text = 0.ToString();
            this.comboBox_vaf12.SelectedIndexChanged += new System.EventHandler(this.comboBox12_SelectedIndexChanged);
            // 
            // comboBox_vaf11
            // 
            this.comboBox_vaf11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_vaf11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_vaf11.FormattingEnabled = true;
            this.comboBox_vaf11.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox_vaf11.Location = new System.Drawing.Point(818, 372);
            this.comboBox_vaf11.Name = "comboBox_vaf11";
            this.comboBox_vaf11.Size = new System.Drawing.Size(45, 26);
            this.comboBox_vaf11.TabIndex = 25;
            this.comboBox_vaf11.Text = 0.ToString();
            this.comboBox_vaf11.SelectedIndexChanged += new System.EventHandler(this.comboBox11_SelectedIndexChanged);
            // 
            // comboBox_vaf10
            // 
            this.comboBox_vaf10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_vaf10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_vaf10.FormattingEnabled = true;
            this.comboBox_vaf10.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox_vaf10.Location = new System.Drawing.Point(818, 340);
            this.comboBox_vaf10.Name = "comboBox_vaf10";
            this.comboBox_vaf10.Size = new System.Drawing.Size(45, 26);
            this.comboBox_vaf10.TabIndex = 24;
            this.comboBox_vaf10.Text = 0.ToString();
            this.comboBox_vaf10.SelectedIndexChanged += new System.EventHandler(this.comboBox10_SelectedIndexChanged);
            // 
            // comboBox_vaf9
            // 
            this.comboBox_vaf9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_vaf9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_vaf9.FormattingEnabled = true;
            this.comboBox_vaf9.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox_vaf9.Location = new System.Drawing.Point(818, 308);
            this.comboBox_vaf9.Name = "comboBox_vaf9";
            this.comboBox_vaf9.Size = new System.Drawing.Size(45, 26);
            this.comboBox_vaf9.TabIndex = 23;
            this.comboBox_vaf9.Text = 0.ToString();
            this.comboBox_vaf9.SelectedIndexChanged += new System.EventHandler(this.comboBox9_SelectedIndexChanged);
            // 
            // button_done
            // 
            this.button_done.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_done.Location = new System.Drawing.Point(279, 519);
            this.button_done.Name = "button_done";
            this.button_done.Size = new System.Drawing.Size(95, 34);
            this.button_done.TabIndex = 29;
            this.button_done.Text = "Done";
            this.button_done.UseVisualStyleBackColor = true;
            this.button_done.Click += new System.EventHandler(this.buttonDoneClick);
            // 
            // button_cancel
            // 
            this.button_cancel.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancel.Location = new System.Drawing.Point(431, 519);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(95, 34);
            this.button_cancel.TabIndex = 30;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.buttonCancelClick);
            // 
            // ValueAdjustmentFactor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 576);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_done);
            this.Controls.Add(this.comboBox_vaf14);
            this.Controls.Add(this.comboBox_vaf13);
            this.Controls.Add(this.comboBox_vaf12);
            this.Controls.Add(this.comboBox_vaf11);
            this.Controls.Add(this.comboBox_vaf10);
            this.Controls.Add(this.comboBox_vaf9);
            this.Controls.Add(this.comboBox_vaf8);
            this.Controls.Add(this.comboBox_vaf7);
            this.Controls.Add(this.comboBox_vaf6);
            this.Controls.Add(this.comboBox_vaf5);
            this.Controls.Add(this.comboBox_vaf4);
            this.Controls.Add(this.comboBox_vaf3);
            this.Controls.Add(this.comboBox_vaf2);
            this.Controls.Add(this.comboBox_vaf1);
            this.Controls.Add(this.label_vaf14);
            this.Controls.Add(this.label_vaf13);
            this.Controls.Add(this.label_vaf12);
            this.Controls.Add(this.label_vaf11);
            this.Controls.Add(this.label_vaf10);
            this.Controls.Add(this.label_vaf9);
            this.Controls.Add(this.label_vaf8);
            this.Controls.Add(this.label_vaf7);
            this.Controls.Add(this.label_vaf6);
            this.Controls.Add(this.label_vaf5);
            this.Controls.Add(this.label_vaf4);
            this.Controls.Add(this.label_vaf3);
            this.Controls.Add(this.label_vaf2);
            this.Controls.Add(this.label_vaf1);
            this.Controls.Add(this.label_heading);
            this.Name = "ValueAdjustmentFactor";
            this.Text = "Value Adjustment Factors";
            this.Load += new System.EventHandler(this.ValueAdjustmentFactor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }





        #endregion

        private System.Windows.Forms.Label label_heading;
        private System.Windows.Forms.Label label_vaf1;
        private System.Windows.Forms.Label label_vaf2;
        private System.Windows.Forms.Label label_vaf3;
        private System.Windows.Forms.Label label_vaf4;
        private System.Windows.Forms.Label label_vaf5;
        private System.Windows.Forms.Label label_vaf6;
        private System.Windows.Forms.Label label_vaf7;
        private System.Windows.Forms.Label label_vaf8;
        private System.Windows.Forms.Label label_vaf9;
        private System.Windows.Forms.Label label_vaf10;
        private System.Windows.Forms.Label label_vaf11;
        private System.Windows.Forms.Label label_vaf12;
        private System.Windows.Forms.Label label_vaf13;
        private System.Windows.Forms.Label label_vaf14;
        private System.Windows.Forms.ComboBox comboBox_vaf1;
        private System.Windows.Forms.ComboBox comboBox_vaf2;
        private System.Windows.Forms.ComboBox comboBox_vaf4;
        private System.Windows.Forms.ComboBox comboBox_vaf3;
        private System.Windows.Forms.ComboBox comboBox_vaf8;
        private System.Windows.Forms.ComboBox comboBox_vaf7;
        private System.Windows.Forms.ComboBox comboBox_vaf6;
        private System.Windows.Forms.ComboBox comboBox_vaf5;
        private System.Windows.Forms.ComboBox comboBox_vaf14;
        private System.Windows.Forms.ComboBox comboBox_vaf13;
        private System.Windows.Forms.ComboBox comboBox_vaf12;
        private System.Windows.Forms.ComboBox comboBox_vaf11;
        private System.Windows.Forms.ComboBox comboBox_vaf10;
        private System.Windows.Forms.ComboBox comboBox_vaf9;
        private System.Windows.Forms.Button button_done;
        private System.Windows.Forms.Button button_cancel;
    }
}