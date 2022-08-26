// https://leetcode.cn/problems/maximum-product-of-two-elements-in-an-array/

namespace MaximumProductOfTwoElementsInAnArray {
    public static class Test {
        public static void RunTest() {
            Solution solution = new();
            Console.WriteLine(solution.MaxProduct(new int[] { 3, 4, 5, 2 }));
            Console.WriteLine(solution.MaxProduct(new int[] { 1, 5, 4, 5 }));
            Console.WriteLine(solution.MaxProduct(new int[] { 3, 7 }));
        }
    }
    public class Solution {
        public int MaxProduct(int[] nums) {
            Array.Sort(nums);
            return (nums[nums.Length - 1] - 1) * (nums[nums.Length - 2] - 1);
        }
    }
}
