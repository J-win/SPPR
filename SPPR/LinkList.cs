using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace SPPR
{
    class node
    {
        public Point data;
        public node next;

        public node(Point data_, node next_)
        {
            data = data_;
            next = next_;
        }
    }

    class LinkList
    {
        private node head;

        public LinkList()
        {
            head = null;
        }

        public Point insertup(Point xk)
        {
            node itl, itr;
            itl = this.head;
            itr = this.head;

            while ((itr != null) && (itr.data.x < xk.x))
            {
                itl = itr;
                itr = itr.next;
            }

            if (head == null)
            {
                head = new node(xk, null);
                return head.data;
            }
            else
            {
                if (itr == head)
                {
                    node dd = new node(xk, head);
                    head = dd;
                    return head.data;
                }
                else
                {
                    node d = new node(xk, itl.next);
                    itl.next = d;
                    return itl.next.data;
                }
            }
        }

        public Point Min()
        {
            node itl = this.head;

            double minx = itl.data.x;
            double minz = itl.data.z;

            while (itl != null)
            {
                if (minz > itl.data.z)
                {
                    minx = itl.data.x;
                    minz = itl.data.z;
                }

                itl = itl.next;
            }

            Point min = new Point(minx, minz);

            return min;
        }

        public double Mfunc()
        {
            node itr, itl;
            itr = itl = head;
            itr = itr.next;

            double max, mm = 0.0;

            while (itr != null)
            {
                max = Math.Abs((itr.data.z - itl.data.z) / (itr.data.x - itl.data.x));

                if (mm < max)
                    mm = max;

                itr = itr.next;
                itl = itl.next;
            }

            return mm;
        }

        public void addQueue(PriorityQueue q, double m, Func<Point, Point, double, double> rf)
        {
            while (!q.empty())
                q.pop();

            node itl, itr;
            itr = itl = this.head;
            itr = itr.next;

            while (itr != null)
            {
                Interval h = new Interval(rf(itl.data, itr.data, m), itl.data, itr.data);
                q.push(h);

                itl = itl.next;
                itr = itr.next;
            }
        }

        public void art(ZedGraph.ZedGraphControl zedGraphControl1)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();

            PointPairList list_x = new PointPairList();
            PointPairList list_z = new PointPairList();

            node itl = this.head;

            while (itl != null)
            {
                list_x.Add(itl.data.x, 0);
                list_z.Add(itl.data.x, itl.data.z);
                itl = itl.next;
            }

            LineItem Curve1 = zedGraphControl1.GraphPane.AddCurve("x", list_x, Color.Green, SymbolType.Plus);
            LineItem Curve2 = zedGraphControl1.GraphPane.AddCurve("z", list_z, Color.Blue, SymbolType.Star);

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        public void Print()
        {
            node itr;
            itr = this.head;

            while (itr != null)
            {
                Console.WriteLine(itr.data.x);
                itr = itr.next;
            }
        }
    }
}
