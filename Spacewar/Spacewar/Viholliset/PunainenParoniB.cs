using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacewar.Viholliset
{
    class PunainenParoniB : PunainenParoni
    {
        int aikaLaskuri = 0;
        int raja = 10;
        public PunainenParoniB(float x, float y, float nopeusX, float nopeusY, int id) : base(x, y, nopeusX, nopeusY, id) { }

        public override void liikuta()
        {
            base.liikuta();
            aikaLaskuri++;
            if (aikaLaskuri % raja == 0)
            {
                aikaLaskuri = 0;
                raja = 20;
                NopeusX = -NopeusX;
            }
        }

    }
}
