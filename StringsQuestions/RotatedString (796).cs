using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
    public static class RotatedString__796_
    {
        public static bool RotateString(string s, string goal)
        {
            if (s.Length != goal.Length) return false;
            string rotatedValue = "";
            int n = s.Length;
            for (var i = 1; i < s.Length; i++)
            {
                rotatedValue = s.Substring(n - i) + s.Substring(0, n - i);
                if (rotatedValue == goal) return true;
            }
            return false;
        }
    }
}
