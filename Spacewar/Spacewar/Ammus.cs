using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Spacewar
{
    public class Ammus : LiikkuvaKohde
    {
        float vahinko;
        public Ammus(float x, float y, float nopeusX, float nopeusY, float leveys, float korkeus, bool nakyvissa, Image kuva, float vahinko)
            : base(x, y, nopeusX, nopeusY, leveys, korkeus, nakyvissa, kuva)
        {
            this.vahinko = vahinko;
        }

        public Ammus(float x, float y, float nopeusX, float nopeusY, float leveys, float korkeus, bool nakyvissa, Image kuva)
            : this(x, y, nopeusX, nopeusY, leveys, korkeus, nakyvissa, kuva,1)
        {
        }

        public float Vahinko
        {
            get { return vahinko; }            
        }

        public void draw(Graphics g) 
        {
            g.DrawImage(Kuva, X, Y);
        }
    }
}
