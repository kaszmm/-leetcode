using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
    public static class ReverseString__917_
    {
		public static  string ReverseOnlyNumbers(string s)
		{
			//fedcba
			if (s.Length == 1) return s;
			char[] newS = s.ToCharArray();
            char temp = 'a';
            int i = 0;
			int j = s.Length - 1;
            while (i < j)
            {
				if (char.IsLetter(s[i]) && char.IsLetter(s[j]))
				{
                    temp = newS[i];
                    newS[i] = newS[j];
                    newS[j] = temp;
                    (newS[i], newS[j]) = (newS[j], newS[i]);
					i++;
					j--;
				}
				else if(!char.IsLetter(s[i]))
				{
					i++;
				}
				else if (!char.IsLetter(s[j]))
                {
					j--;
                }
            }
			return new string(newS);
		}

        public static string ReverseOnlyLetters(string s)
        {

            char[] charArr = s.ToCharArray();
            Stack<char> charStack = new Stack<char>();
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < charArr.Length; i++)
            {
                if (Char.IsLetter(charArr[i]))
                {
                    charStack.Push(charArr[i]);
                }
            }

            for (int i = 0; i < charArr.Length; i++)
            {
                if (Char.IsLetter(charArr[i]))
                {
                    sBuilder.Append(charStack.Pop());
                }
                else
                {
                    sBuilder.Append(charArr[i]);

                }

            }

            return sBuilder.ToString();

        }


    }
}
