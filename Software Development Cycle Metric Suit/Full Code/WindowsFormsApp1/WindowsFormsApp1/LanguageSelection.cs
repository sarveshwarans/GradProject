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
    
    public partial class LanguageSelection : Form
    {
        int checkBoxCount = 0;
        List<string> selectedLang = new List<string>();
        int selectedLangCount = 0;
        public static string strSelLang = "";
        //public static string strLangForHome = "";
        //public static string strLangForVAF = "";
        public LanguageSelection()
        {
            InitializeComponent();
        }

        private void CheckBox_Assembler_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_Assembler.Checked == true)
            {
                checkBoxCount++;
                selectedLang.Add("Assembler");
                selectedLangCount = selectedLang.Count;

            }
            else
            {
                checkBoxCount--;
                if (selectedLang.Remove("Assembler"))
                {
                    selectedLangCount = selectedLang.Count;
                }
            }
        }

        private void checkBox_Ada95_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Ada95.Checked == true)
            {
                checkBoxCount++;
                selectedLang.Add("Ada95");
                selectedLangCount = selectedLang.Count;
            }
            else
            {
                checkBoxCount--;
                if (selectedLang.Remove("Ada95"))
                {
                    selectedLangCount = selectedLang.Count;
                }
            }
        }

        private void checkBox_C_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_C.Checked == true)
            {
                checkBoxCount++;
                selectedLang.Add("C");
                selectedLangCount = selectedLang.Count;
            }
            else
            {
                checkBoxCount--;
                if (selectedLang.Remove("C"))
                {
                    selectedLangCount = selectedLang.Count;
                }
            }
        }

        private void checkBox_CPP_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_CPP.Checked == true)
            {
                checkBoxCount++;
                selectedLang.Add("CPP");
                selectedLangCount = selectedLang.Count;
            }
            else
            {
                checkBoxCount--;
                if (selectedLang.Remove("CPP"))
                {
                    selectedLangCount = selectedLang.Count;
                }
            }

        }

        private void checkBox_CS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_CS.Checked == true)
            {
                checkBoxCount++;
                selectedLang.Add("CS");
                selectedLangCount = selectedLang.Count;
            }
            else
            {
                checkBoxCount--;
                if (selectedLang.Remove("CS"))
                {
                    selectedLangCount = selectedLang.Count;
                }
            }
        }

        private void checkBox_COBOL_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_COBOL.Checked == true)
            {
                checkBoxCount++;
                selectedLang.Add("COBOL");
                selectedLangCount = selectedLang.Count;
            }
            else
            {
                checkBoxCount--;
                if (selectedLang.Remove("COBOL"))
                {
                    selectedLangCount = selectedLang.Count;
                }
            }
        }

        private void checkBox_FORTRON_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_FORTRAN.Checked == true)
            {
                checkBoxCount++;
                selectedLang.Add("FORTRAN");
                selectedLangCount = selectedLang.Count;
            }
            else
            {
                checkBoxCount--;
                if (selectedLang.Remove("FORTRAN"))
                {
                    selectedLangCount = selectedLang.Count;
                }
            }
        }

        private void checkBox_HTML_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_HTML.Checked == true)
            {
                checkBoxCount++;
                selectedLang.Add("HTML");
                selectedLangCount = selectedLang.Count;
            }
            else
            {
                checkBoxCount--;
                if (selectedLang.Remove("HTML"))
                {
                    selectedLangCount = selectedLang.Count;
                }
            }
        }

        private void checkBox_Java_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Java.Checked == true)
            {
                checkBoxCount++;
                selectedLang.Add("Java");
                selectedLangCount = selectedLang.Count;
            }
            else
            {
                checkBoxCount--;
                if (selectedLang.Remove("Java"))
                {
                    selectedLangCount = selectedLang.Count;
                }
            }
        }

        private void checkBox_JavaScript_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_JavaScript.Checked == true)
            {
                checkBoxCount++;
                selectedLang.Add("JavaScript");
                selectedLangCount = selectedLang.Count;
            }
            else
            {
                checkBoxCount--;
                if (selectedLang.Remove("JavaScript"))
                {
                    selectedLangCount = selectedLang.Count;
                }
            }
        }

        private void checkBox_VBScript_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_VBScript.Checked == true)
            {
                checkBoxCount++;
                selectedLang.Add("VBScript");
                selectedLangCount = selectedLang.Count;
            }
            else
            {
                checkBoxCount--;
                if (selectedLang.Remove("VBScript"))
                {
                    selectedLangCount = selectedLang.Count;
                }
            }
        }

        private void checkBox_VB_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_VB.Checked == true)
            {
                checkBoxCount++;
                selectedLang.Add("VB");
                selectedLangCount = selectedLang.Count;
            }
            else
            {
                checkBoxCount--;
                if (selectedLang.Remove("VB"))
                {
                    selectedLangCount = selectedLang.Count;
                }
            }
        }

        private  void buttonDone_Click(object sender, EventArgs e)
        {
            if(checkBoxCount >1 || checkBoxCount==0)
            {
                MessageBox.Show("Please Choose One!!", "Error");
            }
            else
            {

                strSelLang = selectedLang[selectedLangCount - 1];
                var homeForm = Application.OpenForms.OfType<Home>().Single();
                homeForm.SetCurrLang();
                this.Close();
                //strSelLang = "";
                
                
                //LanguageSelectedEventArgs lan = new LanguageSelectedEventArgs();
                //lan.language = strSelLang;
                //OnLangSelected(lan);


                
            }
        }

        public void LanguageSelection_Load(object sender, EventArgs e)
        {
            if (strSelLang != "")
            {
                switch (strSelLang)
                {
                    case "Assembler":
                        checkBox_Assembler.Checked = true;
                        break;
                    case "Ada95":
                        checkBox_Ada95.Checked = true;
                        break;
                    case "C":
                        checkBox_C.Checked = true;
                        break;
                    case "CPP":
                        checkBox_CPP.Checked = true;
                        break;
                    case "CS":
                        checkBox_CS.Checked = true;
                        break;
                    case "COBOL":
                        checkBox_COBOL.Checked = true;
                        break;
                    case "FORTRAN":
                        checkBox_FORTRAN.Checked = true;
                        break;
                    case "HTML":
                        checkBox_HTML.Checked = true;
                        break;
                    case "Java":
                        checkBox_Java.Checked = true;
                        break;
                    case "JavaScript":
                        checkBox_JavaScript.Checked = true;
                        break;
                    case "VBScript":
                        checkBox_VBScript.Checked = true;
                        break;
                    case "VB":
                        checkBox_VB.Checked = true;
                        break;
                }
            }
            if (File.Exists("Project.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Information));
                FileStream read = new FileStream("Project.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
                Information info = (Information)xs.Deserialize(read);

                switch(info.TextBox_changeLang2)
                {
                    case "Assembler":
                        checkBox_Assembler.Checked=true;
                        break;
                    case "Ada95":
                        checkBox_Ada95.Checked = true;
                        break;
                    case "C":
                        checkBox_C.Checked = true;
                        break;
                    case "CPP":
                        checkBox_CPP.Checked = true;
                        break;
                    case "CS":
                        checkBox_CS.Checked = true;
                        break;
                    case "COBOL":
                        checkBox_COBOL.Checked = true;
                        break;
                    case "FORTRAN":
                        checkBox_FORTRAN.Checked = true;
                        break;
                    case "HTML":
                        checkBox_HTML.Checked = true;
                        break;
                    case "Java":
                        checkBox_Java.Checked = true;
                        break;
                    case "JavaScript":
                        checkBox_JavaScript.Checked = true;
                        break;
                    case "VBScript":
                        checkBox_VBScript.Checked = true;
                        break;
                    case "VB":
                        checkBox_VB.Checked = true;
                        break;
                }

            }
        }


        public class LanguageSelectedEventArgs : EventArgs
        {
            public string language { get; set; }
        }
        protected virtual void OnLangSelected(LanguageSelectedEventArgs e)
        {
            EventHandler<LanguageSelectedEventArgs> handler = LanguageSelected;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<LanguageSelectedEventArgs> LanguageSelected;
    }
}
