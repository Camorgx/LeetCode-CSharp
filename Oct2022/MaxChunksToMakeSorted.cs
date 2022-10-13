// https://leetcode.cn/problems/max-chunks-to-make-sorted/

using CommonStructure;

namespace Oct2022 {
    public class MaxChunksToMakeSorted : ITestable {
        public void RunTest() {
            var tests = new int[][] {
                new int[] { 4, 3, 2, 1, 0 },
                new int[] { 1, 0, 2, 3, 4 }
            };
            var solution = new Solution();
            foreach (var test in tests)
                Console.WriteLine(solution.MaxChunksToSorted(test));
        }
        public class Solution {
            public int MaxChunksToSorted(int[] arr) {
                int m = 0, res = 0;
                for (int i = 0; i < arr.Length; i++) {
                    m = Math.Max(m, arr[i]);
                    if (m == i) ++res;
                }
                return res;
            }
        }
    }
}
