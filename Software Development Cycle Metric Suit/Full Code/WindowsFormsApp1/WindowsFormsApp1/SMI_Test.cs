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
    public partial class SMI_Test : Form
    {
        DataTable smi = new DataTable();
        DataRow row;
        public int tModules = 0;
        public int rCount = 0;
        public SMI_Test()
        {
            InitializeComponent();

            smi.Columns.Add("SMI");
            smi.Columns.Add("Modules Added");
            smi.Columns.Add("Modules Changed");
            smi.Columns.Add("Modules Deleted");
            smi.Columns.Add("Total Modules");

            foreach (DataRow dRow in smi.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = dRow["SMI"].ToString();
                dataGridView1.Rows[num].Cells[0].Value = dRow["Modules Added"].ToString();
                dataGridView1.Rows[num].Cells[0].Value = dRow["Modules Changed"].ToString();
                dataGridView1.Rows[num].Cells[0].Value = dRow["Modules Deleted"].ToString();
                dataGridView1.Rows[num].Cells[0].Value = dRow["Total Modules"].ToString();
            }
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

            MessageBox.Show(dSMI.ToString());
            dataGridView1[0, rCount - 2].Value = dSMI.ToString();
            dataGridView1[4, rCount - 2].Value = tModules.ToString();
            smi.Rows.Add(this.row);
        }
    }
}
