using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap__Priority_Queue_
{
    public static class ReduceArraySizeToHalf__1338_
    {
		public static int minSetSize(int[] arr)
		{
			Dictionary<int, int> dict = new Dictionary<int, int>();
			for (var i = 0; i < arr.Length; i++)
			{
				if (!dict.ContainsKey(arr[i])) dict.Add(arr[i], 0);
				dict[arr[i]]++;
			}
			var newList = dict.ToList();
			newList.Sort((x, y) => y.Value - x.Value);
			int count = 0;
			int curCount = 0;
			foreach(var item in newList)
			{
				if (curCount >= arr.Length / 2) break;
				else
				{
					curCount += item.Value;
					count++;
				}

			}
			return count;

		}
        public static  int MinSetSize(int[] arr)
        {
            Dictionary<int, int> count = new Dictionary<int, int>();

            int uniqueElems = 0;
            foreach (var a in arr)
            {
                if (count.TryGetValue(a, out int aCount))
                {
                    count[a] = aCount + 1;
                }
                else
                {
                    uniqueElems++;
                    count.Add(a, 1);
                }
            }

            int[] heap = new int[uniqueElems];
            int heapLen = 0;

            foreach (var key in count.Keys)
            {
                Heapify(heap, heapLen, count[key]);
                heapLen++;
            }

            int sum = 0;
            int result = 0;
            while (sum < arr.Length / 2)
            {
                sum += PopCount(heap, heapLen);
                heapLen--;
                result++;
            }

            return result;

        }

        private static void Heapify(int[] heap, int heapLen, int a)
        {
            int i = heapLen;
            heap[i] = a;
            int parent = i / 2;

            while (heap[parent] < heap[i])
            {
                if (i == 0)
                    break;

                Swap(heap, parent, i);

                i = parent;
                parent = i / 2;
            }
        }

        private static int PopCount(int[] heap, int heapLen)
        {
            int maxElem = heap[0];
            Swap(heap, 0, heapLen - 1);
            heapLen--;

            int p = 0;
            int lc = 2 * p;
            int rc = 2 * p + 1;

            while (lc < heapLen)
            {
                if (rc >= heapLen) rc = lc;

                if (heap[p] >= heap[lc] && heap[p] >= heap[rc])
                    break;

                int swapChild = heap[rc] < heap[lc] ? lc : rc;

                Swap(heap, p, swapChild);

                p = swapChild;
                lc = 2 * p;
                rc = 2 * p + 1;

            }

            return maxElem;
        }

        private static  void Swap(int[] num, int i, int j)
        {
            int temp = num[i];
            num[i] = num[j];
            num[j] = temp;
        }
    }
}
