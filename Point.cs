using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salesman_Problem
{
    class Point
    {
        private double x;
        private double y;

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public double Distance(Point point){
            return Math.Sqrt((x - point.X) * (x - point.X) + (y - point.Y) * (y - point.Y));
            }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType()) return false;

            Point p = obj as Point;
            return (this.x == p.x) && (this.y == p.y);
        }

        

        public static bool operator ==(Point p1, Point p2)
        {
                return (p1.x == p2.x) && (p1.y == p2.y);
        }
        public static bool operator !=(Point p1, Point p2)
        {
            return !((p1.x == p2.x) && (p1.y == p2.y));
        }
    }
}
