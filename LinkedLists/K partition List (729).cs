using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public static class K_partition_List__729_
    {
        public static ListNode[] SplitListToParts(ListNode head, int k)
        {
            int n = 0;
            ListNode curr = head;
            while (curr != null)
            {
                curr = curr.next;
                n++;
            }

            int width = n / k; int rem = n % k;

            ListNode[] res = new ListNode[k];

            ListNode h = head; ListNode temp = null;
            while (h != null)
            {
                for (int i = 0; i < k; i++, rem--)
                {
                    res[i] = h;

                    for (int j = 0; j < width + (rem > 0 ? 1 : 0); j++)
                    {
                        temp = h;
                        h = h.next;
                    }
                    temp.next = null;
                }
            }


            return res;

        }
    }
}
