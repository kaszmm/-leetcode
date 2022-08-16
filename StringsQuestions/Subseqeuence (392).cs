using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
    public static class Subseqeuence__392_
    {
		public static bool IsSubseqeunce(string s, string t)
		{
            int j = 0;
            for(var i = 0; i < t.Length; i++)
            {
                if (t[i] == s[j])
                {
                    j++;
                }
                if (j == s.Length) return true;
            }
            return false;
        }
	}
}
