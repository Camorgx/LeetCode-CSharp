using CommonStructure;

namespace Sept2022 {
    public class BulbSwitcherII : ITestable {
        public void RunTest() {
            var tests = new (int n, int presses)[] {
                (1, 1), (2, 1), (3, 1)
            };
            Solution solution = new();
            foreach (var test in tests)
                Console.WriteLine(solution.FlipLights(test.n, test.presses));
        }
        public class Solution {
            public int FlipLights(int n, int presses) {
                if (presses == 0) return 1;
                return n switch {
                    1 => 2,
                    2 => presses == 1 ? 3 : 4,
                    _ => presses == 1 ? 4 : (presses == 2 ? 7 : 8)
                };
            }
        }
    }
}
