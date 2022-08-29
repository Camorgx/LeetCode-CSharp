// https://leetcode.cn/problems/shuffle-the-array/

namespace ShuffleTheArray {
    public static class Test {
        public static void RunTest() {
            Solution solution = new();
            int[][] test = new int[][] {
                solution.Shuffle(new int[] { 2, 5, 1, 3, 4, 7 }, 3),
                solution.Shuffle(new int[] { 1, 2, 3, 4, 4, 3, 2, 1 }, 4),
                solution.Shuffle(new int[] { 1, 1, 2, 2 }, 2)
            };
            foreach (int[] set in test) {
                foreach (int item in set)
                    Console.Write("{0} ", item);
                Console.WriteLine();
            }
        }
    }
    public class Solution {
        public int[] Shuffle(int[] nums, int n) {
            int[] ans = new int[2 * n];
            for (int i = 0; i < n; ++i) {
                ans[2 * i] = nums[i];
                ans[2 * i + 1] = nums[n + i];
            }
            return ans;
        }
    }
}
