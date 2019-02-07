namespace BookQueries
{
   partial class JoiningTableData
   {
      private System.ComponentModel.IContainer cmComponents = null;

        /// <summary>
        /// This cleans up the memory which is being used. 
        /// </summary>
        /// <param name="boolDisposing"> If the managed resource has to be disposed then this is set to TRUE. 
        /// Else, this is set to FALSE.</param>
        protected override void Dispose( bool boolDisposing )
      {
         if ( boolDisposing && ( cmComponents != null ) )
         {
            cmComponents.Dispose();
         }
         base.Dispose( boolDisposing );
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
            this.textBoxOutputTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxOutputTextBox
            // 
            this.textBoxOutputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutputTextBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOutputTextBox.Location = new System.Drawing.Point(12, 12);
            this.textBoxOutputTextBox.Multiline = true;
            this.textBoxOutputTextBox.Name = "textBoxOutputTextBox";
            this.textBoxOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutputTextBox.Size = new System.Drawing.Size(502, 319);
            this.textBoxOutputTextBox.TabIndex = 1;
            // 
            // JoiningTableData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 343);
            this.Controls.Add(this.textBoxOutputTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "JoiningTableData";
            this.Text = "Joining Tables with LINQ";
            this.Load += new System.EventHandler(this.JoiningTableData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox textBoxOutputTextBox;
   }
}

