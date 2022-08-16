using System;
using System.Collections.Generic;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "adefba";
            string b = "abdbaabebaiakab";
            int[] numsa = { 4,2,5,1,3 };
            int[] numsb = { 4,5,2,3,1 };

            IList<IList<int>> jagList = new List<IList<int>>();
            jagList.Add(new List<int> { 1,1,1});
            jagList.Add(new List<int> { 1,1,1});
            //jagList.Add(new List<int> { 1, 3, 2 });
            //jagList.Add(new List<int> { 2, 4 });
            //jagList.Add(new List<int> { 3, 1, 2 });
            //jagList.Add(new List<int> { 1, 3, 1, 1 });
            IList<string> list = new List<string>();
            var sentence = "the cattle was rattled by the battery";
            list.Add("cat");
            list.Add("bat");
            list.Add("rat");
            //list.Add("ca");
            //list.Add("at");
            Node n1 = new Node(7);
            Node n2 = new Node(11);
            Node n3 = new Node(13);
            Node n4 = new Node(10);
            Node n5 = new Node(1);
            n1.next = n2;
            n1.random = null;
            n2.next = n3;
            n2.random = n1;
            n3.next = n4;
            n3.random = n5;
            n4.next = n5;
            n4.random = n3;
            n5.random = n1;
            char[][] jaggedMAtrix = new char[][]
            {
                new char[] { '5','3','.','.','7','.','.','.','.'},
                new char[] { '6','.','.','1','9','5','.','.','.' },
                new char[] { '.','9','8','.','.','.','.','6','.' },
                new char[] { '8','.','.','.','6','.','.','.','3'},
                new char[] { '4','.','.','8','.','3','.','.','1'},
                new char[] { '7','.','.','.','2','.','.','.','6' }, 
                new char[] { '.','6','.','.','.','.','2','8','.'}, 
                new char[] { '.','.','.','4','1','9','.','.','5'}, 
                new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }

            };
            char[] tasks = { 'A', 'A', 'A', 'A', 'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G' };

            ReplaceWords__648_.ReplaceWords(list,sentence);
        }
    }
}
