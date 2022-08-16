using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathemathics
{
    public static class UniqueBinarySearch__96_
    {
        public static int NumTrees(int n)
        {
            int[] G = new int[n + 1];
            G[0] = G[1] = 1;

            for (int nodes = 2; nodes <= n; ++nodes)
            {
                for (int curRoot = 1; curRoot <= nodes; ++curRoot)
                {              //left side of curRoot       //right side of curRoot
                    G[nodes] += G[curRoot - 1]       *       G[nodes - curRoot];
                }
            }
            return G[n];
        }

        //same code as above
        public static int numTrees(int n)
        {
            int[] numTree = new int[n + 1];
            numTree[0] = numTree[1] = 1;
            for(var node = 2; node <= n; node++)
            {
                for(var root = 1; root <= node; root++)
                {
                    numTree[node] += numTree[root - 1] * numTree[node - root];
                }
            }
            return numTree[n];
        }
    }
}
