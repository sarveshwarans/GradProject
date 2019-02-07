using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Information
    {
        private string 
            textBox_extIntFilesCompValue2, textBox_intLogFilesCompValue2, textBox_extInqCompValue2, textBox_extOutputCompValue2, textBox_extInputCompValue2,
            textBox_extIntFiles2, textBox_intLogFiles2, textBox_extInq2, textBox_extOutput2, textBox_extInput2,
            textBox_computeFP2, textBox_valAdj2, textBox_codeSize2, textBox_changeLang2, textBox_totalCount2;

        private string radioButton1_2, radioButton2_2, radioButton3_2, radioButton4_2, radioButton5_2,
            radioButton6_2, radioButton7_2, radioButton8_2, radioButton9_2, radioButton10_2,
            radioButton11_2, radioButton12_2, radioButton13_2, radioButton14_2, radioButton15_2;

        private string checkBox_Assembler, checkBox_Ada95, checkBox_C, checkBox_CPP, 
            checkBox_COBOL, checkBox_FORTRAN, checkBox_HTML, checkBox_Java,
            checkBox_JavaScript, checkBox_VBScript, checkBox_VB, checkBox_CS;

        private string comboBox_vaf1, comboBox_vaf2, comboBox_vaf3, comboBox_vaf4, comboBox_vaf5,
            comboBox_vaf6, comboBox_vaf7, comboBox_vaf8, comboBox_vaf9, comboBox_vaf10,
            comboBox_vaf11, comboBox_vaf12, comboBox_vaf13, comboBox_vaf14;

        private string fpTabName;
        private string projName;
        private string selectedJavaFiles;

        public string TextBox_extIntFilesCompValue2 { get { return textBox_extIntFilesCompValue2; } set { textBox_extIntFilesCompValue2 = value; } }
        public string TextBox_intLogFilesCompValue2 { get { return textBox_intLogFilesCompValue2; } set { textBox_intLogFilesCompValue2 = value; } }
        public string TextBox_extInqCompValue2 { get { return textBox_extInqCompValue2; } set { textBox_extInqCompValue2 = value; } }
        public string TextBox_extOutputCompValue2 { get { return textBox_extOutputCompValue2; } set { textBox_extOutputCompValue2 = value; } }
        public string TextBox_extInputCompValue2 { get { return textBox_extInputCompValue2; } set { textBox_extInputCompValue2 = value; } }

        public string TextBox_extIntFiles2 { get { return textBox_extIntFiles2; } set { textBox_extIntFiles2 = value; } }
        public string TextBox_intLogFiles2 { get { return textBox_intLogFiles2; } set { textBox_intLogFiles2 = value; } }
        public string TextBox_extInq2 { get { return textBox_extInq2; } set { textBox_extInq2 = value; } }
        public string TextBox_extOutput2 { get { return textBox_extOutput2; } set { textBox_extOutput2 = value; } }
        public string TextBox_extInput2 { get { return textBox_extInput2; } set { textBox_extInput2 = value; } }

        public string TextBox_computeFP2 { get { return textBox_computeFP2; } set { textBox_computeFP2 = value; } }
        public string TextBox_valAdj2 { get { return textBox_valAdj2; } set { textBox_valAdj2 = value; } }
        public string TextBox_codeSize2 { get { return textBox_codeSize2; } set { textBox_codeSize2 = value; } }
        public string TextBox_changeLang2 { get { return textBox_changeLang2; } set { textBox_changeLang2 = value; } }
        public string TextBox_totalCount2 { get { return textBox_totalCount2; } set { textBox_totalCount2 = value; } }

        public string RadioButton1_2 { get { return radioButton1_2; } set { radioButton1_2 = value; } }
        public string RadioButton2_2 { get { return radioButton2_2; } set { radioButton2_2 = value; } }
        public string RadioButton3_2 { get { return radioButton3_2; } set { radioButton3_2 = value; } }
        public string RadioButton4_2 { get { return radioButton4_2; } set { radioButton4_2 = value; } }
        public string RadioButton5_2 { get { return radioButton5_2; } set { radioButton5_2 = value; } }
        public string RadioButton6_2 { get { return radioButton6_2; } set { radioButton6_2 = value; } }
        public string RadioButton7_2 { get { return radioButton7_2; } set { radioButton7_2 = value; } }
        public string RadioButton8_2 { get { return radioButton8_2; } set { radioButton8_2 = value; } }
        public string RadioButton9_2 { get { return radioButton9_2; } set { radioButton9_2 = value; } }
        public string RadioButton10_2 { get { return radioButton10_2; } set { radioButton10_2 = value; } }
        public string RadioButton11_2 { get { return radioButton11_2; } set { radioButton11_2 = value; } }
        public string RadioButton12_2 { get { return radioButton12_2; } set { radioButton12_2 = value; } }
        public string RadioButton13_2 { get { return radioButton13_2; } set { radioButton13_2 = value; } }
        public string RadioButton14_2 { get { return radioButton14_2; } set { radioButton14_2 = value; } }
        public string RadioButton15_2 { get { return radioButton15_2; } set { radioButton15_2 = value; } }

        public string CheckBox_Assembler { get { return checkBox_Assembler; } set { checkBox_Assembler = value; } }
        public string CheckBox_Ada95 { get { return checkBox_Ada95; } set { checkBox_Ada95 = value; } }
        public string CheckBox_C { get { return checkBox_C; } set { checkBox_C = value; } }
        public string CheckBox_CPP { get { return checkBox_CPP; } set { checkBox_CPP = value; } }
        public string CheckBox_COBOL { get { return checkBox_COBOL; } set { checkBox_COBOL = value; } }
        public string CheckBox_FORTRAN { get { return checkBox_FORTRAN; } set { checkBox_FORTRAN = value; } }
        public string CheckBox_HTML { get { return checkBox_HTML; } set { checkBox_HTML = value; } }
        public string CheckBox_Java { get { return checkBox_Java; } set { checkBox_Java = value; } }
        public string CheckBox_JavaScript { get { return checkBox_JavaScript; } set { checkBox_JavaScript = value; } }
        public string CheckBox_VBScript { get { return checkBox_VBScript; } set { checkBox_VBScript = value; } }
        public string CheckBox_VB { get { return checkBox_VB; } set { checkBox_VB = value; } }
        public string CheckBox_CS { get { return checkBox_CS; } set { checkBox_CS = value; } }

        public string ComboBox_vaf1 { get { return comboBox_vaf1; } set { comboBox_vaf1 = value; } }
        public string ComboBox_vaf2 { get { return comboBox_vaf2; } set { comboBox_vaf2 = value; } }
        public string ComboBox_vaf3 { get { return comboBox_vaf3; } set { comboBox_vaf3 = value; } }
        public string ComboBox_vaf4 { get { return comboBox_vaf4; } set { comboBox_vaf4 = value; } }
        public string ComboBox_vaf5 { get { return comboBox_vaf5; } set { comboBox_vaf5 = value; } }
        public string ComboBox_vaf6 { get { return comboBox_vaf6; } set { comboBox_vaf6 = value; } }
        public string ComboBox_vaf7 { get { return comboBox_vaf7; } set { comboBox_vaf7 = value; } }
        public string ComboBox_vaf8 { get { return comboBox_vaf8; } set { comboBox_vaf8 = value; } }
        public string ComboBox_vaf9 { get { return comboBox_vaf9; } set { comboBox_vaf9 = value; } }
        public string ComboBox_vaf10 { get { return comboBox_vaf10; } set { comboBox_vaf10 = value; } }
        public string ComboBox_vaf11 { get { return comboBox_vaf11; } set { comboBox_vaf11 = value; } }
        public string ComboBox_vaf12 { get { return comboBox_vaf12; } set { comboBox_vaf12 = value; } }
        public string ComboBox_vaf13 { get { return comboBox_vaf13; } set { comboBox_vaf13 = value; } }
        public string ComboBox_vaf14 { get { return comboBox_vaf14; } set { comboBox_vaf14 = value; } }

        public string FpTabName { get { return fpTabName; } set { fpTabName = value; } }

        public string ProjName { get { return projName; } set { projName = value; } }

        public string SelectedJavaFiles { get { return selectedJavaFiles; } set { selectedJavaFiles = value; } }


    }
}
