using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPPR
{
    class nodeint
    {
        public Interval data;
        public nodeint next;

        public nodeint(Interval data_, nodeint next_)
        {
            data = data_;
            next = next_;
        }
    }

    class PriorityQueue
    {
        private nodeint head;

        public PriorityQueue()
        {
            head = null;
        }

        public void push(Interval i)
        {
            nodeint itl, itr;
            itl = this.head;
            itr = this.head;

            while ((itr != null) && (itr.data.R > i.R))
            {
                itl = itr;
                itr = itr.next;
            }

            if (itl == null)
            {
                head = new nodeint(i, null);
            }
            else
            {
                nodeint d = new nodeint(i, itl.next);
                itl.next = d;
            }
        }

        public Interval pop()
        {
            Interval i = head.data;
            head = head.next;
            return i;
        }

        public bool empty()
        {
            return (head == null);
        }
    }
}
