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
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public partial class ValueAdjustmentFactor : Form
    {
        public static int[] vafValues = new int[14] {0,0,0,0,0,0,0,0,0,0,0,0,0,0 };
        public static int totalVaf = 0;
        public ValueAdjustmentFactor()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            vafValues[0] = Int32.Parse(comboBox_vaf1.Text);
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            vafValues[1] = Int32.Parse(comboBox_vaf2.Text);
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            vafValues[2] = Int32.Parse(comboBox_vaf3.Text);
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            vafValues[3] = Int32.Parse(comboBox_vaf4.Text);
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            vafValues[4] = Int32.Parse(comboBox_vaf5.Text);
        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            vafValues[5] = Int32.Parse(comboBox_vaf6.Text);
        }
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            vafValues[6] = Int32.Parse(comboBox_vaf7.Text);
        }
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            vafValues[7] = Int32.Parse(comboBox_vaf8.Text);
        }
        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            vafValues[8] = Int32.Parse(comboBox_vaf9.Text);
        }
        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            vafValues[9] = Int32.Parse(comboBox_vaf10.Text);
        }
        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            vafValues[10] = Int32.Parse(comboBox_vaf11.Text);
        }
        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            vafValues[11] = Int32.Parse(comboBox_vaf12.Text);
        }
        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            vafValues[12] = Int32.Parse(comboBox_vaf13.Text);
        }
        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            vafValues[13] = Int32.Parse(comboBox_vaf14.Text);
        }

        private void buttonCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDoneClick(object sender, EventArgs e)
        {
            totalVaf = 0;
            foreach(int element in vafValues)
            {
                totalVaf += element;
            }
            //MessageBox.Show(totalVaf.ToString());
            //Home h1 = new Home();
            //h1.SetVafValue(this);
            var homeForm = Application.OpenForms.OfType<Home>().Single();
            homeForm.SetVafValue(this);
            this.Close();
        }

        private void ValueAdjustmentFactor_Load(object sender, EventArgs e)
        {
            comboBox_vaf1.Text = vafValues[0].ToString();
            comboBox_vaf2.Text = vafValues[1].ToString();
            comboBox_vaf3.Text = vafValues[2].ToString();
            comboBox_vaf4.Text = vafValues[3].ToString();
            comboBox_vaf5.Text = vafValues[4].ToString();
            comboBox_vaf6.Text = vafValues[5].ToString();
            comboBox_vaf7.Text = vafValues[6].ToString();
            comboBox_vaf8.Text = vafValues[7].ToString();
            comboBox_vaf9.Text = vafValues[8].ToString();
            comboBox_vaf10.Text = vafValues[9].ToString();
            comboBox_vaf11.Text = vafValues[10].ToString();
            comboBox_vaf12.Text = vafValues[11].ToString();
            comboBox_vaf13.Text = vafValues[12].ToString();
            comboBox_vaf14.Text = vafValues[13].ToString();



            if (File.Exists("Project.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Information));
                FileStream read = new FileStream("Project.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
                Information info = (Information)xs.Deserialize(read);

                comboBox_vaf1.Text = info.ComboBox_vaf1;
                comboBox_vaf2.Text = info.ComboBox_vaf2;
                comboBox_vaf3.Text = info.ComboBox_vaf3;
                comboBox_vaf4.Text = info.ComboBox_vaf4;
                comboBox_vaf5.Text = info.ComboBox_vaf5;
                comboBox_vaf6.Text = info.ComboBox_vaf6;
                comboBox_vaf7.Text = info.ComboBox_vaf7;
                comboBox_vaf8.Text = info.ComboBox_vaf8;
                comboBox_vaf9.Text = info.ComboBox_vaf9;
                comboBox_vaf10.Text = info.ComboBox_vaf10;
                comboBox_vaf11.Text = info.ComboBox_vaf11;
                comboBox_vaf12.Text = info.ComboBox_vaf12;
                comboBox_vaf13.Text = info.ComboBox_vaf13;
                comboBox_vaf14.Text = info.ComboBox_vaf14;


            }

        }

    }
}
