using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Spacewar.Viholliset
{
    class HarmaaHaikala : Vihollinen
    {
         public HarmaaHaikala(float x, float y, float nopeusX, float nopeusY,int id)
            :base(x, y, nopeusX, nopeusY, 20, 20, true, new Bitmap("miinavihollinen.png"),id,-1,new Bitmap("ammus3.png"),1,532)
        {
                     
        }   

    }
}
