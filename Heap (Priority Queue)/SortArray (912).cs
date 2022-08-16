using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap__Priority_Queue_
{
    public  class SortArray__912_
    {
        public  int[] SortArray(int[] nums)
        {
            if (nums.Length == 1) return nums;
           int[] minHeap = new int[nums.Length + 1];
            int i = 1;
            while (i <= nums.Length)
            {
                minHeap[i] = nums[i - 1];
                minHeap = bubbleUp(minHeap, i);
                i++;
            }
            int[] sorted= new int[nums.Length];
            int k = 0;
            while (k<nums.Length)
            {
                sorted[k] = minHeap[1];
                minHeap = bubbleDown(minHeap);
                k++;
            }
            return sorted;
        }
        public  int[] bubbleUp(int[] arr, int i)
        {
            while (i/2!=0 && arr[i] < arr[i / 2])
            {
                arr = swapIt(arr, i, i / 2);
                if (i == 0) return arr;
                i = i / 2;
            }

            return arr;
        }

        public  int[] bubbleDown(int[] arr)
        {
            int i = 1;
            arr = swapIt(arr, i, arr.Length - 1);
            arr = arr.SkipLast(1).ToArray();
            while (i <= arr.Length / 2)
            {
                if(arr[i]>arr[2*i] || arr[i] > arr[(2 * i) + 1])
                {
                    if (arr[2 * i] <arr[2 * i + 1]){
                        arr = swapIt(arr, arr[i], arr[2 * i]);
                        i = 2 * i;
                    }
                    else
                    {
                        arr = swapIt(arr, arr[i], arr[2 * i+1]);
                        i = (2 * i) + 1;
                    }
                }
                else
                {
                    break;
                }
            }
            return arr;
        }
        public  int[] swapIt(int[] nums, int i, int j)
        {

            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
            return nums;
        }

        public int[] OptimizedSortArray(int[] nums)
        {

            QuickSort(nums, 0, nums.Length - 1);
            return nums;
        }

        private void QuickSort(int[] nums, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(nums, left, right);
                QuickSort(nums, left, pivotIndex - 1);
                QuickSort(nums, pivotIndex + 1, right);
            }
        }

        private int Partition(int[] nums, int left, int right)
        {
            int pivot = nums[right];
            int pivotIndex = left;

            for (int i = left; i < right; i++)
            {
                if (nums[i] <= pivot)
                {
                    Swap(nums, i, pivotIndex);
                    pivotIndex++;
                }
            }

            Swap(nums, pivotIndex, right);
            return pivotIndex;
        }

        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }

    public class NewSolution
    {
        public int[] SortArray(int[] nums)
        {
            if (nums.Length == 1) return nums;
            heapSort(nums);
            return nums;
        }
        private void heapSort(int[] nums)
        {
            for (int i = nums.Length / 2 - 1; i >= 0; i--)
            {
                heapify(nums, i, nums.Length - 1);
            }
            for (int i = nums.Length - 1; i >= 1; i--)
            {
                Swap(nums, 0, i);
                heapify(nums, 0, i - 1);
            }
        }
        private void heapify(int[] nums, int i, int end)
        {
            while (i <= end)
            {
                int l = 2 * i + 1, r = 2 * i + 2;
                int maxIndex = i;
                if (l <= end && nums[l] > nums[maxIndex]) maxIndex = l;
                if (r <= end && nums[r] > nums[maxIndex]) maxIndex = r;
                if (maxIndex == i) break;
                Swap(nums, i, maxIndex);
                i = maxIndex;
            }
        }

        public void HeapSort(int[] nums)
        {
            for (var i = nums.Length / 2 - 1; i >= 0; i--)
            {
                Heapify(nums, i, nums.Length - 1);
            }
            for (var i = nums.Length - 1; i >= 0; i--)
            {
                swap(nums, 0, i);
                Heapify(nums, 0, i - 1);
            }

        }


        public void Heapify(int[] nums, int i, int end)
        {
            while (i <= end)
            {
                int l = 2 * i + 1;
                int r = 2 * i + 2;
                int maxIndex = i;
                if (l <= end && nums[l] > nums[maxIndex])
                {
                    maxIndex = l;
                }
                if (r <= end && nums[r] > nums[maxIndex])
                {
                    maxIndex = r;
                }
                if (maxIndex == i) break;
                swap(nums, i, maxIndex);
                i = maxIndex;
            }
        }
        void swap(int[] nums, int i1, int i2)
        {
            var tmp = nums[i1]; nums[i1] = nums[i2]; nums[i2] = tmp;
        }





        Random rng = new Random();

        void QuickSort(int[] nums, int lo, int hi)
        {
            if (lo >= hi) return;

            int partIndex = Partition(nums, lo, hi);
            QuickSort(nums, lo, partIndex - 1);
            QuickSort(nums, partIndex + 1, hi);
        }

        int Partition(int[] nums, int lo, int hi)
        {
            int indx = rng.Next(lo, hi + 1);
            int partElem = nums[indx];

            Swap(nums, hi, indx);
            int partIndx = lo;
            for (int i = lo; i < hi; ++i)
            {
                if (nums[i] < partElem)
                    Swap(nums, partIndx++, i);
            }
            Swap(nums, partIndx, hi);

            return partIndx;
        }

        void Swap(int[] nums, int i1, int i2)
        {
            var tmp = nums[i1]; nums[i1] = nums[i2]; nums[i2] = tmp;
        }


      
    }
    
}
