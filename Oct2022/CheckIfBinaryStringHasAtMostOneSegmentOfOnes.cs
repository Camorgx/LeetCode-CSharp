// https://leetcode.cn/problems/check-if-binary-string-has-at-most-one-segment-of-ones/

using CommonStructure;

namespace Oct2022 {
    public class CheckIfBinaryStringHasAtMostOneSegmentOfOnes
        : ITestable {
        public void RunTest() {
            var tests = new string[] {
                "1001",
                "110"
            };
            var solution = new Solution();
            foreach (var test in tests)
                Console.WriteLine(solution.CheckOnesSegment(test));
        }
        public class Solution {
            public bool CheckOnesSegment(string s)
                => !s.Contains("01");
        }
    }
}
