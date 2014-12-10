using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Spacewar.Viholliset
{
    class OranssiOlio : Vihollinen
    {
        int jaahdytysaika2 = 10;
        int jaahdytyslaskuri2 = 0;
        Bitmap ammuksen2Kuva = new Bitmap("ammus5.png");

         public OranssiOlio(float x, float y, float nopeusX, float nopeusY,int id)
            :base(x, y, nopeusX, nopeusY, 40, 40, true, new Bitmap("oranssiVihollinen.png"),id,30,new Bitmap("ammus4.png"),2,25461)
        {
                     
        }

         public override void liikuta()
         {
             base.liikuta();

             jaahdytyslaskuri2++;
             if (jaahdytyslaskuri2%jaahdytysaika2 == 0 && Nakyvissa)
             {
                 ammu2();                 
             }
         }

         public void ammu2()         
        {
            for (int i = 0; i < MaxAmmukset; i++)
            {
                if (Ammukset[i] == null && Ammukset[i+1] == null)
                {
                    Ammukset[i] = new Ammus((X + Leveys / 2 - ammuksen2Kuva.Width / 2) - 10, Y + Korkeus - 5, -5,5 + NopeusY, ammuksen2Kuva.Width, ammuksen2Kuva.Height, true, ammuksen2Kuva);
                    Ammukset[i + 1] = new Ammus((X + Leveys / 2 - ammuksen2Kuva.Width / 2) , Y + Korkeus - 5, 5, 5 + NopeusY, ammuksen2Kuva.Width, ammuksen2Kuva.Height, true, ammuksen2Kuva);
                    return;
                }
            }
        }
    }
}
