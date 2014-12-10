using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace Spacewar
{
    public delegate void OmaAlusTuhotaanEventHandler(object sender, EventArgs e);

    class OmaAlus : LiikkuvaKohde
    {
        public event OmaAlusTuhotaanEventHandler Tuhotaan;
        private Rajahdys rajahdys = null;
        float maxNopeus = 12;
        float kiihtyvyys = 2F;
        int marginaalinLeveys = 16;
        int marginaalinKorkeus = 39;
        bool rajahtaa = false;
        int jaahtymisaika = 2;
        int jaahtymislaskuri = 0;
        int pelinLeveys;
        int pelinKorkeus;
        int syntymislaskuri = 0;
        int syntymisaika = 50;
        int immuniteettilaskuri;
        int immuniteettiaika = 50;

        static int maxAmmukset = 60;
        Ammus[] ammukset = new Ammus[maxAmmukset];


        public OmaAlus(int pelinLeveys, int pelinKorkeus, bool immuniteetti)
            :base(222, 447, 0, 0, 35, 44, true, new Bitmap("alus.png"))
        {
            this.pelinKorkeus = pelinKorkeus;
            this.pelinLeveys = pelinLeveys;
            if (immuniteetti)
                immuniteettilaskuri = 0;
            else
                immuniteettilaskuri = immuniteettiaika + 1;
        }

        protected virtual void OnTuhotaan(EventArgs e)
        {
            if (Tuhotaan != null)
                Tuhotaan(this, e);
        }

        public int MaxAmmukset
        {
            get { return maxAmmukset; }
            set { maxAmmukset = value; }
        }

        public Ammus[] Ammukset
        {
            get { return ammukset; }
            set { ammukset = value; }
        }

        public bool Rajahtaa
        {
            get { return rajahtaa; }
            set { rajahtaa = value; }
        }

        public float MaxNopeus
        {
            get { return maxNopeus; }
            set { maxNopeus = value; }
        }

        public float Kiihtyvyys
        {
            get { return kiihtyvyys; }
            set { kiihtyvyys = value; }
        }

        public void liikuta(int leveysraja, int korkeusraja)
        {
            X += NopeusX;
            Y += NopeusY;

            if (X < 0) { X = 0; NopeusX = 0; }
            if (Y < 0) { Y = 0; NopeusY = 0; }
            if (X + Leveys + marginaalinLeveys > leveysraja) { X = leveysraja - Leveys - marginaalinLeveys; NopeusX = 0; }
            if (Y + Korkeus + marginaalinKorkeus > korkeusraja) { Y = korkeusraja - Korkeus - marginaalinKorkeus; NopeusY = 0; }
            if (rajahtaa && rajahdys!=null)
                rajahdys.liikutaOsasia();

            liikutaAmmuksia();
            if (!Nakyvissa && rajahdys == null && !ammuksiaJaljella())
            {
                syntymislaskuri++;
                if(syntymislaskuri > syntymisaika)
                    OnTuhotaan(EventArgs.Empty);
            }
            if (immuniteettilaskuri <= immuniteettiaika)
                immuniteettilaskuri++;
        }

        private bool ammuksiaJaljella()
        {
            for (int i = 0; i < maxAmmukset; i++)
            {
                if (ammukset[i] != null)
                    return true;
            }
            return false;
        }

        public void reagoiLiikenappaimiin(ArrayList nappaimet)
        {
            if (nappaimet.Contains(Keys.Up))
                if (NopeusY > -MaxNopeus)
                    NopeusY -= Kiihtyvyys;
            if (nappaimet.Contains(Keys.Down))
                if (NopeusY < MaxNopeus)
                    NopeusY += Kiihtyvyys;
            if (nappaimet.Contains(Keys.Right))
                if (NopeusX < MaxNopeus)
                    NopeusX += Kiihtyvyys;
            if (nappaimet.Contains(Keys.Left))
                if (NopeusX > -MaxNopeus)
                    NopeusX -= Kiihtyvyys;

            if (!nappaimet.Contains(Keys.Up) && !nappaimet.Contains(Keys.Down))
            {
                if (NopeusY < 0) NopeusY += Kiihtyvyys;
                if (NopeusY > 0) NopeusY -= Kiihtyvyys;
            }
            if (!nappaimet.Contains(Keys.Right) && !nappaimet.Contains(Keys.Left))
            {
                if (NopeusX < 0) NopeusX += Kiihtyvyys;
                if (NopeusX > 0) NopeusX -= Kiihtyvyys;
            }
        }

        public void rajahda()
        {
            if (!rajahtaa && immuniteettilaskuri > immuniteettiaika)
            {
                NopeusX = 0;
                NopeusY = 0;
                rajahdys = new Rajahdys(X, Y, Leveys, Korkeus, 0, Color.Yellow);
                rajahdys.RajahdysLoppu += new RajahdysLoppuEventHandler(omaAlus_RajahdysLoppu);
                rajahdys.alustaOsaset();
                rajahtaa = true;
                Nakyvissa = false;
            }
        }

        public bool Immuniteetti
        {
            get { return (immuniteettilaskuri < immuniteettiaika); }
        }

        private void omaAlus_RajahdysLoppu(object sender, EventArgs e)
        {
            rajahdys = null;
            rajahtaa = false;
            //OnTuhotaan(EventArgs.Empty);
        }

        public void reagoiAmpumiseen(ArrayList nappaimet)
        {
            jaahtymislaskuri++;
            if (nappaimet.Contains(Keys.Space) && jaahtymislaskuri > jaahtymisaika && Nakyvissa)
            {
                ammu();
                jaahtymislaskuri = 0;
                //nappaimet.Remove(Keys.Space);
            }
        }

        public void ammu()
        {
            for (int i = 0; i < maxAmmukset; i++)
            {
                if (ammukset[i] == null)
                {
                    ammukset[i] = new Ammus(X + Leveys / 2, Y, 0, -20, 9, 11, true, new Bitmap("ammus2.png"),1);
                    return;
                }
            }
        }

        public void draw(Graphics g)
        {
            if (Nakyvissa)
                if (Immuniteetti)
                {
                    if ((immuniteettilaskuri / 3) % 2 == 0)
                        g.DrawImage(Kuva, (float)X, (float)Y);
                }
                else
                    g.DrawImage(Kuva, (float)X, (float)Y);
            if (rajahdys != null)
                rajahdys.draw(g);
        }

        public void drawAmmukset(Graphics g)
        {
            for (int i = 0; i < maxAmmukset; i++)
            {
                if (ammukset[i] != null)
                    ammukset[i].draw(g);
            }
        }

        public void liikutaAmmuksia()
        {
            for (int i = 0; i < maxAmmukset; i++)
            {
                if (ammukset[i] != null)
                {
                    ammukset[i].Y += ammukset[i].NopeusY;
                    if (ammukset[i].Y > pelinKorkeus || ammukset[i].Y < 0)
                    {
                        ammukset[i] = null;
                    }
                }
            }
        }
    }
}
