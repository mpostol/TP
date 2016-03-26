using Biathlon.Measurements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biathlon
{
    public class ShootingRange
    {
        private PointsDistance Distance;

        public ShootingRange(PointsDistance distance)
        {
            if (distance == null)
                throw new ArgumentNullException(nameof(distance));
            Distance = distance;
        }

        public Point SearchFirstNearest(Point target, double radius)
        {
            while (true)
            {
                Point point = ReadPoint();
                if (FinishChecking(point))
                    return null;
                if (TargetHit(point, target, radius))
                    return point;
            }
        }

        public bool TargetHit(Point point, Point target, double radius)
        {
            double distance = Distance.CalculateDistance(point, target);
            return (distance <= radius);
        }

        public bool FinishChecking(Point point)
        {
            if (point == null)
                throw new ArgumentException(nameof(point));
            return (point.X == 0.0 && point.Y == 0.0);
        }

        public Point ReadPoint()
        {
            Console.Write("X: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Y: ");
            double y = Convert.ToDouble(Console.ReadLine());
            return new Point(x, y);
        }
    }
}
