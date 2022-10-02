using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blind_75
{

    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
    public class UndirectedGraphNode
    {
        public int label;
        public List<UndirectedGraphNode> neighbors;
        public UndirectedGraphNode(int x)
        {
            label = x;
            neighbors = new List<UndirectedGraphNode>();
        }
    }
    public class Graphs
    {
        //1 (using DFS)
        public int NumIslands(char[][] grid)
        {
            int rows = grid.Length;
            int columns = grid[0].Length;
            int islandCount = 0;
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        MapIsland(i, j, ref grid);
                        islandCount++;
                    }

                }

            }
            return islandCount;
        }
        public void MapIsland(int r, int c, ref char[][] grid)
        {
            if (r >= grid.Length || r < 0 || c < 0 || c >= grid[0].Length || grid[r][c] == '#' || grid[r][c] == '0')
            {
                return;
            }
            grid[r][c] = '#';
            MapIsland(r, c + 1, ref grid);
            MapIsland(r, c - 1, ref grid);
            MapIsland(r + 1, c, ref grid);
            MapIsland(r - 1, c, ref grid);
            return;
        }

        //using (BFS)
        public int BfsNumIslands(char[][] grid)
        {
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            int islands = 0;
            void BfsMap(int r, int c)
            {
                Queue<(int, int)> q = new Queue<(int, int)>();

                q.Enqueue((r, c));
                visited.Add((r, c));
                while (q.Count > 0)
                {
                    var value = q.Dequeue();
                    List<int[]> directions = new List<int[]>() { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
                    foreach (var item in directions)
                    {
                        r = item[0] + value.Item1;
                        c = item[1] + value.Item2;
                        if ((r >= 0) && (r < grid.Length) && (c >= 0) && (c < grid[0].Length) && !visited.Contains((r, c)) && grid[r][c] == '1')
                        {
                            q.Enqueue((r, c));
                            visited.Add((r, c));
                        }
                    }
                }
            }

            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1' && !visited.Contains((i, j)))
                    {
                        BfsMap(i, j);
                        islands++;
                    }

                }

            }
            return islands;
        }

        //2 DFS Clone
        public Node CloneGraph(Node node)
        {
            Dictionary<int, Node> dict = new Dictionary<int, Node>();
            Node DfsClone(Node node)
            {
                if (node == null) return null;
                if (dict.ContainsKey(node.val))
                {
                    return dict[node.val];
                }
                var tempNode = new Node(node.val, new List<Node>());
                dict.Add(node.val, tempNode);
                foreach (var n in node.neighbors)
                {
                    tempNode.neighbors.Add(DfsClone(n));
                }
                return tempNode;
            }
            return DfsClone(node);
        }

        //BFS clone
        public Node BfsCloneGraph(Node node)
        {
            if (node == null) return node;
            Queue<Node> q = new Queue<Node>();
            Dictionary<Node, Node> visited = new Dictionary<Node, Node>();
            visited[node] = new Node(node.val);

            q.Enqueue(node);
            while (q.Count > 0)
            {
                Node temp = q.Dequeue();
                foreach (var nei in temp.neighbors)
                {
                    if (!visited.ContainsKey(nei))
                    {
                        visited[nei] = new Node(nei.val);
                        q.Enqueue(nei);
                    }

                    visited[temp].neighbors.Add(visited[nei]);
                }
            }

            return visited[node];
        }

        //3
        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            HashSet<(int, int)> isPacific = new HashSet<(int, int)>();
            HashSet<(int, int)> isAtlantic = new HashSet<(int, int)>();

            IList<IList<int>> result = new List<IList<int>>();
            int ROWS = heights.Length;
            int COLUMNS = heights[0].Length;
            void DfsTravel(int r, int c, HashSet<(int,int)> visit,int curHeight)
            {
                if (r < 0 || r >= ROWS || c < 0 || c >= COLUMNS || heights[r][c] <curHeight || visit.Contains((r,c)))
                {
                    return;
                }
                visit.Add((r,c));
                DfsTravel(r, c - 1, visit, heights[r][c]);
                DfsTravel(r, c + 1, visit, heights[r][c]);
                DfsTravel(r - 1, c, visit, heights[r][c]); 
                DfsTravel(r + 1, c, visit, heights[r][c]);
            }
            for(var col = 0; col < COLUMNS; col++)
            {
                DfsTravel(0, col, isPacific, heights[0][col]);
                DfsTravel(ROWS-1, col, isAtlantic, heights[ROWS-1][col]);

            }
            for (var row = 0; row < ROWS; row++)
            {
                DfsTravel(row,0, isPacific, heights[row][0]);
                DfsTravel(row,COLUMNS-1, isAtlantic, heights[row][COLUMNS-1]);
            }

            for (var i = 0; i < ROWS; i++)
            {
                for (var j = 0; j < COLUMNS; j++)
                {
                    if (isAtlantic.Contains((i,j)) && isPacific.Contains((i, j)))
                    {
                        result.Add(new List<int> { i, j });
                    }
                }

            }

            return result;
        }


        //4
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, List<int>> preMap = new Dictionary<int, List<int>>();
            HashSet<int> visited = new HashSet<int>();

            for (int i = 0; i < numCourses; i++)
            {
                preMap.Add(i, new List<int>());
            }
            foreach (var item in prerequisites)
            {
                if (!preMap.ContainsKey(item[0])) preMap.Add(item[0],new List<int>());
                preMap[item[0]].Add(item[1]);
            }

            bool DfsSearch(int curCourse)
            {
                if (visited.Contains(curCourse)) return false;
                if (preMap[curCourse].Count==0)
                    return true;
                visited.Add(curCourse);


                foreach(var item in preMap[curCourse])
                {
                    if (!DfsSearch(item)) return false;
                }
                visited.Remove(curCourse);
                preMap[curCourse] = new List<int>();
                return true;
            }
            foreach (int cor in Enumerable.Range(0, numCourses))
            {
                if (!DfsSearch(cor)) return false;
            }
            return true;
        }

        //Iterative DFS using Stack
        public bool IterativeCanFinish(int numCourses, int[][] prerequisites)
        {
            var prereqMap = new Dictionary<int, List<int>>();
            var prereqCount = new int[numCourses];

            for (int i = 0; i < prerequisites.Length; i++)
            {
                if (!prereqMap.ContainsKey(prerequisites[i][1]))
                {
                    prereqMap[prerequisites[i][1]] = new List<int>();
                }
                prereqCount[prerequisites[i][0]] += 1;
                prereqMap[prerequisites[i][1]].Add(prerequisites[i][0]);
            }
            var stack = new Stack<int>();
            for (int i = 0; i < prereqCount.Length; i++)
            {
                if (prereqCount[i] == 0)
                {
                    stack.Push(i);
                }
            }
            var count = 0;
            while (stack.Count != 0)
            {
                var popped = stack.Pop();
                count += 1;
                if (prereqMap.ContainsKey(popped))
                {
                    foreach (var prereq in prereqMap[popped])
                    {
                        prereqCount[prereq] -= 1;
                        if (prereqCount[prereq] == 0)
                        {
                            stack.Push(prereq);
                        }
                    }
                }
            }
            return count == numCourses ? true : false;
        }

        private int[] parent;
        private int[] rank;

        //5  (didnt did it cause it is a premium question) uses Union find in this problem
        public int countComponents(int n, int[][] edges)
        {
            int find(int node)
            {
                int result = node;

                while (parent[result] != result)
                {
                    parent[result] = parent[parent[result]];
                    result = parent[result];
                }

                return result;
            }

            int union(int n1, int n2)
            {
                int p1 = find(n1);
                int p2 = find(n2);

                if (p1 == p2)
                {
                    return 0;
                }

                if (rank[p2] > rank[p1])
                {
                    parent[p1] = p2;
                    rank[p2] += rank[p1];
                }
                else
                {
                    parent[p2] = p1;
                    rank[p1] += rank[p2];
                }

                return 1;
            }
            parent = new int[n];
            rank = new int[n];

            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
                rank[i] = 1;
            }

            int result = n;
            for (int i = 0; i < edges.Length; i++)
            {
                if (union(edges[i][0], edges[i][1]) == 1)
                {
                    result--;
                }
            }

            return result;
        }

        //another same as 5 (number of provinces) use union find
        public int FindCircleNum(int[][] isConnected)
        {
            List<int[]> graph = new List<int[]>();
            int[] parents = new int[isConnected.Length];
            int[] ranks = new int[isConnected.Length];
            for (var i = 0; i < isConnected.Length; i++)
            {
                parents[i] = i;
                ranks[i] = 1;
            }

            int FindParent(int num)
            {
                var result = num;
                while (parents[result] != result)
                {
                    parents[result] = parents[parents[result]];
                    result = parents[result];
                }
                return result;

            }
            int Union(int num1, int num2)
            {
                int p1 = FindParent(num1);
                int p2 = FindParent(num2);
                if (p1 == p2) return 0;
                if (ranks[p1] > ranks[p2])
                {
                    parents[p2] = p1;
                    ranks[p1] += ranks[p2];

                }
                else
                {
                    parents[p1] = p2;
                    ranks[p2] += ranks[p1];
                }
                return 1;
            }
            var result = isConnected.Length;
            for (var i = 0; i < isConnected.Length; i++)
            {
                for (var j = 1; j < isConnected.Length; j++)
                {
                    if (isConnected[i][j] == 1)
                    {
                        graph.Add(new int[] { i, j });
                    }
                }
            }

            foreach(var item in graph)
            {
                if (Union(item[0], item[1]) == 1)
                {
                    result--;
                }
            }
            return result;
        }
        //using dfs
        public int DfsFindCircleNum(int[][] isConnected)
        {
            void DFS(int[][] grid, int[] visited, int start)
            {
                for (int i = 0; i < grid[start].Length; i++)
                {
                    if (visited[i] == 0 && grid[start][i] == 1)
                    {
                        visited[i] = 1;
                        DFS(grid, visited, i);
                    }
                }
            }

            int[] visited = new int[isConnected.Length];
            int ans = 0;
            for (int i = 0; i < isConnected.Length; i++)
            {
                if (visited[i] == 0)
                {
                    visited[i] = 1;
                    DFS(isConnected, visited, i);
                    ans++;
                }
            }
            return ans;
        }


        //6
        public bool validTree(int n, int[][] edges)
        {
            if (n == 0 || n == 1) return true; //if empty or only one node exist return true
            Dictionary<int,List<int>> adj = new Dictionary<int, List<int>>();
            HashSet<int> visited = new HashSet<int>();
            foreach(var item in edges)
            {
                var node1 = item[0];
                var node2 = item[1];
                if(!adj.ContainsKey(node1)) adj.Add(node1, new List<int>());
                if (!adj.ContainsKey(node2)) adj.Add(node2, new List<int>());
                adj[node1].Add(node2);
                adj[node2].Add(node1);
            }

            bool Dfs(int curNode,int prevNode)
            {
                if (visited.Contains(curNode))  //detected loop so cant be valid tree
                    return false;

                visited.Add(curNode);
                foreach(var item in adj[curNode])
                {
                    if (item != prevNode)           //with each curNode we attach its prevNode because
                                                    //we node need to confuse ourself when we encounter the name which exist in visited hashmap
                                                    //into considering that that is a loop because it is false positive loop so avoid using prevNode
                    {
                        if (!Dfs(item, curNode)) return false;  //here now curNODe will be item and prevNode will be curNode
                    }
                }
                return true;
            }
            return Dfs(0, -1) && n == visited.Count;
        }
    }
}
