using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap__Priority_Queue_
{
    public static class ReOrganizeString__767_
    {
		public static string ReOrganizeString(string S)
		{
            int[] hash = new int[26];
            for (int i = 0; i < S.Length; i++)
            {
                hash[S.ElementAt(i) - 'a']++;
            }
            int max = 0, letter = 0;
            for (int i = 0; i < hash.Length; i++)
            {
                if (hash[i] > max)
                {
                    max = hash[i];
                    letter = i;
                }
            }
            if (max > (S.Length + 1) / 2)
            {
                return "";
            }
            char[] res = new char[S.Length];
            int idx = 0;
            while (hash[letter] > 0)
            {
                res[idx] = (char)(letter + 'a');
                idx += 2;
                hash[letter]--;
            }
            for (int i = 0; i < hash.Length; i++)
            {
                while (hash[i] > 0)
                {
                    if (idx >= res.Length)
                    {
                        idx = 1;
                    }
                    res[idx] = (char)(i + 'a');
                    idx += 2;
                    hash[i]--;
                }
            }
            return new string(res);

        }
        public static string reOrganizeString(string s)
        {
            int[] hash = new int[26];
            for (var i = 0; i < s.Length; i++)
            {
                hash[s.ElementAt(i) - 'a']++;
            }
            int max = 0, letter = 0;
            for (var i=0; i < hash.Length; i++){
                if (hash[i] > max)
                {
                    max = hash[i];
                    letter = i;
                }

            }
            if (max > (s.Length + 1) / 2) return string.Empty;
            int idx = 0;
            char[] result = new char[s.Length];
            while (hash[letter] > 0)
            {
                result[idx] = (char)(letter + 'a');
                idx += 2;
                hash[letter]--;
            }
            for (var i = 0; i < hash.Length; i++)
            {
                while(hash[i] > 0)
                {
                    if (idx >= result.Length) idx = 1;
                    result[idx] = (char)(i + 'a');
                    idx += 2;
                    hash[i]--;
                }


            }
            return new string(result);
        }
    }
}
