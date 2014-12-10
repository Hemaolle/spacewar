using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Spacewar.Viholliset
{
    class SininenSivaltajaB : SininenSivaltaja
    {
        int aikaLaskuri = 0;
        bool kaannosTehty = false;
        public SininenSivaltajaB(float x, float y, float nopeusX, float nopeusY, int id)
            : base(x, y, nopeusX, nopeusY, id)
        {
        }

        public override void liikuta()
        {
            base.liikuta();
            aikaLaskuri += (int)NopeusY;
            if (aikaLaskuri >= 400 && !kaannosTehty)
            {
                kaannosTehty = true;
                if (X < pelinLeveys / 2)
                    NopeusX = -NopeusY;
                else
                    NopeusX = NopeusY;
                NopeusY = 0;
            }
        }
    }
}
