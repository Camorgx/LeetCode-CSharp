// https://leetcode.cn/problems/score-of-parentheses/

using CommonStructure;

namespace Oct2022 {
    public class ScoreOfParentheses : ITestable {
        public void RunTest() {
            var tests = new string[] {
                "()", "(())", "()()", "(()(()))"
            };
            var solution = new Solution();
            foreach (var test in tests)
                Console.WriteLine(solution.ScoreOfParentheses(test));
        }
        public class Solution {
            public int ScoreOfParentheses(string s) {
                if (s.Length == 2) return 1;
                int cnt = 0, subStrLen = 0;
                for (int i = 0; i < s.Length; ++i) {
                    if (s[i] == '(') ++cnt;
                    else --cnt;
                    if (cnt == 0) {
                        subStrLen = i + 1;
                        break;
                    }
                }
                if (subStrLen == s.Length)
                    return 2 * ScoreOfParentheses(s.Substring(1, subStrLen - 2));
                else return ScoreOfParentheses(s.Substring(0, subStrLen))
                        + ScoreOfParentheses(s.Substring(subStrLen));
            }
        }
    }
}
