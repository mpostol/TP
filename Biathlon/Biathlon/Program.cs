using Biathlon.Pomiary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biathlon
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Biathlon");

            Punkt zadany = WczytajPunktPoczatkowy();
            double promien = 3.0;

            Strzelnica st = new Strzelnica();
            Punkt znaleziony = st.SzukajPierwszegoNajblizszego(zadany, promien);

            SprawdzTrafienie(znaleziony);
        }

        private static Punkt WczytajPunktPoczatkowy()
        {
            Console.Write("Poczatkowy X: ");
            double zadanyX = Convert.ToDouble(Console.ReadLine());
            Console.Write("Poczatkowy Y: ");
            double zadanyY = Convert.ToDouble(Console.ReadLine());
            return new Punkt(zadanyX, zadanyY);
        }

        private static void SprawdzTrafienie(Punkt znaleziony)
        {
            if (znaleziony == null)
                Console.WriteLine("Nie trafiono");
            else
                Console.WriteLine("Trafienie!");
        }
    }
}
