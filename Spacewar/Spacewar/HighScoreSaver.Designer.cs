namespace Spacewar
{
    partial class HighScoreSaver
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
            this.labelPisteetOtsikko = new System.Windows.Forms.Label();
            this.labelPisteet = new System.Windows.Forms.Label();
            this.labelNimiOtsikko = new System.Windows.Forms.Label();
            this.textBoxNimi = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelPisteetOtsikko
            // 
            this.labelPisteetOtsikko.AutoSize = true;
            this.labelPisteetOtsikko.Location = new System.Drawing.Point(36, 26);
            this.labelPisteetOtsikko.Name = "labelPisteetOtsikko";
            this.labelPisteetOtsikko.Size = new System.Drawing.Size(42, 13);
            this.labelPisteetOtsikko.TabIndex = 0;
            this.labelPisteetOtsikko.Text = "Pisteet:";
            // 
            // labelPisteet
            // 
            this.labelPisteet.AutoSize = true;
            this.labelPisteet.Location = new System.Drawing.Point(84, 26);
            this.labelPisteet.Name = "labelPisteet";
            this.labelPisteet.Size = new System.Drawing.Size(0, 13);
            this.labelPisteet.TabIndex = 1;
            // 
            // labelNimiOtsikko
            // 
            this.labelNimiOtsikko.AutoSize = true;
            this.labelNimiOtsikko.Location = new System.Drawing.Point(36, 54);
            this.labelNimiOtsikko.Name = "labelNimiOtsikko";
            this.labelNimiOtsikko.Size = new System.Drawing.Size(41, 13);
            this.labelNimiOtsikko.TabIndex = 2;
            this.labelNimiOtsikko.Text = "Nimesi:";
            // 
            // textBoxNimi
            // 
            this.textBoxNimi.Location = new System.Drawing.Point(83, 51);
            this.textBoxNimi.Name = "textBoxNimi";
            this.textBoxNimi.Size = new System.Drawing.Size(100, 20);
            this.textBoxNimi.TabIndex = 3;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(87, 92);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // HighScoreSaver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 146);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxNimi);
            this.Controls.Add(this.labelNimiOtsikko);
            this.Controls.Add(this.labelPisteet);
            this.Controls.Add(this.labelPisteetOtsikko);
            this.Name = "HighScoreSaver";
            this.Text = "Pääsit High Score -listalle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPisteetOtsikko;
        private System.Windows.Forms.Label labelPisteet;
        private System.Windows.Forms.Label labelNimiOtsikko;
        private System.Windows.Forms.TextBox textBoxNimi;
        private System.Windows.Forms.Button buttonOK;
    }
}