// https://leetcode.cn/problems/check-permutation-lcci/

using CommonStructure;

namespace Sept2022 {
    public class CheckPermutationLcci : ITestable {
        public void RunTest() {
            var tests = new (string s1, string s2)[] {
                ("abc", "bca"),
                ("abc", "bad")
            };
            var solution = new Solution();
            foreach (var (s1, s2) in tests)
                Console.WriteLine(solution.CheckPermutation(s1, s2));
        }
        public class Solution {
            public bool CheckPermutation(string s1, string s2) {
                char[] chars1 = s1.ToCharArray();
                char[] chars2 = s2.ToCharArray();
                Array.Sort(chars1);
                Array.Sort(chars2);
                return chars1.SequenceEqual(chars2);
            }
        }
    }
}
