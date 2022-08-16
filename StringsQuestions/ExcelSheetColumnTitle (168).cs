using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
    public static class ExcelSheetColumnTitle__168_
    {
        public static string ConvertNumtoString(int n)
        {
            StringBuilder stringBuilder = new StringBuilder();
            while (n > 0)
            {
                n--;
                int current = n % 26;
                n /= 26;
                stringBuilder.Append((char)(current + 'A'));
            }
            char[] l = stringBuilder.ToString().ToCharArray();
            Array.Reverse(l);
            return new string(l);

        }
    }
}
