using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathemathics
{
    public static class HappyNumber__202_
    {
        
        public static bool IsHappy(int n)
        {
            if (n == 1) return true;
            HashSet<int> seen = new HashSet<int>();
            int curnum = n;
            while (true)
            {
                int sum = 0;
                
                foreach(var num in curnum.ToString())
                {
                    sum += (num-'0') * (num - '0');
                }
                if (sum == 1)
                    return true;
                if (seen.Contains(sum)) 
                    return false;
                seen.Add(sum);
                curnum = sum;
            }
        }
        public static int digitSquareSum(int n)
        {
            int sum = 0, tmp;
            while (n!=0)
            {
                tmp = n % 10;
                sum += tmp * tmp;
                n /= 10;
            }
            return sum;
        }

        public static bool isHappy(int n)
        {
            int slow, fast;
            slow = fast = n;
            do
            {
                slow = digitSquareSum(slow);
                fast = digitSquareSum(fast);
                fast = digitSquareSum(fast);
            } while (slow != fast);
            if (slow == 1) 
                return true;
            else 
                return false;
        }
    }
}
