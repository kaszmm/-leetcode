using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blind_75
{
    #region 1D Dynamic Programming
    public class DynamicProgramming
    {
        //1 Optimal
        public int climbStairs(int n)
        {
            int one = 1;
            int two = 1;

            for (int i = 0; i < n - 1; i++)
            {
                var temp = one;
                one = one + two;
                two = temp;
            }
            return one;
        }

        //Bottom Up
        public int BtmclimbStairs(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;

            for (int i = 2; i < n + 1; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }


        //2
        public int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2) return nums[0] > nums[1] ? nums[0] : nums[1];
            int[] dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            for (var i = 2; i < dp.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 1], nums[i] + dp[i - 2]);
            }
            return dp[dp.Length - 1];
        }
        //some uniuqe way to do it also
        private Dictionary<int, int> cache = new();

        public int Rob(Span<int> nums)
        {
            switch (nums.Length)
            {
                case 0: return 0;
                case 1: return nums[0];
                case 2: return Math.Max(nums[0], nums[1]);
                default:
                    {
                        if (cache.TryGetValue(nums.Length, out var res))
                        {
                            return res;
                        }

                        res = Math.Max(nums[0] + Rob(nums[2..]), Rob(nums[1..]));
                        cache[nums.Length] = res;
                        return res;
                    };
            };
        }



        //3
        //Intuition So logic is basically same as house robber I but in this probelms we have one xtra condition of first and last house being adjacen tto each other,
        //so what we can do is use house robber algo from house 1 till second last house whihc gives us x value and use house rober algo from second house till last house whihc gives us y values
        //and take max of x or y what it says is i cant use house rober for first till last house
        //but i can use house rober algo from first trill second last excluding last house and second till last house excluding first house
        //and take whatever the max we can get from one of the house ranges.
        public int RobII(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2) return nums[0] > nums[1] ? nums[0] : nums[1];

            int RobHelper(int[] arr)
            {
                int rob1 = 0;
                int rob2 = 0;
                foreach (var item in arr)
                {
                    int newRobVal = Math.Max(rob1 + item, rob2);
                    rob1 = rob2;
                    rob2 = newRobVal;
                }
                return rob2;
            }
            var x = nums[1..];
            var y = nums[0..(nums.Length - 1)];
            int val = Math.Max(RobHelper(nums[1..]), (RobHelper(nums[0..(nums.Length - 1)])));
            return val;
        }


        //4
        //Before intuition let me tell you something, I didnt even know how this sum is dp like we dont use array or used previous result to get current result,
        //but it is still tagged under dp so i guess i am missing somwthing here
        //INTUITION:
        //So what we can do we can find palindrome with two methods first we take two pointers first will be 0 while second pointer will be length-1 and we check if tghose two matches and if they match we move inwards
        //Second Approach the one we gonna use is we loop throught each char and from that character we take left char of origin char and we take right char from our orgin char and
        //check whether that left and right matches if they match we move outWards by incrementing right and decrementing left
        //But in this there are two cases when the palindrome in string is even means we take l and l+1 but if we have odd than we take l and l 
        //Second Plaindrom figure  "a a a b"
        //   ^             (l==r)
        //^     ^           (l--,r++) ... so on and we check in outwards direction.
        public string LongestPalindrome(string s)
        {
            string result = "";
            int strLength = 0;
            for (var i = 0; i < s.Length; i++)
            {
                //odd length
                var l = i;
                var r = i;
                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                    if (r - l + 1 > strLength)
                    {
                        result = s.Substring(l, r - l + 1);
                        strLength = r - l + 1;
                    }
                    l--;
                    r++;
                }

                //even length
                l = i;
                r = i + 1;
                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                    if (r - l + 1 > strLength)
                    {
                        result = s.Substring(l, r - l + 1);
                        strLength = r - l + 1;
                    }
                    l--;
                    r++;
                }
            }
            return result;
        }

        //same as above just different way to write it 
        public string OthLongestPalindrome(string s)
        {

            int PalindromeLength(string s, int left, int right)
            {
                while (left >= 0 && right < s.Length && s[left] == s[right])
                {
                    left--;
                    right++;
                }
                return right - left - 1; // (right+1) - (left-1) - 1
            }

            if (s == "" || s.Length <= 1)
                return s;
            int length = 0, start = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int evenLength = PalindromeLength(s, i, i + 1);
                int oddLength = PalindromeLength(s, i, i);
                int currentLength = Math.Max(evenLength, oddLength);

                if (currentLength > length)
                {
                    length = currentLength;
                    start = i - (length - 1) / 2;
                }
            }

            return s.Substring(start, length);
        }

        //5
        //Intuition is same as 4th problem we just addd the count that is all.
        public int CountSubstrings(string s)
        {
            int count = 0;
            for (var i = 0; i < s.Length; i++)
            {
                int l = i;
                int r = i;
                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                    count++;
                    l--;
                    r++;
                }

                l = i;
                r = i + 1;
                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                    count++;
                    l--;
                    r++;
                }
            }
            return count;
        }


        //6
        //intuition is we can decode string by making two decision at time first will be taking only one digit while second will be
        //taking two digits to decode
        public int NumDecodings(string s)
        {
            int[] dp = new int[s.Length];
            Array.Fill(dp, -1);
            int result = 0;
            int DfsCount(int i)
            {
                if (i == s.Length) return 1;
                if (s.ElementAt(i) == '0')            //if we ever get "0{somestring}" then we return 0 because 0 is nto mapped with any characters
                    return 0;
                if (dp[i] != -1)                    //default dp have -1 in it, and we use dp to cache if value already exist in our dp then we simply retunr that
                {
                    return dp[i];
                }
                int result = DfsCount(i + 1);        //taking one digit
                if (i + 1 < s.Length && (s.ElementAt(i) == '1' || (s.ElementAt(i) == '2' && s.ElementAt(i + 1) < '7'))) //validation if we want to take 2 digits count
                {                                                                        //then check if first digit is 1 then its ok
                    result += DfsCount(i + 2);   //taking two digit                    //but if first digit is 2 then also check if its less than 7
                                                 //because max length is 26=Z for us
                }
                dp[i] = result;
                return dp[i];
            }
            result = DfsCount(0);
            return result;
        }

        //Sub-Optimal  (check Vid name Decode ways in Solution item)
        //Intuition is same but here we use pure dp with O(n) space complexity can use two variable instead of entire arr with O(1) space complexity(Most Optimal)
        public int OptNumDecodings(string s)
        {
            int[] dp = new int[s.Length + 1];
            dp[0] = 1;  //if encounter {digit}0 return 1
            dp[1] = s.ElementAt(0) == '0' ? 0 : 1; //if first element is 0 then 0 else 1
            for (var i = 2; i <= s.Length; i++)
            {
                int oneDigit = s.ElementAt(i - 1) - '0';
                int twoDigits = int.Parse(s.Substring(i - 2, 2));
                if (oneDigit > 0)
                {
                    dp[i] += dp[i - 1];
                }
                if (twoDigits >= 10 && twoDigits < 27) //check upper bound as >=10 because what if our twodigit string is "09"(its invalid string) but when its in int version it will be 9 so we dont need that 
                {
                    dp[i] += dp[i - 2];  //since we are adding every valid two digit number to the solution of dp[i-2] , dp[0] denotes the solution {} so doing dp[i] += dp[i-2] means we are getting {} U {twodigitNumber} = {twodigitNumber}

                }

            }
            return dp[s.Length];
        }


        //7
        //Complete intuition explained in audio check solution material under two sum solution folder 
        public int CoinChange(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];
            Array.Fill(dp, amount + 1);
            dp[0] = 0;
            for (var amt = 1; amt <= amount; amt++)
            {
                foreach (var coin in coins)
                {
                    if (coin <= amt)
                    {
                        dp[amt] = Math.Min(dp[amt], 1 + dp[amt - coin]);
                    }
                }
            }
            return dp[amount] == amount + 1 ? -1 : dp[amount];
        }

        //Minor Optimisation
        public int OptCoinChange(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];
            Array.Fill(dp, amount + 1);
            dp[0] = 0;
            Array.Sort(coins);  //we sort coins
            for (var amt = 1; amt <= amount; amt++)
            {
                foreach (var coin in coins)
                {
                    if (coin <= amt)
                    {
                        dp[amt] = Math.Min(dp[amt], 1 + dp[amt - coin]);
                    }
                    else
                    {
                        break;     //in contrast to our prevoius solution here we break loop when
                                   //we encouter coin> amount because we already sorted our coins so
                                   //if current coin is greater than amount it means that next coins in loop will also be greater than amount
                                   //so break loop and go for next amount 
                    }
                }
            }
            return dp[amount] == amount + 1 ? -1 : dp[amount];
        }

        //8
        public int MaxProduct(int[] nums)
        {
            int result = nums.Max();
            int curMax = 1;
            int curMin = 1;
            foreach (var item in nums)
            {
                if (item == 0)
                {
                    curMax = curMin = 1;
                    continue;
                }
                int oldMax = curMax;
                curMax = Math.Max(Math.Max(item * curMax, item * curMin), item);
                curMin = Math.Min(Math.Min(item * oldMax, item * curMin), item);
                result = Math.Max(Math.Max(curMax, curMin), result);
            }
            return result;
        }

        //9
        //Sub -Optimal Solution using trie , Intution behind is first impkment AddWord for trie and just add words in it
        //now main issuse comes in SearchWord in string because there are some edge cases that neeed to be dealth with.
        //So normal word search will not word here we need to use recursion and od word search on entire string in order to get ans why?
        //Because lets take an example like ["aaa","aaaa"] s= "aaaaaaa" , normal word search will just return false, but recusrive wod search will return true (which is right answer)
        public class TrieNode
        {
            public TrieNode[] childerns;
            public bool IsWordEnded;
            public TrieNode()
            {
                childerns = new TrieNode[26];
                IsWordEnded = false;
            }
        }
        TrieNode root = new TrieNode();
        bool[] failed = new bool[301];
        public bool WordBreak(string s, IList<string> wordDict)
        {
            AddWords(wordDict);
            return WordSearch(s, 0);
        }
        public void AddWords(IList<string> words)  //normal Add word implementation
        {
            for (var i = 0; i < words.Count; i++)
            {
                var temp = root.childerns;
                for (var c = 0; c < words[i].Length; c++)
                {
                    if (temp[words[i][c] - 'a'] == null)
                    {
                        temp[words[i][c] - 'a'] = new TrieNode();
                    }
                    if (c == words[i].Length - 1)
                    {
                        temp[words[i][c] - 'a'].IsWordEnded = true;
                    }
                    temp = temp[words[i][c] - 'a'].childerns;
                }
            }
        }

        public bool WordSearch(string s, int startIdx)
        {
            if (failed[startIdx]) return false;  //memoization
            if (startIdx >= s.Length) return true;  //if startIdx is out of bound which can be when startIdx is greater than or equal to string length  return true, means we found entire string in our trie

            var temp = root;                    //Reset trie on each recursive call
            for (var c = startIdx; c < s.Length; c++)
            {
                if (temp.childerns[s[c] - 'a'] == null)
                {
                    return false;
                }
                temp = temp.childerns[s[c] - 'a'];

                if (temp.IsWordEnded)
                {
                    if (WordSearch(s, c + 1))  //recursively call wordsearch on next index of char in string 
                    {
                        return true;
                    }
                    failed[c + 1] = true;    //Add all the failed recursive attemp in cache of failed so when we call recursively on same index of string again we just return true/false directly from cache
                }
            }
            return false;
        }

        //Optimal Solution (Dynamic Programming) (End to Start Approach)
        //Intuition is we start from last index and increase string char by char and check if the susbstring is greater than or qeual to word in wordDict if it does contains in wordDict
        //then we can say that current i is true from ith till word.Length so dp[i] =dp[i+word.Lenght] means if word mataches at i=4 than word starts from i=4 till the word length (let say word length is 4)
        //so from index i=4 +word.Length(4) we have a match in wordDict list (which is also out sub problems) so dp[4] =dp[4(curretn index)+4(word.Length)]
        //now if our string engh is 8 and initially we used dp[s.Lenght]=true this measn our sub-problem sp[4]=dp[8]=true and that how we solve for dp[0] =dp[0+4(word length)]=true
        //return true
        //
        public bool OptWordBreak(string s, IList<string> wordList)
        {
            bool[] dp = new bool[s.Length + 1];
            dp[s.Length] = true;
            for (var i = s.Length - 1; i >= 0; i--)
            {
                foreach (var word in wordList)
                {
                    if (s.Length - i >= word.Length && s.Substring(i, word.Length) == word)
                    {
                        dp[i] = dp[i + word.Length];
                    }
                    if (dp[i]) break;
                }
            }
            return dp[0];
        }

        //Do (Start to End Approach
        //Approach here is from start to end and we intaillise dp[0]=true because string with zero length is always true
        //We use two pointer start and end , if subString(start to end ) does matahces our word in wordDict then we set the dp for end index true saying
        //word starting from start index till ending in end index does contain in our wordDict
        public bool Opt2WordBreak(string s, IList<string> wordList)
        {
            bool[] dp = new bool[s.Length + 1];
            dp[0] = true;
            for (var start = 0; start <= s.Length; start++)
            {
                if (!dp[start]) continue;    //major optimisation is we encounter any dp[start[] which is false
                                             //then we continue loop because word satrting from this start index will never match word in our wordDict
                for (var end = start + 1; end <= s.Length; end++)
                {
                    if (wordList.Contains(s.Substring(start, end - start)))
                    {
                        dp[end] = true;
                    }
                }
            }
            return dp[s.Length];
        }


        //10
        //(Sub optimal) brute Force wiht memoization (recursion top down approach)    O(n^3)
        public int LengthOfLIS(int[] nums)
        {
            int count = 1;
            int[] memo = new int[nums.Length];
            Array.Fill(memo, 0);
            int dfs(int idx, int curVal)
            {
                if (idx == nums.Length) return 1; //if ut of bound return 1
                if (memo[idx] != 0)  //memo
                {
                    return memo[idx];
                }
                int totalCount = 1;                    //this count will only gets updated if we found some count wiht more value in it
                for (var start = idx; start < nums.Length; start++)
                {
                    int curCount = 1;              //this will get updated on every loop recurion and whatever the value in it we put it in count if it is max vlaue
                    if (nums[start] > curVal)
                    {
                        curCount += dfs(start + 1, nums[start]);  //do dfs for start +1 index and with curVal as nums[start]
                        totalCount = Math.Max(totalCount, curCount);   //take max from curCount and totalcount 
                    }
                }
                memo[idx] = totalCount;   //whatever we get from count (max count value) put that count value in memo[idx]
                return totalCount;

            }
            //iterate over every index and find the max count
            for (var i = 1; i < nums.Length; i++)
            {
                count = Math.Max(count, dfs(i, nums[i - 1]));

            }
            return count;

        }

        //(OPTIMAL SOLUTION)  Dynamic Programming bottom - up approach  O(n^2)
        //intuition is simple we start from last index will value of 1 in every dp array because that is minimum vlaue every dp will have
        //(because if 1000 dont have any other subsequnce than the count of 1000 itself is 1)
        //and innner loop starts from where our outer loop starts so if outer loop is i and inner loop start from i+1 till n
        //and we update our dp[i] if nums[i]< nums[i+1..n];
        public int OptLengthOfLIS(int[] nums)
        {
            int[] dp = new int[nums.Length];
            Array.Fill(dp, 1);
            var maxSoFar = 1;
            for (var i = dp.Length - 1; i >= 0; i--)
            {

                for (var j = i + 1; j < dp.Length; j++)
                {
                    if (nums[i] < nums[j])   //only update dp[i] if nums[i+1..n] is greater than nums[i] because we want stricly increasing subsequence
                    {
                        dp[i] = Math.Max(dp[i], 1 + dp[j]);  //one side we take max of dp[i], and other side 1+dp[i+1..n] here 1+ is the number count of nums[i] itself because we also nee to ocunt the curretn ith element along wiht other possible count of subsequence from i+1..n
                    }
                }
                //we need to also take maxSofar because there might scenario where when we start countinf increasing subsequence from 0th index is less than count of subsequence in 2nd index because the value itslef on 0th index and 2nd index arwe aslo diff ,
                //so based on what value is on ith index subsequnces chnages
                maxSoFar = Math.Max(maxSoFar, dp[i]);
            }
            return maxSoFar;
        }

        //NON DP SOLUTION FASTTTT
        public int Opt2LengthOfLIS(int[] nums)
        {
            var tails = new int[nums.Length];
            var size = 0;
            foreach (var num in nums)
            {
                var (i, j) = (0, size);
                while (i != j)
                {
                    var m = (i + j) / 2;
                    if (tails[m] < num)
                    {
                        i = m + 1;
                    }
                    else
                    {
                        j = m;
                    }
                }

                tails[i] = num;
                if (i == size)
                {
                    size++;
                }
            }

            return size;
        }



    }
    #endregion


    #region 2D Dynamic Programming Problems
    //Brute Force with memoization (top down approach)
    public class TwoDDynamicProgramming
    {
        //1
        public int UniquePaths(int m, int n)
        {

            int[,] memo = new int[m,n];   //caching
            int Dfs(int row, int col)
            {
                if (row >= m || col >= n)      //no need to use visited Hashset here , because we will never go to already visited path again
                    return 0;
                if (row == (m - 1) && col == (n - 1))
                    return 1;
                if (memo[row,col] != 0)
                    return memo[row, col];
                int countPath = 0;
                countPath += Dfs(row + 1, col);   //we go down
                countPath += Dfs(row, col + 1);    ///we go right

                memo[row, col] = countPath;
                return countPath;
            }

            return Dfs(0, 0);

        }

        //Optimal Dp Solutiopn (Bottom up- right to left approach)  time-o(m*n) Space-O(m*n) or maybe O(n) space complexity [I dont know]
        //Intuition is fill the last column dp[m-1][n-1]=1, now start looping backwards from m-1 ..0 and inner loop n-1 ..0 and fill [i][j]
        //now [i][j] will be sum of all unique paths for going in down path(i+1,j) and going in right path(i,j+1) and wiht that we will get solution in out (0,0) position 
        public int OptUniquePaths(int m, int n)
        {
            int[,] dp = new int[m, n];
            dp[m - 1, n - 1] = 1;  //our goal will be 1 initially

            for (var i = m - 1; i >= 0; i--)
            {
                for (var j = n - 1; j >= 0; j--)
                {
                    dp[i, j] += (i + 1 >= m ? 0 : dp[i + 1, j]); //means down
                    dp[i, j] += (j + 1 >= n ? 0 : dp[i, j + 1]); //means right
                }

            }
            return dp[0, 0];
        }

        //2
        //Recursion Memoization Solution (Code is Commented but it is correct solution for recuriosn memoixation approach)
        //Code is not in c#, that is why commnected it, it is in JAVA

        //int[][] dp;
        //public int longestCommonSubsequence(String text1, String text2)
        //{
        //    int n = text2.Length;
        //    int m = text1.Length;
        //    dp = new int[m + 1][n + 1];
        //    for (int i = 0; i < m; i++)
        //    {
        //        Arrays.fill(dp[i], -1);
        //    }
        //    return reccursion(text1, text2, m - 1, n - 1);
        //}

        //private int reccursion(String s1, String s2, int m, int n)
        //{
        //    if (m < 0 || n < 0) return 0;
        //    if (dp[m][n] != -1) return dp[m][n];
        //    if (s1.charAt(m) == s2.charAt(n)) return dp[m][n] = 1 + reccursion(s1, s2, m - 1, n - 1);
        //    else return dp[m][n] = Math.max(reccursion(s1, s2, m - 1, n), reccursion(s1, s2, m, n - 1));
        //}

        //Dp Bottom Up approach (see vid putted ub Solution Items Folder)
        //Intuition is we satrt from last index in our 2d matrix with extra row and column , now we start from last index and if text1[i] matches text2[j] then we add 1+(whatever diagonal value in matrix), else we take max of down value or right value
        public int LongestCommonSubsequence(string text1, string text2)
        {
            int[,] dp = new int[text1.Length + 1, text2.Length + 1];
            for(var i = text1.Length - 1; i >= 0; i--)
            {
                for (var j = text2.Length - 1; j >= 0; j--)
                {
                    if (text1[i] == text2[j])
                    {
                        //here 1+ means we had found a mathicng char in both string so 1+ and now we solve our subproblem for remaining string from i+1 and j+1
                        dp[i, j] = 1 + dp[i + 1, j + 1];
                    }
                    else
                    {
                        //we take max of downward value of our current ith and jth index whihc is (i+1,j) or we take right value of our ith and jth index which is (i,j+1)
                        dp[i,j] = Math.Max(dp[i + 1, j], dp[i, j + 1]);
                    }
                }
            }
            return dp[0, 0];
        }
    }
    #endregion

}
