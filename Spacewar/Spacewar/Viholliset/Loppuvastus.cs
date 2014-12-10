using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace Spacewar.Viholliset
{
    class Loppuvastus : Vihollinen
    {
        bool pysahtynyt = false;
        int todKorkeus = 148;
        int ampumaVaihe = 2;
        int seuraavaAmpumaVaihe = 0;
        int ampumaLaskuri = 0;
        int ampumaRaja = 20;
        Peli peli;
        Random random = new Random();

        public Loppuvastus(float x, float y, float nopeusX, float nopeusY,int id, Peli peli)
            :base(x, y, nopeusX, nopeusY, 273, 60, true, new Bitmap("loppuvastus.png"),id,8,new Bitmap("ammus5.png"),200,121654)
        {
            this.peli = peli;
        }

        public override void liikuta()
        {
            if (rajahdys == null)
            {
                X += NopeusX;
                Y += NopeusY;

                if (X + Leveys - 100 + marginaalinLeveys > pelinLeveys) { Nakyvissa = false; }
                if (X + 100 + marginaalinLeveys < 0) { Nakyvissa = false; }
                if (Y + Korkeus - 100 + marginaalinKorkeus > pelinKorkeus) { Nakyvissa = false; }
                if (Y + 200 + marginaalinKorkeus < 0) { Nakyvissa = false; }
            }
            else
                rajahdys.liikutaOsasia();

            liikutaAmmuksia();
            
            ammuOma();
            

            if (!Nakyvissa && rajahdys == null)
                OnTuhotaan(EventArgs.Empty);

            if (Y == 30 && !pysahtynyt)
            {
                NopeusY = 0;
                pysahtynyt = true;
            }
        }

        public void ammuOma()
        {
            if (ampumaLaskuri > ampumaRaja)
            {
                ampumaLaskuri = 0;
                if (ampumaVaihe != 3)
                {
                    ampumaVaihe = 3;
                    ampumaRaja = 5;
                }
                else
                {
                    ampumaVaihe = seuraavaAmpumaVaihe;
                    seuraavaAmpumaVaihe = (seuraavaAmpumaVaihe + 1) % 3;
                }
                if (ampumaVaihe == 0)
                {
                    ammuksenKuva = new Bitmap("ammus.png");
                    ampumaRaja = 20;
                    jaahdytysaika = 8;
                    ammuksenNopeus = 10;
                }
                if (ampumaVaihe == 1)
                {
                    ammuksenKuva = new Bitmap("ammus5.png");
                    ampumaRaja = 40;
                    jaahdytysaika = 5;
                    ammuksenNopeus = 10;
                }
                if (ampumaVaihe == 2)
                {                    
                    ampumaRaja = 20;
                    jaahdytysaika = 8;
                    ammuksenNopeus = 10;
                }

                if (ampumaVaihe == 3)
                {
                    ampumaRaja = 40;
                    ammuksenNopeus = 7;
                }
            }

            if (jaahdytyslaskuri > jaahdytysaika && Nakyvissa && jaahdytysaika > 0 && pysahtynyt)
            {
                switch (ampumaVaihe)
                {
                    case 0:
                        for (int i = 0; i < MaxAmmukset; i++)
                        {
                            if (Ammukset[i] == null)
                            {
                                Ammukset[i] = new Ammus(X + Leveys / 2 - ammuksenKuva.Width / 2, Y + todKorkeus - 18, 0,ammuksenNopeus, ammuksenKuva.Width, ammuksenKuva.Height, true, ammuksenKuva);
                                //ampumaLaskuri++;
                                break;
                            }
                        }
                        jaahdytyslaskuri = 0;
                        break;
                    case 1:
                         for (int i = 0; i < MaxAmmukset; i++)
                        {
                            if (Ammukset[i] == null && Ammukset[i+1] == null)
                            {
                                float ympyraNopeusX;

                                ympyraNopeusX = (ampumaLaskuri + 40)%(ammuksenNopeus*4);
                                if (ympyraNopeusX > ammuksenNopeus && ympyraNopeusX < ammuksenNopeus * 3)
                                    ympyraNopeusX = ammuksenNopeus - (ympyraNopeusX - ammuksenNopeus);
                                if (ympyraNopeusX >= ammuksenNopeus * 3)
                                    ympyraNopeusX = ympyraNopeusX - (4 * ammuksenNopeus);
                                float ympyraNopeusY = (float)Math.Sqrt((double)(ammuksenNopeus * ammuksenNopeus - ympyraNopeusX * ympyraNopeusX));
                                Ammukset[i] = new Ammus(X + Leveys / 2 - ammuksenKuva.Width / 2 - 53, Y + todKorkeus - 18, ympyraNopeusX, ympyraNopeusY, ammuksenKuva.Width, ammuksenKuva.Height, true, ammuksenKuva);
                                Ammukset[i + 1] = new Ammus(X + Leveys / 2 - ammuksenKuva.Width / 2 + 53, Y + todKorkeus - 18, ympyraNopeusX, ympyraNopeusY, ammuksenKuva.Width, ammuksenKuva.Height, true, ammuksenKuva);
                                //ampumaLaskuri++;
                                
                                break;
                            }
                        }
                         jaahdytyslaskuri = 0;
                         break;
                        
                    case 2:
                         for (int i = 0; i < peli.publicVihollisetnMax - 1; i++)
                        {
                            if (peli.viholliset[i] == null && peli.viholliset[i+1] == null)
                            {
                                float nopeusX1 = (float)(random.NextDouble() * (2*ammuksenNopeus) - ammuksenNopeus);
                                float nopeusY1 = (float)Math.Sqrt((double)(ammuksenNopeus * ammuksenNopeus - nopeusX1 * nopeusX1));
                                peli.viholliset[i] = new Viholliset.HarmaaHaikalaB(X + Leveys / 2 - ammuksenKuva.Width / 2 - 53, Y + todKorkeus - 18,nopeusX1,nopeusY1,i);
                                peli.viholliset[i].Tuhotaan += new VihollinenTuhotaanEventHandler(peli.Peli_VihollinenTuhoutui);
                                float nopeusX2 = (float)(random.NextDouble() * (2 * ammuksenNopeus) - ammuksenNopeus);
                                float nopeusY2 = (float)Math.Sqrt((double)(ammuksenNopeus * ammuksenNopeus - nopeusX2 * nopeusX2));
                                peli.viholliset[i+1] = new Viholliset.HarmaaHaikalaB(X + Leveys / 2 - ammuksenKuva.Width / 2 + 53, Y + todKorkeus - 18, nopeusX2, nopeusY2, i+1);
                                peli.viholliset[i+1].Tuhotaan += new VihollinenTuhotaanEventHandler(peli.Peli_VihollinenTuhoutui);
                                //ampumaLaskuri++;
                                break;
                            }
                        }
                        jaahdytyslaskuri = 0;
                        
                         break;

                    case 3:
                         break;                        
                        
                    default:
                        break;
                }
                ampumaLaskuri++;
                
            }

            jaahdytyslaskuri++;
            
        }
    }
}
