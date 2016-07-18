using Biathlon.Measurements;
using MetricsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biathlon
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Biathlon");

            Point target = ReadInitialPoint();
            double radius = 3.0;

            // Composition root (for normal program run)
            // Compose objects here using Dependency Injection
            IDistanceMetric metric = new EuclideanDistance();
            PointsDistance distance = new PointsDistance(metric);
            ShootingRange sr = new ShootingRange(distance);

            Point found = sr.SearchFirstNearest(target, radius);

            CheckHit(found);
            Console.ReadLine();
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
