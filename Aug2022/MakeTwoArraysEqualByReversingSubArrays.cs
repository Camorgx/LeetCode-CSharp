// https://leetcode.cn/problems/make-two-arrays-equal-by-reversing-sub-arrays/

namespace MakeTwoArraysEqualByReversingSubArrays {
    public static class Test {
        public static void RunTest() {
            Solution solution = new();

            Console.WriteLine(solution.CanBeEqual(
                new int[] { 1, 2, 3, 4 }, new int[] { 2, 4, 1, 3 }));
            Console.WriteLine(solution.CanBeEqual(
                new int[] { 7 }, new int[] { 7 }));
            Console.WriteLine(solution.CanBeEqual(
                new int[] { 3, 7, 9 }, new int[] { 3, 7, 11 }));
        }
    }
    public class Solution {
        public bool CanBeEqual(int[] target, int[] arr) {
            Array.Sort(arr);
            Array.Sort(target);
            return target.SequenceEqual(arr);
        }
    }
}
