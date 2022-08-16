using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    class DesignHashMap__706_
    {
    }

	public class MyHashMap
	{

		List<ListNode> organicDict;
		public MyHashMap()
		{
			organicDict = new List<ListNode>();
		}

		public void Put(int key, int value)
		{
			bool isAdded = false;
			if (organicDict.Count != 0)
			{
				foreach (var item in organicDict)
				{
					if (item.val == key)
					{
						item.next.val = value;
						isAdded = true;
						break;
					}
				}
			}
			if(!isAdded)
			{
				ListNode n = new ListNode();
				n.val = key;
				n.next = new ListNode(value);
				organicDict.Add(n);
			}

		}

		public int Get(int key)
		{
			if (organicDict.Count == 0) return -1;
			foreach(var item in organicDict){
				if (item.val == key) return item.next.val;
			}
			return -1;
		}

		public void Remove(int key)
		{
            if (organicDict.Count != 0)
            {
				foreach (var item in organicDict)
				{
					if (item.val == key)
					{
						organicDict.Remove(item);
						break;
					}
				}
			}
			
		}
	}
}
