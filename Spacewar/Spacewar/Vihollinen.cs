using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Spacewar
{
    public delegate void VihollinenTuhotaanEventHandler(object sender, EventArgs e);

    public class Vihollinen : LiikkuvaKohde
    {
        public event VihollinenTuhotaanEventHandler Tuhotaan;
        public Rajahdys rajahdys = null;
        protected int jaahdytysaika;
        protected int jaahdytyslaskuri = 0;
        protected int marginaalinLeveys = 16;
        protected int marginaalinKorkeus = 39;
        bool rajahtaa = false;
        int id;
        static int maxAmmukset = 120;
        Ammus[] ammukset = new Ammus[maxAmmukset];
        public static int pelinKorkeus;
        public static int pelinLeveys;
        protected Image ammuksenKuva;
        int pisteet;
        float elinpisteet;
        protected int ammuksenNopeus= 10;

        public Vihollinen(float x, float y, float nopeusX, float nopeusY, float leveys, float korkeus,
            bool nakyvissa, Image kuva, int id, int jaahdytysaika,
            Image ammuksenKuva,float elinpisteet, int pisteet)
            :base(x, y, nopeusX, nopeusY, leveys, korkeus, nakyvissa, kuva)
        {
            this.id = id;
            //this.pelinKorkeus = pelinKorkeus;
            //this.pelinLeveys = pelinLeveys;
            this.jaahdytysaika = jaahdytysaika;
            this.ammuksenKuva = ammuksenKuva;
            jaahdytyslaskuri = jaahdytysaika * 2 / 3;
            this.pisteet = pisteet;
            this.elinpisteet = elinpisteet;
        }

        public float Elinpisteet
        {
            get { return elinpisteet; }
            set { elinpisteet = value; }
        }

        public int PelinKorkeus
        {
            get { return pelinKorkeus; }
            set { pelinKorkeus = value; }
        }

        public int PelinLeveys
        {
            get { return pelinLeveys; }
            set { pelinLeveys = value; }
        }

        public virtual void OnTuhotaan(EventArgs e)
        {
            if (Tuhotaan != null)
                Tuhotaan(this, e);
        }

        public int Pisteet
        {
            get { return pisteet; }
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

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Boolean Rajahtaa
        {
            get { return rajahtaa; }
            set { rajahtaa = value; }
        }       

        public bool osu(Ammus ammus)
        {
            elinpisteet -= ammus.Vahinko;
            if (elinpisteet <= 0)
            {
                Nakyvissa = false;
                rajahda();
                return true;
            }
            return false;
        }

        public void draw(Graphics g)
        {
            if (Nakyvissa) g.DrawImage(Kuva, (float)X, (float)Y);
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

        public virtual void liikuta()
        {
            if (rajahdys == null)
            {
                X += NopeusX;
                Y += NopeusY;

                if (X + Leveys - 100 + marginaalinLeveys > pelinLeveys) { Nakyvissa = false; }
                if (X + 100 + marginaalinLeveys < 0) { Nakyvissa = false; }
                if (Y + Korkeus - 100 + marginaalinKorkeus > pelinKorkeus) { Nakyvissa = false; }
                if (Y + 200 + marginaalinKorkeus < 0) { Nakyvissa = false; }
            }
            else
                rajahdys.liikutaOsasia();

            liikutaAmmuksia();

            if (jaahdytyslaskuri > jaahdytysaika && Nakyvissa && jaahdytysaika > 0)
            {
                ammu();
                jaahdytyslaskuri = 0;
            }
            jaahdytyslaskuri++;

            if (!Nakyvissa && rajahdys == null && !ammuksiaJaljella())
                OnTuhotaan(EventArgs.Empty);
        }

        public void vihollinen_RajahdysLoppu(object sender, EventArgs e)
        {
            rajahdys = null;
            if(!ammuksiaJaljella())
                OnTuhotaan(EventArgs.Empty);
        }

        public bool ammuksiaJaljella()
        {
            for (int i = 0; i < maxAmmukset; i++)
            {
                if (ammukset[i] != null)
                    return true;
            }
            return false;
        }

        public void rajahda()
        {
            NopeusX = 0;
            NopeusY = 0;
            rajahdys = new Rajahdys(X, Y, Leveys, Korkeus, 0);
            rajahdys.RajahdysLoppu += new RajahdysLoppuEventHandler(vihollinen_RajahdysLoppu);
            rajahdys.alustaOsaset();
            rajahtaa = true;
        }

        public virtual void ammu()
        {
            for (int i = 0; i < maxAmmukset; i++)
            {
                if (ammukset[i] == null)
                {
                    ammukset[i] = new Ammus(X + Leveys/2 - ammuksenKuva.Width/2, Y + Korkeus, 0,ammuksenNopeus, ammuksenKuva.Width, ammuksenKuva.Height, true, ammuksenKuva);
                    return;
                }
            }
        }

        public void liikutaAmmuksia()
        {
            for (int i = 0; i < maxAmmukset; i++)
            {
                if (ammukset[i] != null)
                {
                    ammukset[i].Y += ammukset[i].NopeusY;
                    ammukset[i].X += ammukset[i].NopeusX;
                    if (ammukset[i].Y > pelinKorkeus )
                    {
                        ammukset[i] = null;
                    }
                }
            }
        }
    }
}
