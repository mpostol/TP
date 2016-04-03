using Biathlon.Pomiary;
using System;

namespace Biathlon
{
    public class Strzelnica
    {
        private OdlegloscPunktow Odleglosc;

        public Strzelnica(OdlegloscPunktow odleglosc)
        {
            if (odleglosc == null)
                throw new ArgumentNullException(nameof(odleglosc));
            Odleglosc = odleglosc;
        }

        public Punkt SzukajPierwszegoNajblizszego(Punkt zadany, double promien)
        {
            while (true)
            {
                Punkt punkt = WczytajPunkt();
                if (KoniecSprawdzania(punkt))
                    return null;
                if (SprawdzTrafienie(punkt, zadany, promien))
                    return punkt;
            }
        }

        public bool SprawdzTrafienie(Punkt punkt, Punkt zadany, double promien)
        {
            double dystans = Odleglosc.ObliczOdleglosc(punkt, zadany);
            return (dystans <= promien);
        }

        public bool KoniecSprawdzania(Punkt punkt)
        {
            if (punkt == null)
                throw new ArgumentException(nameof(punkt));
            return (punkt.X == 0.0 && punkt.Y == 0.0);
        }

        public Punkt WczytajPunkt()
        {
            Console.Write("X: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Y: ");
            double y = Convert.ToDouble(Console.ReadLine());
            return new Punkt(x, y);
        }
    }
}