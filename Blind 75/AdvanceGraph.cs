using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blind_75
{
    public class AdvanceGraph
    {
        //dont refer neetcode solution refer to vid saved in leetcode folder names Solution Item under this solution
        public string AlienDictionary(string[] words)
        {
            Dictionary<char,HashSet<char>> adjList = new Dictionary<char,HashSet<char>>();
            int[] indegree = new int[26];

            //fill the adj List and indgree array first
            foreach(var word in words)
            {
                foreach(var letter in word)
                {
                    if(!adjList.ContainsKey(letter))
                        adjList[letter] = new HashSet<char>();
                }
            }

            for(var i = 0; i < words.Length - 1; i++)
            {
                var first = words[i];
                var second = words[i+1];

                var ischanged = false;
                var minLength = Math.Min(first.Length, second.Length);
                for(var j=0;j< minLength; j++)
                {
                    if (first[j] != second[j])
                    {
                        if (!adjList[first[j]].Contains(second[j]))
                        {
                            adjList[first[j]].Add(second[j]);
                            indegree[second[j] - 'a']++;
                            ischanged = true;
                            break;
                        }
                    }
                }
                if (!ischanged)
                {
                    if (first.Length > second.Length) return "";   //means we found let say applee[first] and ape[second] which is incorrect
                }
            }

            Queue<char> q = new Queue<char>();
            foreach(var item in adjList)
            {
                if (indegree[item.Key - 'a'] == 0)
                    q.Enqueue(item.Key);
            }

            //bfs
            var result = "";
            while (q.Count > 0)
            {
                var value = q.Dequeue();
                result += value;
                foreach(var neighbors in adjList[value])
                {
                    indegree[neighbors-'a']--;
                    if (indegree[neighbors-'a'] == 0)
                        q.Enqueue(neighbors);
                }
            }

            return result.Length == adjList.Count ? result : "";
        }
    }
}
