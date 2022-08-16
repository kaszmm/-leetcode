using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap__Priority_Queue_
{
    public static class NetworkTimeDelay__743_
    {
        public static int NetworkDelayTime(int[][] times, int N, int K)
        {
            Dictionary<int, List<int[]>> graph = new Dictionary<int, List<int[]>>();
            foreach (int[] edge in times)
            {
                if (!graph.ContainsKey(edge[0]))
                    graph.Add(edge[0], new List<int[]>());
                graph[edge[0]].Add(new int[] { edge[1], edge[2] }); //adj node and weight;  
            }

            //list of node in queue
            List<int> Q = new List<int>();
            for (int i = 1; i <= N; i++)
                Q.Add(i);

            //distance from k to node i;
            int[] distmap = new int[N + 1];
            //init all the distance to MaxValue, except K node; since it is already at the source.
            //nodes are using 1 to N; so 0 node is useless;
            for (int i = 1; i <= N; i++)
                distmap[i] = Int32.MaxValue;

            distmap[0] = -1; //0 node does not exist.
            distmap[K] = 0;

            while (Q.Count > 0)
            {
                //find the node with shortest distance from K.
                Q.Sort(Comparer<int>.Create((a, b) => distmap[a] - distmap[b]));
                int q = Q[0];
                if (q == 0)
                    break;
                if (graph.ContainsKey(q))
                {
                    List<int[]> adj = graph[q];
                    for (int i = 0; i < adj.Count; i++)
                    {
                        int v = adj[i][0];
                        int dist = adj[i][1];
                        //relax the distance between K and v;
                        distmap[v] = Math.Min(distmap[v], distmap[q] + dist);
                    }
                }
                Q.Remove(q);
            }
            //find the max distance in distmap
            int max = 0;
            for (int i = 1; i <= N; i++)
            {
                max = Math.Max(distmap[i], max);
            }
            return (max == Int32.MaxValue) ? -1 : max;
        }
        public static int networkDelayTime(int[][] times, int n, int k)
        {
            Dictionary<int, List<int[]>> graph = new Dictionary<int, List<int[]>>();
            foreach (var item in times)
            {
                if (!graph.ContainsKey(item[0]))
                    graph.Add(item[0], new List<int[]>());
                graph[item[0]].Add(new int[] { item[1], item[2] });

            }
            List<int> nodes = new List<int>();
            for (var i = 1; i <= n; i++) nodes.Add(i);
            int[] distances = new int[n + 1];
            for (var i = 1; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[0] = -99;
            distances[k] = 0; //main source node
            while (nodes.Count > 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);
                int current = nodes[0];
                if (graph.ContainsKey(current))
                {
                    List<int[]> edges = graph[current];
                    foreach (var item in edges)
                    {
                        distances[item[0]] = Math.Min(distances[item[0]], distances[current] + item[1]);
                    }
                }
                nodes.Remove(current);

            }
            int max = 0;
            foreach (var item in distances)
            {
                max = Math.Max(item, max);
            }
            return max == int.MaxValue ? -1 : max;

        }

        public static int OptimizedNetworkDelayTime(int[][] times, int n, int k)
        {
            int[,] connections = new int[n, n];
            HashSet<int> visited = new HashSet<int>();
            int[] distances = new int[n];

            int maxDistance = -1;

            for (int i = 0; i < n; i++)
            {
                distances[i] = -1;
                for (int j = 0; j < n; j++)
                {
                    connections[i, j] = -1;
                }
            }
            for (int i = 0; i < times.Length; i++)
            {
                int from = times[i][0] - 1;
                int to = times[i][1] - 1;
                int d = times[i][2];
                connections[from, to] = d;
            }

            Queue<int> nodes = new Queue<int>();
            k--;
            nodes.Enqueue(k);
            distances[k] = 0;

            while (nodes.Count > 0)
            {
                int cur = nodes.Dequeue();
                int curDistance = distances[cur];

                for (int i = 0; i < n; i++)
                {
                    if (cur == i || connections[cur, i] < 0)
                    {
                        continue;
                    }

                    int totalDistance = curDistance + connections[cur, i];
                    if (distances[i] == -1 || totalDistance < distances[i])
                    {
                        distances[i] = totalDistance;
                        nodes.Enqueue(i);
                    }
                }
            }

            for (int i = 0; i < distances.Length; i++)
            {
                if (distances[i] == -1)
                {
                    return -1;
                }

                if (distances[i] > maxDistance)
                {
                    maxDistance = distances[i];
                }
            }

            return maxDistance;
        }
    }
}
