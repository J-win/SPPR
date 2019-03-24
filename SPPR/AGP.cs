using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPPR
{
    abstract class AGP
    {
        protected abstract double Rfunc(Point lp, Point rp, double m);
        protected abstract double searchxk(Interval zk, double m);

        public MinPoint minSearch(LinkList p, double a, double b, double ee, int n, double r, Func<double, double> f)
        {
            PriorityQueue q = new PriorityQueue();
            Interval zk = new Interval();

            double mm, m = -1.0;
            int k = 1;

            Point a0 = new Point(a, f(a));
            Point b0 = new Point(b, f(b));

            p.insertup(a0);
            p.insertup(b0);

            do
            {
                double mold = m;
                mm = p.Mfunc();

                if (mm > 0.0)
                    m = r * mm;
                else
                    m = 1.0;

                if (mold != m)
                    p.addQueue(q, m, Rfunc);

                zk = q.pop();

                double xk = searchxk(zk, m);

                Point t = new Point(xk, f(xk));
                Point tt = p.insertup(t);

                Interval i1 = new Interval(Rfunc(zk.lp, tt, m), zk.lp, tt);
                Interval i2 = new Interval(Rfunc(tt, zk.rp, m), tt, zk.rp);

                q.push(i1);
                q.push(i2);

                k++;

            } while ((zk.rp.x - zk.lp.x > ee) && (k < n));

            MinPoint minp = new MinPoint(p.Min(), k, zk.rp.x - zk.lp.x);

            return minp;
        }
    }
}
