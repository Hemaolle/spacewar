using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Spacewar.Viholliset
{
    class SininenSivaltaja : Vihollinen
    {
        public SininenSivaltaja(float x, float y, float nopeusX, float nopeusY, int id)
            : base(x, y, nopeusX, nopeusY, 31, 43, true, new Bitmap("sininenVihollinen.png"), id, 35, new Bitmap("ammus4.png"), 4, 7251)
        {
            ammuksenNopeus = 12;
        }
    }
}