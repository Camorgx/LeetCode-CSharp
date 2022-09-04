// https://leetcode.cn/problems/maximum-length-of-pair-chain/

using CommonStructure;

namespace Sept2022 {
    public class MaximumLengthOfPairChain : ITestable {
        public void RunTest() {
            int[][] test = new int[][] {
                new int[] { 1, 2 },
                new int[] { 2, 3 },
                new int[] { 3, 4 }
            };
            Solution solution = new();
            Console.WriteLine(solution.FindLongestChain(test));
        }
        public class Solution {
            public int FindLongestChain(int[][] pairs) {
                if (pairs.Length == 0) return 0;
                int current = int.MinValue, ans = 0;
                Array.Sort(pairs, (x, y) => x[1] - y[1]);
                foreach (int[] pair in pairs)
                    if (current < pair[0]) {
                        current = pair[1];
                        ++ans;
                    }
                return ans;
            }
        }
    }
}
