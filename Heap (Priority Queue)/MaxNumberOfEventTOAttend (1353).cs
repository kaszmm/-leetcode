using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap__Priority_Queue_
{
    public  class MaxNumberOfEventTOAttend__1353_
    {
		public  int MaxEventsToAttend(int[][] events)
		{
			int max = events.SelectMany(x => x).ToList().Max();
			List<(string,int)>[] buckets = new List<(string, int)>[max+1];
			int i = 1;
			List<string> blackList = new List<string>();
			string curEvent = "";
			int diff = 0;
			string eventToAdd = "";
			int eventWithMinDiff = int.MaxValue;
			foreach (var item in events)
			{
				Dictionary<string, int> dict = new Dictionary<string, int>();
				curEvent = $"e{i}";
				diff = item[1] - item[0];
				i++;
				if (buckets[item[0]] == null) buckets[item[0]] = new List<(string, int)>();
				if (buckets[item[1]] == null) buckets[item[1]] = new List<(string, int)>();
				buckets[item[0]].Add((curEvent, diff));
				if (diff==0) continue;
				buckets[item[1]].Add((curEvent, diff));
			}
			for(var j = 1; j < buckets.Length; j++)
			{
                if (buckets[j] != null)
                {
					eventToAdd = "";
					eventWithMinDiff =int.MaxValue;
					foreach (var bevent in buckets[j])
					{
                        if (eventWithMinDiff >=bevent.Item2 && !blackList.Contains(bevent.Item1))
                        {
							eventToAdd = bevent.Item1;
							eventWithMinDiff = bevent.Item2;
						}
					}
					if (!string.IsNullOrEmpty(eventToAdd))
					{
						blackList.Add(eventToAdd);
					}
				}
			}
			blackList.ForEach(x => Console.WriteLine("The elemet under list is " + x));
			return blackList.Count();
		}
        public int MaxEvents(int[][] events)
        {
            int N = events.Length;
            if (N <= 1) return N;

            // sort by start day
            Array.Sort(events, (a, b) => a[0].CompareTo(b[0]));

            int eventCnt = 0;
            var pq = new MyPriorityQueue(N);
            int maxDay = 100000;
            int actualMax = 0;
            int i = 0;
            for (int day = events[0][0]; day <= maxDay; ++day)
            {
                // add open events to the queue
                while (i < N && events[i][0] == day)
                {
                    if (events[i][1] > actualMax) actualMax = events[i][1];
                    pq.Enqueue(events[i][1]);
                    i++;
                }

                int endDay = 0;
                while (endDay < day && pq.Count > 0)
                    endDay = pq.Dequeue();

                if (endDay >= day) eventCnt++;

                if (i >= N && day > actualMax) break;
            }

            /*
                [1,5],[1,5],[1,5],[2,3],[2,3]
                eventCnt = 1
                i = 1, curDay = 1, nextDay = 2
            */

            return eventCnt;
        }

        // Min heap
        public class MyPriorityQueue
        {
            private const int Root = 1;

            // 0 not used, 1 | 2,3 | 4,5 6,7 |
            private int[] heap;
            private int capacity;

            public int Count;

            public MyPriorityQueue(int capacity)
            {
                this.capacity = capacity;
                heap = new int[capacity + 1];
                Count = 0;
            }

            public void Enqueue(int val)
            {
                Count++;
                heap[Count] = val;
                Float(Count);
            }

            public int Dequeue()
            {
                int val = heap[Root];
                Swap(Root, Count);
                Count--;
                Sink();

                return val;
            }

            private void Float(int cur)
            {
                int parent = cur / 2;
                while (cur > Root && heap[cur] < heap[parent])
                {
                    Swap(cur, parent);
                    cur = parent;
                    parent = cur / 2;
                }
            }

            private void Sink()
            {
                int cur = Root;
                int left = 2 * cur;
                int right = left + 1;
                while (left <= Count)
                {
                    int smaller = (right <= Count && heap[right] < heap[left]) ?  right : left;

                    if (heap[cur] > heap[smaller])
                    {
                        Swap(cur, smaller);
                        cur = smaller;
                        left = 2 * cur;
                        right = left + 1;
                    }
                    else
                        return;
                }
            }

            private void Swap(int i, int j)
            {
                var temp = heap[i];
                heap[i] = heap[j];
                heap[j] = temp;
            }
        }
    }


}
