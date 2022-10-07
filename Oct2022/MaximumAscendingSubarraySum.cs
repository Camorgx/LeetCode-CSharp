// https://leetcode.cn/problems/maximum-ascending-subarray-sum/

using CommonStructure;

namespace Oct2022 {
    public class MaximumAscendingSubarraySum : ITestable {
        public void RunTest() {
            var tests = new int[][] {
                new int[] { 0, 20, 30, 5, 10, 50 },
                new int[] { 10, 20, 30, 40, 50 },
                new int[] { 12, 17, 15, 13, 10, 11, 12 },
                new int[] { 100, 10, 1 }
            };
            var solution = new Solution();
            foreach (var test in tests)
                Console.WriteLine(solution.MaxAscendingSum(test));
        }
        public class Solution {
            public int MaxAscendingSum(int[] nums) {
                int curSum = nums[0], ans = nums[0];
                for (int i = 1; i < nums.Length; ++i) {
                    if (nums[i] > nums[i - 1])
                        curSum += nums[i];
                    else curSum = nums[i];
                    ans = Math.Max(ans, curSum);
                }
                return ans;
            }
        }
    }
}
