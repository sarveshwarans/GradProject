namespace WindowsFormsApp1
{
    partial class ProjectNew
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
            this.label_heading = new System.Windows.Forms.Label();
            this.label_projectName = new System.Windows.Forms.Label();
            this.label_productName = new System.Windows.Forms.Label();
            this.label_creator = new System.Windows.Forms.Label();
            this.textBox_projectName = new System.Windows.Forms.TextBox();
            this.textBox_productName = new System.Windows.Forms.TextBox();
            this.textBox_creator = new System.Windows.Forms.TextBox();
            this.label_comments = new System.Windows.Forms.Label();
            this.textBox_comments = new System.Windows.Forms.TextBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_heading
            // 
            this.label_heading.AutoSize = true;
            this.label_heading.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_heading.Location = new System.Drawing.Point(30, 29);
            this.label_heading.Name = "label_heading";
            this.label_heading.Size = new System.Drawing.Size(445, 37);
            this.label_heading.TabIndex = 0;
            this.label_heading.Text = "CECS 543 Metrics Suit New Project";
            // 
            // label_projectName
            // 
            this.label_projectName.AutoSize = true;
            this.label_projectName.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_projectName.Location = new System.Drawing.Point(33, 96);
            this.label_projectName.Name = "label_projectName";
            this.label_projectName.Size = new System.Drawing.Size(109, 21);
            this.label_projectName.TabIndex = 1;
            this.label_projectName.Text = "Project Name:";
            // 
            // label_productName
            // 
            this.label_productName.AutoSize = true;
            this.label_productName.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_productName.Location = new System.Drawing.Point(33, 130);
            this.label_productName.Name = "label_productName";
            this.label_productName.Size = new System.Drawing.Size(115, 21);
            this.label_productName.TabIndex = 2;
            this.label_productName.Text = "Product Name:";
            // 
            // label_creator
            // 
            this.label_creator.AutoSize = true;
            this.label_creator.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_creator.Location = new System.Drawing.Point(33, 163);
            this.label_creator.Name = "label_creator";
            this.label_creator.Size = new System.Drawing.Size(67, 21);
            this.label_creator.TabIndex = 3;
            this.label_creator.Text = "Creator:";
            // 
            // textBox_projectName
            // 
            this.textBox_projectName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_projectName.Location = new System.Drawing.Point(173, 96);
            this.textBox_projectName.Name = "textBox_projectName";
            this.textBox_projectName.Size = new System.Drawing.Size(292, 26);
            this.textBox_projectName.TabIndex = 4;
            // 
            // textBox_productName
            // 
            this.textBox_productName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_productName.Location = new System.Drawing.Point(173, 130);
            this.textBox_productName.Name = "textBox_productName";
            this.textBox_productName.Size = new System.Drawing.Size(292, 26);
            this.textBox_productName.TabIndex = 5;
            // 
            // textBox_creator
            // 
            this.textBox_creator.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_creator.Location = new System.Drawing.Point(173, 163);
            this.textBox_creator.Name = "textBox_creator";
            this.textBox_creator.Size = new System.Drawing.Size(292, 26);
            this.textBox_creator.TabIndex = 6;
            // 
            // label_comments
            // 
            this.label_comments.AutoSize = true;
            this.label_comments.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_comments.Location = new System.Drawing.Point(33, 199);
            this.label_comments.Name = "label_comments";
            this.label_comments.Size = new System.Drawing.Size(91, 21);
            this.label_comments.TabIndex = 7;
            this.label_comments.Text = "Comments:";
            // 
            // textBox_comments
            // 
            this.textBox_comments.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_comments.Location = new System.Drawing.Point(37, 223);
            this.textBox_comments.Multiline = true;
            this.textBox_comments.Name = "textBox_comments";
            this.textBox_comments.Size = new System.Drawing.Size(428, 100);
            this.textBox_comments.TabIndex = 8;
            // 
            // button_ok
            // 
            this.button_ok.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ok.Location = new System.Drawing.Point(150, 349);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(88, 30);
            this.button_ok.TabIndex = 9;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancel.Location = new System.Drawing.Point(255, 349);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(88, 30);
            this.button_cancel.TabIndex = 10;
            this.button_cancel.Text = "CANCEL";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // ProjectNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 399);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.textBox_comments);
            this.Controls.Add(this.label_comments);
            this.Controls.Add(this.textBox_creator);
            this.Controls.Add(this.textBox_productName);
            this.Controls.Add(this.textBox_projectName);
            this.Controls.Add(this.label_creator);
            this.Controls.Add(this.label_productName);
            this.Controls.Add(this.label_projectName);
            this.Controls.Add(this.label_heading);
            this.Name = "ProjectNew";
            this.Text = "New Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_heading;
        private System.Windows.Forms.Label label_projectName;
        private System.Windows.Forms.Label label_productName;
        private System.Windows.Forms.Label label_creator;
        private System.Windows.Forms.TextBox textBox_projectName;
        private System.Windows.Forms.TextBox textBox_productName;
        private System.Windows.Forms.TextBox textBox_creator;
        private System.Windows.Forms.Label label_comments;
        private System.Windows.Forms.TextBox textBox_comments;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
    }
}