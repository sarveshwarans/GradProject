namespace BookQueries
{
    partial class BooksQueryForm
    {
        private System.ComponentModel.IContainer cmComponent = null;

        /// <summary>
        /// This cleans up the memory which is being used. 
        /// </summary>
        /// <param name="boolDisposing"> If the managed resource has to be disposed then this is set to TRUE. 
        /// Else, this is set to FALSE.</param>
        protected override void Dispose(bool boolDisposing)
        {
            if (boolDisposing && (cmComponent != null))
            {
                cmComponent.Dispose();
            }
            base.Dispose(boolDisposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Full = new System.Windows.Forms.Button();
            this.textBoxResultText = new System.Windows.Forms.TextBox();
            this.button_OptA = new System.Windows.Forms.Button();
            this.button_OptB = new System.Windows.Forms.Button();
            this.button_OptC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_FullOutput
            // 
            this.button_Full.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Full.Location = new System.Drawing.Point(15, 24);
            this.button_Full.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Full.Name = "buttonGetData";
            this.button_Full.Size = new System.Drawing.Size(144, 41);
            this.button_Full.TabIndex = 0;
            this.button_Full.Text = "FULL OUTPUT";
            this.button_Full.UseVisualStyleBackColor = true;
            this.button_Full.Click += new System.EventHandler(this.button_FullOutput);
            // 
            // textBoxResultText
            // 
            this.textBoxResultText.BackColor = System.Drawing.SystemColors.InfoText;
            this.textBoxResultText.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxResultText.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxResultText.Location = new System.Drawing.Point(15, 85);
            this.textBoxResultText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxResultText.Multiline = true;
            this.textBoxResultText.Name = "textBoxResultText";
            this.textBoxResultText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxResultText.Size = new System.Drawing.Size(625, 452);
            this.textBoxResultText.TabIndex = 3;
            // 
            // button_OptionA
            // 
            this.button_OptA.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OptA.Location = new System.Drawing.Point(177, 24);
            this.button_OptA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_OptA.Name = "button1";
            this.button_OptA.Size = new System.Drawing.Size(144, 41);
            this.button_OptA.TabIndex = 4;
            this.button_OptA.Text = "OPTION A";
            this.button_OptA.UseVisualStyleBackColor = true;
            this.button_OptA.Click += new System.EventHandler(this.button_OptionA);
            // 
            // button_OptionB
            // 
            this.button_OptB.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OptB.Location = new System.Drawing.Point(339, 24);
            this.button_OptB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_OptB.Name = "button2";
            this.button_OptB.Size = new System.Drawing.Size(144, 41);
            this.button_OptB.TabIndex = 5;
            this.button_OptB.Text = "OPTION B";
            this.button_OptB.UseVisualStyleBackColor = true;
            this.button_OptB.Click += new System.EventHandler(this.button_OptionB);
            // 
            // button_OptionC
            // 
            this.button_OptC.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OptC.Location = new System.Drawing.Point(496, 24);
            this.button_OptC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_OptC.Name = "button3";
            this.button_OptC.Size = new System.Drawing.Size(144, 41);
            this.button_OptC.TabIndex = 6;
            this.button_OptC.Text = "OPTION C";
            this.button_OptC.UseVisualStyleBackColor = true;
            this.button_OptC.Click += new System.EventHandler(this.button_OptionC);
            // 
            // BooksQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(652, 550);
            this.Controls.Add(this.button_OptC);
            this.Controls.Add(this.button_OptB);
            this.Controls.Add(this.button_OptA);
            this.Controls.Add(this.textBoxResultText);
            this.Controls.Add(this.button_Full);
            this.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BooksQueryForm";
            this.Text = "Title and Author";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Full;
        private System.Windows.Forms.TextBox textBoxResultText;
        private System.Windows.Forms.Button button_OptA;
        private System.Windows.Forms.Button button_OptB;
        private System.Windows.Forms.Button button_OptC;
    }
}