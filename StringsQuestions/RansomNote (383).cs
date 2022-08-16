using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
    public static class RansomNote__383_
    {
		public static bool CanMakeNote(string ransomNote, string magazine)
		{
            if (String.IsNullOrEmpty(ransomNote)) return true;
            if (String.IsNullOrEmpty(magazine) || magazine.Length<ransomNote.Length) return false;
			IDictionary<char, int> magMap = new Dictionary<char, int>();

			foreach(var item in magazine)
            {
                if (!magMap.ContainsKey(item))
                {
                    magMap[item] = 0;
                }
                magMap[item]++;
            }

            foreach(var item in ransomNote)
            {
                if (!magMap.ContainsKey(item) || magMap[item] == 0 ) return false;
                magMap[item]--;
            }
            return true;




		}
	}
}
