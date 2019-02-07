using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static WindowsFormsApp1.LanguageSelection;
using static WindowsFormsApp1.GetFPName;
using Microsoft.VisualBasic;
using Antlr.Runtime;

namespace WindowsFormsApp1
{
    public partial class Home : Form
    {
        int clickCount = 1;
        int clickCountSMI = 1;
        public string textBox_extIntFiles;
        public string textBox_intLogFiles;
        public string textBox_extInq;
        public string textBox_extOutput;
        public string textBox_extInput;
        public string radio_extInput;
        public string radio_extOutput;
        public string radio_extInq;
        public string radio_intLogFiles;
        public string radio_extIntFiles;
        private LanguageSelection lang = new LanguageSelection();
        //private GetFPName g = new GetFPName();
        TextBox textBox_totalCount2;
        TextBox textBox_extIntFilesCompValue2, textBox_intLogFilesCompValue2, textBox_extInqCompValue2, textBox_extOutputCompValue2, textBox_extInputCompValue2;
        TextBox textBox_valAdj2;
        TextBox textBox_changeLang2;
        TextBox textBox_computeFP2;
        TextBox textBox_codeSize2;
        TextBox textBox_extIntFiles2, textBox_intLogFiles2, textBox_extInq2, textBox_extOutput2, textBox_extInput2;
        double fpValue;
        Button button1_2;
        RadioButton radioButton1_2, radioButton2_2, radioButton3_2, radioButton4_2, radioButton5_2,
            radioButton6_2, radioButton7_2, radioButton8_2, radioButton9_2, radioButton10_2,
            radioButton11_2, radioButton12_2, radioButton13_2, radioButton14_2, radioButton15_2;
        public static List<Information> Linfo = new List<Information>();
        public static List<Information> LFile = new List<Information>();
        Home h;
        Information info,fInfo;
        DataTable smi = new DataTable();
        DataRow row;
        public int tModules = 0;
        public int rCount = 0;
        DataGridView dataGridView1;
        DataSet ds = new DataSet();
        public String fileNameWithoutExt;
        int index;
        public StringBuilder fileNameSBI;
        List<string> selectedJavaFiles = new List<string>();
        //List<string> selectedJavaFilesImport = new List<string>();
        TreeNode node;
        TabPage tabTV;
        public Home()
        {
            InitializeComponent();

        }

        //private void Form_Load(object sender, EventArgs e)
        //{
        //    //
        //    // This is the first node in the view.
        //    //
        //    TreeNode treeNode = new TreeNode("Windows");
        //    treeView1.Nodes.Add(treeNode);
        //    //
        //    // Another node following the first node.
        //    //
        //    treeNode = new TreeNode("Linux");
        //    treeView1.Nodes.Add(treeNode);
        //    //
        //    // Create two child nodes and put them in an array.
        //    // ... Add the third node, and specify these as its children.
        //    //
        //    TreeNode node2 = new TreeNode("C#");
        //    TreeNode node3 = new TreeNode("VB.NET");
        //    TreeNode[] array = new TreeNode[] { node2, node3 };
        //    //
        //    // Final node.
        //    //
        //    treeNode = new TreeNode("Dot Net Perls", array);
        //    treeView1.Nodes.Add(treeNode);
        //}

        private void mnuDeleteFile_Click(object sender, System.EventArgs e)
        {

            string messageBoxText = "Do you want to delete this from the project?";
            string caption = "Delete from project !!";
            MessageBoxButtons button = MessageBoxButtons.YesNoCancel;
            DialogResult result = MessageBox.Show(messageBoxText, caption, button);

            // Process message box results
            switch (result)
            {
                case DialogResult.Yes:
                    // User pressed Yes button
                    // ...
                    String selectedTabPageName = Convert.ToString(treeView1.SelectedNode.Tag);
                    try
                    {
                        tabControl_fp.SelectTab(selectedTabPageName);
                        foreach (TabPage tp in tabControl_fp.TabPages)
                        {
                            if (tp.Text == selectedTabPageName)
                            {
                                tabControl_fp.SelectedTab = tp;
                                tabControl_fp.TabPages.Remove(tp);
                                treeView1.SelectedNode.Remove();

                                break;
                            }
                        }
                    }
                    catch
                    {
                        treeView1.SelectedNode.Remove();
                    }
                    break;
                case DialogResult.No:
                    // User pressed No button
                    // ...
                    //this.Close();
                    break;
                case DialogResult.Cancel:
                    // User pressed Cancel button
                    // ...
                    //e.Cancel = true;
                    break;
            }



            //String selectedTabPageName = Convert.ToString(treeView1.SelectedNode.Tag);
            //try
            //{
            //    tabControl_fp.SelectTab(selectedTabPageName);
            //    foreach (TabPage tp in tabControl_fp.TabPages)
            //    {
            //        if (tp.Text == selectedTabPageName)
            //        {
            //            tabControl_fp.SelectedTab = tp;
            //            tabControl_fp.TabPages.Remove(tp);
            //            treeView1.SelectedNode.Remove();

            //            break;
            //        }
            //    }
            //}
            //catch
            //{
            //    treeView1.SelectedNode.Remove();
            //}

        }

        private void mnuOpen_Click(object sender, System.EventArgs e)
        {
            try
            {
                String selectedTabPageName = Convert.ToString(treeView1.SelectedNode.Tag);
                tabControl_fp.SelectTab(selectedTabPageName);
            }
            catch
            {

            }


        }

        private void mnuClose_Click(object sender, System.EventArgs e)
        {
            try
            {
                String selectedTabPageName = Convert.ToString(treeView1.SelectedNode.Tag);
                tabControl_fp.SelectTab(selectedTabPageName);
                foreach (TabPage tp in tabControl_fp.TabPages)
                {
                    if (tp.Text == selectedTabPageName)
                    {
                        tabControl_fp.SelectedTab = tp;
                        tabControl_fp.TabPages.Remove(tp);
                        break;
                    }
                }
            }
            catch
            {

            }

        }

        private TreeNode m_OldSelectNode;
        private void treeView1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Show menu only if the right mouse button is clicked.
            if (e.Button == MouseButtons.Right)
            {

                // Point where the mouse is clicked.
                Point p = new Point(e.X, e.Y);

                // Get the node that the user has clicked.
                TreeNode node = treeView1.GetNodeAt(p);
                if (node != null)
                {

                    // Select the node the user has clicked.
                    // The node appears selected until the menu is displayed on the screen.
                    m_OldSelectNode = treeView1.SelectedNode;
                    treeView1.SelectedNode = node;

                    // Find the appropriate ContextMenu depending on the selected node.
                    switch (Convert.ToString(node.Tag))
                    {
                        default:
                            contextMenuStrip1.Show(treeView1, p);
                            break;
                    }

                    // Highlight the selected node.
                    treeView1.SelectedNode = m_OldSelectNode;
                    m_OldSelectNode = null;
                }
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            //Home_FormClosing(sender, FormClosingEventArgs e);
            //string messageBoxText = "Do you want to save changes?";
            //string caption = "Save / Discard Changes";
            //MessageBoxButtons button = MessageBoxButtons.YesNoCancel;
            //DialogResult result = MessageBox.Show(messageBoxText, caption, button);

            //// Process message box results
            //switch (result)
            //{
            //    case DialogResult.Yes:
            //        // User pressed Yes button
            //        // ...
            //        saveToolStripMenuItem_Click(sender, e);
            //        break;
            //    case DialogResult.No:
            //        // User pressed No button
            //        // ...
            //        this.Close();
            //        break;
            //    case DialogResult.Cancel:
            //        // User pressed Cancel button
            //        // ...
            //        break;
            //}
            ////this.Close();
        }

        private void functionPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void languageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LanguageSelection ls = new LanguageSelection();
            ls.Show();
        }

        private void enterFPDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.Text.Contains("-"))
            {
                MessageBox.Show("Please Create A New Project Before Proceeding With The Calculation");
            }
            else
            {
                GetFPName g = new GetFPName();
                g.Show();
                //FPTabSetup();
            }
        }

        public void FPTabSetup(string s)
        {
            tabTV = new TabPage();
            if (clickCount == 1)
            {
                Controls.Add(tabControl_fp);
                tabSetup(tabTV);
                tabTV.Name = s;
                tabControl_fp.Show();
            }
            else
            {
                tabSetup(tabTV);
                tabTV.Name = s;
            }
            int tabCount = tabControl_fp.TabCount;
            tabControl_fp.SelectedIndex = tabCount - 1;
            clickCount++;
        }


        public void tabSetup(TabPage tabPage2)
        {

            Label label1_2 = new System.Windows.Forms.Label();
            //this.tabControl_fp = new System.Windows.Forms.TabControl();
            Label label_currLang2 = new System.Windows.Forms.Label();
            //TextBox textBox_changeLang2 = new System.Windows.Forms.TextBox();
            textBox_changeLang2 = new System.Windows.Forms.TextBox();
            textBox_codeSize2 = new System.Windows.Forms.TextBox();
            //TextBox 
            textBox_valAdj2 = new System.Windows.Forms.TextBox();
            textBox_computeFP2 = new System.Windows.Forms.TextBox();
            Button button4_2 = new System.Windows.Forms.Button();
            Button button3_2 = new System.Windows.Forms.Button();
            Button button2_2 = new System.Windows.Forms.Button();
            button1_2 = new System.Windows.Forms.Button();
            //TextBox textBox_totalCount2 = new System.Windows.Forms.TextBox();
            textBox_totalCount2 = new System.Windows.Forms.TextBox();
            Label label_totalCount2 = new System.Windows.Forms.Label();
            radioButton11_2 = new System.Windows.Forms.RadioButton();
            radioButton12_2 = new System.Windows.Forms.RadioButton();
            radioButton13_2 = new System.Windows.Forms.RadioButton();
            radioButton14_2 = new System.Windows.Forms.RadioButton();
            radioButton15_2 = new System.Windows.Forms.RadioButton();
            radioButton6_2 = new System.Windows.Forms.RadioButton();
            radioButton7_2 = new System.Windows.Forms.RadioButton();
            radioButton8_2 = new System.Windows.Forms.RadioButton();
            radioButton9_2 = new System.Windows.Forms.RadioButton();
            radioButton10_2 = new System.Windows.Forms.RadioButton();
            radioButton5_2 = new System.Windows.Forms.RadioButton();
            radioButton4_2 = new System.Windows.Forms.RadioButton();
            radioButton3_2 = new System.Windows.Forms.RadioButton();
            radioButton2_2 = new System.Windows.Forms.RadioButton();
            radioButton1_2 = new System.Windows.Forms.RadioButton();
            //TextBox textBox_extIntFilesCompValue2 = new System.Windows.Forms.TextBox();
            //TextBox textBox_intLogFilesCompValue2 = new System.Windows.Forms.TextBox();
            //TextBox textBox_extInqCompValue2 = new System.Windows.Forms.TextBox();
            //TextBox textBox_extOutputCompValue2 = new System.Windows.Forms.TextBox();
            //TextBox textBox_extInputCompValue2 = new System.Windows.Forms.TextBox();
            textBox_extIntFilesCompValue2 = new System.Windows.Forms.TextBox();
            textBox_intLogFilesCompValue2 = new System.Windows.Forms.TextBox();
            textBox_extInqCompValue2 = new System.Windows.Forms.TextBox();
            textBox_extOutputCompValue2 = new System.Windows.Forms.TextBox();
            textBox_extInputCompValue2 = new System.Windows.Forms.TextBox();
            textBox_extIntFiles2 = new System.Windows.Forms.TextBox();
            textBox_intLogFiles2 = new System.Windows.Forms.TextBox();
            textBox_extInq2 = new System.Windows.Forms.TextBox();
            textBox_extOutput2 = new System.Windows.Forms.TextBox();
            textBox_extInput2 = new System.Windows.Forms.TextBox();
            Label label_extIntFiles2 = new System.Windows.Forms.Label();
            Label label_intLofFiles2 = new System.Windows.Forms.Label();
            Label label_extInq2 = new System.Windows.Forms.Label();
            Label label_extOutput2 = new System.Windows.Forms.Label();
            Label label_extInput2 = new System.Windows.Forms.Label();
            Label label_complex2 = new System.Windows.Forms.Label();
            Label label_average2 = new System.Windows.Forms.Label();
            Label label_simple2 = new System.Windows.Forms.Label();
            Label label_weightFactors2 = new System.Windows.Forms.Label();

            Panel panel_extInput2 = new System.Windows.Forms.Panel();
            Panel panel_extOutput2 = new System.Windows.Forms.Panel();
            Panel panel_extInq2 = new System.Windows.Forms.Panel();
            Panel panel_intLogFiles2 = new System.Windows.Forms.Panel();
            Panel panel_extIntFiles2 = new System.Windows.Forms.Panel();
            // 
            // label1
            // 
            label1_2.AutoSize = true;
            label1_2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1_2.Location = new System.Drawing.Point(195, 15);
            label1_2.Name = "label1";
            label1_2.Size = new System.Drawing.Size(240, 37);
            label1_2.TabIndex = 0;
            label1_2.Text = "Weighting Factors";
            /*// 
            // tabControl_fp
            // 
            tabControl_fp.Controls.Add(this.tabPage1);
            tabControl_fp.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tabControl_fp.Location = new System.Drawing.Point(12, 31);
            tabControl_fp.Name = "tabControl_fp";
            tabControl_fp.SelectedIndex = 0;
            tabControl_fp.Size = new System.Drawing.Size(771, 642);
            tabControl_fp.TabIndex = 1; */
            // 
            // tabPage1
            // 
            tabPage2.Controls.Add(panel_extIntFiles2);
            tabPage2.Controls.Add(panel_intLogFiles2);
            tabPage2.Controls.Add(panel_extInq2);
            tabPage2.Controls.Add(panel_extOutput2);
            tabPage2.Controls.Add(panel_extInput2);
            tabPage2.Controls.Add(label_currLang2);
            tabPage2.Controls.Add(textBox_changeLang2);
            tabPage2.Controls.Add(textBox_codeSize2);
            tabPage2.Controls.Add(textBox_valAdj2);
            tabPage2.Controls.Add(textBox_computeFP2);
            tabPage2.Controls.Add(button4_2);
            tabPage2.Controls.Add(button3_2);
            tabPage2.Controls.Add(button2_2);
            tabPage2.Controls.Add(button1_2);
            tabPage2.Controls.Add(textBox_totalCount2);
            tabPage2.Controls.Add(label_totalCount2);
            /*tabPage2.Controls.Add(radioButton11_2);
            tabPage2.Controls.Add(radioButton12_2);
            tabPage2.Controls.Add(radioButton13_2);
            tabPage2.Controls.Add(radioButton14_2);
            tabPage2.Controls.Add(radioButton15_2);
            tabPage2.Controls.Add(radioButton6_2);
            tabPage2.Controls.Add(radioButton7_2);
            tabPage2.Controls.Add(radioButton8_2);
            tabPage2.Controls.Add(radioButton9_2);
            tabPage2.Controls.Add(radioButton10_2);
            tabPage2.Controls.Add(radioButton5_2);
            tabPage2.Controls.Add(radioButton4_2);
            tabPage2.Controls.Add(radioButton3_2);
            tabPage2.Controls.Add(radioButton2_2);
            tabPage2.Controls.Add(radioButton1_2);*/
            tabPage2.Controls.Add(textBox_extIntFilesCompValue2);
            tabPage2.Controls.Add(textBox_intLogFilesCompValue2);
            tabPage2.Controls.Add(textBox_extInqCompValue2);
            tabPage2.Controls.Add(textBox_extOutputCompValue2);
            tabPage2.Controls.Add(textBox_extInputCompValue2);
            tabPage2.Controls.Add(textBox_extIntFiles2);
            tabPage2.Controls.Add(textBox_intLogFiles2);
            tabPage2.Controls.Add(textBox_extInq2);
            tabPage2.Controls.Add(textBox_extOutput2);
            tabPage2.Controls.Add(textBox_extInput2);
            tabPage2.Controls.Add(label_extIntFiles2);
            tabPage2.Controls.Add(label_intLofFiles2);
            tabPage2.Controls.Add(label_extInq2);
            tabPage2.Controls.Add(label_extOutput2);
            tabPage2.Controls.Add(label_extInput2);
            tabPage2.Controls.Add(label_complex2);
            tabPage2.Controls.Add(label_average2);
            tabPage2.Controls.Add(label_simple2);
            tabPage2.Controls.Add(label_weightFactors2);


            tabPage2.Location = new System.Drawing.Point(4, 30);
            tabPage2.Name = "Functional Points";
            //tabPage2.Name = GetFPName.fpName;
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.Size = new System.Drawing.Size(763, 608);
            tabPage2.TabIndex = 0;
            //tabPage2.Text = "Function Points";
            tabPage2.Text = GetFPName.fpName;
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += new System.EventHandler(tabPage1_Click);
            // 
            // label12
            // 
            label_currLang2.AutoSize = true;
            label_currLang2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_currLang2.Location = new System.Drawing.Point(245, 430);
            label_currLang2.Name = "label12";
            label_currLang2.Size = new System.Drawing.Size(134, 21);
            label_currLang2.TabIndex = 44;
            label_currLang2.Text = "Current Language";
            // 
            // textBox_currLang
            // 
            textBox_changeLang2.Location = new System.Drawing.Point(385, 427);
            textBox_changeLang2.Name = "textBox_currLang";
            textBox_changeLang2.ReadOnly = true;
            textBox_changeLang2.Size = new System.Drawing.Size(156, 28);
            textBox_changeLang2.TabIndex = 43;
            //if(LanguageSelection.strLangForHome == "" && LanguageSelection.strSelLang =="")
            //    textBox_changeLang2.Text = "None";
            //else if(LanguageSelection.strSelLang=="" && LanguageSelection.strLangForHome !="")
            //    textBox_changeLang2.Text = LanguageSelection.strLangForHome;
            //else
            //    textBox_changeLang2.Text = "None";

            if (LanguageSelection.strSelLang == "")
                textBox_changeLang2.Text = "None";
            else
                textBox_changeLang2.Text = LanguageSelection.strSelLang;

            // 
            // textBox_codeSize
            // 
            textBox_codeSize2.Location = new System.Drawing.Point(579, 427);
            textBox_codeSize2.Name = "textBox_codeSize";
            textBox_codeSize2.ReadOnly = true;
            textBox_codeSize2.Size = new System.Drawing.Size(156, 28);
            textBox_codeSize2.TabIndex = 42;
            // 
            // textBox_valAdj
            // 
            textBox_valAdj2.Location = new System.Drawing.Point(579, 390);
            textBox_valAdj2.Name = "textBox_valAdj";
            textBox_valAdj2.ReadOnly = true;
            textBox_valAdj2.Size = new System.Drawing.Size(156, 28);
            textBox_valAdj2.TabIndex = 41;
            // 
            // textBox_computeFP
            // 
            textBox_computeFP2.Location = new System.Drawing.Point(579, 353);
            textBox_computeFP2.Name = "textBox_computeFP";
            textBox_computeFP2.ReadOnly = true;
            textBox_computeFP2.Size = new System.Drawing.Size(156, 28);
            textBox_computeFP2.TabIndex = 40;
            // 
            // button4
            // 
            button4_2.Location = new System.Drawing.Point(33, 461);
            button4_2.Name = "button4";
            button4_2.Size = new System.Drawing.Size(155, 31);
            button4_2.TabIndex = 39;
            button4_2.Text = "Change Language";
            button4_2.UseVisualStyleBackColor = true;
            button4_2.Click += new System.EventHandler(this.changeLang_ButtonClick);
            // 
            // button3
            // 
            button3_2.Location = new System.Drawing.Point(33, 424);
            button3_2.Name = "button3";
            button3_2.Size = new System.Drawing.Size(155, 31);
            button3_2.TabIndex = 38;
            button3_2.Text = "Compute Code Size";
            button3_2.UseVisualStyleBackColor = true;
            button3_2.Click += new System.EventHandler(this.computeLOC_ButtonClick);
            // 
            // button_valueAdjustments
            // 
            button2_2.Location = new System.Drawing.Point(33, 387);
            button2_2.Name = "button_valueAdjustments";
            button2_2.Size = new System.Drawing.Size(155, 31);
            button2_2.TabIndex = 37;
            button2_2.Text = "Value Adjustments";
            button2_2.UseVisualStyleBackColor = true;
            button2_2.Click += new System.EventHandler(this.vaf_ButtonCLick);
            // 
            // button_computeFP
            // 
            button1_2.Location = new System.Drawing.Point(33, 350);
            button1_2.Name = "button_computeFP";
            button1_2.Size = new System.Drawing.Size(155, 31);
            button1_2.TabIndex = 36;
            button1_2.Text = "Compute FP";
            button1_2.UseVisualStyleBackColor = true;
            button1_2.Click += new System.EventHandler(this.button_ComputeFPClick);

            // 
            // textBox_totalCount
            // 
            textBox_totalCount2.Location = new System.Drawing.Point(635, 294);
            textBox_totalCount2.Name = "textBox_totalCount";
            textBox_totalCount2.ReadOnly = true;
            textBox_totalCount2.Size = new System.Drawing.Size(100, 28);
            textBox_totalCount2.TabIndex = 35;
            textBox_totalCount2.Click += new System.EventHandler(this.textBox_totalCountOnClick);
            // 
            // label11
            // 
            label_totalCount2.AutoSize = true;
            label_totalCount2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_totalCount2.Location = new System.Drawing.Point(29, 297);
            label_totalCount2.Name = "label11";
            label_totalCount2.Size = new System.Drawing.Size(90, 21);
            label_totalCount2.TabIndex = 34;
            label_totalCount2.Text = "Total Count";
            // 
            // radioButton11
            // 
            radioButton11_2.AutoSize = true;
            radioButton11_2.Location = new System.Drawing.Point(182, -1);
            radioButton11_2.Name = "radioButton11";
            radioButton11_2.Size = new System.Drawing.Size(49, 25);
            radioButton11_2.TabIndex = 33;
            radioButton11_2.TabStop = true;
            radioButton11_2.Text = "10";
            radioButton11_2.UseVisualStyleBackColor = true;
            radioButton11_2.Click += new System.EventHandler(this.radioButton11_OnClick);
            // 
            // radioButton12
            // 
            radioButton12_2.AutoSize = true;
            radioButton12_2.Location = new System.Drawing.Point(182, 5);
            radioButton12_2.Name = "radioButton12";
            radioButton12_2.Size = new System.Drawing.Size(49, 25);
            radioButton12_2.TabIndex = 32;
            radioButton12_2.TabStop = true;
            radioButton12_2.Text = "15";
            radioButton12_2.UseVisualStyleBackColor = true;
            radioButton12_2.Click += new System.EventHandler(this.radioButton12_OnClick);
            // 
            // radioButton13
            // 
            radioButton13_2.AutoSize = true;
            radioButton13_2.Location = new System.Drawing.Point(182, 7);
            radioButton13_2.Name = "radioButton13";
            radioButton13_2.Size = new System.Drawing.Size(40, 25);
            radioButton13_2.TabIndex = 31;
            radioButton13_2.TabStop = true;
            radioButton13_2.Text = "6";
            radioButton13_2.UseVisualStyleBackColor = true;
            radioButton13_2.Click += new System.EventHandler(this.radioButton13_OnClick);
            // 
            // radioButton14
            // 
            radioButton14_2.AutoSize = true;
            radioButton14_2.Location = new System.Drawing.Point(182, 5);
            radioButton14_2.Name = "radioButton14";
            radioButton14_2.Size = new System.Drawing.Size(40, 25);
            radioButton14_2.TabIndex = 30;
            radioButton14_2.TabStop = true;
            radioButton14_2.Text = "7";
            radioButton14_2.UseVisualStyleBackColor = true;
            radioButton14_2.Click += new System.EventHandler(this.radioButton14_OnClick);
            // 
            // radioButton15
            // 
            radioButton15_2.AutoSize = true;
            radioButton15_2.Location = new System.Drawing.Point(182, 8);
            radioButton15_2.Name = "radioButton15";
            radioButton15_2.Size = new System.Drawing.Size(40, 25);
            radioButton15_2.TabIndex = 29;
            radioButton15_2.TabStop = true;
            radioButton15_2.Text = "6";
            radioButton15_2.UseVisualStyleBackColor = true;
            radioButton15_2.Click += new System.EventHandler(this.radioButton15_OnClick);
            // 
            // radioButton6
            // 
            radioButton6_2.AutoSize = true;
            radioButton6_2.Location = new System.Drawing.Point(99, -1);
            radioButton6_2.Name = "radioButton6";
            radioButton6_2.Size = new System.Drawing.Size(40, 25);
            radioButton6_2.TabIndex = 28;
            radioButton6_2.TabStop = true;
            radioButton6_2.Text = "7";
            radioButton6_2.UseVisualStyleBackColor = true;
            radioButton6_2.Checked = true;
            radioButton6_2.Click += new System.EventHandler(this.radioButton6_OnClick);
            // 
            // radioButton7
            // 
            radioButton7_2.AutoSize = true;
            radioButton7_2.Location = new System.Drawing.Point(99, 7);
            radioButton7_2.Name = "radioButton7";
            radioButton7_2.Size = new System.Drawing.Size(49, 25);
            radioButton7_2.TabIndex = 27;
            radioButton7_2.TabStop = true;
            radioButton7_2.Text = "10";
            radioButton7_2.UseVisualStyleBackColor = true;
            radioButton7_2.Checked = true;
            radioButton7_2.Click += new System.EventHandler(this.radioButton7_OnClick);
            // 
            // radioButton8
            // 
            radioButton8_2.AutoSize = true;
            radioButton8_2.Location = new System.Drawing.Point(99, 7);
            radioButton8_2.Name = "radioButton8";
            radioButton8_2.Size = new System.Drawing.Size(40, 25);
            radioButton8_2.TabIndex = 26;
            radioButton8_2.TabStop = true;
            radioButton8_2.Text = "4";
            radioButton8_2.UseVisualStyleBackColor = true;
            radioButton8_2.Checked = true;
            radioButton8_2.Click += new System.EventHandler(this.radioButton8_OnClick);
            // 
            // radioButton9
            // 
            radioButton9_2.AutoSize = true;
            radioButton9_2.Location = new System.Drawing.Point(99, 8);
            radioButton9_2.Name = "radioButton9";
            radioButton9_2.Size = new System.Drawing.Size(40, 25);
            radioButton9_2.TabIndex = 25;
            radioButton9_2.TabStop = true;
            radioButton9_2.Text = "5";
            radioButton9_2.UseVisualStyleBackColor = true;
            radioButton9_2.Checked = true;
            radioButton9_2.Click += new System.EventHandler(this.radioButton9_OnClick);
            // 
            // radioButton10
            // 
            radioButton10_2.AutoSize = true;
            radioButton10_2.Location = new System.Drawing.Point(99, 8);
            radioButton10_2.Name = "radioButton10";
            radioButton10_2.Size = new System.Drawing.Size(40, 25);
            radioButton10_2.TabIndex = 24;
            radioButton10_2.TabStop = true;
            radioButton10_2.Text = "4";
            radioButton10_2.UseVisualStyleBackColor = true;
            radioButton10_2.Checked = true;
            radioButton10_2.Click += new System.EventHandler(this.radioButton10_OnClick);
            // 
            // radioButton5
            // 
            radioButton5_2.AutoSize = true;
            radioButton5_2.Location = new System.Drawing.Point(21, -1);
            radioButton5_2.Name = "radioButton5";
            radioButton5_2.Size = new System.Drawing.Size(40, 25);
            radioButton5_2.TabIndex = 23;
            radioButton5_2.TabStop = true;
            radioButton5_2.Text = "5";
            radioButton5_2.UseVisualStyleBackColor = true;
            radioButton5_2.Click += new System.EventHandler(this.radioButton5_OnClick);
            // 
            // radioButton4
            // 
            radioButton4_2.AutoSize = true;
            radioButton4_2.Location = new System.Drawing.Point(21, 7);
            radioButton4_2.Name = "radioButton4";
            radioButton4_2.Size = new System.Drawing.Size(40, 25);
            radioButton4_2.TabIndex = 22;
            radioButton4_2.TabStop = true;
            radioButton4_2.Text = "7";
            radioButton4_2.UseVisualStyleBackColor = true;
            radioButton4_2.Click += new System.EventHandler(this.radioButton4_OnClick);
            // 
            // radioButton3
            // 
            radioButton3_2.AutoSize = true;
            radioButton3_2.Location = new System.Drawing.Point(21, 7);
            radioButton3_2.Name = "radioButton3";
            radioButton3_2.Size = new System.Drawing.Size(40, 25);
            radioButton3_2.TabIndex = 21;
            radioButton3_2.TabStop = true;
            radioButton3_2.Text = "3";
            radioButton3_2.UseVisualStyleBackColor = true;
            radioButton3_2.Click += new System.EventHandler(this.radioButton3_OnClick);
            // 
            // radioButton2
            // 
            radioButton2_2.AutoSize = true;
            radioButton2_2.Location = new System.Drawing.Point(21, 8);
            radioButton2_2.Name = "radioButton2";
            radioButton2_2.Size = new System.Drawing.Size(40, 25);
            radioButton2_2.TabIndex = 20;
            radioButton2_2.TabStop = true;
            radioButton2_2.Text = "4";
            radioButton2_2.UseVisualStyleBackColor = true;
            radioButton2_2.Click += new System.EventHandler(this.radioButton2_OnClick);
            // 
            // radioButton1
            // 
            radioButton1_2.AutoSize = true;
            radioButton1_2.Location = new System.Drawing.Point(21, 8);
            radioButton1_2.Name = "radioButton1";
            radioButton1_2.Size = new System.Drawing.Size(40, 25);
            radioButton1_2.TabIndex = 19;
            radioButton1_2.TabStop = true;
            radioButton1_2.Text = "3";
            radioButton1_2.UseVisualStyleBackColor = true;
            radioButton1_2.Click += new System.EventHandler(this.radioButton1_OnClick);
            // 
            // panel1
            // 
            panel_extInput2.Controls.Add(radioButton15_2);
            panel_extInput2.Controls.Add(radioButton10_2);
            panel_extInput2.Controls.Add(radioButton1_2);
            panel_extInput2.Location = new System.Drawing.Point(341, 117);
            panel_extInput2.Name = "panel1";
            panel_extInput2.Size = new System.Drawing.Size(231, 35);
            panel_extInput2.TabIndex = 46;
            //panel_extInput2.Click += new System.EventHandler(this.Panel_extInput2);
            // 
            // panel2
            // 
            panel_extOutput2.Controls.Add(radioButton2_2);
            panel_extOutput2.Controls.Add(radioButton9_2);
            panel_extOutput2.Controls.Add(radioButton14_2);
            panel_extOutput2.Location = new System.Drawing.Point(341, 152);
            panel_extOutput2.Name = "panel2";
            panel_extOutput2.Size = new System.Drawing.Size(231, 35);
            panel_extOutput2.TabIndex = 47;
            // 
            // panel3
            // 
            panel_extInq2.Controls.Add(radioButton3_2);
            panel_extInq2.Controls.Add(radioButton8_2);
            panel_extInq2.Controls.Add(radioButton13_2);
            panel_extInq2.Location = new System.Drawing.Point(341, 186);
            panel_extInq2.Name = "panel3";
            panel_extInq2.Size = new System.Drawing.Size(231, 35);
            panel_extInq2.TabIndex = 48;
            // 
            // panel4
            // 
            panel_intLogFiles2.Controls.Add(radioButton4_2);
            panel_intLogFiles2.Controls.Add(radioButton7_2);
            panel_intLogFiles2.Controls.Add(radioButton12_2);
            panel_intLogFiles2.Location = new System.Drawing.Point(341, 220);
            panel_intLogFiles2.Name = "panel4";
            panel_intLogFiles2.Size = new System.Drawing.Size(231, 35);
            panel_intLogFiles2.TabIndex = 49;
            // 
            // panel5
            // 
            panel_extIntFiles2.Controls.Add(radioButton5_2);
            panel_extIntFiles2.Controls.Add(radioButton6_2);
            panel_extIntFiles2.Controls.Add(radioButton11_2);
            panel_extIntFiles2.Location = new System.Drawing.Point(341, 258);
            panel_extIntFiles2.Name = "panel5";
            panel_extIntFiles2.Size = new System.Drawing.Size(231, 35);
            panel_extIntFiles2.TabIndex = 50;
            // 
            // textBox_extIntFilesCompValue
            // 
            textBox_extIntFilesCompValue2.Location = new System.Drawing.Point(635, 258);
            textBox_extIntFilesCompValue2.Name = "textBox_extIntFilesCompValue";
            textBox_extIntFilesCompValue2.ReadOnly = true;
            textBox_extIntFilesCompValue2.Size = new System.Drawing.Size(100, 28);
            textBox_extIntFilesCompValue2.TabIndex = 18;
            textBox_extIntFilesCompValue2.Click += new System.EventHandler(this.TextBox_extIntFilesCompValue);


            // 
            // textBox_intLogFilesCompValue
            // 
            textBox_intLogFilesCompValue2.Location = new System.Drawing.Point(635, 224);
            textBox_intLogFilesCompValue2.Name = "textBox_intLogFilesCompValue";
            textBox_intLogFilesCompValue2.ReadOnly = true;
            textBox_intLogFilesCompValue2.Size = new System.Drawing.Size(100, 28);
            textBox_intLogFilesCompValue2.TabIndex = 17;
            textBox_intLogFilesCompValue2.Click += new System.EventHandler(this.TextBox_intLogFilesCompValue);
            // 
            // textBox_extInqCompValue
            // 
            textBox_extInqCompValue2.Location = new System.Drawing.Point(635, 190);
            textBox_extInqCompValue2.Name = "textBox_extInqCompValue";
            textBox_extInqCompValue2.ReadOnly = true;
            textBox_extInqCompValue2.Size = new System.Drawing.Size(100, 28);
            textBox_extInqCompValue2.TabIndex = 16;
            textBox_extInqCompValue2.Click += new System.EventHandler(this.TextBox_extInqCompValue);
            // 
            // textBox_extOutputCompValue
            // 
            textBox_extOutputCompValue2.Location = new System.Drawing.Point(635, 156);
            textBox_extOutputCompValue2.Name = "textBox_extOutputCompValue";
            textBox_extOutputCompValue2.ReadOnly = true;
            textBox_extOutputCompValue2.Size = new System.Drawing.Size(100, 28);
            textBox_extOutputCompValue2.TabIndex = 15;
            textBox_extOutputCompValue2.Click += new System.EventHandler(this.TextBox_extOutputCompValue);
            // 
            // textBox_extInputCompValue
            // 
            textBox_extInputCompValue2.Location = new System.Drawing.Point(635, 121);
            textBox_extInputCompValue2.Name = "textBox_extInputCompValue";
            textBox_extInputCompValue2.ReadOnly = true;
            textBox_extInputCompValue2.Size = new System.Drawing.Size(100, 28);
            textBox_extInputCompValue2.TabIndex = 14;
            textBox_extInputCompValue2.Click += new System.EventHandler(this.TextBox_extInputCompValue);
            // 
            // textBox_extIntFiles
            // 
            textBox_extIntFiles2.Location = new System.Drawing.Point(219, 254);
            textBox_extIntFiles2.Name = "textBox_extIntFiles";
            textBox_extIntFiles2.Size = new System.Drawing.Size(100, 28);
            textBox_extIntFiles2.TabIndex = 13;
            textBox_extIntFiles2.TextChanged += new System.EventHandler(this.TextBox_extIntFiles);
            // 
            // textBox_intLogFiles
            // 
            textBox_intLogFiles2.Location = new System.Drawing.Point(219, 220);
            textBox_intLogFiles2.Name = "textBox_intLogFiles";
            textBox_intLogFiles2.Size = new System.Drawing.Size(100, 28);
            textBox_intLogFiles2.TabIndex = 12;
            textBox_intLogFiles2.TextChanged += new System.EventHandler(this.TextBox_intLogFiles);
            // 
            // textBox_extInq
            // 
            textBox_extInq2.Location = new System.Drawing.Point(219, 186);
            textBox_extInq2.Name = "textBox_extInq";
            textBox_extInq2.Size = new System.Drawing.Size(100, 28);
            textBox_extInq2.TabIndex = 11;
            textBox_extInq2.TextChanged += new System.EventHandler(this.TextBox_extInqFiles);
            // 
            // textBox_extOutput
            // 
            textBox_extOutput2.Location = new System.Drawing.Point(219, 152);
            textBox_extOutput2.Name = "textBox_extOutput";
            textBox_extOutput2.Size = new System.Drawing.Size(100, 28);
            textBox_extOutput2.TabIndex = 10;
            textBox_extOutput2.TextChanged += new System.EventHandler(this.TextBox_extOutput);
            // 
            // textBox_extInput
            // 
            textBox_extInput2.Location = new System.Drawing.Point(219, 117);
            textBox_extInput2.Name = "textBox_extInput";
            textBox_extInput2.Size = new System.Drawing.Size(100, 28);
            textBox_extInput2.TabIndex = 9;
            textBox_extInput2.TextChanged += new System.EventHandler(this.TextBox_extInput);
            // 
            // label10
            // 
            label_extIntFiles2.AutoSize = true;
            label_extIntFiles2.Location = new System.Drawing.Point(29, 261);
            label_extIntFiles2.Name = "label10";
            label_extIntFiles2.Size = new System.Drawing.Size(173, 21);
            label_extIntFiles2.TabIndex = 8;
            label_extIntFiles2.Text = "External Interface Files";
            // 
            // label9
            // 
            label_intLofFiles2.AutoSize = true;
            label_intLofFiles2.Location = new System.Drawing.Point(29, 227);
            label_intLofFiles2.Name = "label9";
            label_intLofFiles2.Size = new System.Drawing.Size(150, 21);
            label_intLofFiles2.TabIndex = 7;
            label_intLofFiles2.Text = "Internal Logical Files";
            // 
            // label8
            // 
            label_extInq2.AutoSize = true;
            label_extInq2.Location = new System.Drawing.Point(29, 193);
            label_extInq2.Name = "label8";
            label_extInq2.Size = new System.Drawing.Size(130, 21);
            label_extInq2.TabIndex = 6;
            label_extInq2.Text = "External Inquiries";
            // 
            // label7
            // 
            label_extOutput2.AutoSize = true;
            label_extOutput2.Location = new System.Drawing.Point(29, 159);
            label_extOutput2.Name = "label7";
            label_extOutput2.Size = new System.Drawing.Size(127, 21);
            label_extOutput2.TabIndex = 5;
            label_extOutput2.Text = "External Outputs";
            // 
            // label6
            // 
            label_extInput2.AutoSize = true;
            label_extInput2.Location = new System.Drawing.Point(29, 124);
            label_extInput2.Name = "label6";
            label_extInput2.Size = new System.Drawing.Size(114, 21);
            label_extInput2.TabIndex = 4;
            label_extInput2.Text = "External Inputs";
            // 
            // label_comments
            // 
            label_complex2.AutoSize = true;
            label_complex2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_complex2.Location = new System.Drawing.Point(519, 80);
            label_complex2.Name = "label_comments";
            label_complex2.Size = new System.Drawing.Size(83, 24);
            label_complex2.TabIndex = 3;
            label_complex2.Text = "Complex";
            // 
            // label_creator
            // 
            label_average2.AutoSize = true;
            label_average2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_average2.Location = new System.Drawing.Point(436, 80);
            label_average2.Name = "label_creator";
            label_average2.Size = new System.Drawing.Size(77, 24);
            label_average2.TabIndex = 2;
            label_average2.Text = "Average";
            // 
            // label3
            // 
            label_simple2.AutoSize = true;
            label_simple2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_simple2.Location = new System.Drawing.Point(358, 80);
            label_simple2.Name = "label3";
            label_simple2.Size = new System.Drawing.Size(66, 24);
            label_simple2.TabIndex = 1;
            label_simple2.Text = "Simple";
            // 
            // label2
            // 
            label_weightFactors2.AutoSize = true;
            label_weightFactors2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_weightFactors2.Location = new System.Drawing.Point(264, 19);
            label_weightFactors2.Name = "label2";
            label_weightFactors2.Size = new System.Drawing.Size(240, 37);
            label_weightFactors2.TabIndex = 0;
            label_weightFactors2.Text = "Weighting Factors";



            tabControl_fp.TabPages.Add(tabPage2);
        }

        private void computeLOC_ButtonClick(object sender, EventArgs e)
        {
            int mulFactor = 0;
            int linesOfCode = 0;
            string selLang = LanguageSelection.strSelLang;
            switch (selLang)
            {
                case "Assembler":
                    mulFactor = 209;
                    break;
                case "Ada95":
                    mulFactor = 154;
                    break;
                case "C":
                    mulFactor = 148;
                    break;
                case "CPP":
                    mulFactor = 59;
                    break;
                case "CS":
                    mulFactor = 58;
                    break;
                case "COBOL":
                    mulFactor = 80;
                    break;
                case "FORTRAN":
                    mulFactor = 90;
                    break;
                case "HTML":
                    mulFactor = 43;
                    break;
                case "Java":
                    mulFactor = 55;
                    break;
                case "JavaScript":
                    mulFactor = 54;
                    break;
                case "VBScript":
                    mulFactor = 38;
                    break;
                case "VB":
                    mulFactor = 50;
                    break;
            }
            linesOfCode = Convert.ToInt32(fpValue) * mulFactor;
            CultureInfo ci = new CultureInfo("en-us");
            textBox_codeSize2.Text = linesOfCode.ToString("N0", ci);
        }
        private void button_ComputeFPClick(object sender, EventArgs e)
        {
            if ((textBox_extInput2.Text == "" || textBox_extInq2.Text == "" || textBox_extIntFiles2.Text == ""
                || textBox_intLogFiles2.Text == "" || textBox_extOutput2.Text == "") && ValueAdjustmentFactor.totalVaf == 0)
            {
                MessageBox.Show("Please Input All The Functional Data Points");
                return;
            }
            else if ((textBox_extInput2.Text == "" || textBox_extInq2.Text == "" || textBox_extIntFiles2.Text == ""
                || textBox_intLogFiles2.Text == "" || textBox_extOutput2.Text == "") && ValueAdjustmentFactor.totalVaf != 0)
            {
                MessageBox.Show("Please Input All The Funtional Data Points Before Adjusting VAF");
                textBox_valAdj2.Text = 0.ToString();
                return;
            }
            if (radioButton10_2.Checked == true)
                radioButton10_2.Select();
            if (radioButton9_2.Checked == true)
                radioButton9_2.Select();
            if (radioButton8_2.Checked == true)
                radioButton8_2.Select();
            if (radioButton7_2.Checked == true)
                radioButton7_2.Select();
            if (radioButton6_2.Checked == true)
                radioButton6_2.Select();
            if (radioButton5_2.Checked == true)
                radioButton5_2.Select();
            if (radioButton3_2.Checked == true)
                radioButton3_2.Select();
            if (radioButton2_2.Checked == true)
                radioButton2_2.Select();
            if (radioButton4_2.Checked == true)
                radioButton4_2.Select();
            if (radioButton1_2.Checked == true)
                radioButton1_2.Select();
            if (radioButton11_2.Checked == true)
                radioButton11_2.Select();
            if (radioButton12_2.Checked == true)
                radioButton12_2.Select();
            if (radioButton13_2.Checked == true)
                radioButton13_2.Select();
            if (radioButton14_2.Checked == true)
                radioButton14_2.Select();
            if (radioButton15_2.Checked == true)
                radioButton15_2.Select();

            //textBox_totalCount2.Text = totalCount.ToString();
            int totCount =
                Int32.Parse((textBox_extInputCompValue2.Text)) +
                Int32.Parse((textBox_extOutputCompValue2.Text)) +
                Int32.Parse((textBox_extInqCompValue2.Text)) +
                Int32.Parse((textBox_intLogFilesCompValue2.Text)) +
                Int32.Parse((textBox_extIntFilesCompValue2.Text));

            textBox_totalCount2.Text = totCount.ToString();
            fpValue = totCount * (0.65 + (0.01 * ValueAdjustmentFactor.totalVaf));
            //textBox_computeFP2.Text=String.Format("{0,12:0,000.00}", fpValue);
            CultureInfo ci = new CultureInfo("en-us");
            textBox_computeFP2.Text = fpValue.ToString("N02", ci);

        }
        private void textBox_totalCountOnClick(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            //objTextBox.Text = totalCount.ToString();
        }
        private void radioButton15_OnClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                radio_extInput = rb.Text;
                textBox_extInputCompValue2.Text = ((Int32.Parse(textBox_extInput)) * (Int32.Parse(radio_extInput))).ToString();
                radioButton15_2.Checked = true;

            }
        }
        private void radioButton10_OnClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                radio_extInput = rb.Text;
                textBox_extInputCompValue2.Text = ((Int32.Parse(textBox_extInput)) * (Int32.Parse(radio_extInput))).ToString();
                radioButton10_2.Checked = true;
            }
        }
        private void radioButton1_OnClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            {
                radio_extInput = rb.Text;
                textBox_extInputCompValue2.Text = ((Int32.Parse(textBox_extInput)) * (Int32.Parse(radio_extInput))).ToString();
                radioButton1_2.Checked = true;
            }
        }
        private void radioButton9_OnClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                radio_extOutput = rb.Text;
                textBox_extOutputCompValue2.Text = ((Int32.Parse(textBox_extOutput)) * (Int32.Parse(radio_extOutput))).ToString();
                radioButton9_2.Checked = true;
            }
        }
        private void radioButton2_OnClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                radio_extOutput = rb.Text;
                textBox_extOutputCompValue2.Text = ((Int32.Parse(textBox_extOutput)) * (Int32.Parse(radio_extOutput))).ToString();
                radioButton2_2.Checked = true;
            }
        }
        private void radioButton14_OnClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                radio_extOutput = rb.Text;
                textBox_extOutputCompValue2.Text = ((Int32.Parse(textBox_extOutput)) * (Int32.Parse(radio_extOutput))).ToString();
                radioButton14_2.Checked = true;
            }
        }
        private void radioButton3_OnClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                radio_extInq = rb.Text;
                textBox_extInqCompValue2.Text = ((Int32.Parse(textBox_extInq)) * (Int32.Parse(radio_extInq))).ToString();
                radioButton3_2.Checked = true;
            }
        }
        private void radioButton8_OnClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                radio_extInq = rb.Text;
                textBox_extInqCompValue2.Text = ((Int32.Parse(textBox_extInq)) * (Int32.Parse(radio_extInq))).ToString();
                radioButton8_2.Checked = true;
            }
        }
        private void radioButton13_OnClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                radio_extInq = rb.Text;
                textBox_extInqCompValue2.Text = ((Int32.Parse(textBox_extInq)) * (Int32.Parse(radio_extInq))).ToString();
                radioButton13_2.Checked = true;
            }
        }
        private void radioButton4_OnClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                radio_intLogFiles = rb.Text;
                textBox_intLogFilesCompValue2.Text = ((Int32.Parse(textBox_intLogFiles)) * (Int32.Parse(radio_intLogFiles))).ToString();
                radioButton4_2.Checked = true;
            }
        }
        private void radioButton7_OnClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                radio_intLogFiles = rb.Text;
                textBox_intLogFilesCompValue2.Text = ((Int32.Parse(textBox_intLogFiles)) * (Int32.Parse(radio_intLogFiles))).ToString();
                radioButton7_2.Checked = true;
            }
        }
        private void radioButton12_OnClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                radio_intLogFiles = rb.Text;
                textBox_intLogFilesCompValue2.Text = ((Int32.Parse(textBox_intLogFiles)) * (Int32.Parse(radio_intLogFiles))).ToString();
                radioButton12_2.Checked = true;
            }
        }
        private void radioButton5_OnClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                radio_extIntFiles = rb.Text;
                textBox_extIntFilesCompValue2.Text = ((Int32.Parse(textBox_extIntFiles)) * (Int32.Parse(radio_extIntFiles))).ToString();
                radioButton5_2.Checked = true;
            }
        }
        private void radioButton6_OnClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                radio_extIntFiles = rb.Text;
                textBox_extIntFilesCompValue2.Text = ((Int32.Parse(textBox_extIntFiles)) * (Int32.Parse(radio_extIntFiles))).ToString();
                radioButton6_2.Checked = true;
            }
        }
        private void radioButton11_OnClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                radio_extIntFiles = rb.Text;
                textBox_extIntFilesCompValue2.Text = ((Int32.Parse(textBox_extIntFiles)) * (Int32.Parse(radio_extIntFiles))).ToString();
                radioButton11_2.Checked = true;
            }
        }
        private void TextBox_intLogFilesCompValue(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            objTextBox.Text = ((Int32.Parse(textBox_intLogFiles)) * (Int32.Parse(radio_intLogFiles))).ToString();
            //totalCount += Int32.Parse(objTextBox.Text);
        }

        private void TextBox_extInqCompValue(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            objTextBox.Text = ((Int32.Parse(textBox_extInq)) * (Int32.Parse(radio_extInq))).ToString();
            //totalCount += Int32.Parse(objTextBox.Text);
        }
        // Sarvesh SMI Code

        /*private void projectCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.Text.Contains("-"))
            {
                MessageBox.Show("Please Create A New Project Before Proceeding With The Calculation");
            }
            else
            {
                TabPage tab = new TabPage();
                if (clickCountSMI == 1)
                {
                    Controls.Add(tabControl_fp);
                    tabSetupSMI(tab);
                    tabControl_fp.Show();
                }
                else
                {
                    tabControl_fp.Show();
                }
                int tabCount = tabControl_fp.TabCount;
                tabControl_fp.SelectedIndex = tabCount - 1;
                clickCountSMI++;
            }
        }
        */
        private void tabSetupSMI(TabPage tab)
        {
            //SMI_Test t = new SMI_Test();
            //t.Show();

            Button button2 = new System.Windows.Forms.Button();
            Button button1 = new System.Windows.Forms.Button();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            DataGridViewTextBoxColumn Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Label label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).BeginInit();

            //// 
            //// tabControl1
            //// 
            //this.tabControl1.Controls.Add(this.tabPage1);
            //this.tabControl1.Location = new System.Drawing.Point(12, 12);
            //this.tabControl1.Name = "tabControl1";
            //this.tabControl1.SelectedIndex = 0;
            //this.tabControl1.Size = new System.Drawing.Size(755, 628);
            //this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tab.Controls.Add(button2);
            tab.Controls.Add(button1);
            tab.Controls.Add(dataGridView1);
            tab.Controls.Add(label1);
            tab.Font = new System.Drawing.Font("Segoe UI", 9F);
            tab.Location = new System.Drawing.Point(4, 25);
            tab.Name = "SMI";
            tab.Padding = new System.Windows.Forms.Padding(3);
            tab.Size = new System.Drawing.Size(982, 723);
            tab.TabIndex = 0;
            tab.Text = "SMI";
            tab.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(391, 533);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(125, 33);
            button2.TabIndex = 3;
            button2.Text = "Compute Index";
            button2.UseVisualStyleBackColor = true;
            button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(102, 533);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(125, 33);
            button1.TabIndex = 2;
            button1.Text = "Add Row";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            Column1,
            Column2,
            Column3,
            Column4,
            Column5});
            dataGridView1.Location = new System.Drawing.Point(28, 112);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 36;
            dataGridView1.Size = new System.Drawing.Size(600, 400);
            dataGridView1.TabIndex = 1;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "SMI";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Column2.HeaderText = "Modules Added";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Column3.HeaderText = "Modules Changed";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Column4.HeaderText = "Modules Deleted";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Column5.HeaderText = "Total Modules";
            Column5.Name = "Column5";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(195, 37);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(321, 37);
            label1.TabIndex = 0;
            label1.Text = "Software Maturity Index";
            // 
            // SMI_Test
            // 
            //AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            //AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //ClientSize = new System.Drawing.Size(800, 800);
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).EndInit();
            tabControl_fp.TabPages.Add(tab);

            smi.Columns.Add("SMI");
            smi.Columns.Add("Modules Added");
            smi.Columns.Add("Modules Changed");
            smi.Columns.Add("Modules Deleted");
            smi.Columns.Add("Total Modules");

            //foreach (DataRow dRow in smi.Rows)
            //{
            //    int num = dataGridView1.Rows.Add();
            //    dataGridView1.Rows[num].Cells[0].Value = dRow["SMI"].ToString();
            //    dataGridView1.Rows[num].Cells[0].Value = dRow["Modules Added"].ToString();
            //    dataGridView1.Rows[num].Cells[0].Value = dRow["Modules Changed"].ToString();
            //    dataGridView1.Rows[num].Cells[0].Value = dRow["Modules Deleted"].ToString();
            //    dataGridView1.Rows[num].Cells[0].Value = dRow["Total Modules"].ToString();
            //}



        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            row = smi.NewRow();
            rCount = dataGridView1.Rows.Count;

            //row["SMI"] = dataGridView1[0, rCount - 2].Value.ToString();
            row["Modules Added"] = dataGridView1[1, rCount - 2].Value.ToString();
            row["Modules Changed"] = dataGridView1[2, rCount - 2].Value.ToString();
            row["Modules Deleted"] = dataGridView1[3, rCount - 2].Value.ToString();
            row["Total Modules"] = Convert.ToInt32(row["Modules Added"]) - Convert.ToInt32(row["Modules Deleted"]);
            tModules += Convert.ToInt32(row["Total Modules"]);
            float iModAdd, iModChang, iModDel;
            double dSMI = 0.0;
            iModAdd = (float)Convert.ToDouble(row["Modules Added"]);
            iModChang = (float)Convert.ToDouble(row["Modules Changed"]);
            iModDel = (float)Convert.ToDouble(row["Modules Deleted"]);

            dSMI = (tModules -
                (((Convert.ToInt32(row["Modules Added"])) + (Convert.ToInt32(row["Modules Changed"])) +
                (Convert.ToInt32(row["Modules Deleted"]))))) /
                tModules;
            dSMI = (tModules - (iModAdd + iModChang + iModDel)) / tModules;

            dataGridView1[0, rCount - 2].Value = dSMI.ToString();
            row["SMI"] = dataGridView1[0, rCount - 2].Value.ToString();
            dataGridView1[4, rCount - 2].Value = tModules.ToString();
            row["Total Modules"] = dataGridView1[4, rCount - 2].Value.ToString();
            smi.Rows.Add(this.row);
            //ds.Tables.Add(smi);
            //dataGridView1.DataSource = ds.Tables[0];
            //smi.TableName = "Test";9
            //smi.WriteXml("11.xml", true);
        }


        private void TextBox_extOutputCompValue(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            objTextBox.Text = ((Int32.Parse(textBox_extOutput)) * (Int32.Parse(radio_extOutput))).ToString();
            //totalCount += Int32.Parse(objTextBox.Text);
        }

        // Sarvesh 

        private void addCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Select JAVA File/Files";
            open.Multiselect = true;
            open.Filter = "JAVA Files (*.java)|*.java";
            if (open.ShowDialog() == DialogResult.OK)
            {


                foreach (String file in open.FileNames)
                {
                    selectedJavaFiles.Add(file);
                }
                //foreach (object o in selectedJavaFiles)
                //{
                //    MessageBox.Show(o.ToString());
                //}

                //TabPage tab = new TabPage() { Text = open.FileName.ToString() };
                //tabControl_fp.TabPages.Add(tab);
                //tabControl_fp.SelectedTab = tab;
                //RichTextBox rich = new RichTextBox { Parent = tab, Dock = DockStyle.Fill };
                //rich.LoadFile(open.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void projectCodeStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (object o in selectedJavaFiles)
            {
                //TabPage tab = new TabPage() { Text = System.IO.Path.GetFileName(o.ToString()) };
               
                
                //tabTV = new TabPage();
                //tabTV.Text = System.IO.Path.GetFileName(o.ToString());
                //tabTV.Name = System.IO.Path.GetFileName(o.ToString());
                //Controls.Add(tabControl_fp);
                //tabControl_fp.TabPages.Add(tabTV);
                //tabControl_fp.SelectedTab = tabTV;
                //RichTextBox rich = new RichTextBox { Parent = tabTV, Dock = DockStyle.Fill };
                //rich.LoadFile(o.ToString(), RichTextBoxStreamType.PlainText);
                treeView1_Update(System.IO.Path.GetFileName(o.ToString()));
                //tabControl_fp.Show();

                JavaJavaLexer jL = new JavaJavaLexer(new ANTLRFileStream(o.ToString()));
                JavaJavaParser jP = new JavaJavaParser(new CommonTokenStream(jL));
                jP.compilationUnit();

                Dictionary<string, string> computedData = new Dictionary<string, string>();

                string fileName = System.IO.Path.GetFileName(o.ToString());
                computedData.Add("File Name", fileName);

                FileInfo fi = new FileInfo(o.ToString());
                long fileSize = fi.Length;
                computedData.Add("File Length In Bytes", fileSize.ToString());

                double fileWhiteSpace = JavaJavaLexer.ws;
                computedData.Add("File White Space", fileWhiteSpace.ToString());

                long fileCommentSize = JavaJavaLexer.commentcount;
                computedData.Add("File Comment Size In Bytes", fileCommentSize.ToString());

                //double commentPercent = JavaJavaLexer.commentcount * 100 / fileSize;
                double commentPercent = Math.Round(Convert.ToDouble(JavaJavaLexer.commentcount) * 100 / fileSize,2);
                computedData.Add("Comment Percentage", commentPercent.ToString() + "%");

                computedData.Add("Halstead Metrics:", "");

                double n1;
                n1 = JavaMetrics.UniqueSpecial.Count() + JavaMetrics.UniqueKeywords.Count();
                double uniqueOperators = n1;
                computedData.Add("  Unique Operators", uniqueOperators.ToString());

                double n2;
                n2 = JavaMetrics.UniqueConstants.Count() + JavaMetrics.UniqueIdentifiers.Count();
                double uniqueOperands = n2;
                computedData.Add("  Unique Operands", uniqueOperands.ToString());

                double N1;
                N1 = JavaJavaParser.specialcount + JavaJavaParser.keywordCount + JavaJavaParser.importKWCount;
                double totalOperators = N1;
                computedData.Add("  Total Operators", totalOperators.ToString());

                double N2;
                N2 = JavaJavaParser.identcount + JavaJavaLexer.constantcount + JavaJavaParser.importIDCount;
                double totalOperands = N2;
                computedData.Add("  Total Operands", totalOperands.ToString());

                double N;
                N = N1 + N2;
                double programLength = N;
                computedData.Add("  Program Length (N)", programLength.ToString());

                double n;
                n = n1 + n2;
                double programVocabulory = n;
                computedData.Add("  Program Vocabulory (n)", programVocabulory.ToString());

                // Volume = N Log2 (n1+n2) ----- Page Number - 676
                // Voumme = N Log2 (n)
                double V;
                //V = N * Math.Log(N) / Math.Log(2);
                V = N * Math.Log(n,2.0);
                double volume = V;
                computedData.Add("  Volume", volume.ToString());

                double D;
                D = (n1 / 2) * (N2 / n2);
                double difficulty = D;
                computedData.Add("  Difficulty", difficulty.ToString());

                double E;
                E = D * V;
                double effort = E;
                computedData.Add("  Effort", effort.ToString());

                double T;
                T = E / 18;
                double time = T;
                computedData.Add("  Time", time.ToString() +" (" +Math.Round(time/60,2) +" Minutes (OR) "+Math.Round((time/60)/60,2) +" Hours (OR) "+ time/504000 +" Person Months )");

                double B;
                B = V / 3000;
                double bugsExpected = B;
                computedData.Add("  Bugs Expected", bugsExpected.ToString());

                computedData.Add("McCabe's Cyclomatic Complexity", "");

                //foreach ( String value in JavaMetrics.MccabeValues)
                //{
                //    computedData.Add("  " + value.Split('=')[0], value.Split('=')[1]);
                //}
                int duplicateCounter = 0;
                string tempKey = "";
                foreach (String value in JavaMetrics.MccabeValues)
                {
                    try
                    {
                        computedData.Add("  " + value.Split('=')[0], value.Split('=')[1]);
                        tempKey = value.Split('=')[0];
                    }
                    catch
                    {
                        if (tempKey == value.Split('=')[0])
                        {
                            duplicateCounter++;
                            computedData.Add("  " + value.Split('=')[0] + "_" + duplicateCounter, value.Split('=')[1]);
                        }
                    }
                }
                //try
                //{
                //    foreach (String value in JavaMetrics.MccabeValues)
                //    {
                //        JavaMetrics.MccabeValues.Remove(value);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.ToString());
                //}
                HashSet<String> deleteOldMccabeValues = new HashSet<String>();
                foreach (String value in JavaMetrics.MccabeValues)
                {
                    deleteOldMccabeValues.Add(value);
                }
                foreach (String value in deleteOldMccabeValues)
                {
                    JavaMetrics.MccabeValues.Remove(value);
                }
                createOrOpenFile(o, computedData);

            }
        }

        private void createOrOpenFile(object o, Dictionary<string, string> d)
        {
            string newFileName = System.IO.Path.GetFileNameWithoutExtension(o.ToString()) + "_Computed.txt";
            string newPath = System.IO.Path.GetDirectoryName(o.ToString()) + "/" + newFileName;
            if (!File.Exists(newPath))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(newPath))
                {
                    foreach (KeyValuePair<string, string> kvp in d)
                    {
                        sw.WriteLine("{0} : {1}", kvp.Key, kvp.Value);
                    }

                }
                d = null;
                tabTV = new TabPage();
                //tabTV.Text = System.IO.Path.GetFileName(newFileName);
                //tabTV.Name = System.IO.Path.GetFileName(newFileName);
                tabTV.Text = System.IO.Path.GetFileName(o.ToString());
                tabTV.Name = System.IO.Path.GetFileName(o.ToString());
                Controls.Add(tabControl_fp);
                tabControl_fp.TabPages.Add(tabTV);
                tabControl_fp.SelectedTab = tabTV;
                RichTextBox rich = new RichTextBox { Parent = tabTV, Dock = DockStyle.Fill };
                rich.LoadFile(newPath, RichTextBoxStreamType.PlainText);
            }

            // Open the file to read from.
            //using (StreamReader sr = File.OpenText(newPath))
            //{
            //    string s = "";
            //    while ((s = sr.ReadLine()) != null)
            //    {
            //        Console.WriteLine(s);
            //    }
            //}
        }

        private void sMIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.Text.Contains("-"))
            {
                MessageBox.Show("Please Create A New Project Before Proceeding With The Calculation");
            }
            else
            {
                tabTV = new TabPage();
                if (clickCountSMI == 1)
                {
                    Controls.Add(tabControl_fp);
                    tabSetupSMI(tabTV);
                    treeView1_Update("SMI");
                    tabControl_fp.Show();
                }
                else
                {
                    tabControl_fp.Show();
                }
                int tabCount = tabControl_fp.TabCount;
                tabControl_fp.SelectedIndex = tabCount - 1;
                clickCountSMI++;
            }
        }

        public void treeView1_Load()
        {
            //treeView1.Nodes.Add(ProjectNew.projName);
            //this.panel1.Visible = true;

            node = new TreeNode(ProjectNew.projName);
            node.Tag = "ProjectName";
            treeView1.Nodes.Add(node);
            this.panel1.Visible = true;

        }
        public void treeView1_Update(string s)
        {
            //treeView1.Nodes[0].Nodes.Add(s);
            node = new TreeNode(s);
            node.Tag = s;
            treeView1.Nodes[0].Nodes.Add(node);
        }



        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            //switch ((e.Action))
            //{
            //    case TreeViewAction.ByKeyboard:
            //        MessageBox.Show("You like the keyboard!");
            //        break;
            //    case TreeViewAction.ByMouse:
            //        MessageBox.Show("You like the mouse!");
            //        break;

            //}
            //TreeNode node = treeView1.SelectedNode;
            //
            // Render message box.
            //
            //MessageBox.Show(string.Format("You selected: {0}", node.Text));
            //treeView1.Nodes.Add("Parent");
            //treeView1.Nodes[0].Nodes.Add("Child 1");
            //treeView1.Nodes[0].Nodes.Add("Child 2");
            //treeView1.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
            //treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
            //if (treeView1.SelectedNode.Text == "Usercontrol1")
            //{
            //    panel1.Controls.Clear();
            //    panel1.Visible = true;
            //    UserControl1 usr1 = new UserControl1();
            //    usr1.Show();
            //    panel1.Controls.Add(usr1);
            //}
            //if (treeView1.SelectedNode.Text == "Usercontrol2")
            //{
            //    panel1.Controls.Clear();
            //    panel1.Visible = true;
            //    UserControl2 usr2 = new UserControl2();
            //    usr2.Show();
            //    panel1.Controls.Add(usr2);
            //}
            //if (treeView1.SelectedNode.Text == "Root")
            //{
            //    panel1.Controls.Clear();
            //    panel1.Visible = false;
            //}
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            string messageBoxText = "Do you want to save changes?";
            string caption = "Save / Discard Changes";
            MessageBoxButtons button = MessageBoxButtons.YesNoCancel;
            DialogResult result = MessageBox.Show(messageBoxText, caption, button);

            // Process message box results
            switch (result)
            {
                case DialogResult.Yes:
                    // User pressed Yes button
                    // ...
                    saveToolStripMenuItem_Click(sender, e);
                    break;
                case DialogResult.No:
                    // User pressed No button
                    // ...
                    //this.Close();
                    break;
                case DialogResult.Cancel:
                    // User pressed Cancel button
                    // ...
                    e.Cancel = true;
                    break;
            }

        }

        private void TextBox_extInputCompValue(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            objTextBox.Text = ((Int32.Parse(textBox_extInput)) * (Int32.Parse(radio_extInput))).ToString();
            //totalCount += Int32.Parse(objTextBox.Text);
        }
        private void TextBox_extIntFilesCompValue(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            objTextBox.Text = ((Int32.Parse(textBox_extIntFiles)) * (Int32.Parse(radio_extIntFiles))).ToString();
            //totalCount += Int32.Parse(objTextBox.Text);
        }
        private void TextBox_extOutput(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(objTextBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Enter A Valid Positive Number >= 0");
                objTextBox.Text = objTextBox.Text.Remove(objTextBox.Text.Length - 1);
            }
            else
            {
                textBox_extOutput = objTextBox.Text;
                //radioButton9_2.Select();
            }
        }
        private void TextBox_extInput(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(objTextBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Enter A Valid Positive Number >= 0");
                objTextBox.Text = objTextBox.Text.Remove(objTextBox.Text.Length - 1);
            }
            else
            {
                textBox_extInput = objTextBox.Text;
                //radioButton10_2.Select();
            }

        }
        private void TextBox_extInqFiles(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(objTextBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Enter A Valid Positive Number >= 0");
                objTextBox.Text = objTextBox.Text.Remove(objTextBox.Text.Length - 1);
            }
            else
            {
                textBox_extInq = objTextBox.Text;
                //radioButton8_2.Select();
            }
        }
        private void TextBox_intLogFiles(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(objTextBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Enter A Valid Positive Number >= 0");
                objTextBox.Text = objTextBox.Text.Remove(objTextBox.Text.Length - 1);
            }
            else
            {
                textBox_intLogFiles = objTextBox.Text;
                //radioButton7_2.Select();
            }
        }
        private void changeLang_ButtonClick(object sender, EventArgs e)
        {
            LanguageSelection ls = new LanguageSelection();
            ls.Show();

        }
        private void TextBox_extIntFiles(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(objTextBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Enter A Valid Positive Number >= 0");
                objTextBox.Text = objTextBox.Text.Remove(objTextBox.Text.Length - 1);
            }
            else
            {
                textBox_extIntFiles = objTextBox.Text;
                //radioButton6_2.Select();
            }
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectNew pn = new ProjectNew();
            pn.Show();
            info = new Information();

        }
        private void vaf_ButtonCLick(object sender, EventArgs e)
        {

            ValueAdjustmentFactor vaf = new ValueAdjustmentFactor();
            vaf.Show();
            //textBox_valAdj2.Text = ValueAdjustmentFactor.totalVaf.ToString();


            //vaf.TopLevel = false;
            //vaf.Visible = true;
            //vaf.FormBorderStyle = FormBorderStyle.None;
            //vaf.Dock = DockStyle.Fill;
            //tabControl_fp.TabPages[tabControl_fp.SelectedIndex].Controls.Add(vaf);
            //vaf.Show();
        }
        public void SetVafValue(ValueAdjustmentFactor vaf)
        {
            //textBox_valAdj2.Text = ValueAdjustmentFactor.totalVaf.ToString();
            //button1_2.PerformClick();

            TextBox tb = null;
            try
            {
                TabPage tp = tabControl_fp.SelectedTab;
                if (tp != null)
                {
                    tb = tp.Controls["textBox_valAdj"] as TextBox;
                }
                tb.Text = ValueAdjustmentFactor.totalVaf.ToString();
                button1_2.PerformClick();
            }
            catch
            {
                return;
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ////Information info = new Information();
                //DataTable dt = (DataTable)dataGridView1.DataSource;
                //SaveFileDialog sfd = new SaveFileDialog();
                //sfd.Filter = "XML|*.xml";
                //if (sfd.ShowDialog() == DialogResult.OK)
                //    dt.WriteXml(sfd.FileName);
                //    //SaveXML.saveProject(dt, "1.xml");



                for (int i = 0; i < tabControl_fp.TabCount; i++)
                {

                    tabControl_fp.SelectedIndex = i;
                    TabPage tp = tabControl_fp.SelectedTab;
                    if (tp.Name.Contains("_FP"))
                    //if(tp.Name=="Functional Points")
                    {
                        Home h = new Home();
                        info = new Information();




                        info.FpTabName = tp.Text;
                        info.TextBox_extInputCompValue2 = tp.Controls["textBox_extInputCompValue"].Text;
                        info.TextBox_extInqCompValue2 = tp.Controls["textBox_extInqCompValue"].Text;
                        info.TextBox_extIntFilesCompValue2 = tp.Controls["textBox_extIntFilesCompValue"].Text;
                        info.TextBox_extOutputCompValue2 = tp.Controls["textBox_extOutputCompValue"].Text;
                        info.TextBox_intLogFilesCompValue2 = tp.Controls["textBox_intLogFilesCompValue"].Text;

                        info.TextBox_extIntFiles2 = tp.Controls["textBox_extIntFiles"].Text;
                        info.TextBox_intLogFiles2 = tp.Controls["textBox_intLogFiles"].Text;
                        info.TextBox_extInq2 = tp.Controls["textBox_extInq"].Text;
                        info.TextBox_extOutput2 = tp.Controls["textBox_extOutput"].Text;
                        info.TextBox_extInput2 = tp.Controls["textBox_extInput"].Text;

                        info.TextBox_changeLang2 = tp.Controls["textBox_currLang"].Text;
                        info.TextBox_codeSize2 = tp.Controls["textBox_codeSize"].Text;
                        info.TextBox_computeFP2 = tp.Controls["textBox_computeFP"].Text;
                        info.TextBox_valAdj2 = tp.Controls["textBox_valAdj"].Text;
                        info.TextBox_totalCount2 = tp.Controls["textBox_totalCount"].Text;


                        Panel p = tp.Controls["panel1"] as Panel;
                        RadioButton rb = p.Controls["radioButton15"] as RadioButton;
                        info.RadioButton15_2 = rb.Checked.ToString();
                        p = tp.Controls["panel1"] as Panel;
                        rb = p.Controls["radioButton10"] as RadioButton;
                        info.RadioButton10_2 = rb.Checked.ToString();
                        p = tp.Controls["panel1"] as Panel;
                        rb = p.Controls["radioButton1"] as RadioButton;
                        info.RadioButton1_2 = rb.Checked.ToString();

                        p = tp.Controls["panel2"] as Panel;
                        rb = p.Controls["radioButton2"] as RadioButton;
                        info.RadioButton2_2 = rb.Checked.ToString();
                        p = tp.Controls["panel2"] as Panel;
                        rb = p.Controls["radioButton9"] as RadioButton;
                        info.RadioButton9_2 = rb.Checked.ToString();
                        p = tp.Controls["panel2"] as Panel;
                        rb = p.Controls["radioButton14"] as RadioButton;
                        info.RadioButton14_2 = rb.Checked.ToString();

                        p = tp.Controls["panel3"] as Panel;
                        rb = p.Controls["radioButton3"] as RadioButton;
                        info.RadioButton3_2 = rb.Checked.ToString();
                        p = tp.Controls["panel3"] as Panel;
                        rb = p.Controls["radioButton8"] as RadioButton;
                        info.RadioButton8_2 = rb.Checked.ToString();
                        p = tp.Controls["panel3"] as Panel;
                        rb = p.Controls["radioButton13"] as RadioButton;
                        info.RadioButton13_2 = rb.Checked.ToString();

                        p = tp.Controls["panel4"] as Panel;
                        rb = p.Controls["radioButton4"] as RadioButton;
                        info.RadioButton4_2 = rb.Checked.ToString();
                        p = tp.Controls["panel4"] as Panel;
                        rb = p.Controls["radioButton7"] as RadioButton;
                        info.RadioButton7_2 = rb.Checked.ToString();
                        p = tp.Controls["panel4"] as Panel;
                        rb = p.Controls["radioButton12"] as RadioButton;
                        info.RadioButton12_2 = rb.Checked.ToString();

                        p = tp.Controls["panel5"] as Panel;
                        rb = p.Controls["radioButton5"] as RadioButton;
                        info.RadioButton5_2 = rb.Checked.ToString();
                        p = tp.Controls["panel5"] as Panel;
                        rb = p.Controls["radioButton6"] as RadioButton;
                        info.RadioButton6_2 = rb.Checked.ToString();
                        p = tp.Controls["panel5"] as Panel;
                        rb = p.Controls["radioButton11"] as RadioButton;
                        info.RadioButton11_2 = rb.Checked.ToString();


                        info.ComboBox_vaf1 = ValueAdjustmentFactor.vafValues[0].ToString();
                        info.ComboBox_vaf2 = ValueAdjustmentFactor.vafValues[1].ToString();
                        info.ComboBox_vaf3 = ValueAdjustmentFactor.vafValues[2].ToString();
                        info.ComboBox_vaf4 = ValueAdjustmentFactor.vafValues[3].ToString();
                        info.ComboBox_vaf5 = ValueAdjustmentFactor.vafValues[4].ToString();
                        info.ComboBox_vaf6 = ValueAdjustmentFactor.vafValues[5].ToString();
                        info.ComboBox_vaf7 = ValueAdjustmentFactor.vafValues[6].ToString();
                        info.ComboBox_vaf8 = ValueAdjustmentFactor.vafValues[7].ToString();
                        info.ComboBox_vaf9 = ValueAdjustmentFactor.vafValues[8].ToString();
                        info.ComboBox_vaf10 = ValueAdjustmentFactor.vafValues[9].ToString();
                        info.ComboBox_vaf11 = ValueAdjustmentFactor.vafValues[10].ToString();
                        info.ComboBox_vaf12 = ValueAdjustmentFactor.vafValues[11].ToString();
                        info.ComboBox_vaf13 = ValueAdjustmentFactor.vafValues[12].ToString();
                        info.ComboBox_vaf14 = ValueAdjustmentFactor.vafValues[13].ToString();

                        info.ProjName = ProjectNew.projName;

                        //for (int iCount = 0; iCount < selectedJavaFiles.Count; iCount++)
                        //{
                        //    if (iCount == 0)
                        //    {
                        //        info.SelectedJavaFiles = selectedJavaFiles[i];
                        //    }
                        //    else
                        //    {
                        //        info.SelectedJavaFiles += ";" + selectedJavaFiles[i];
                        //    }

                        //}
                        

                        Linfo.Add(info);
                    }
                    else if (tp.Name == "SMI")
                    {
                        smi.TableName = "SMI_Table";
                        smi.WriteXml(ProjectNew.projName + "_ProjectFiles_SMI.ms", true);
                    }
                  
                    //SaveXML.saveProject(info, ProjectNew.projName + "_ProjectFiles.ms");
                }
                //foreach (string s in selectedJavaFiles)
                //{
                //    info.SelectedJavaFiles = s.ToString();
                //}
                fInfo = new Information();
                for (int i = 0; i < selectedJavaFiles.Count; i++)
                {
                    if (i == 0)
                    {
                        fInfo.SelectedJavaFiles = selectedJavaFiles[i];
                    }
                    else
                    {
                        fInfo.SelectedJavaFiles += ";" + selectedJavaFiles[i];
                    }

                }
                LFile.Add(fInfo);
                SaveXML.saveProject(LFile, ProjectNew.projName + "_ProjectFiles_CFile.ms");
                SaveXML.saveProject(Linfo, ProjectNew.projName + "_ProjectFiles.ms");
 
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Enter Project Informations In Functional Points Tab");
            }


        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open File";
            open.Filter = "MS Files (*.ms)|*.ms";
            if (open.ShowDialog() == DialogResult.OK)
            {
                if (open.SafeFileName.Contains("ProjectFiles.ms"))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Information));
                    FileStream read = new FileStream(open.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                    //info = (Information)xs.Deserialize(read);
                    //TabPage tab = new TabPage();

                    //String fileNameWithoutExt = open.SafeFileName.ToString();
                    //int index = fileNameWithoutExt.IndexOf(".");
                    //if (index > 0)
                    //    fileNameWithoutExt = fileNameWithoutExt.Substring(0, index);
                    //StringBuilder fileNameSBI = new StringBuilder();
                    //fileNameSBI.Append(fileNameWithoutExt).Append("_SMI.ms");


                    XmlDataDocument xmldoc = new XmlDataDocument();
                    XmlNodeList xmlnode;
                    int i = 0, j = 0;
                    string str = null;
                    xmldoc.Load(read);
                    xmlnode = xmldoc.GetElementsByTagName("Information");
                    for (i = 0; i < xmlnode.Count; i++)
                    {
                        TabPage tab = new TabPage();

                        if (i == 0)
                        {

                            Controls.Add(tabControl_fp);
                            tabSetup(tab);
                            tabControl_fp.Show();
                            tabControl_fp.SelectedIndex = i;
                            tab = tabControl_fp.SelectedTab;
                            ProjectNew.projName = xmlnode[0].ChildNodes.Item(45).InnerText.Trim();
                            treeView1_Load();
                            treeView1_Update(xmlnode[i].ChildNodes.Item(44).InnerText.Trim());

                            this.Text += " - " + xmlnode[i].ChildNodes.Item(45).InnerText.Trim();
                        }
                        else
                        {
                            tabSetup(tab);
                            treeView1_Update(xmlnode[i].ChildNodes.Item(44).InnerText.Trim());
                            //tabControl_fp.Show();
                            tabControl_fp.SelectedIndex = i;
                            tab = tabControl_fp.SelectedTab;
                        }
                        tab.Text = xmlnode[i].ChildNodes.Item(44).InnerText.Trim();
                        tab.Controls["textBox_extIntFilesCompValue"].Text = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                        tab.Controls["textBox_intLogFilesCompValue"].Text = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                        tab.Controls["textBox_extInqCompValue"].Text = xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
                        tab.Controls["textBox_extOutputCompValue"].Text = xmlnode[i].ChildNodes.Item(3).InnerText.Trim();
                        tab.Controls["textBox_extInputCompValue"].Text = xmlnode[i].ChildNodes.Item(4).InnerText.Trim();

                        tab.Controls["textBox_extIntFiles"].Text = xmlnode[i].ChildNodes.Item(5).InnerText.Trim();
                        tab.Controls["textBox_intLogFiles"].Text = xmlnode[i].ChildNodes.Item(6).InnerText.Trim();
                        tab.Controls["textBox_extInq"].Text = xmlnode[i].ChildNodes.Item(7).InnerText.Trim();
                        tab.Controls["textBox_extOutput"].Text = xmlnode[i].ChildNodes.Item(8).InnerText.Trim();
                        tab.Controls["textBox_extInput"].Text = xmlnode[i].ChildNodes.Item(9).InnerText.Trim();

                        tab.Controls["textBox_computeFP"].Text = xmlnode[i].ChildNodes.Item(10).InnerText.Trim();
                        tab.Controls["textBox_valAdj"].Text = xmlnode[i].ChildNodes.Item(11).InnerText.Trim();
                        tab.Controls["textBox_codeSize"].Text = xmlnode[i].ChildNodes.Item(12).InnerText.Trim();
                        tab.Controls["textBox_currLang"].Text = xmlnode[i].ChildNodes.Item(13).InnerText.Trim();
                        tab.Controls["textBox_totalCount"].Text = xmlnode[i].ChildNodes.Item(14).InnerText.Trim();

                        Panel p = tab.Controls["panel1"] as Panel;
                        RadioButton rb = p.Controls["radioButton1"] as RadioButton;
                        rb.Checked = Convert.ToBoolean(xmlnode[i].ChildNodes.Item(15).InnerText.Trim());
                        p = tab.Controls["panel2"] as Panel;
                        rb = p.Controls["radioButton2"] as RadioButton;
                        rb.Checked = Convert.ToBoolean(xmlnode[i].ChildNodes.Item(16).InnerText.Trim());
                        p = tab.Controls["panel3"] as Panel;
                        rb = p.Controls["radioButton3"] as RadioButton;
                        rb.Checked = Convert.ToBoolean(xmlnode[i].ChildNodes.Item(17).InnerText.Trim());
                        p = tab.Controls["panel4"] as Panel;
                        rb = p.Controls["radioButton4"] as RadioButton;
                        rb.Checked = Convert.ToBoolean(xmlnode[i].ChildNodes.Item(18).InnerText.Trim());
                        p = tab.Controls["panel5"] as Panel;
                        rb = p.Controls["radioButton5"] as RadioButton;
                        rb.Checked = Convert.ToBoolean(xmlnode[i].ChildNodes.Item(19).InnerText.Trim());
                        p = tab.Controls["panel5"] as Panel;
                        rb = p.Controls["radioButton6"] as RadioButton;
                        rb.Checked = Convert.ToBoolean(xmlnode[i].ChildNodes.Item(20).InnerText.Trim());
                        p = tab.Controls["panel4"] as Panel;
                        rb = p.Controls["radioButton7"] as RadioButton;
                        rb.Checked = Convert.ToBoolean(xmlnode[i].ChildNodes.Item(21).InnerText.Trim());
                        p = tab.Controls["panel3"] as Panel;
                        rb = p.Controls["radioButton8"] as RadioButton;
                        rb.Checked = Convert.ToBoolean(xmlnode[i].ChildNodes.Item(22).InnerText.Trim());
                        p = tab.Controls["panel2"] as Panel;
                        rb = p.Controls["radioButton9"] as RadioButton;
                        rb.Checked = Convert.ToBoolean(xmlnode[i].ChildNodes.Item(23).InnerText.Trim());
                        p = tab.Controls["panel1"] as Panel;
                        rb = p.Controls["radioButton10"] as RadioButton;
                        rb.Checked = Convert.ToBoolean(xmlnode[i].ChildNodes.Item(24).InnerText.Trim());
                        p = tab.Controls["panel5"] as Panel;
                        rb = p.Controls["radioButton11"] as RadioButton;
                        rb.Checked = Convert.ToBoolean(xmlnode[i].ChildNodes.Item(25).InnerText.Trim());
                        p = tab.Controls["panel4"] as Panel;
                        rb = p.Controls["radioButton12"] as RadioButton;
                        rb.Checked = Convert.ToBoolean(xmlnode[i].ChildNodes.Item(26).InnerText.Trim());
                        p = tab.Controls["panel3"] as Panel;
                        rb = p.Controls["radioButton13"] as RadioButton;
                        rb.Checked = Convert.ToBoolean(xmlnode[i].ChildNodes.Item(27).InnerText.Trim());
                        p = tab.Controls["panel2"] as Panel;
                        rb = p.Controls["radioButton14"] as RadioButton;
                        rb.Checked = Convert.ToBoolean(xmlnode[i].ChildNodes.Item(28).InnerText.Trim());
                        p = tab.Controls["panel1"] as Panel;
                        rb = p.Controls["radioButton15"] as RadioButton;
                        rb.Checked = Convert.ToBoolean(xmlnode[i].ChildNodes.Item(29).InnerText.Trim());





                    }
                    String fileNameWithoutExt = open.FileName.ToString();
                    int index = fileNameWithoutExt.IndexOf(".");
                    if (index > 0)
                        fileNameWithoutExt = fileNameWithoutExt.Substring(0, index);
                    StringBuilder fileNameSBI = new StringBuilder();
                    fileNameSBI.Append(fileNameWithoutExt).Append("_SMI.ms");
                    if (File.Exists(fileNameSBI.ToString()))
                    {
                        //MessageBox.Show("File Exists");
                        XmlDataDocument xmldocSMI = new XmlDataDocument();
                        XmlNodeList xmlnodeSMI;
                        xmldocSMI.Load(fileNameSBI.ToString());
                        xmlnodeSMI = xmldocSMI.GetElementsByTagName("DocumentElement");
                        for (i = 0; i < xmlnodeSMI.Count; i++)
                        {
                            TabPage tab = new TabPage();
                            Controls.Add(tabControl_fp);
                            tabSetupSMI(tab);
                            treeView1_Update("SMI");
                            tabControl_fp.Show();
                            int tabCount = tabControl_fp.TabCount;
                            tabControl_fp.SelectedIndex = tabCount - 1;
                        }
                        xmlnodeSMI = xmldocSMI.GetElementsByTagName("SMI_Table");
                        for (i = 0; i < xmlnodeSMI.Count; i++)
                        {
                            //row = smi.NewRow();
                            //rCount = dataGridView1.Rows.Count;
                            //dataGridView1[0, rCount - 1].Value = xmlnodeSMI[i].ChildNodes.Item(0).InnerText.Trim();
                            //dataGridView1[1, rCount - 1].Value = xmlnodeSMI[i].ChildNodes.Item(1).InnerText.Trim();
                            //dataGridView1[2, rCount - 1].Value = xmlnodeSMI[i].ChildNodes.Item(2).InnerText.Trim();
                            //dataGridView1[3, rCount - 1].Value = xmlnodeSMI[i].ChildNodes.Item(3).InnerText.Trim();
                            //dataGridView1[4, rCount - 1].Value = xmlnodeSMI[i].ChildNodes.Item(4).InnerText.Trim();
                            //smi.Rows.Add(row);
                            DataGridViewRow r = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                            r.Cells[0].Value = xmlnodeSMI[i].ChildNodes.Item(0).InnerText.Trim();
                            r.Cells[1].Value = xmlnodeSMI[i].ChildNodes.Item(1).InnerText.Trim();
                            r.Cells[2].Value = xmlnodeSMI[i].ChildNodes.Item(2).InnerText.Trim();
                            r.Cells[3].Value = xmlnodeSMI[i].ChildNodes.Item(3).InnerText.Trim();
                            r.Cells[4].Value = xmlnodeSMI[i].ChildNodes.Item(4).InnerText.Trim();
                            dataGridView1.Rows.Add(r);

                        }

                    }
                    String fileNameWithoutExt1 = open.FileName.ToString();
                    int index1 = fileNameWithoutExt1.IndexOf(".");
                    if (index1 > 0)
                        fileNameWithoutExt1 = fileNameWithoutExt1.Substring(0, index);
                    StringBuilder fileNameCFile = new StringBuilder();
                    fileNameCFile.Append(fileNameWithoutExt1).Append("_CFile.ms");
                    //if (File.Exists(fileNameCFile.ToString()))
                    //{
                    //    string allJavaFiles = "";

                    //    XmlDataDocument xmldoc1 = new XmlDataDocument();
                    //    XmlNodeList xmlnode1;
                    //    int i1 = 0, j1 = 0;
                    //    string str1 = null;
                    //    xmldoc1.Load(read);
                    //    xmlnode1 = xmldoc1.GetElementsByTagName("Information");
                    //    for (i1 = 0; i1 < xmlnode1.Count; i1++)
                    //    {
                    //        TabPage tab = new TabPage();

                    //        if (i == 0)
                    //        {

                    //            Controls.Add(tabControl_fp);
                    //            tabSetup(tab);
                    //            tabControl_fp.Show();
                    //            tabControl_fp.SelectedIndex = i;
                    //            tab = tabControl_fp.SelectedTab;
                    //            allJavaFiles = xmlnode1[0].ChildNodes.Item(45).InnerText.Trim();
                    //            MessageBox.Show(allJavaFiles);
                    //        }
                    //    }
                    //}
                    if (File.Exists(fileNameCFile.ToString()))
                    {
                        //MessageBox.Show("File Exists");
                        string allJavaFiles = "";
                        XmlDataDocument xmldocCFile = new XmlDataDocument();
                        XmlNodeList xmlnodeCFile;
                        xmldocCFile.Load(fileNameCFile.ToString());
                        xmlnodeCFile = xmldocCFile.GetElementsByTagName("Information");
                        for (int k = 0; k < xmlnodeCFile.Count; k++)
                        {
                            //TabPage tab = new TabPage();
                            //Controls.Add(tabControl_fp);
                            //tabSetup(tab);
                            //tabControl_fp.Show();
                            //tabControl_fp.SelectedIndex = k;
                            //tab = tabControl_fp.SelectedTab;
                            //allJavaFiles = xmlnodeCFile[0].ChildNodes.Item(45).InnerText.Trim();
                            //MessageBox.Show(allJavaFiles);
                        }
                        xmlnodeCFile = xmldocCFile.GetElementsByTagName("SelectedJavaFiles");
                        for (i = 0; i < xmlnodeCFile.Count; i++)
                        {
                            allJavaFiles = xmlnodeCFile[0].ChildNodes.Item(0).InnerText.Trim();
                            
                            foreach (String s in allJavaFiles.Split(';'))
                            {
                                selectedJavaFiles.Add(s);
                            }
                            
                            projectCodeStatisticsToolStripMenuItem_Click(sender, e);

                        }
                    }
                }
                else if (open.SafeFileName.Contains("SMI.ms"))
                {

                    if (true)
                    {
                        FileStream read = new FileStream(open.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                        //MessageBox.Show("File Exists");
                        XmlDataDocument xmldocSMI = new XmlDataDocument();
                        XmlNodeList xmlnodeSMI;
                        xmldocSMI.Load(read);
                        xmlnodeSMI = xmldocSMI.GetElementsByTagName("DocumentElement");
                        for (int i = 0; i < xmlnodeSMI.Count; i++)
                        {
                            TabPage tab = new TabPage();
                            Controls.Add(tabControl_fp);
                            tabSetupSMI(tab);
                            treeView1_Update("SMI");
                            tabControl_fp.Show();
                            int tabCount = tabControl_fp.TabCount;
                            tabControl_fp.SelectedIndex = tabCount - 1;
                        }
                        xmlnodeSMI = xmldocSMI.GetElementsByTagName("SMI_Table");
                        for (int i = 0; i < xmlnodeSMI.Count; i++)
                        {
                            //row = smi.NewRow();
                            //rCount = dataGridView1.Rows.Count;
                            //dataGridView1[0, rCount - 1].Value = xmlnodeSMI[i].ChildNodes.Item(0).InnerText.Trim();
                            //dataGridView1[1, rCount - 1].Value = xmlnodeSMI[i].ChildNodes.Item(1).InnerText.Trim();
                            //dataGridView1[2, rCount - 1].Value = xmlnodeSMI[i].ChildNodes.Item(2).InnerText.Trim();
                            //dataGridView1[3, rCount - 1].Value = xmlnodeSMI[i].ChildNodes.Item(3).InnerText.Trim();
                            //dataGridView1[4, rCount - 1].Value = xmlnodeSMI[i].ChildNodes.Item(4).InnerText.Trim();
                            //smi.Rows.Add(row);
                            DataGridViewRow r = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                            r.Cells[0].Value = xmlnodeSMI[i].ChildNodes.Item(0).InnerText.Trim();
                            r.Cells[1].Value = xmlnodeSMI[i].ChildNodes.Item(1).InnerText.Trim();
                            r.Cells[2].Value = xmlnodeSMI[i].ChildNodes.Item(2).InnerText.Trim();
                            r.Cells[3].Value = xmlnodeSMI[i].ChildNodes.Item(3).InnerText.Trim();
                            r.Cells[4].Value = xmlnodeSMI[i].ChildNodes.Item(4).InnerText.Trim();
                            dataGridView1.Rows.Add(r);

                        }

                    }
                }
            }
        }
        private void Home_Load(object sender, EventArgs e)
        {

        }

        public void SetCurrLang()
        {
            TextBox tb = null;
            try
            {
                TabPage tp = tabControl_fp.SelectedTab;
                if (tp != null)
                {
                    tb = tp.Controls["textBox_currLang"] as TextBox;
                }
                tb.Text = LanguageSelection.strSelLang;
            }
            catch
            {
                return;
            }

        }

        public void SetTitleBar(string projName)
        {
            this.Text += " - " + projName;
        }
        private void metricsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public void LanguageSelected(object sender, EventArgs e)
        {
            lang.LanguageSelected += LS_LangSelected;

        }
        void LS_LangSelected(object sender, LanguageSelectedEventArgs e)
        {
            if (tabControl_fp.SelectedIndex >= 0)
            {
                this.tabControl_fp.SelectTab(tabControl_fp.SelectedIndex);

                this.tabControl_fp.SelectedTab.Controls["textBox_changeLang2"].Name = e.language.ToString();
            }
        }
    }

}
