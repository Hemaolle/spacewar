using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacewar
{
    class OhjeYksikko
    {
        Vihollinen vihollinen;       
        int aika;

        public OhjeYksikko(int aika, Vihollinen vihollinen)
        {
            this.aika = aika;
            this.vihollinen = vihollinen;            
        }

        public int Aika
        {
            get { return aika; }
        }

        public Vihollinen Vihu
        {
            get { return vihollinen; }
        }
    }
}
