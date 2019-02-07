namespace WindowsFormsApp1
{
    partial class LanguageSelection
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
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_Assembler = new System.Windows.Forms.CheckBox();
            this.checkBox_Ada95 = new System.Windows.Forms.CheckBox();
            this.checkBox_C = new System.Windows.Forms.CheckBox();
            this.checkBox_CPP = new System.Windows.Forms.CheckBox();
            this.checkBox_COBOL = new System.Windows.Forms.CheckBox();
            this.checkBox_FORTRAN = new System.Windows.Forms.CheckBox();
            this.checkBox_HTML = new System.Windows.Forms.CheckBox();
            this.checkBox_Java = new System.Windows.Forms.CheckBox();
            this.checkBox_JavaScript = new System.Windows.Forms.CheckBox();
            this.checkBox_VBScript = new System.Windows.Forms.CheckBox();
            this.checkBox_VB = new System.Windows.Forms.CheckBox();
            this.checkBox_CS = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select One Language";
            // 
            // checkBox_Assembler
            // 
            this.checkBox_Assembler.AutoSize = true;
            this.checkBox_Assembler.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Assembler.Location = new System.Drawing.Point(34, 90);
            this.checkBox_Assembler.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBox_Assembler.Name = "checkBox_Assembler";
            this.checkBox_Assembler.Size = new System.Drawing.Size(105, 25);
            this.checkBox_Assembler.TabIndex = 2;
            this.checkBox_Assembler.Text = "Assembler";
            this.checkBox_Assembler.UseVisualStyleBackColor = true;
            //this.checkBox_Assembler.ThreeState = true;
            this.checkBox_Assembler.CheckedChanged += new System.EventHandler(this.CheckBox_Assembler_CheckedChanged);
            // 
            // checkBox_Ada95
            // 
            this.checkBox_Ada95.AutoSize = true;
            this.checkBox_Ada95.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Ada95.Location = new System.Drawing.Point(34, 113);
            this.checkBox_Ada95.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBox_Ada95.Name = "checkBox_Ada95";
            this.checkBox_Ada95.Size = new System.Drawing.Size(81, 25);
            this.checkBox_Ada95.TabIndex = 1;
            this.checkBox_Ada95.Text = "Ada 95";
            this.checkBox_Ada95.UseVisualStyleBackColor = true;
            //this.checkBox_Ada95.ThreeState = true;
            this.checkBox_Ada95.CheckedChanged += new System.EventHandler(this.checkBox_Ada95_CheckedChanged);
            // 
            // checkBox_C
            // 
            this.checkBox_C.AutoSize = true;
            this.checkBox_C.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_C.Location = new System.Drawing.Point(34, 135);
            this.checkBox_C.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBox_C.Name = "checkBox_C";
            this.checkBox_C.Size = new System.Drawing.Size(41, 25);
            this.checkBox_C.TabIndex = 3;
            this.checkBox_C.Text = "C";
            this.checkBox_C.UseVisualStyleBackColor = true;
            //this.checkBox_C.ThreeState = true;
            this.checkBox_C.CheckedChanged += new System.EventHandler(this.checkBox_C_CheckedChanged);
            // 
            // checkBox_CPP
            // 
            this.checkBox_CPP.AutoSize = true;
            this.checkBox_CPP.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_CPP.Location = new System.Drawing.Point(34, 159);
            this.checkBox_CPP.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBox_CPP.Name = "checkBox_CPP";
            this.checkBox_CPP.Size = new System.Drawing.Size(57, 25);
            this.checkBox_CPP.TabIndex = 4;
            this.checkBox_CPP.Text = "C++";
            this.checkBox_CPP.UseVisualStyleBackColor = true;
            //this.checkBox_CPP.ThreeState = true;
            this.checkBox_CPP.CheckedChanged += new System.EventHandler(this.checkBox_CPP_CheckedChanged);
            // 
            // checkBox_COBOL
            // 
            this.checkBox_COBOL.AutoSize = true;
            this.checkBox_COBOL.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_COBOL.Location = new System.Drawing.Point(34, 201);
            this.checkBox_COBOL.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBox_COBOL.Name = "checkBox_COBOL";
            this.checkBox_COBOL.Size = new System.Drawing.Size(79, 25);
            this.checkBox_COBOL.TabIndex = 5;
            this.checkBox_COBOL.Text = "COBOL";
            this.checkBox_COBOL.UseVisualStyleBackColor = true;
            //this.checkBox_COBOL.ThreeState = true;
            this.checkBox_COBOL.CheckedChanged += new System.EventHandler(this.checkBox_COBOL_CheckedChanged);
            // 
            // checkBox_FORTRAN
            // 
            this.checkBox_FORTRAN.AutoSize = true;
            this.checkBox_FORTRAN.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_FORTRAN.Location = new System.Drawing.Point(34, 225);
            this.checkBox_FORTRAN.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBox_FORTRAN.Name = "checkBox_FORTRAN";
            this.checkBox_FORTRAN.Size = new System.Drawing.Size(98, 25);
            this.checkBox_FORTRAN.TabIndex = 6;
            this.checkBox_FORTRAN.Text = "FORTRAN";
            this.checkBox_FORTRAN.UseVisualStyleBackColor = true;
            //this.checkBox_FORTRAN.ThreeState = true;
            this.checkBox_FORTRAN.CheckedChanged += new System.EventHandler(this.checkBox_FORTRON_CheckedChanged);
            // 
            // checkBox_HTML
            // 
            this.checkBox_HTML.AutoSize = true;
            this.checkBox_HTML.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_HTML.Location = new System.Drawing.Point(34, 249);
            this.checkBox_HTML.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBox_HTML.Name = "checkBox_HTML";
            this.checkBox_HTML.Size = new System.Drawing.Size(73, 25);
            this.checkBox_HTML.TabIndex = 7;
            this.checkBox_HTML.Text = "HTML";
            this.checkBox_HTML.UseVisualStyleBackColor = true;
            //this.checkBox_HTML.ThreeState = true;
            this.checkBox_HTML.CheckedChanged += new System.EventHandler(this.checkBox_HTML_CheckedChanged);
            // 
            // checkBox_Java
            // 
            this.checkBox_Java.AutoSize = true;
            this.checkBox_Java.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Java.Location = new System.Drawing.Point(34, 272);
            this.checkBox_Java.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBox_Java.Name = "checkBox_Java";
            this.checkBox_Java.Size = new System.Drawing.Size(61, 25);
            this.checkBox_Java.TabIndex = 8;
            this.checkBox_Java.Text = "Java";
            this.checkBox_Java.UseVisualStyleBackColor = true;
            //this.checkBox_Java.ThreeState = true;
            this.checkBox_Java.CheckedChanged += new System.EventHandler(this.checkBox_Java_CheckedChanged);
            // 
            // checkBox_JavaScript
            // 
            this.checkBox_JavaScript.AutoSize = true;
            this.checkBox_JavaScript.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_JavaScript.Location = new System.Drawing.Point(34, 295);
            this.checkBox_JavaScript.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBox_JavaScript.Name = "checkBox_JavaScript";
            this.checkBox_JavaScript.Size = new System.Drawing.Size(101, 25);
            this.checkBox_JavaScript.TabIndex = 9;
            this.checkBox_JavaScript.Text = "JavaScript";
            this.checkBox_JavaScript.UseVisualStyleBackColor = true;
            //this.checkBox_JavaScript.ThreeState = true;
            this.checkBox_JavaScript.CheckedChanged += new System.EventHandler(this.checkBox_JavaScript_CheckedChanged);
            // 
            // checkBox_VBScript
            // 
            this.checkBox_VBScript.AutoSize = true;
            this.checkBox_VBScript.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_VBScript.Location = new System.Drawing.Point(34, 319);
            this.checkBox_VBScript.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBox_VBScript.Name = "checkBox_VBScript";
            this.checkBox_VBScript.Size = new System.Drawing.Size(91, 25);
            this.checkBox_VBScript.TabIndex = 10;
            this.checkBox_VBScript.Text = "VBScript";
            this.checkBox_VBScript.UseVisualStyleBackColor = true;
            //this.checkBox_VBScript.ThreeState = true;
            this.checkBox_VBScript.CheckedChanged += new System.EventHandler(this.checkBox_VBScript_CheckedChanged);
            // 
            // checkBox_VB
            // 
            this.checkBox_VB.AutoSize = true;
            this.checkBox_VB.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_VB.Location = new System.Drawing.Point(34, 342);
            this.checkBox_VB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBox_VB.Name = "checkBox_VB";
            this.checkBox_VB.Size = new System.Drawing.Size(113, 25);
            this.checkBox_VB.TabIndex = 11;
            this.checkBox_VB.Text = "Visual Basic";
            this.checkBox_VB.UseVisualStyleBackColor = true;
            //this.checkBox_VB.ThreeState = true;
            this.checkBox_VB.CheckedChanged += new System.EventHandler(this.checkBox_VB_CheckedChanged);
            // 
            // checkBox_CS
            // 
            this.checkBox_CS.AutoSize = true;
            this.checkBox_CS.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_CS.Location = new System.Drawing.Point(34, 181);
            this.checkBox_CS.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBox_CS.Name = "checkBox_CS";
            this.checkBox_CS.Size = new System.Drawing.Size(49, 25);
            this.checkBox_CS.TabIndex = 12;
            this.checkBox_CS.Text = "C#";
            this.checkBox_CS.UseVisualStyleBackColor = true;
            //this.checkBox_CS.ThreeState = true;
            this.checkBox_CS.CheckedChanged += new System.EventHandler(this.checkBox_CS_CheckedChanged);
            // 
            // buttonDone
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(34, 405);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "buttonDone";
            this.button1.Size = new System.Drawing.Size(99, 32);
            this.button1.TabIndex = 13;
            this.button1.Text = "DONE";
            //this.button_ok.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // LanguageSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 534);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox_Assembler);
            this.Controls.Add(this.checkBox_Ada95);
            this.Controls.Add(this.checkBox_C);
            this.Controls.Add(this.checkBox_CPP);
            this.Controls.Add(this.checkBox_CS);
            this.Controls.Add(this.checkBox_COBOL);
            this.Controls.Add(this.checkBox_FORTRAN);
            this.Controls.Add(this.checkBox_HTML);
            this.Controls.Add(this.checkBox_Java);
            this.Controls.Add(this.checkBox_JavaScript);
            this.Controls.Add(this.checkBox_VBScript);
            this.Controls.Add(this.checkBox_VB);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "LanguageSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LanguageSelection";
            this.Load += new System.EventHandler(this.LanguageSelection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_Assembler;
        private System.Windows.Forms.CheckBox checkBox_Ada95;
        private System.Windows.Forms.CheckBox checkBox_C;
        private System.Windows.Forms.CheckBox checkBox_CPP;
        private System.Windows.Forms.CheckBox checkBox_CS;
        private System.Windows.Forms.CheckBox checkBox_COBOL;
        private System.Windows.Forms.CheckBox checkBox_FORTRAN;
        private System.Windows.Forms.CheckBox checkBox_HTML;
        private System.Windows.Forms.CheckBox checkBox_Java;
        private System.Windows.Forms.CheckBox checkBox_JavaScript;
        private System.Windows.Forms.CheckBox checkBox_VBScript;
        private System.Windows.Forms.CheckBox checkBox_VB;
        private System.Windows.Forms.Button button1;
    }
}