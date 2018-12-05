using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediumProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            var node1 = new ListNode(7);
            var node3 = new ListNode(3);
            var node2 = new ListNode(9);
            node1.next = node2;
            node2.next = node3;

            var node1a = new ListNode(5);
            var node3a = new ListNode(5);
            var node2a = new ListNode(6);
            node1a.next = node2a;
            node2a.next = node3a;

            var sol = new Solution();
            var res = sol.AddTwoNumbers(node1, node1a);
            while (res != null)
            {
                Console.WriteLine(res.val);
                res = res.next;
            }

            Console.Read();
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var prev = new ListNode(0);
            var head = prev;
            var carryVal = 0;
            while (l1 != null || l2 != null)
            {
                var cur = new ListNode(0);
                var sum = l1.val + l2.val + carryVal;
                cur.val = sum % 10;
                carryVal = (sum >= 10) ? 1 : 0;
                prev.next = cur;
                prev = cur;

                if ((l1?.next == null) && (l2?.next == null) && carryVal != 1) break;
                l1 = l1?.next ?? new ListNode(0);
                l2 = l2?.next ?? new ListNode(0);
            }
            return head.next;
        }
    }
}
