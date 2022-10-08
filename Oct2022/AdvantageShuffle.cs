// https://leetcode.cn/problems/advantage-shuffle/

using CommonStructure;

namespace Oct2022 {
    public class AdvantageShuffle : ITestable {
        public void RunTest() {
            var tests = new (int[], int[])[] {
                (
                    new int[] { 2,7,11,15 },
                    new int[] { 1,10,4,11 }
                ),
                (
                    new int[] { 12, 24, 8, 32 },
                    new int[] { 13, 25, 32, 11 }
                )
            };
            var solution = new Solution();
            foreach (var (nums1, nums2) in tests) {
                var res = solution.AdvantageCount(nums1, nums2);
                foreach (var item in res)
                    Console.Write($"{item} ");
                Console.WriteLine();
            }
        }
        public class Solution {
            public int[] AdvantageCount(int[] nums1, int[] nums2) {
                int n = nums1.Length;
                int[] idx1 = new int[n];
                int[] idx2 = new int[n];
                for (int i = 0; i < n; ++i)
                    idx1[i] = idx2[i] = i;
                Array.Sort(idx1, (i, j) => nums1[i] - nums1[j]);
                Array.Sort(idx2, (i, j) => nums2[i] - nums2[j]);
                int[] ans = new int[n];
                int left = 0, right = n - 1;
                for (int i = 0; i < n; ++i) {
                    if (nums1[idx1[i]] > nums2[idx2[left]])
                        ans[idx2[left++]] = nums1[idx1[i]];
                    else ans[idx2[right--]] = nums1[idx1[i]];
                }
                return ans;
            }
        }
    }
}
