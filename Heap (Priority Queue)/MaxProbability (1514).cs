using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap__Priority_Queue_
{
    public static class MaxProbability__1514_
    {
        public static double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end)
        {
            var graph = new Dictionary<int, Dictionary<int, double>>();
            for (int i = 0; i < n; i++)
                graph[i] = new Dictionary<int, double>();

            for (int i = 0; i < edges.Length; i++)
            {
                int u = edges[i][0], v = edges[i][1];
                graph[u][v] = succProb[i];
                graph[v][u] = succProb[i];
            }

            var prob = new Dictionary<int, double>();
            for (int i = 0; i < n; i++)
                prob[i] = 0;
            prob[start] = 1.0;
            var queue = new Queue<int>();
            queue.Enqueue(start);

            while (queue.Count != 0)
            {
                var curr = queue.Dequeue();
                foreach (var edge in graph[curr])
                {
                    int next = edge.Key;
                    double p = edge.Value;
                    if (prob[next] < (prob[curr] * p))
                    {
                        queue.Enqueue(next);
                        prob[next] = prob[curr] * p;
                    }
                }
            }

            return prob[end];
        }
        public static double OptimizedMaxProbability(int n, int[][] edges, double[] succProb, int start, int end)
        {

            var cost = new double[n];
            cost[start] = 1;
            for (int i = 0; i < n - 1; i++)
            {
                var flag = false; //It should be updated at least every time it runs, but if it doesn't, there's no reason to run it, so quit immediately

                for (int j = 0; j < edges.Length; j++)
                {

                    var posImprove = cost[edges[j][0]] * succProb[j];
                    if (posImprove > cost[edges[j][1]])
                    {
                        cost[edges[j][1]] = posImprove;
                        flag = true;
                    }
                    posImprove = cost[edges[j][1]] * succProb[j];
                    if (posImprove > cost[edges[j][0]])
                    {
                        cost[edges[j][0]] = posImprove;
                        flag = true;
                    }
                }
                if (flag == false)
                    break;
            }
            return cost[end];
        }
    }
}
