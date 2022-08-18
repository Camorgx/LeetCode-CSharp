// https://leetcode.cn/problems/median-of-two-sorted-arrays/

namespace FindMedianSortedArrays {
    public static class Test {
        public static void RunTest() {
            Solution solution = new();

            int[] a1 = { 1, 3 }, b1 = { 2 };
            Console.WriteLine(solution.FindMedianSortedArrays(a1, b1));

            int[] a2 = { 1, 2 }, b2 = { 3, 4 };
            Console.WriteLine(solution.FindMedianSortedArrays(a2, b2));
        }
    }
    public class Solution {
        private static int GetKthElement(int[] nums1, int[] nums2, int k) {
            int start1 = 0, start2 = 0;
            while (true) {
                if (start1 == nums1.Length) return nums2[start2 + k - 1];
                if (start2 == nums2.Length) return nums1[start1 + k - 1];
                if (k == 1) return Math.Min(nums1[start1], nums2[start2]);
                int newStart1 = Math.Min(start1 + k / 2 - 1, nums1.Length - 1);
                int newStart2 = Math.Min(start2 + k / 2 - 1, nums2.Length - 1);
                if (nums1[newStart1] <= nums2[newStart2]) {
                    k -= newStart1 - start1 + 1;
                    start1 = newStart1 + 1;
                }
                else {
                    k -= newStart2 - start2 + 1;
                    start2 = newStart2 + 1;
                }
            }
        }
        public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
            int totalLength = nums1.Length + nums2.Length;
            if (totalLength % 2 == 0)
                return (GetKthElement(nums1, nums2, totalLength / 2)
                    + GetKthElement(nums1, nums2, totalLength / 2 + 1)) / 2.0;
            else return GetKthElement(nums1, nums2, totalLength / 2 + 1);
        }
    }
}
