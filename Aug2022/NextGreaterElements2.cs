// https://leetcode.cn/problems/next-greater-element-ii/

namespace NextGreaterElements2 {
    public static class Test {
        public static void RunTest() {
            Solution solution = new();

            int[] test1 = { 1, 2, 1 };
            int[] ans1 = solution.NextGreaterElements(test1);
            foreach (int i in ans1) Console.Write("{0} ", i);
            Console.WriteLine();

            int[] test2 = { 1, 2, 3, 4, 3 };
            int[] ans2 = solution.NextGreaterElements(test2);
            foreach (int i in ans2) Console.Write("{0} ", i);
        }
    }
    public class Solution {
        public int[] NextGreaterElements(int[] nums) {
            int[] ans = new int[nums.Length];
            Array.Fill(ans, -1);
            Stack<int> stack = new();
            for (int i = 0; i < nums.Length * 2 - 1; ++i) {
                while (stack.Count > 0 && nums[stack.Peek()] < nums[i % nums.Length])
                    ans[stack.Pop()] = nums[i % nums.Length];
                stack.Push(i % nums.Length);
            }
            return ans;
        }
    }
}
