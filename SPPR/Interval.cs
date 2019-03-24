using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPPR
{
    class Interval
    {
        public double R;
        public Point lp;
        public Point rp;

        public Interval(double R_ = 0.0, Point lp_ = null, Point rp_ = null)
        {
            R = R_;
            lp = lp_;
            rp = rp_;
        }

        public Interval(Interval i)
        {
            R = i.R;
            lp = i.lp;
            rp = i.rp;
        }
    }
}
