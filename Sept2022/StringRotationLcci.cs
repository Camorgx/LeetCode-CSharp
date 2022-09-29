// https://leetcode.cn/problems/string-rotation-lcci/

using CommonStructure;

namespace Sept2022 {
    public class StringRotationLcci : ITestable {
        public void RunTest() {
            var tests = new (string, string)[] {
                ("waterbottle", "erbottlewat"),
                ("aa", "aba")
            };
            var solution = new Solution();
            foreach (var (s1, s2) in tests)
                Console.WriteLine(solution.IsFlipedString(s1, s2));
        }
        public class Solution {
            public bool IsFlipedString(string s1, string s2) {
                return s1.Length == s2.Length
                    && (s1 + s1).Contains(s2);
            }
        }
    }
}
