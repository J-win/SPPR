using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPPR
{
    class Piyavsky : AGP
    {
        protected override double Rfunc(Point lp, Point rp, double m)
        {
            double dx = rp.x - lp.x;
            double dz = rp.z + lp.z;
            return (0.5 * m * dx - dz / 2.0);
        }

        protected override double searchxk(Interval zk, double m)
        {
            return (0.5 * (zk.rp.x + zk.lp.x) - ((zk.rp.z - zk.lp.z) / (2.0 * m)));
        }
    }
}
