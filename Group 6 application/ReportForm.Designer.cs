namespace Group_6_application
{
    partial class ReportForm
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
            this.TbreportDescription = new System.Windows.Forms.TextBox();
            this.BtnSendReport = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TbreportDescription
            // 
            this.TbreportDescription.Location = new System.Drawing.Point(12, 12);
            this.TbreportDescription.Multiline = true;
            this.TbreportDescription.Name = "TbreportDescription";
            this.TbreportDescription.Size = new System.Drawing.Size(416, 196);
            this.TbreportDescription.TabIndex = 0;
            // 
            // BtnSendReport
            // 
            this.BtnSendReport.Location = new System.Drawing.Point(149, 214);
            this.BtnSendReport.Name = "BtnSendReport";
            this.BtnSendReport.Size = new System.Drawing.Size(145, 49);
            this.BtnSendReport.TabIndex = 1;
            this.BtnSendReport.Text = "Send Report";
            this.BtnSendReport.UseVisualStyleBackColor = true;
            this.BtnSendReport.Click += new System.EventHandler(this.BtnSendReport_Click);
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(351, 219);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(77, 60);
            this.btnback.TabIndex = 2;
            this.btnback.Text = " Back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 291);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.BtnSendReport);
            this.Controls.Add(this.TbreportDescription);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbreportDescription;
        private System.Windows.Forms.Button BtnSendReport;
        private System.Windows.Forms.Button btnback;
    }
}