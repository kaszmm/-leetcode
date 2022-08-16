using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public static class MinArrowToBurstBalloon__452_
    {
        public static int findMinArrowShots(int[][] points)
        {
            if (points == null || points.Length == 0)
                return 0;

            Array.Sort(points, (a, b) => a[1].CompareTo(b[1]));
            int end = points[0][1], cnt = 1;
            for (int i = 1; i < points.Length; i++)
            {
                if (end >= points[i][0])
                    continue;

                cnt++;
                end = points[i][1];
            }

            return cnt;
        }

    }
}
