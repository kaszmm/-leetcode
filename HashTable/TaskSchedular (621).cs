using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public static class TaskSchedular__621_
    {
        public static int leastInterval(char[] tasks, int n)
        {
            if (n == 0) return tasks.Length;
            int[] counter = new int[26];
            int max = 0;
            int maxCount = 0;
            foreach(char task in tasks)
            {
                counter[task - 'A']++;
                if (max == counter[task - 'A'])
                {
                    maxCount++;
                }
                else if (max < counter[task - 'A'])
                {
                    max = counter[task - 'A'];
                    maxCount = 1;
                }
            }

            int emptySlots = n * (max - 1);
            int emptySpace = emptySlots - (tasks.Length - max - (maxCount - 1));
            if (emptySpace < 0)
                emptySpace = 0;
            return tasks.Length + emptySpace;
        }
    }
}
