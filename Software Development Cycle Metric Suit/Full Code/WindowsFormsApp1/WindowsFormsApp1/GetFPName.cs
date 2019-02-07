using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class GetFPName : Form
    {
        public static string fpName ="";
        public GetFPName()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fpName = textBox1.Text+"_FP";
            var homeForm = Application.OpenForms.OfType<Home>().Single();
            homeForm.FPTabSetup(fpName);
            homeForm.treeView1_Update(fpName);
            this.Close();
        }

        private void GetFPName_Load(object sender, EventArgs e)
        {

        }
    }
}
