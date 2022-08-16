using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public static class BrickWall__554_
    {
		public static int LeastBricks(IList<IList<int>> wall)
		{

			Dictionary<int, int> dict = new Dictionary<int, int>();
			int max = 0;
			int sum = 0;
			foreach(var item in wall)
            {
				sum = 0;
				for(var i=0;i<item.Count-1;i++)
                {
					sum += item.ElementAt(i);
					if (!dict.ContainsKey(sum)) dict.Add(sum, 0);
					dict[sum]++;
					max = Math.Max(max, dict[sum]);
                }
            }
			return wall.Count - max;
		}
	}
}
