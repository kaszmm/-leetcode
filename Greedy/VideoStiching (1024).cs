using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public static class VideoStiching__1024_
    {
        public static int VideoStitching(int[][] clips, int T)
        {
            Array.Sort(clips, (x, y) => x[0].CompareTo(y[0]) != 0 ? x[0].CompareTo(y[0]) : y[1].CompareTo(x[1]));

            int res = 0;
            int curEnd = 0;
            int nextEnd = 0;
            int i = 0;
            while (i < clips.Length && clips[i][0] <= curEnd)
            {
                // be greedy on next clip selection, pick the one has max end
                for (; i < clips.Length && clips[i][0] <= curEnd; ++i)
                {
                    nextEnd = Math.Max(nextEnd, clips[i][1]);
                }

                // add next clip and update merged clip end
                ++res;
                curEnd = nextEnd;
                if (curEnd >= T)
                {
                    return res;
                }
            }
            return -1;
        }
    }
}
