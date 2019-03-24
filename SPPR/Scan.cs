using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPPR
{
    class Scan : AGP
    {
        protected override double Rfunc(Point lp, Point rp, double m)
        {
            return (rp.x - lp.x);
        }

        protected override double searchxk(Interval zk, double m)
        {
            return (0.5 * (zk.rp.x + zk.lp.x));
        }
    }
}
