using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPPR
{
    class MinPoint : Point
    {
        public double k;
        public double ee;

        public MinPoint(Point p, double k_, double ee_) : base(p)
        {
            k = k_;
            ee = ee_;
        }
    }
}
