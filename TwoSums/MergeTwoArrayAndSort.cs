using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSums
{
    static class  MergeTwoArrayAndSort
    {
        public static void MergeIt()
        {                    
            int[] a = { 4,5,6,0,0,0};
            int[] b = { 1,2,3};
            Merge(a, 3, b,3);
        }
        //public static void InsertionSort(int[] nums1,int m,int[] nums2,int n)
        //{
        //    nums1 = nums1.Take(m).ToArray();
        //    List<int> lists = nums1.ToList();
        //    lists.Add(0);
        //    lists.Add(0);
        //    foreach (var bi in nums2)
        //    {
        //        bool takeIt = true;
        //        foreach(var ai in nums1)
        //        {
        //            if (bi<=ai)
        //            {
        //                lists.Insert(lists.IndexOf(bi), bi);
        //                takeIt = false;
        //                break;
        //            }

        //        }
        //        if(takeIt)
        //        lists.Insert(lists.Count - 2, bi);
        //    }
        //    lists = lists.Take(lists.Count-2).ToList();
        //    nums1 = lists.ToArray();

        //}

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1;
            int j = n - 1;
            int k = (m + n) - 1;
            while(i>=0 && j >= 0)
            {
                if (nums1[i] < nums2[j]) {
                    nums1[k] = nums2[j];
                    k--;
                    j--;
                }
                else
                {
                    nums1[k] = nums1[i];
                    k--;
                    i--;
                }
            }
            while(j >= 0){
                nums1[k] = nums2[j];
                j--;
                k--;
            }
        }
    }
}
