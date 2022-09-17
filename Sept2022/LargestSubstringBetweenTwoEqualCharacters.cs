// https://leetcode.cn/problems/largest-substring-between-two-equal-characters/

using CommonStructure;

namespace Sept2022 {
    public class LargestSubstringBetweenTwoEqualCharacters
        : ITestable {
        public void RunTest() {
            var tests = new string[] {
                "aa",
                "abca",
                "cbzxy",
                "cabbac"
            };
            Solution solution = new();
            foreach (var test in tests)
                Console.WriteLine(solution.MaxLengthBetweenEqualCharacters(test));
        }
        public class Solution {
            public int MaxLengthBetweenEqualCharacters(string s) {
                int[] first = new int[26];
                int[] last = new int[26];
                Array.Fill(first, s.Length);
                Array.Fill(last, -1);
                for (int i = 0; i < s.Length; ++i) {
                    first[s[i] - 'a'] = Math.Min(first[s[i] - 'a'], i);
                    last[s[i] - 'a'] = Math.Max(last[s[i] - 'a'], i);
                }
                int ans = -1;
                for (int i = 0; i < 26; ++i)
                    if (last[i] != -1)
                        ans = Math.Max(ans, last[i] - first[i] - 1);
                return ans;
            }
        }
    }
}
