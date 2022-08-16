using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
    public static class RepeatedSubstring__459_
    {

		public static bool ISRepeatedSubstring(string s)
        {
            int[] newLps = KmpAlgo(s);
            int n = s.Length;
            int k = newLps[n - 1];
            return k > 0 && n % (n - k) == 0;
        }

        public static int[] KmpAlgo(string s)
        {
            int[] lps = new int[s.Length];
            int j = 0;
            int i= 1;
            while (i < s.Length)
            {
                if (s[i] == s[j])
                {
                    j += 1;
                    lps[i] = j;
                    i += 1;
                }
                else if (j > 0)
                {
                    j = lps[j - 1];
                }
                else
                {
                    lps[i] = 0;
                    i += 1;
                }
            }
            return lps;
        }



        //is s is roattion of itself(Another Method to find soluton
        public static bool IsRepeatedSubstringWithRotations(string s)
        {
            return (s + s).Substring(1, 2 * s.Length - 2).Contains(s);
        }





        //c# optimal solution
        public static bool RepeatedSubstringPattern(string s)
        {
            int n = s.Length;

            if (n == 1) return false;
            if (n == 2) return s[0] == s[1];

            foreach (var d in Divisors(n))
            {

                var part = s.Substring(0, d);
                var match = true;
                for (int i = 0; i < n; ++i)
                {

                    if (s[i] != part[i % d])
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                    return true;
            }

            return false;
        }

        static IEnumerable<int> Divisors(int n)
        {
            for (int i = n / 2; i >= 1; --i)
            {
                if (n % i == 0)
                    yield return i;
            }
        }
    }
}
