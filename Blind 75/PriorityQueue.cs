using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blind_75
{
    public class PriorityQ
	{

		//Min heap implemented
		public class MinHeap
		{
		    int Root = 0;
		    int Count;
		    int Capacity;
		    int[] heap;

			public MinHeap(int capacity)
			{
				Capacity = capacity + 1;
				Count = 0;
				heap = new int[Capacity];
			}

			public void Enqueue(int val)
			{
				heap[Count] = val;
				BubbleUp();
				Count++;
			}

			public void BubbleUp()
			{
				int current = Count;
				int parent = (int)Math.Floor((double)(current - 1) / 2);
				while (current > Root && heap[current] < heap[parent])
				{
					(heap[current], heap[parent]) = (heap[parent], heap[current]);
					current = parent;
					parent = current / 2;
				}
			}

			public int Dequeue()
			{
				Count--;
				int value = heap[Root];
				(heap[Root], heap[Count]) = (heap[Count], heap[Root]);
				Heapify();
				return value;
			}

			public void Heapify()
			{
				int current = Root;
				int left = 2 * current + 1;
				int right = 2 * current + 2;
				while (left < Count)
				{
					int smaller = right < Count && heap[right] < heap[left] ? right : left;
					if (heap[current] >heap[smaller])
					{
						(heap[current], heap[smaller]) = (heap[smaller], heap[current]);
						current = smaller;
						left = 2 * current + 1;
						right = 2 * current + 2;
					}
					else return;
				}
			}
		}


		//1
		public class MaxHeapComparer : IComparer<int>
		{
			public int Compare(int x, int y) => y.CompareTo(x);

		}
		PriorityQueue<int,int> largeHeapWithMinHeap = new PriorityQueue<int,int>();
		PriorityQueue<int,int> smallHeapWithMaxHeap = new PriorityQueue<int,int>(new MaxHeapComparer());


		public void AddNum(int num)
		{
			smallHeapWithMaxHeap.Enqueue(num,num);
			if ((smallHeapWithMaxHeap.Count > 0 && largeHeapWithMinHeap.Count > 0 && smallHeapWithMaxHeap.Peek() > largeHeapWithMinHeap.Peek()))
			{
				var val = smallHeapWithMaxHeap.Dequeue();
				largeHeapWithMinHeap.Enqueue(val,val);
			}
			if(smallHeapWithMaxHeap.Count > largeHeapWithMinHeap.Count + 1){
				var val = smallHeapWithMaxHeap.Dequeue();
				largeHeapWithMinHeap.Enqueue(val, val);
			}
			if (largeHeapWithMinHeap.Count > smallHeapWithMaxHeap.Count + 1)
			{
				var val = largeHeapWithMinHeap.Dequeue();
				smallHeapWithMaxHeap.Enqueue(val, val);
			}
		}

		public double FindMedian()
		{
			if (smallHeapWithMaxHeap.Count == largeHeapWithMinHeap.Count)
			{
				return (double)(smallHeapWithMaxHeap.Peek() + largeHeapWithMinHeap.Peek()) / 2;
			}
			else if (smallHeapWithMaxHeap.Count > largeHeapWithMinHeap.Count)
			{
				return smallHeapWithMaxHeap.Peek();
			}
			else { return largeHeapWithMinHeap.Peek(); }
		}

		//optimized version   (use exact code like Neetcode python version)
		private PriorityQueue<int, int> small=new(); //max heap
		private PriorityQueue<int, int> large=new(); //min heap
		public void OptAddNum(int num)
		{
			// add to small (max heap);
			small.Enqueue(num, -num);

			// check if largest value in small is larger than smallest value in large
			if (small.Count > 0 &&
				large.Count > 0 &&
				small.Peek() > large.Peek())
			{
				var val = small.Dequeue();
				large.Enqueue(val, val);
			}

			// check lengths.
			if (small.Count > large.Count + 1)
			{
				var val = small.Dequeue();
				large.Enqueue(val, val);
			}
			if (large.Count > small.Count + 1)
			{
				var val = large.Dequeue();
				small.Enqueue(val, -val);
			}
		}
		public double OptFindMedian()
		{
			if (small.Count > large.Count)
			{
				return small.Peek();
			}
			if (large.Count > small.Count)
			{
				return large.Peek();
			}

			return small.Peek() + (large.Peek() - small.Peek()) / 2.0;
		}


		public int MostFrequentEven(int[] nums)
		{
			Dictionary<int, int> dict = new Dictionary<int, int>();
			PriorityQueue<int, int> pq = new PriorityQueue<int, int>(new MaxHeapComparer());
			foreach (var item in nums)
			{
				if (!dict.ContainsKey(item))
				{
					dict.Add(item, 0);
				}
				dict[item]++;
			}
			foreach (var item in dict)
			{
				if (item.Key % 2 == 0)
				{
					pq.Enqueue(item.Key, item.Value);
				}
			}
			if (pq.Count == 0) return -1;
			return pq.Dequeue();
		}

		public int PartitionString(string s)
		{
			int i = 0;
			int j = 1;
			string temp = "";
			HashSet<int> tempSet = new HashSet<int>();

			List<string> ans = new List<string>();
			while (i<j && i<s.Length)
			{
				if (!tempSet.Contains(s[i]))
				{
					tempSet.Add(s[i]);
					temp += s[i];
				}
				if ( j<s.Length && !tempSet.Contains(s[j]))
				{
					tempSet.Add(s[j]);
					temp += s[j];
				}
				else
				{
					ans.Add(temp);
					temp = "";
					tempSet = new HashSet<int>();
					i = j;
				}
				j++;
			}
			return ans.Count;
		}

	}
}
