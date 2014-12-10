using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Spacewar.Viholliset
{
    class VihreaVipeltaja : Vihollinen
    {
         public VihreaVipeltaja(float x, float y, float nopeusX, float nopeusY,int id)
            : base(x, y, nopeusX, nopeusY, 40, 40, true, new Bitmap("vihreaVihollinen.png"), id, -1, new Bitmap("vihreaVihollinen.png"), 10, 12483)
        {
                     
        }   

    }
}
