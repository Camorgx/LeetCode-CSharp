// https://leetcode.cn/problems/check-if-one-string-swap-can-make-strings-equal/

using CommonStructure;

namespace Oct2022 {
    public class CheckIfOneStringSwapCanMakeStringsEqual : ITestable {
        public void RunTest() {
            var tests = new (string, string)[] {
                ("bank", "kanb"),
                ("attack", "defend"),
                ("kelb", "kelb"),
                ("abcd", "dcba"),
                ("qqlvguziljnavojtlukwzmgyrqvsqsub", 
                 "qqlvgujiljnavoztlukwzmgyrqvsqsub")
            };
            var solution = new Solution();
            foreach (var (s1, s2) in tests)
                Console.WriteLine(solution.AreAlmostEqual(s1, s2));
        }
        public class Solution {
            public bool AreAlmostEqual(string s1, string s2) {
                if (s1.Length != s2.Length) return false;
                char[] newS1 = s1.ToCharArray();
                for (int i = 0; i < s1.Length; ++i) {
                    if (newS1[i] != s2[i]) {
                        IList<int> pos = new List<int>();
                        for (int j = i + 1; j < newS1.Length; ++j)
                            if (newS1[j] == s2[i])
                                pos.Add(j);
                        if (pos.Count == 0) return false;
                        foreach (int p in pos) {
                            (newS1[i], newS1[p]) = (newS1[p], newS1[i]);
                            if (new string(newS1, i, newS1.Length - i) == s2[i..])
                                return true;
                            (newS1[i], newS1[p]) = (newS1[p], newS1[i]);
                        }
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
