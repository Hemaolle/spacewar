using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Spacewar
{
    public partial class Peli : Form
    {
        ArrayList nappaimet = new ArrayList();
       
        public static int vihollistenMaxMaara = 30;
        public int publicVihollisetnMax = vihollistenMaxMaara;
        int pisteet = 0;
        int elamat = 5;
        int aikalaskuri = 0;
        int leveys;
        bool kenttaAlkaa = true;
        bool gameOver = false;
        public Vihollinen[] viholliset = new Vihollinen[vihollistenMaxMaara];
        OmaAlus omaAlus;
        Rajahdys[] rajahdykset = new Rajahdys[vihollistenMaxMaara];
        static int ohjeidenMaxMaara = 200;
        OhjeYksikko[] ohjeet = new OhjeYksikko[ohjeidenMaxMaara];
        static int tahtienMaxMaara = 100;
        LiikkuvaKohde[] tahdet = new LiikkuvaKohde[tahtienMaxMaara];
        string lopputeksti = "HÄVISIT";

        static int ammustenMaxMaara = 40;
        
        Ammus[] ammus = new Ammus[ammustenMaxMaara];
        
        Random random = new Random();        
        
        Image imageAlus = new Bitmap("alus.png");

        Paavalikko paavalikko;

        /*
         * Alustetaan peli ja aluksen tiedot
         */
        public Peli(Paavalikko valikko)
        {
            
            paavalikko = valikko;
            InitializeComponent();
            leveys = Width - 40;
            //alustaVihollinen();
            alustaOmaAlus();
            Vihollinen.pelinKorkeus = Height;
            Vihollinen.pelinLeveys = Width;
            int i = 0;
            //reunoilla
            
            ohjeet[i] = new OhjeYksikko(80, new Viholliset.PunainenParoni(80, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(150, new Viholliset.PunainenParoni(leveys - 80, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(220, new Viholliset.PunainenParoni(80, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(290, new Viholliset.PunainenParoni(leveys - 80, -40, 0, 8, i)); i++;
            
            // 3 ryhmä keskellä
            ohjeet[i] = new OhjeYksikko(360, new Viholliset.PunainenParoni(leveys/2, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(370, new Viholliset.PunainenParoni(leveys/2 - 100, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(370, new Viholliset.PunainenParoni(leveys / 2 + 100, -40, 0, 8, i)); i++;

            ohjeet[i] = new OhjeYksikko(440, new Viholliset.SininenSivaltajaB(leveys / 2 - 80, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(440, new Viholliset.SininenSivaltajaB(leveys / 2 + 80, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(450, new Viholliset.SininenSivaltajaB(leveys / 2 - 80, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(450, new Viholliset.SininenSivaltajaB(leveys / 2 + 80, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(460, new Viholliset.SininenSivaltajaB(leveys / 2 - 80, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(460, new Viholliset.SininenSivaltajaB(leveys / 2 + 80, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(470, new Viholliset.SininenSivaltajaB(leveys / 2 - 80, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(470, new Viholliset.SininenSivaltajaB(leveys / 2 + 80, -40, 0, 8, i)); i++;

            ohjeet[i] = new OhjeYksikko(540, new Viholliset.PunainenParoni(50, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(540, new Viholliset.PunainenParoni(150, -40, 0, 8, i)); i++;

            ohjeet[i] = new OhjeYksikko(580, new Viholliset.PunainenParoni(50, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(580, new Viholliset.PunainenParoni(150, -40, 0, 8, i)); i++;

            ohjeet[i] = new OhjeYksikko(650, new Viholliset.SininenSivaltaja(leveys - 100, -40, 0, 8, i)); i++;

            ohjeet[i] = new OhjeYksikko(700, new Viholliset.VihreaVipeltaja(100, -40, 0, 3, i)); i++;
            ohjeet[i] = new OhjeYksikko(760, new Viholliset.VihreaVipeltaja(leveys - 100, -40, 0, 3, i)); i++;
            ohjeet[i] = new OhjeYksikko(820, new Viholliset.VihreaVipeltaja(100, -40, 0, 3, i)); i++;
            ohjeet[i] = new OhjeYksikko(880, new Viholliset.VihreaVipeltaja(leveys - 100, -40, 0, 3, i)); i++;
            ohjeet[i] = new OhjeYksikko(940, new Viholliset.VihreaVipeltaja(100, -40, 0, 3, i)); i++;
            ohjeet[i] = new OhjeYksikko(1000, new Viholliset.VihreaVipeltaja(leveys - 100, -40, 0, 3, i)); i++;

            ohjeet[i] = new OhjeYksikko(1000, new Viholliset.PunainenParoniB(leveys/2, -40, 3, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(1010, new Viholliset.PunainenParoniB(leveys / 2, -40, 3, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(1020, new Viholliset.PunainenParoniB(leveys / 2, -40, 3, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(1030, new Viholliset.PunainenParoniB(leveys / 2, -40, 3, 8, i)); i++;
            
            //seuraavat 7 riviä toistaa saman kuvion kuin alussa
            ohjeet[i] = new OhjeYksikko(1100, new Viholliset.PunainenParoni(80, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(1170, new Viholliset.PunainenParoni(leveys - 80, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(1240, new Viholliset.PunainenParoni(80, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(1310, new Viholliset.PunainenParoni(leveys - 80, -40, 0, 8, i)); i++;

            // 3 ryhmä keskellä
            ohjeet[i] = new OhjeYksikko(1380, new Viholliset.PunainenParoni(leveys / 2, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(1390, new Viholliset.PunainenParoni(leveys / 2 - 100, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(1390, new Viholliset.PunainenParoni(leveys / 2 + 100, -40, 0, 8, i)); i++;

            ohjeet[i] = new OhjeYksikko(1450, new Viholliset.OranssiOlio(leveys / 2, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(1550, new Viholliset.OranssiOlio(leveys / 2, -40, 0, 8, i)); i++;

            for (int j = 35; j < leveys; j += 50)
            {
                ohjeet[i] = new OhjeYksikko(1620, new Viholliset.HarmaaHaikala(j, -40, 0, 8, i)); i++;
            }

            for (int j = 35; j < leveys; j += 50)
            {
                ohjeet[i] = new OhjeYksikko(1650, new Viholliset.HarmaaHaikala(j, -40, 0, 8, i)); i++;
            }

            for (int j = 35; j < leveys; j += 50)
            {
                ohjeet[i] = new OhjeYksikko(1680, new Viholliset.HarmaaHaikala(j, -40, 0, 8, i)); i++;
            }

            for (int j = 35; j < leveys; j += 50)
            {
                ohjeet[i] = new OhjeYksikko(1710, new Viholliset.HarmaaHaikalaB(j, -40, 0, 8, i)); i++;
            }

            for (int j = 35; j < leveys; j += 50)
            {
                ohjeet[i] = new OhjeYksikko(1720, new Viholliset.HarmaaHaikalaB(j, -40, 0, 8, i)); i++;
            }

            ohjeet[i] = new OhjeYksikko(1800, new Viholliset.OranssiOlio(150, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(1800, new Viholliset.OranssiOlio(leveys-150, -40, 0, 8, i)); i++;

            for (int j = 35; j < leveys; j += 50)
            {
                ohjeet[i] = new OhjeYksikko(1865 + j/7, new Viholliset.SininenSivaltaja(j, -40, 0, 8, i)); i++;
            }
            for (int j = 85; j < leveys; j += 50)
            {
                ohjeet[i] = new OhjeYksikko(1922 + j / 7, new Viholliset.SininenSivaltaja(leveys - j, -40, 0, 8, i)); i++;
            }

            ohjeet[i] = new OhjeYksikko(2000, new Viholliset.VihreaVipeltaja(75, -40, 0, 3, i)); i++;
            ohjeet[i] = new OhjeYksikko(2000, new Viholliset.VihreaVipeltaja(leveys-75, -40, 0, 3, i)); i++;
            ohjeet[i] = new OhjeYksikko(2040, new Viholliset.VihreaVipeltaja(leveys/2, -40, 0, 3, i)); i++;
            ohjeet[i] = new OhjeYksikko(2080, new Viholliset.VihreaVipeltaja(100, -40, 0, 3, i)); i++;
            ohjeet[i] = new OhjeYksikko(2080, new Viholliset.VihreaVipeltaja(leveys-100,-40, 0, 3, i)); i++;

            ohjeet[i] = new OhjeYksikko(2140, new Viholliset.PunainenParoni(leveys / 2, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(2150, new Viholliset.PunainenParoni(leveys / 2 - 100, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(2150, new Viholliset.PunainenParoni(leveys / 2 + 100, -40, 0, 8, i)); i++;

            ohjeet[i] = new OhjeYksikko(2170, new Viholliset.PunainenParoni(leveys / 2, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(2180, new Viholliset.PunainenParoni(75, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(2180, new Viholliset.PunainenParoni(leveys -75, -40, 0, 8, i)); i++;

            ohjeet[i] = new OhjeYksikko(2200, new Viholliset.PunainenParoni(leveys / 2, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(2200, new Viholliset.PunainenParoni(75, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(2200, new Viholliset.PunainenParoni(leveys - 75, -40, 0, 8, i)); i++;

            ohjeet[i] = new OhjeYksikko(2220, new Viholliset.PunainenParoni(leveys / 2, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(2220, new Viholliset.PunainenParoni(75, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(2220, new Viholliset.PunainenParoni(leveys - 75, -40, 0, 8, i)); i++;

            ohjeet[i] = new OhjeYksikko(2240, new Viholliset.PunainenParoni(leveys / 2, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(2240, new Viholliset.PunainenParoni(75, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(2240, new Viholliset.PunainenParoni(leveys - 75, -40, 0, 8, i)); i++;

            ohjeet[i] = new OhjeYksikko(2300, new Viholliset.OranssiOlio(leveys / 2, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(2350, new Viholliset.OranssiOlio(leveys / 2, -40, 0, 8, i)); i++;

            ohjeet[i] = new OhjeYksikko(2400, new Viholliset.SininenSivaltajaB(leveys / 2 - 80, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(2400, new Viholliset.SininenSivaltajaB(leveys / 2 + 80, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(2410, new Viholliset.SininenSivaltajaB(leveys / 2 - 80, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(2410, new Viholliset.SininenSivaltajaB(leveys / 2 + 80, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(2420, new Viholliset.SininenSivaltajaB(leveys / 2 - 80, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(2420, new Viholliset.SininenSivaltajaB(leveys / 2 + 80, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(2430, new Viholliset.SininenSivaltajaB(leveys / 2 - 80, -40, 0, 8, i)); i++;
            ohjeet[i] = new OhjeYksikko(2430, new Viholliset.SininenSivaltajaB(leveys / 2 + 80, -40, 0, 8, i)); i++;

            ohjeet[i] = new OhjeYksikko(2500, new Viholliset.HarmaaHaikalaB(leveys/2, -40, 0, 8, i)); i++;

            for (int j = 50; j < leveys/2; j += 50)
            {
                ohjeet[i] = new OhjeYksikko(2500 + j/7, new Viholliset.HarmaaHaikalaB(leveys/2 - j, -40, 0, 8, i)); i++;
                ohjeet[i] = new OhjeYksikko(2500 + j/7, new Viholliset.HarmaaHaikalaB(leveys/2 + j, -40, 0, 8, i)); i++;
            }

            ohjeet[i] = new OhjeYksikko(2530, new Viholliset.HarmaaHaikalaB(leveys / 2, -40, 0, 8, i)); i++;

            for (int j = 50; j < leveys / 2; j += 50)
            {
                ohjeet[i] = new OhjeYksikko(2530 + j / 7, new Viholliset.HarmaaHaikalaB(leveys / 2 - j, -40, 0, 8, i)); i++;
                ohjeet[i] = new OhjeYksikko(2530 + j / 7, new Viholliset.HarmaaHaikalaB(leveys / 2 + j, -40, 0, 8, i)); i++;
            }

            ohjeet[i] = new OhjeYksikko(2800, new Viholliset.Loppuvastus(leveys/2-125, -160, 0, 2, i,this)); i++;

            for (int j = 0; j < 100; j++)
            {
                luoTahti();
                liikutaTahtia();
            }
        }

        /*
       * Pelisilmukka.
       */
        private void pelisilmukka(object sender, EventArgs e)
        {
            if (gameOver == false)
            {
                reagoiNappaimiin();
                liikutaAlusta();
                liikutaVihollista();
                tarkastaTormaykset();
                suoritaOhjeet();
                aikalaskuri++;
                luoTahti();
                liikutaTahtia();
                pictureBoxTausta.Invalidate();
            }
            else
            {
                pictureBoxTausta.Invalidate();
                HighScoreSaver pisteetPopup = new HighScoreSaver(pisteet);
                pisteetPopup.Show();
                timerAjastin.Enabled = false;
            }
        }

        private void suoritaOhjeet()
        {
            for (int i = 0; i < ohjeidenMaxMaara; i++)
            {
                if (ohjeet[i]!= null)
                    if (aikalaskuri == ohjeet[i].Aika)
                        alustaVihollinen(ohjeet[i].Vihu);
            }
        }

        private void luoTahti()
        {
            for (int i = 0; i < tahtienMaxMaara; i++)
            {
                if (tahdet[i] == null)
                {
                    if (random.NextDouble() < 0.3)
                        tahdet[i] = new LiikkuvaKohde(random.Next(Width), 0, 0, (float)(random.NextDouble() * 10 + 5), 1, 1, true, new Bitmap("ammus3.png"));                    
                    return;
                }
            }
        }

        private void liikutaTahtia()
        {
            for (int i = 0; i < tahtienMaxMaara; i++)
            {
                if (tahdet[i] != null)
                {
                    tahdet[i].Y += tahdet[i].NopeusY;
                    if (tahdet[i].Y > Height)
                        tahdet[i] = null;
                }
            }
        }

        /*
         * Liikutetaan vihollista sen nopeuden verran.
         */
        private void liikutaVihollista()
        {
            for (int i = 0; i < vihollistenMaxMaara; i++)
            {
                if (viholliset[i] != null)
                {
                    viholliset[i].liikuta();                    
                }
            }

            //vihollinen.liikuta(Width, Height);            
        }

        private void alustaOmaAlus()
        {
            if (kenttaAlkaa)
            {
                omaAlus = new OmaAlus(Width, Height, false);                
                kenttaAlkaa = false;
            }
            else
            {
                omaAlus = new OmaAlus(Width, Height, true);                
            }
            omaAlus.Tuhotaan += new OmaAlusTuhotaanEventHandler(omaAlus_Tuhotaan);
        }

        public void omaAlus_Tuhotaan(object sender, EventArgs e)
        {
            alustaOmaAlus();
        }

        /*
         *Alustetaan vihollinen.
         */
        private void alustaVihollinen()
        {
            for (int i = 0; i < vihollistenMaxMaara; i++)
            {
                if (viholliset[i] == null)
                {
                    viholliset[i] = new Viholliset.PunainenParoni(random.Next(Width - 40), -40, (float)random.NextDouble() * 4 - 2, 5, i);
                    viholliset[i].Tuhotaan += new VihollinenTuhotaanEventHandler(Peli_VihollinenTuhoutui);
                    return;
                }
            }
        }

        private void alustaVihollinen(Vihollinen vihollinen)
        {
            for (int i = 0; i < vihollistenMaxMaara; i++)
            {
                if (viholliset[i] == null)
                {
                    viholliset[i] = vihollinen;
                    viholliset[i].Id = i;
                    viholliset[i].Tuhotaan += new VihollinenTuhotaanEventHandler(Peli_VihollinenTuhoutui);
                    return;
                }
            }           
        }

        public void Peli_VihollinenTuhoutui(object sender, EventArgs e)
        {
            if (sender is Viholliset.Loppuvastus)
            {
                lopputeksti = "   VOITIT!";
                gameOver = true;
            }            
            viholliset[((Vihollinen)sender).Id] = null;
        }

        
        /*
         * Kun näppäin painetaan alas, se lisätään alas
         * painettujen näppäinten listaan. Sama näppäin lisätään
         * kuitenkin vain kerran.
         */
        private void Peli_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space && gameOver == true)
            {
                Close();
                paavalikko.Show();
            }
            if (!nappaimet.Contains(e.KeyData))
                nappaimet.Add(e.KeyData);
        }

        /*
         * Kun näppäin nostetaan ylös, se poistetaan painettujen 
         * näppäinten listasta.
         */
        private void Peli_KeyUp(object sender, KeyEventArgs e)
        {
            if (nappaimet.Contains(e.KeyData))
                nappaimet.Remove(e.KeyData);
        }       

        /*
         * Tarkastaa törmääkö joku ammuksista viholliseen. Jos törmää, vihollinen laitetaan pois näkyvistä
         * ja sen kohdalla laukaistaan räjähdys.
         */
        private void tarkastaTormaykset()
        {
            for (int i = 0; i < vihollistenMaxMaara; i++)
            {
                if (viholliset[i] != null)
                {
                    Rectangle rectVihollinen = new Rectangle((int)viholliset[i].X, (int)viholliset[i].Y, (int)viholliset[i].Leveys, (int)viholliset[i].Korkeus);
                    Rectangle rectAlus = new Rectangle((int)omaAlus.X, (int)omaAlus.Y, (int)omaAlus.Leveys, (int)omaAlus.Korkeus);
                    
                    //osuuko oma ammus viholliseen?
                    for (int j = 0; j < omaAlus.MaxAmmukset; j++)
                    {
                        if (omaAlus.Ammukset[j] != null)
                        {
                            Rectangle rectAmmus = new Rectangle((int)omaAlus.Ammukset[j].X, (int)omaAlus.Ammukset[j].Y,
                                (int)omaAlus.Ammukset[j].Leveys, (int)omaAlus.Ammukset[j].Korkeus);

                            rectAmmus.Intersect(rectVihollinen);
                            if (!rectAmmus.IsEmpty && !viholliset[i].Rajahtaa)
                            {
                                if (viholliset[i].Nakyvissa)
                                {
                                    if(viholliset[i].osu(omaAlus.Ammukset[j]))                                 
                                        pisteet += viholliset[i].Pisteet;
                                    omaAlus.Ammukset[j] = null;
                                }                                                       
                            }
                        }
                    }

                    //osuuko vihollinen omaan alukseen?
                    rectAlus.Intersect(rectVihollinen);
                    if (!rectAlus.IsEmpty && viholliset[i].Nakyvissa)
                        tuhoaOmaAlus();                        

                    rectAlus = new Rectangle((int)omaAlus.X, (int)omaAlus.Y, (int)omaAlus.Leveys, (int)omaAlus.Korkeus);

                    //osuuko vihollisen ammus itseen?
                    for (int j = 0; j < viholliset[i].MaxAmmukset; j++)
                    {                        
                        if (viholliset[i].Ammukset[j] != null)
                        {
                            Rectangle rectAmmus = new Rectangle((int)viholliset[i].Ammukset[j].X, (int)viholliset[i].Ammukset[j].Y,
                                (int)viholliset[i].Ammukset[j].Leveys, (int)viholliset[i].Ammukset[j].Korkeus);

                            rectAmmus.Intersect(rectAlus);
                            if (!rectAmmus.IsEmpty)
                            {
                                tuhoaOmaAlus();
                            }
                        }
                    }
                }
            }
        }

        private void tuhoaOmaAlus()
        {
            if (!omaAlus.Rajahtaa && omaAlus.Nakyvissa && !omaAlus.Immuniteetti)
            {
                omaAlus.rajahda();
                elamat--;
                if (elamat < 1)
                    gameOver = true;
            }
        }

        /*
         * Reagoidaan näppäimistösyötteeseen.
         */
        private void reagoiNappaimiin()
        {
            reagoiLiikenappaimiin();
            reagoiAmpumiseen();          
        }

        /*
         * Liikutetaan alusta oikealla nopeudella oikeaan suuntaan.
         * Jos törmätään reunaan, alus pysähtyy.
         */
        private void liikutaAlusta()
        {            
            omaAlus.liikuta(Width, Height);
        }        

        /*
         * Reagoidaan nuolinäppäinten painalluksiin. Näppäinten painaminen
         * kiihdyttää aluksen nopeutta asianmukaiseen suuntaan. Jos mitään
         * näppäintä ei paineta, aluksen nopeus hidastuu.
         */
        private void reagoiLiikenappaimiin()
        {           
            omaAlus.reagoiLiikenappaimiin(nappaimet);
        }

        /*
         * Välilyöntiä painaessa luodaan ammus.
         */
        private void reagoiAmpumiseen()
        {
            omaAlus.reagoiAmpumiseen(nappaimet);       
         
        }

        private void pictureBoxTausta_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < tahtienMaxMaara; i++)
                if (tahdet[i] != null)
                    g.DrawEllipse(Pens.White, tahdet[i].X, tahdet[i].Y, 1, 1);

            omaAlus.drawAmmukset(g);
            omaAlus.draw(g);  

            for (int i = 0; i < vihollistenMaxMaara; i++)
            {
                if (viholliset[i] != null)
                {
                    viholliset[i].drawAmmukset(g);
                }
            }

            for (int i = 0; i < vihollistenMaxMaara; i++)
            {
                if (viholliset[i] != null)
                {
                    viholliset[i].draw(g);
                }
            }

            string stringPisteet = pisteet.ToString();
            string stringElamat = "X " + elamat.ToString();
            g.DrawString(stringPisteet, SystemFonts.DefaultFont, Brushes.Yellow, Width - 20 - stringPisteet.Length*6, 20);
            g.DrawString(stringElamat, SystemFonts.DefaultFont, Brushes.Yellow, 20 , Height - 20 - 39);
            
            

            if (gameOver == true)
            {
                Font fontti = new Font(FontFamily.GenericSansSerif, 50.0F, FontStyle.Bold);
                Font fonttiOhjeteksti = new Font(FontFamily.GenericSerif  , 15.0F, FontStyle.Regular);
                if (lopputeksti == "HÄVISIT")
                    g.DrawString(lopputeksti,fontti, Brushes.Red, 105, Height/2 - 75);
                else
                    g.DrawString(lopputeksti, fontti, Brushes.Green, 20, Height / 2 - 75);

                g.DrawString("Paina välilyöntiä palataksesi päävalikkoon", fonttiOhjeteksti, Brushes.White, 60, Height / 2);
            }
        }

        private void Peli_FormClosed(object sender, FormClosedEventArgs e)
        {
            paavalikko.Show();
        }       
    }
}