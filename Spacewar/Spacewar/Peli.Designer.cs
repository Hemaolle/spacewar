namespace Spacewar
{
    partial class Peli
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Peli));
            this.timerAjastin = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxTausta = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTausta)).BeginInit();
            this.SuspendLayout();
            // 
            // timerAjastin
            // 
            this.timerAjastin.Enabled = true;
            this.timerAjastin.Interval = 35;
            this.timerAjastin.Tick += new System.EventHandler(this.pelisilmukka);
            // 
            // pictureBoxTausta
            // 
            this.pictureBoxTausta.Location = new System.Drawing.Point(1, 1);
            this.pictureBoxTausta.Name = "pictureBoxTausta";
            this.pictureBoxTausta.Size = new System.Drawing.Size(492, 566);
            this.pictureBoxTausta.TabIndex = 0;
            this.pictureBoxTausta.TabStop = false;
            this.pictureBoxTausta.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxTausta_Paint);
            // 
            // Peli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(492, 566);
            this.Controls.Add(this.pictureBoxTausta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(700, 200);
            this.MaximizeBox = false;
            this.Name = "Peli";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Spacewar";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Peli_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Peli_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Peli_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTausta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerAjastin;
        private System.Windows.Forms.PictureBox pictureBoxTausta;
    }
}