// https://leetcode.cn/problems/number-of-students-doing-homework-at-a-given-time/

namespace BusyStudent {
    public static class Test {
        public static void RunTest() {
            Solution solution = new();

            int[][] startTime = {
                new int[] { 1, 2, 3 },
                new int[] { 4 },
                new int[] { 4 },
                new int[] { 1, 1, 1, 1 },
                new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 }
            };
            int[][] endTime = {
                new int[] { 3, 2, 7 },
                new int[] { 4 },
                new int[] { 4 },
                new int[] { 1, 3, 2, 4 },
                new int[] { 10, 10 ,10, 10, 10, 10, 10, 10, 10 }
            };
            int[] queryTime = { 4, 4, 5, 7, 5 };

            for (int i = 0; i < 5; ++i)
                Console.WriteLine(
                    solution.BusyStudent(startTime[i], endTime[i], queryTime[i])); ;
        }
    }
    public class Solution {
        public int BusyStudent(int[] startTime, int[] endTime, int queryTime) {
            int ans = 0;
            for (int i = 0; i < startTime.Length; ++i)
                if (startTime[i] <= queryTime && queryTime <= endTime[i])
                    ++ans;
            return ans;
        }
    }
}
