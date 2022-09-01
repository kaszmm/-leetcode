using System.Linq;

namespace Blind_75
{
    public static class ArraysAndHashing
    {
        //1
        public static bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> num = new HashSet<int>();
            foreach (var item in nums)
            {
                if (!num.Add(item)) return true;
            }
            return false;

            //In hashset when we call add function in it it return true if the element added else it returns false if element already exist
        }

        //2
        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
            int[] sArr = new int[26];
            int[] tArr = new int[26];

            for (var i = 0; i < s.Length; i++)
            {
                sArr[s[i] - 'a']++;
                tArr[t[i] - 'a']++;

            }
            if (Enumerable.SequenceEqual(sArr, tArr)) return true;
            else return false;

        }
        //optimized
        public static bool IsOptAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            int[] arr = new int[26];
            foreach (var item in s)
            {
                arr[item - 'a']++;
            }
            foreach (var item in t)
            {
                arr[item - 'a']--;
            }
            foreach (var item in arr)
            {
                if (item != 0) return false;
            }
            return true;
            //simple to understand
        }


        //3
        public static int[] TwoSum(int[] nums, int target)
        {
            //HashSet<int> vals = new HashSet<int>();
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (!map.ContainsKey(nums[i])) map.Add(nums[i], i);
            }

            for (var i = 0; i < nums.Length; i++)
            {
                var curTarget = target - nums[i];
                if (map.ContainsKey(curTarget))
                {
                    map.TryGetValue(curTarget, out int j);
                    if (j != i)
                    {
                        return new int[] { i, j };
                    }
                }

            }
            return new int[] { };
        }

        //more Optimized
        public static int[] OptTwoSum(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>();
            dic[target - nums[0]] = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (dic.TryGetValue(nums[i], out _))
                {
                    return new[] { i, dic[nums[i]] };
                }
                dic[target - nums[i]] = i;
            }
            return new int[] { };

            //more optiized approach 
        }


        //4
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {

            if (strs.Length == 0) return new List<IList<string>>();
            IList<IList<string>> ans = new List<IList<string>>();
            List<int[]> anags = new List<int[]>();
            HashSet<string> visited = new HashSet<string>();
            foreach (var word in strs)
            {
                int[] arr = new int[26];
                for (var i = 0; i < word.Length; i++)
                {
                    arr[word[i] - 'a']++;

                }
                anags.Add(arr);
            }


            for (var i = 0; i < anags.Count(); i++)
            {
                List<string> ann = new List<string>();
                if (visited.Add(strs[i]))
                {
                    ann.Add(strs[i]);
                    //visited.Add(strs[i]);
                    for (var j = i + 1; j < anags.Count(); j++)
                    {
                        if (Enumerable.SequenceEqual(anags[i], anags[j]))
                        {
                            ann.Add(strs[j]);
                            visited.Add(strs[j]);
                        }
                    }

                    ans.Add(ann);
                }
            }
            return ans;
        }

        //optimized
        public static IList<IList<string>> OptGroupAnagrams(string[] strs)
        {

            if (strs.Length == 0) return new List<IList<string>>();
            Dictionary<string, IList<string>> ans = new Dictionary<string, IList<string>>();
            foreach (var str in strs)
            {
                //1 O(n)   here we create charList and add frequency of our str in array then convert that frequnecy of array into string as key,
                            //so similar str will have similar freq in result in similar key
                var charList = new char[26];
                foreach (char c in str)
                {
                    charList[c - 'a']++;
                }
                // or 2   O(nLogn)  //here we simply convert str into array and sort it and reconvert into string again and make it as key,
                                   //so similar Array will have similar key
                //var chars = str.ToArray();
                //Array.Sort(chars);

                var key = new string(charList);
                if(!ans.ContainsKey(key))
                {
                    ans.Add(key, new List<string>());
                }
                ans[key].Add(str);
            }
            return ans.Values.ToList();
            //so approach is similar anagram will have similar key after sorting string so after that use basic functionality of dictionary and
            //put strings appropiate to its key value pair
        }


        //5 (nLogn)
        public static int[] topKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int[] freqNums = new int[k];
            foreach (var item in nums)
            {
                if (!dict.ContainsKey(item)) dict.Add(item, 0);
                dict[item]++;
            }
            dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            for (var i = 0; i < k; i++)
            {
                freqNums[i] = dict.ElementAt(i).Key;
            }

            return freqNums;

        }

        //optimized n^2
        public static int[] EtopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            List<int> freqNums = new List<int>();
            List<int>[] bucket = new List<int>[nums.Length+1];
            foreach (var item in nums)
            {
                if (!dict.ContainsKey(item)) dict.Add(item, 0);
                dict[item]++;
            }
            foreach (var item in dict)
            {
                var freq = dict[item.Key];
                if (bucket[freq] == null)
                {
                    bucket[freq] = new List<int>();
                }
                bucket[freq].Add(item.Key);
            }
            for (var i = bucket.Length - 1; i >= 0 && freqNums.Count<=k; i--)
            {
                if(bucket[i] != null)
                {
                    freqNums.AddRange(bucket[i]);
                }
            }

            return freqNums.Take(k).ToArray();

        }

        //moreOptimized n^2 but faster
        public static int[] OptTopKFrequent(int[] nums, int k)
        {
            if (nums.Length == 1) return nums;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            List<int>[] buckets = new List<int>[nums.Length + 1]; //frequency can never be more than array length,
                                                                  //but array is 0 based and k is not so we need array.lenght "+1" to compensate  
            int[] topElements = new int[k];
            foreach (var item in nums)
            {
                if (!dict.ContainsKey(item)) dict.Add(item, 1);
                else dict[item]++;
            }

            foreach (var item in dict)
            {
                if (buckets[item.Value] == null)
                    buckets[item.Value] = new List<int>();
                buckets[item.Value].Add(item.Key);
            }

            int i = 0;
            for (var j = buckets.Length - 1; j > 0; j--)
            {
                if (buckets[j] != null)
                {
                    foreach (var item in buckets[j])
                    {
                        topElements[i] = item;
                        if (i == k - 1) return topElements;
                        i++;
                    }
                }
            }
            return topElements;

            //here we define one bucket now List<int>[] and List<int[]> is two diff things,
            //what we want here is an array with each index we have an List<int> and for that we use List<int>[] ,
            //we taek all characters frequency in dictionary, and we add each element of nums array based on there frequency in our bucket array of list
            //so if -1,2,3 have frequency of 6,4,2 then on index 6 of bucket a new List<int>() is made and number -1 will be added to that list same goes for rest
            //after that we loop from last index in bucket to zeroth because we need more frequent and we saved the numbers based on frequency in bucket index so loop from last
            //then we have another loop to add each elemnt from the list<int> to be added in our topElements array and retrun array answer.
        }

    
        //6
        public static int[] ProductExceptSelf(int[] nums)
        {
            int[] res = new int[nums.Length];
            int prefix = 1;
            int postfix = 1;
            for (var i = 0; i < nums.Length; i++)
            {
                res[i] = prefix;
                prefix *= nums[i];
            }
            for (var r = nums.Length - 1; r >= 0; r--)
            {
                res[r] *= postfix;
                postfix *= nums[r];
            }
            return res;
        }
        //https://leetcode.com/problems/product-of-array-except-self/discuss/65622/Simple-Java-solution-in-O(n)-without-extra-space
        //Good Explanation up here, also watch neetcode solution video
        //


        //7
        public static class EnDeString
        {
            public static string Encode(List<string> strs)
            {
                var str = "";
                foreach (var item in strs)
                {
                    str += $"{item.Length}#{item}";
                }
                return str;


            }

            public static List<string> Decode(string str)
            {
                List<string> strs = new List<string>();
                int s = 0;
                while (s < str.Length)
                {
                    if (int.TryParse(str[s].ToString(), out int wordLength))
                    {
                        Range r = new(s + 2, s + 2 + wordLength);
                        var word = str.Take(r);
                        strs.Add(new string(word.ToArray()) ?? "");
                        s += 2 + wordLength;
                    }
                }
                return strs.ToList();
            }
        }

        //8
        //optimize
        public static int LongestConsecutive(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int totMax = 1;
            HashSet<int> hs = new HashSet<int>(nums);
            foreach (var item in nums)
            {
                if (hs.Contains(item - 1)) continue;
                int count = 1;
                while (hs.Contains(item + count)) { count++; }
                totMax = Math.Max(totMax, count);
            }

            return totMax;
        }
        //other optimizes
        public static int OptLongestConsecutive(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return 1;
            int res = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (var n in nums)
            {
                if (!map.ContainsKey(n))
                {
                    int left = (map.ContainsKey(n - 1)) ? map[n - 1] : 0;
                    int right = (map.ContainsKey(n + 1)) ? map[n + 1] : 0;
                    // sum: length of the sequence n is in
                    int sum = left + right + 1;
                    map[n] = sum;

                    // keep track of the max length 
                    res = Math.Max(res, sum);

                    // extend the length to the boundary(s)
                    // of the sequence
                    // will do nothing if n has no neighbors
                    map[n - left] = sum;
                    map[n + right] = sum;
                }
                else
                {
                    // duplicates
                    continue;
                }
            }
            return res;
        }
    }
}
