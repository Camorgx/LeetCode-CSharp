// https://leetcode.cn/problems/missing-two-lcci/

using CommonStructure;

namespace Sept2022 {
    public class MissingTwoLcci : ITestable {
        public void RunTest() {
            var tests = new int[][] {
                new int[] { 1 },
                new int[] { 2, 3 }
            };
            var solution = new Solution();
            foreach (var test in tests) {
                var res = solution.MissingTwo(test);
                foreach (var item in res)
                    Console.Write($"{item} ");
                Console.WriteLine();
            }
        }
        public class Solution {
            public int[] MissingTwo(int[] nums) {
                int n = nums.Length + 2;
                int ansSum = n * (n + 1) / 2;
                Array.ForEach(nums, x => { ansSum -= x; });
                int mid = ansSum / 2;
                int ans = mid * (mid + 1) / 2;
                Array.ForEach(nums, x => {
                    if (x <= mid) ans -= x;
                });
                return new int[] { ans, ansSum - ans };
            }
        }
    }
}
