// https://leetcode.cn/problems/minimum-swaps-to-make-sequences-increasing/

using CommonStructure;

namespace Oct2022 {
    public class MinimumSwapsToMakeSequencesIncreasing : ITestable {
        public void RunTest() {
            var tests = new (int[], int[])[] {
                (
                    new int[] { 1, 3, 5, 4 },
                    new int[] { 1, 2, 3, 7 }
                ),
                (
                    new int[] { 0, 3, 5, 8, 9 },
                    new int[] { 2, 1, 4, 6, 9 }
                )
            };
            var solution = new Solution();
            foreach (var (nums1, nums2) in tests)
                Console.WriteLine(solution.MinSwap(nums1, nums2));
        }
        public class Solution {
            public int MinSwap(int[] nums1, int[] nums2) {
                int n = nums1.Length;
                int a = 0, b = 1;
                for (int i = 1; i < n; ++i) {
                    int at = a, bt = b;
                    a = b = n;
                    if (nums1[i] > nums1[i - 1] && nums2[i] > nums2[i - 1]) {
                        a = Math.Min(a, at);
                        b = Math.Min(b, bt + 1);
                    }
                    if (nums1[i] > nums2[i - 1] && nums2[i] > nums1[i - 1]) {
                        a = Math.Min(a, bt);
                        b = Math.Min(b, at + 1);
                    }
                }
                return Math.Min(a, b);
            }
        }
    }
}
