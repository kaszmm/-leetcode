using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blind_75
{
    public class Tries
    {

        public class TrieNode
        {
            public TrieNode[] childern = new TrieNode[26];
            public bool IsWordEnded = false;
        }
        public class NewTrieNode
        {
            public Dictionary<char, NewTrieNode> childernSet = new Dictionary<char, NewTrieNode>();
            public bool IsWordEnded = false;
            public int numOfTimeReferenced = 0;
        }
        TrieNode root = new TrieNode();
        NewTrieNode newRoot=new NewTrieNode();
        //1
        //recursion slow
        public void Insert(string word)
        {
            InsertHelper(word, 0, root);
        }
        public void InsertHelper(string word, int index, TrieNode current)
        {
            if (index == word.Length)
            {
                return;
            }
            if (current.childern[word.ElementAt(index) - 'a'] == null)
            {
                var child = new TrieNode();
                current.childern[word.ElementAt(index) - 'a'] = child;
            }
            if (index == word.Length - 1)
            {
                current.childern[word.ElementAt(index) - 'a'].IsWordEnded = true;
            }
            InsertHelper(word, index + 1, current.childern[word.ElementAt(index) - 'a']);

        }
        public bool Search(string word)
        {
            return SearchHelper(word, 0, root);
        }
        public bool SearchHelper(string word, int index, TrieNode current)
        {
            if (index > word.Length - 1 || current.childern[word.ElementAt(index) - 'a'] == null)
            {
                return false;
            }
            if (current.childern[word.ElementAt(index) - 'a'].IsWordEnded == true && index == word.Length - 1) return true;
            return SearchHelper(word, index + 1, current.childern[word.ElementAt(index) - 'a']);
        }
        public bool StartsWith(string prefix)
        {
            return StartsWithHelper(prefix, 0, root);
        }
        public bool StartsWithHelper(string word, int index, TrieNode current)
        {
            if (index > word.Length - 1 || current.childern[word.ElementAt(index) - 'a'] == null)
            {
                return false;
            }
            if (index == word.Length - 1) return true;
            return StartsWithHelper(word, index + 1, current.childern[word.ElementAt(index) - 'a']);
        }

        //iterative fast
        public void OptInsert(string word)
        {
            TrieNode temp = root;
            foreach (var item in word)
            {
                if (temp.childern[item - 'a'] == null)
                {
                    temp.childern[item - 'a'] = new TrieNode();
                }
                temp = temp.childern[item - 'a'];
            }
            temp.IsWordEnded = true;
        }
        public bool OptSearch(string word)
        {
            TrieNode temp = root;
            foreach (var item in word)
            {
                if (temp.childern[item - 'a'] == null)
                {
                    return false;
                }
                temp = temp.childern[item - 'a'];
            }
            return temp.IsWordEnded;
        }
        public bool OptStartsWith(string word)
        {
            TrieNode temp = root;
            foreach (var item in word)
            {
                if (temp.childern[item - 'a'] == null)
                {
                    return false;
                }
                temp = temp.childern[item - 'a'];
            }
            return true;
        }

        //2
        public void AddWord(string word)
        {
            TrieNode temp = root;
            foreach (var item in word)
            {
                if (temp.childern[item - 'a'] == null)
                {
                    var node = new TrieNode();
                    temp.childern[item - 'a'] = node;
                }
                temp = temp.childern[item - 'a'];

            }
            temp.IsWordEnded = true;
        }
        public bool NewSearch(string word)
        {
            return NewSearchHelper(word, 0, root);
        }
        public bool NewSearchHelper(string word, int idx, TrieNode subNode)
        {
            TrieNode temp = subNode;
            for (var i = idx; i < word.Length; i++)
            {
                if (word[i] == '.')
                {
                    for (var j = 0; j < 26; j++)
                    {
                        if (temp.childern[j] != null && NewSearchHelper(word, i + 1, temp.childern[j])) { return true; }
                    }
                    return false;
                }
                else
                {
                    if (temp.childern[word[i] - 'a'] == null) return false;
                }
                temp = temp.childern[word[i] - 'a'];
            }

            return temp.IsWordEnded;
        }


        //optimized using HashSet
        Dictionary<int, HashSet<string>> d = new Dictionary<int, HashSet<string>>();
        public void OptAddWord(string word)
        {
            int n = word.Length;
            if (!d.ContainsKey(n))
                d.Add(n, new HashSet<string>());
            d[n].Add(word);
        }
        public bool OptNewSearch(string word)
        {
            int n = word.Length;
            if (!d.ContainsKey(n))
                return false;
            var words = d[n];
            if (words.Contains(word))
                return true;
            if (word.Contains("."))
            {
                foreach (var w in words)
                {
                    bool found = true;
                    for (int i = 0; i < n; i++)
                    {
                        if (word[i] != '.' && word[i] != w[i])
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found)
                        return true;
                }
            }
            return false;
        }



        //3
        //Correct but not accepted due to bug in leetcode
        public IList<string> FindWords(char[][] board, string[] words)
        {
            HashSet<string> result = new HashSet<string>();

            int COLUMNS = board[0].Length;
            int ROWS = board.Length;
            foreach(var item in words)
            {
                NewWordAdd(item);
            }
            for(var i=0;i<ROWS; i++)
            {
                for(var j = 0; j < COLUMNS; j++)
                {
                    HashSet<string> visited = new HashSet<string>();
                    DfsSearch(newRoot, j, i, board, result, visited, "");
                }
            }
            return result.ToList();
        }

        public void DfsSearch(NewTrieNode node,int c,int r, char[][] board,HashSet<string> res,HashSet<string> vis,string word)
        {
            if(c<0 || r<0 || c==board.Length || r==board.Length || vis.Contains(r + "-" + c) || !node.childernSet.ContainsKey(board[r][c]))
            {
                return;
            }
            vis.Add(r + "-" + c);
            word += board[r][c];
            node = node.childernSet[board[r][c]];   //imp for traversing to next char
            if (node.IsWordEnded)
            {
                res.Add(word);
            }

            DfsSearch(node,c,  r-1, board, res, vis, word);
            DfsSearch(node,c,  r+1, board, res, vis, word);
            DfsSearch(node,c-1,r,   board, res, vis, word);
            DfsSearch(node,c+1,r,   board, res, vis, word);
            vis.Remove(r + "-" + c);   //when dfs search done for one char in grid then remove the visit thing
                                       //so that we can sue the r and c for the next char in grid when we start dfs for that new char
        }
        public void NewWordAdd(string word){
            NewTrieNode temp = newRoot;
            temp.numOfTimeReferenced += 1;
            foreach(var item in word)
            {
                if (!temp.childernSet.ContainsKey(item))
                {
                    temp.childernSet[item] = new NewTrieNode(); 
                }
                temp.childernSet[item].numOfTimeReferenced += 1;
                temp = temp.childernSet[item];
            }
            temp.IsWordEnded = true;
        }


        //optimized and Correct and Accepted by Leetcode
        private class TreeNode2
        {
            public TreeNode2[] next = new TreeNode2[26];
            public string word;
        }
        public IList<string> OptFindWords(char[][] board, string[] words)
        {
            var rs = new List<string>();
            var root = BuildTree(words);
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    Aux(board, i, j, root, rs);
                }
            }
            return rs;
        }
        private void Aux(char[][] board, int i, int j, TreeNode2 p, List<string> rs)
        {
            char c = board[i][j];
            if (c == '#' || p.next[c - 'a'] == null) return;
            p = p.next[c - 'a'];
            if (p.word != null)
            {
                rs.Add(p.word);
                p.word = null;
            }
            board[i][j] = '#';
            if (i > 0) Aux(board, i - 1, j, p, rs);
            if (j > 0) Aux(board, i, j - 1, p, rs);
            if (i < board.Length - 1) Aux(board, i + 1, j, p, rs);
            if (j < board[0].Length - 1) Aux(board, i, j + 1, p, rs);
            board[i][j] = c;
        }
        private TreeNode2 BuildTree(string[] words)
        {
            var root = new TreeNode2();
            foreach (var w in words)
            {
                TreeNode2 p = root;
                foreach (char c in w.ToCharArray())
                {
                    int i = c - 'a';
                    if (p.next[i] == null) p.next[i] = new TreeNode2();
                    p = p.next[i];
                }
                p.word = w;
            }
            return root;
        }
    }
}
