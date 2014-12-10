using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Spacewar.Viholliset
{
    class PunainenParoni : Vihollinen
    {
        public PunainenParoni(float x, float y, float nopeusX, float nopeusY,int id)
            :base(x, y, nopeusX, nopeusY, 40, 40, true, new Bitmap("vihollinen.png"),id,30,new Bitmap("ammus3.png"),2,3251)
        {
            ammuksenNopeus = 12;     
        }       
    }
}