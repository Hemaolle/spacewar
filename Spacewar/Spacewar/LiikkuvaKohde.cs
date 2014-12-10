using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Spacewar
{
    public class LiikkuvaKohde
    {
        float x = 0;
        float y = 0;
        float nopeusX = 0;
        float nopeusY = 0;
        float leveys = 0;
        float korkeus = 0;        
        Boolean nakyvissa = true;
        Image kuva;

        public LiikkuvaKohde()
        {           
        }

        public LiikkuvaKohde(float x, float y, float nopeusX, float nopeusY, float leveys, float korkeus, Boolean nakyvissa, Image kuva)
        {
            this.x = x;
            this.y = y;
            this.nopeusX = nopeusX;
            this.nopeusY = nopeusY;
            this.leveys = leveys;
            this.korkeus = korkeus;
            this.nakyvissa = nakyvissa;
            this.kuva = kuva;
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

        public float NopeusX
        {
            get { return nopeusX; }
            set { nopeusX = value; }
        }

        public float NopeusY
        {
            get { return nopeusY; }
            set { nopeusY = value; }
        }

        public float Leveys
        {
            get { return leveys; }
            set { leveys = value; }
        }

        public float Korkeus
        {
            get { return korkeus; }
            set { korkeus = value; }
        }        

        public Image Kuva
        {
            get { return kuva; }
            set { kuva = value; }
        }

        public Boolean Nakyvissa
        {
            get { return nakyvissa; }
            set { nakyvissa = value; }
        }
    }
}
