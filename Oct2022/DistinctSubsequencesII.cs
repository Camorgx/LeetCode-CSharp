// https://leetcode.cn/problems/distinct-subsequences-ii/

using CommonStructure;

namespace Oct2022 {
    public class DistinctSubsequencesII : ITestable {
        public void RunTest() {
            var tests = new string[] { "abc", "aba", "aaa" };
            var solution = new Solution();
            foreach (var test in tests) 
                Console.WriteLine(solution.DistinctSubseqII(test));
        }
        public class Solution {
            public int DistinctSubseqII(string s) {
                const int MOD = (int)1e9 + 7;
                int[] alphabet = new int[26];
                int n = s.Length, total = 0;
                for (int i = 0; i < n; ++i) {
                    int ind = s[i] - 'a';
                    int prev = alphabet[ind];
                    alphabet[ind] = (total + 1) % MOD;
                    total = ((total + alphabet[ind] - prev) % MOD + MOD) % MOD;
                }
                return total;
            }
        }
    }
}
