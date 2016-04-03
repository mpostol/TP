using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetrykiLib;

namespace Biathlon.Pomiary
{
    public class OdlegloscPunktow
    {
        private IMiaraOdleglosci Miernik;
        public OdlegloscPunktow(IMiaraOdleglosci miernik)
        {
            if (miernik == null)
                throw new ArgumentNullException(nameof(miernik));
            Miernik = miernik;
        }
        public double ObliczOdleglosc(Punkt p1, Punkt p2)
        {
            double[] a = { p1.X, p1.Y };
            double[] b = { p2.X, p2.Y };
            return Miernik.ObliczOdleglosc(a, b);
        }
    }
}
