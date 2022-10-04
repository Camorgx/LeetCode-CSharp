// https://leetcode.cn/problems/minimum-add-to-make-parentheses-valid/

using CommonStructure;

namespace Oct2022 {
    public class MinimumAddToMakeParenthesesValid : ITestable {
        public void RunTest() {
            var tests = new string[] {
                "())",
                "((("
            };
            var solution = new Solution();
            foreach (var test in tests) 
                Console.WriteLine(solution.MinAddToMakeValid(test));
        }
        public class Solution {
            public int MinAddToMakeValid(string s) {
                int ans = 0, cnt = 0;
                foreach (char c in s) {
                    if (c == '(') ++cnt;
                    else if (cnt > 0) --cnt;
                    else ++ans;
                }
                return ans + cnt;
            }
        }
    }
}
