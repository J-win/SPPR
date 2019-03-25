using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPPR
{
    class Strongin : AGP
    {
        protected override double Rfunc(Point lp, Point rp, double m)
        {
            double dx = rp.x - lp.x;
            double dz = rp.z - lp.z;
            return (m * dx + dz * dz / (m * dx) - 2.0 * (rp.z + lp.z));
        }

        protected override double searchxk(Interval zk, double m)
        {
            return (0.5 * (zk.rp.x + zk.lp.x) - ((zk.rp.z - zk.lp.z) / (2.0 * m)));
        }

        protected override bool bv(double r, double l, double ee, int k, int n)
        {
            return ((r - l > ee) && (k < n));
        }
    }
}
