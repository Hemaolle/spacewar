using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Spacewar
{
    public delegate void RajahdysLoppuEventHandler(object sender, EventArgs e);

    public class Rajahdys
    {
        float x;
        float y;
        float leveys;
        float korkeus;
        int laskuri = 0;
        int kesto = 20;
        int id;
        double[,] osaset = new double[4, 50];
        Random random = new Random();
        Color vari;

        public event RajahdysLoppuEventHandler RajahdysLoppu;

        protected virtual void OnRajahdysLoppu(EventArgs e)
        {
            if (RajahdysLoppu != null)
                RajahdysLoppu(this, e);
        }

        public Rajahdys(float x, float y, float leveys, float korkeus, int id)
        {
            this.x = x;
            this.y = y;
            this.leveys = leveys;
            this.korkeus = korkeus;
            this.id = id;
            this.vari = Color.White;
        }

        public Rajahdys(float x, float y, float leveys, float korkeus, int id, Color vari)
            : this(x, y, leveys, korkeus, id)
        {
            this.vari = vari;
        }

        /**
         * Alustetaan räjähdyksen osaset ympyrän muotoiselle pienelle alueelle räjähdyksen keskelle.
         * Jokaiselle osaselle alustetaan myös oma nopeus, joka riippuu alun koordinaateista. Jokainen
         * osa lähtee siihen suuntaan, mihin se on alussa räjähdyksen keskipisteestä.
         */
        public void alustaOsaset()
        {
            for (int i = 0; i < 50; i++)
            {
                double suuntaX;
                double suuntaY;
                do
                {
                    suuntaX = random.NextDouble() - 0.5;
                    suuntaY = random.NextDouble() - 0.5;
                } while (suuntaX * suuntaX + suuntaY * suuntaY > 0.5 * 0.5);                

                osaset[0, i] = suuntaX*20 + leveys / 2;
                osaset[1, i] = suuntaY * 20 + leveys / 2;
                osaset[2, i] = suuntaX * 4;
                osaset[3, i] = suuntaY * 4;
                
            }
        }

        /**
         * Liikutetaan räjähdyksen osia jokaisen osan omalla nopeudella.
         * Kun Räjähdysanimaatiota on pyöritetty tarpeeksi kauan, lähetetään
         * viesti räjähdyksen loppumisesta.
         */
        public void liikutaOsasia()
        {
            for (int i = 0; i < 50; i++)
            {
                osaset[0, i] += osaset[2, i];
                osaset[1, i] += osaset[3, i];
            }
            laskuri++;
            if (laskuri > kesto)
            {
                OnRajahdysLoppu(EventArgs.Empty);
            }       
        }
        /**
         * Piirretään räjähdys annettuun Graphics-objektiin
         */
        public void draw(Graphics g)
        {
            Pen kyna = new Pen(vari);
            for (int i = 0; i < 50; i++)
            {
                g.DrawEllipse(kyna, X + (int)Osaset[0, i],
            Y + (int)Osaset[1, i], 1, 1);
            }
            kyna.Dispose();
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public double[,] Osaset
        {
            get { return osaset; }
            set { osaset = value; }
        }

    }
}
