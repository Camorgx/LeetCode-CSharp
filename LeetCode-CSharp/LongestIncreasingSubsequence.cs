// https://leetcode.cn/problems/longest-increasing-subsequence/

namespace LongestIncreasingSubsequence {
    public static class Test {
        public static void RunTest() {
            int[][] tests = new int[][] {
                new int[] { 10, 9, 2, 5, 3, 7, 101, 18 },
                new int[] { 0, 1, 0, 3, 2, 3 },
                new int[] { 7, 7, 7, 7, 7, 7, 7 }
            };
            Solution solution = new();
            foreach (var test in tests)
                Console.WriteLine(solution.LengthOfLIS(test));
        }
    }
    public class Solution {
        public int LengthOfLIS(int[] nums) {
            if (nums.Length == 0) return 0;
            int[] dp = new int[nums.Length];
            Array.Fill(dp, 1);
            int ans = 1;
            for (int i = 1; i < nums.Length; i++) {
                for (int j = 0; j < i; ++j)
                    if (nums[i] > nums[j])
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                ans = Math.Max(ans, dp[i]);
            }
            return ans;
        }
    }
}
