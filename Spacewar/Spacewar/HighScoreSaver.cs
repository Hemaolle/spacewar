using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Design;

namespace Spacewar
{
    public partial class HighScoreSaver : Form
    {
        
        public HighScoreSaver(int pisteet)
        {
            InitializeComponent();
            labelPisteet.Text = pisteet.ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxNimi.Text == "")
            {
                MessageBox.Show("Anna nimesi", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TextWriter tw = new StreamWriter("highscore.dat", true);
                tw.WriteLine(textBoxNimi.Text + "|" + labelPisteet.Text);
                tw.Close();
                Close();
            }
        }
    }
}
