using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
    public static class ValidParenthesis__20_
    {
        public static bool IsValidPrenthesis(string s)
        {
            Stack<char> parens = new Stack<char>();
            for(var i=0;i<s.Length;i++)
            {
                switch (s[i])
                {
                    case '(':
                        parens.Push(')');
                        break;
                    case '{':
                        parens.Push('}');
                        break;
                    case '[':
                        parens.Push(']');
                        break;
                    case ')': case '}': case ']':
                        if (parens.Count == 0 || parens.Pop() != s[i]) return false;
                        break;
                }
            }
            return parens.Count == 0;
        }
        public static bool OptimizedIsValid(string s)
        {

            Stack<char> st = new();
            foreach (char ch in s)
            {
                if (ch == '(' || ch == '{' || ch == '[') st.Push(ch);
                else
                {
                    if (st.Count == 0) st.Push(ch);

                    else if ((ch == ')' && st.Peek() == '(') ||
                            (ch == '}' && st.Peek() == '{') ||
                            (ch == ']' && st.Peek() == '[')) st.Pop();

                    else st.Push(ch);
                }
            }
            return st.Count == 0;
        }
    }
}
