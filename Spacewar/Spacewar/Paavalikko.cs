using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spacewar
{
    public partial class Paavalikko : Form
    {
        public Paavalikko()
        {
            InitializeComponent();
        }

        private void buttonPoistu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonPelaa_Click(object sender, EventArgs e)
        {
            Peli peli = new Peli(this);
            peli.Show();
            Hide();
        }

        private void buttonApua_Click(object sender, EventArgs e)
        {
            Avustus avustus = new Avustus();
            avustus.Show();
        }

        private void buttonAsetukset_Click(object sender, EventArgs e)
        {
            HighScoreTest high = new HighScoreTest();
            /*HighScoreList highScoreList1 = new HighScoreList();
            highScoreList1.Location = new System.Drawing.Point(105, 101);
            highScoreList1.Name = "highScoreList1";
            highScoreList1.Naytetaan = 0;
            highScoreList1.Size = new System.Drawing.Size(294, 328);
            highScoreList1.TabIndex = 0;
            high.Controls.Add(highScoreList1);
            highScoreList1.Naytetaan = 15;*/
            high.Show();
        }
    }
}
