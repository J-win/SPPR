using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPPR
{
    class Point
    {
        public double x;
        public double z;

        public Point(double x_ = 0, double z_ = 0)
        {
            x = x_;
            z = z_;
        }

        public Point(Point p)
        {
            x = p.x;
            z = p.z;
        }
    }
}
