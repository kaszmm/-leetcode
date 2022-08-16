using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
    public static class ExcelSheetColumn__171_
    {
       
            public static int TitleToNumber(string s)
            {
                //int res = 0;

                //for (int i = s.Length - 1; i >= 0; i--)
                //{
                //    int num = s[i] - 'A' + 1;
                //    int degree = s.Length - 1 - i;
                //    res += ((int)Math.Pow(26, degree)) * num;
                //}

                //return res;

            if (s == null) return -1;
            int sum = 0;
            // for each loop so we don't need to mess with index values.
            foreach(var item in s.ToCharArray())
            {
                sum *= 26;
                sum += item - 'A' + 1;
            }
            return sum;
        }
        
    }
}
