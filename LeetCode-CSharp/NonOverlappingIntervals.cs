// https://leetcode.cn/problems/non-overlapping-intervals/

namespace NonOverlappingIntervals {
    public static class Test {
        public static void RunTest() {
            int[][][] tests = new int[][][] {
                new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 },
                    new int[] { 3, 4 }, new int[] { 1, 3 } },
                new int[][] { new int[] { 1, 2 }, new int[] { 1, 2 },
                    new int[] { 1, 2 } },
                new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 } }
            };
            Solution solution = new();
            foreach (var test in tests)
                Console.WriteLine(solution.EraseOverlapIntervals(test));
        }
    }
    public class Solution {
        public int EraseOverlapIntervals(int[][] intervals) {
            if (intervals.Length == 0) return 0;
            Array.Sort(intervals, (int[] x, int[] y) => x[1] - y[1]);
            int right = int.MinValue, cnt = 0;
            foreach (int[] interval in intervals) {
                if (interval[0] >= right) {
                    ++cnt;
                    right = interval[1];
                }
            }
            return intervals.Length - cnt;
        }
    }
}
