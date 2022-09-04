// https://leetcode.cn/problems/validate-stack-sequences/

namespace ValidateStackSequences {
    public static class Test {
        public static void RunTest() {
            Solution solution = new();
            Console.WriteLine(solution.ValidateStackSequences(
                new int[] { 0 }, new int[] { 0 }));
            Console.WriteLine(solution.ValidateStackSequences(
                new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5, 3, 2, 1 }));
            Console.WriteLine(solution.ValidateStackSequences(
                new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 3, 5, 1, 2 }));
        }
    }
    public class Solution {
        public bool ValidateStackSequences(int[] pushed, int[] popped) {
            Stack<int> stack = new();
            int indexPush = 1, indexPop = 0;
            stack.Push(pushed[0]);
            do {
                while (indexPush < pushed.Length && 
                    (stack.Count == 0 || popped[indexPop] != stack.Peek()))
                    stack.Push(pushed[indexPush++]);
                while (stack.Count > 0 && popped[indexPop] == stack.Peek()) {
                    ++indexPop;
                    stack.Pop();
                }
            } while (indexPush < pushed.Length && indexPop < popped.Length);
            return (indexPush == pushed.Length && indexPop == popped.Length);
        }
    }
}
