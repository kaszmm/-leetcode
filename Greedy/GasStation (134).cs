using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public static class GasStation__134_
    {
        public static int CanCompleteCircuit(int[] gas, int[] cost)
        {
            //determine if we have a solution
            int total = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                total += gas[i] - cost[i];
            }
            if (total < 0)
            {
                return -1;
            }

            // find out where to start
            int tank = 0;
            int start = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                tank += gas[i] - cost[i];
                if (tank < 0)
                {
                    start = i + 1;
                    tank = 0;
                }
            }
            return start;
        }
    }
}
