namespace Spacewar
{
    partial class Paavalikko
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paavalikko));
            this.buttonPelaa = new System.Windows.Forms.Button();
            this.buttonAsetukset = new System.Windows.Forms.Button();
            this.buttonApua = new System.Windows.Forms.Button();
            this.buttonPoistu = new System.Windows.Forms.Button();
            this.pictureBoxAlus = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPelaa
            // 
            this.buttonPelaa.BackColor = System.Drawing.Color.DarkOrchid;
            this.buttonPelaa.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPelaa.Location = new System.Drawing.Point(24, 97);
            this.buttonPelaa.Name = "buttonPelaa";
            this.buttonPelaa.Size = new System.Drawing.Size(218, 54);
            this.buttonPelaa.TabIndex = 0;
            this.buttonPelaa.Text = "Pelaa";
            this.buttonPelaa.UseVisualStyleBackColor = false;
            this.buttonPelaa.Click += new System.EventHandler(this.buttonPelaa_Click);
            // 
            // buttonAsetukset
            // 
            this.buttonAsetukset.BackColor = System.Drawing.Color.DarkOrchid;
            this.buttonAsetukset.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAsetukset.Location = new System.Drawing.Point(24, 157);
            this.buttonAsetukset.Name = "buttonAsetukset";
            this.buttonAsetukset.Size = new System.Drawing.Size(218, 54);
            this.buttonAsetukset.TabIndex = 1;
            this.buttonAsetukset.Text = "Pistelista";
            this.buttonAsetukset.UseVisualStyleBackColor = false;
            this.buttonAsetukset.Click += new System.EventHandler(this.buttonAsetukset_Click);
            // 
            // buttonApua
            // 
            this.buttonApua.BackColor = System.Drawing.Color.DarkOrchid;
            this.buttonApua.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApua.Location = new System.Drawing.Point(24, 217);
            this.buttonApua.Name = "buttonApua";
            this.buttonApua.Size = new System.Drawing.Size(218, 54);
            this.buttonApua.TabIndex = 2;
            this.buttonApua.Text = "Apua";
            this.buttonApua.UseVisualStyleBackColor = false;
            this.buttonApua.Click += new System.EventHandler(this.buttonApua_Click);
            // 
            // buttonPoistu
            // 
            this.buttonPoistu.BackColor = System.Drawing.Color.DarkOrchid;
            this.buttonPoistu.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPoistu.Location = new System.Drawing.Point(24, 277);
            this.buttonPoistu.Name = "buttonPoistu";
            this.buttonPoistu.Size = new System.Drawing.Size(218, 54);
            this.buttonPoistu.TabIndex = 3;
            this.buttonPoistu.Text = "Poistu";
            this.buttonPoistu.UseVisualStyleBackColor = false;
            this.buttonPoistu.Click += new System.EventHandler(this.buttonPoistu_Click);
            // 
            // pictureBoxAlus
            // 
            this.pictureBoxAlus.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxAlus.Image")));
            this.pictureBoxAlus.InitialImage = null;
            this.pictureBoxAlus.Location = new System.Drawing.Point(24, 388);
            this.pictureBoxAlus.Name = "pictureBoxAlus";
            this.pictureBoxAlus.Size = new System.Drawing.Size(63, 72);
            this.pictureBoxAlus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAlus.TabIndex = 4;
            this.pictureBoxAlus.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(179, 388);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Paavalikko
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(267, 524);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBoxAlus);
            this.Controls.Add(this.buttonPoistu);
            this.Controls.Add(this.buttonApua);
            this.Controls.Add(this.buttonAsetukset);
            this.Controls.Add(this.buttonPelaa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Paavalikko";
            this.Text = "Spacewar";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPelaa;
        private System.Windows.Forms.Button buttonAsetukset;
        private System.Windows.Forms.Button buttonApua;
        private System.Windows.Forms.Button buttonPoistu;
        private System.Windows.Forms.PictureBox pictureBoxAlus;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

