using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathemathics
{
    public static class MinimumTimeDifference__539_
    {
        public static int FindMinDifference(IList<string> timePoints)
        {
            bool[] mark = new bool[24 * 60];//total possible time difference is 1440(24*60)
            foreach (var time in timePoints)
            {
                var t = time.Split(":");
                int h = int.Parse(t[0]);
                int m = int.Parse(t[1]);
                if (mark[h * 60 + m]) return 0;//if time already exist in array means same time exist in array so difference will be 0 so return 0
                mark[h * 60 + m] = true;//else mark the array as true
            }
            int prev = 0, min = int.MaxValue;//we using min for capturing min time difference between sequential times like 3:44 and 4:21
            int first = int.MaxValue, last = int.MinValue;//we using first and last to find difference in wrap around time like 00:00 and 23:59 is much closer than 00:00 and 1:00 so to capture that difference use first as minimum of all time we found in array like 00:00 and last being the maximum time we can find in array like 23:59
            for (int i = 0; i < 24 * 60; i++)
            {
                if (mark[i]) //we compute if and only if that time exist in array
                {
                    if (first != int.MaxValue)//so first is MaxValue than it means we step upon first time in array so cant compute sequential diff if we have only one time
                    {
                        min = Math.Min(min, i - prev);//it is just a sequential time difference  like 2:30 and 4:21 
                    }
                    first = Math.Min(first, i);//here get the most minimum time we can get
                    last = Math.Max(last, i);//get the most maximum time we can get
                    prev = i;//it is used to to calculate sequential time difference
                }
            }

            min = Math.Min(min, (24 * 60 - last + first));//at end we check whther the sequential time difference is low or the wrap aorund time is low ,
                                                          //sequential time like 2:00 and 4:21 while wrap aound time is 00:00 and 23:00
                                                          //return which ever is low

            return min;
        }
    }
}
