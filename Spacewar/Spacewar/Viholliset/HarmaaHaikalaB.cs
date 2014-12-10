using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacewar.Viholliset
{
    class HarmaaHaikalaB : HarmaaHaikala
    {
        public HarmaaHaikalaB(float x, float y, float nopeusX, float nopeusY, int id) : base(x, y, nopeusX, nopeusY, id) {
            Elinpisteet = 2;
        }

    }
}
