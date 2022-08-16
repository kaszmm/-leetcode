using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public static class TwoCityScheduling__1029_
    {
        public static int TwoCitySchedCost(int[][] costs)
        {
            var listOfList = costs.ToList();
            listOfList.Sort((a, b) => (a.First() - a.Last()) - (b.First()- b.Last()));
            costs = listOfList.ToArray();
            int price = 0;
            for (int i = 0; i < costs.Length / 2; i++)
            {
                price += costs[i][0];
            }
            for (int i = costs.Length / 2; i < costs.Length; i++)
            {
                price += costs[i][1];
            }
            return price;
        }
    }
}
