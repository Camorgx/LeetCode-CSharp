// https://leetcode.cn/problems/build-an-array-with-stack-operations/

using CommonStructure;

namespace Oct2022 {
    public class BuildAnArrayWithStackOperations : ITestable {
        public void RunTest() {
            var tests = new (int[], int)[] {
                (new int[] { 1, 3 }, 3),
                (new int[] { 1, 2, 3 }, 3),
                (new int[] { 1, 2 }, 4)
            };
            var solution = new Solution();
            foreach (var (target, n) in tests) {
                var res = solution.BuildArray(target, n);
                foreach (var item in res)
                    Console.Write(item + " ");
                Console.WriteLine();
            }
        }
        public class Solution {
            public IList<string> BuildArray(int[] target, int n) {
                IList<string> res = new List<string>();
                int prev = 0;
                foreach (int number in target) {
                    for (int i = prev + 1; i < number; ++i) {
                        res.Add("Push");
                        res.Add("Pop");
                    }
                    res.Add("Push");
                    prev = number;
                }
                return res;
            }
        }
    }
}
