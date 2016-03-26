using Biathlon.Measurements;
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

            Point target = ReadInitialPoint();
            double radius = 3.0;

            ShootingRange sr = new ShootingRange();
            Point found = sr.SearchFirstNearest(target, radius);

            CheckHit(found);
        }

        private static Point ReadInitialPoint()
        {
            Console.Write("Initial X: ");
            double givenX = Convert.ToDouble(Console.ReadLine());
            Console.Write("Initial Y: ");
            double givenY = Convert.ToDouble(Console.ReadLine());
            return new Point(givenX, givenY);
        }

        private static void CheckHit(Point found)
        {
            if (found == null)
                Console.WriteLine("There was no hit");
            else
                Console.WriteLine("You hit it!");
        }
    }
}
