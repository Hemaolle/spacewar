namespace Spacewar
{
    partial class HighScoreTest
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
            this.labelHSTitle = new System.Windows.Forms.Label();
            this.highScoreList1 = new Spacewar.HighScoreList();
            this.SuspendLayout();
            // 
            // labelHSTitle
            // 
            this.labelHSTitle.AutoSize = true;
            this.labelHSTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHSTitle.Location = new System.Drawing.Point(107, 28);
            this.labelHSTitle.Name = "labelHSTitle";
            this.labelHSTitle.Size = new System.Drawing.Size(96, 20);
            this.labelHSTitle.TabIndex = 1;
            this.labelHSTitle.Text = "High Scores";
            // 
            // highScoreList1
            // 
            this.highScoreList1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.highScoreList1.Location = new System.Drawing.Point(96, 61);
            this.highScoreList1.Name = "highScoreList1";
            this.highScoreList1.Naytetaan = 20;
            this.highScoreList1.Size = new System.Drawing.Size(294, 328);
            this.highScoreList1.TabIndex = 0;
            // 
            // HighScoreTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 514);
            this.Controls.Add(this.labelHSTitle);
            this.Controls.Add(this.highScoreList1);
            this.Name = "HighScoreTest";
            this.Text = "HighScoreTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HighScoreList highScoreList1;
        private System.Windows.Forms.Label labelHSTitle;













    }
}