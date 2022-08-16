using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSums
{
    public static class BuyAndSellStock
    {
        public static int MaxProfits(int[] prices)
        {
            int current = 0;
            int maxProfit = 0;
            for(var i = 0; i < prices.Length-1; i++)
            {
                current = Math.Max(0,current+=prices[i+1]-prices[i]);
                maxProfit = Math.Max(current, maxProfit);
            }
            return maxProfit;
        }

        
    }
}
