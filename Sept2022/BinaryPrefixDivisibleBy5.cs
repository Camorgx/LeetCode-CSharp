// https://leetcode.cn/problems/binary-prefix-divisible-by-5/

using CommonStructure;

namespace Sept2022 {
    public class BinaryPrefixDivisibleBy5 : ITestable {
        public void RunTest() {
            int[][] tests = new int[][] {
                new int[] { 0, 1, 1 },
                new int[] { 1, 1, 1 }
            };
            Solution solution = new();
            foreach (var test in tests) {
                var res = solution.PrefixesDivBy5(test);
                foreach (var n in res)
                    Console.Write($"{n} ");
                Console.WriteLine();
            }
        }
        public class Solution {
            private enum States {
                S0, S1, S2, S3, S4
            }
            public IList<bool> PrefixesDivBy5(int[] nums) {
                States state = States.S0;
                IList<bool> res = new List<bool>();
                foreach (int num in nums) {
                    state = state switch {
                        States.S0 => num == 0 ? States.S0 : States.S1,
                        States.S1 => num == 0 ? States.S2 : States.S3,
                        States.S2 => num == 0 ? States.S4 : States.S0,
                        States.S3 => num == 0 ? States.S1 : States.S2,
                        States.S4 => num == 0 ? States.S3 : States.S4,
                        _ => States.S0
                    };
                    res.Add(state == States.S0);
                }
                return res;
            }
        }
    }
}
