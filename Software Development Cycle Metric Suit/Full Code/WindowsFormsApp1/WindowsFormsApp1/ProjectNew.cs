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
    public partial class ProjectNew : Form
    {
        public static string projName, prodName, creator, comments;
        public ProjectNew()
        {
            InitializeComponent();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            projName = textBox_projectName.Text;
            prodName = textBox_productName.Text;
            creator = textBox_creator.Text;
            comments = textBox_comments.Text;
            var homeForm = Application.OpenForms.OfType<Home>().Single();
            homeForm.SetTitleBar(projName);
            homeForm.treeView1_Load();
            this.Close();
        }
    }
}
