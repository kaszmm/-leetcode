using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public static class ReplaceWords__648_
    {
        public static string ReplaceWords(IList<string> dictionary, string sentence)
        {
            Trie trie = new Trie();

            foreach (var w in dictionary)
                trie.Add(w);

            string[] arr = sentence.Split(' ');

            for (int i = 0; i < arr.Length; i++)
                arr[i] = trie.Replace(arr[i]);

            return string.Join(" ", arr);
        }

    }

    public class Trie
    {
        class TrieNode
        {
            public TrieNode[] children = new TrieNode[26];
            public bool isEnd;
            public string word;
        }

        TrieNode root = new TrieNode();

        public string Replace(string word)
        {
            TrieNode cur = root;

            foreach (var c in word)
            {
                if (cur.children[c - 'a'] == null || cur.isEnd)
                    break;

                cur = cur.children[c - 'a'];
            }
            return cur.isEnd ? cur.word : word;
        }

        public void Add(string word)
        {
            TrieNode cur = root;

            foreach (var c in word)
            {
                if (cur.children[c - 'a'] == null)
                    cur.children[c - 'a'] = new TrieNode();

                cur = cur.children[c - 'a'];
            }

            cur.isEnd = true;
            cur.word = word;
        }
    }
}

