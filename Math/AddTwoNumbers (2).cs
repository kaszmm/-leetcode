using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathemathics
{
     public class ListNode
     {
         public int val;
         public ListNode next;
         public ListNode(int val = 0, ListNode next = null)
         {
            this.val = val;
            this.next = next;
         }
     }
    public static class AddTwoNumbers__2_
    {
		public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
		{

			ListNode n1 = l1;
			ListNode n2 = l2;
			ListNode final = new(-1);
			ListNode dummy = final;
			var carry = 0;
			var sum = 0;
			while (n1 != null || n2 != null)
			{
				var a = n1 == null ? 0 : n1.val;
				var b = n2 == null ? 0 : n2.val;
				sum = a + b + carry;
				carry = sum / 10;
				dummy.next = new ListNode(sum % 10);
				if(n1!=null)
					n1 = n1.next;
				if(n2!=null)
					n2 = n2.next;
				dummy = dummy.next;
			}
            if (carry>0)
            {
				dummy.next = new ListNode(carry);
            }
			return final.next;
		}
	}
}
