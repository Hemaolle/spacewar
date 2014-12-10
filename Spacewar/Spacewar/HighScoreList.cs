using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Spacewar
{
    public partial class HighScoreList : UserControl
    {
        Label labelName;
        Label labelScore;
        int naytetaan = 10;
        [Description("Montako parasta tulosta näytetään?s")]
        [DefaultValue(10)]
        public int Naytetaan
        {
            get { return naytetaan; }
            set
            {
                naytetaan = value;
                initializeLabels();
                updateList();
            }
        }

        public HighScoreList()
        {
            InitializeComponent();

            initializeLabels();

            updateList();
        }

        public void initializeLabels()
        {
            labelName = new System.Windows.Forms.Label();

            labelName.AutoSize = true;
            labelName.Location = new System.Drawing.Point(14, 24);
            labelName.Name = "labelName";
            labelName.TabIndex = 0;

            labelScore = new System.Windows.Forms.Label();

            labelScore.AutoSize = true;
            labelScore.Location = new System.Drawing.Point(100, 24);
            labelScore.Name = "labelScore";
            labelScore.TabIndex = 1;
            labelScore.TextAlign = ContentAlignment.TopRight;
            labelScore.Visible = true;
        }

        public void updateList()
        {
            
            
            
                TextReader tr = new StreamReader("highscore.dat");
                //TextReader tr = new StreamReader("highscore.dat");
                // read a line of text

                labelName.Text = "";

                int riveja = 0;
                string rivi = tr.ReadLine();
                for (; rivi != null; rivi = tr.ReadLine())
                {
                    riveja++;
                }
                
                tr.Close();

                Pistetieto[] pistetiedot = new Pistetieto[riveja];
                long[] pisteet = new long[riveja];
            
                tr = new StreamReader("highscore.dat");
                rivi = tr.ReadLine();
                for (int i = 0; rivi != null && rivi != ""; rivi = tr.ReadLine(), i++)
                {
                    int valimerkki = rivi.IndexOf('|');
                    pistetiedot[i] = new Pistetieto();
                    pistetiedot[i].Nimi = rivi.Substring(0, valimerkki);
                    pistetiedot[i].Pisteet = Int64.Parse(rivi.Substring(valimerkki + 1));
                    pisteet[i] = pistetiedot[i].Pisteet;

                }


                Array.Sort(pisteet, pistetiedot);
                Array.Reverse(pistetiedot);

                //label2.Text += riveja.ToString() + "\n";
                //label2.Text += pistetiedot[0].Nimi + pistetiedot[0].Pisteet;

                for (int i = 0; i < this.Naytetaan && i < riveja; i++)
                {
                    Pistetieto tieto = pistetiedot[i];
                    labelName.Text += (i + 1).ToString() + ". ";
                    labelName.Text += tieto.Nimi + "\n";
                    //labelName.Text += "          ";
                    labelScore.Text += tieto.Pisteet.ToString() + "\n";
                }
                Controls.Add(labelName);
                Controls.Add(labelScore);
                //this.Size = labelName.Size;
                // close the stream
                tr.Close();
            /*}
            catch (Exception e)
            {

            }*/
        }
    }

    

    public class Pistetieto
    {
        public long Pisteet { get; set; }
        public string Nimi { get; set; }
    }
}
