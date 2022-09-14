// https://leetcode.cn/problems/maximum-swap/

using CommonStructure;

namespace Sept2022 {
    public class MaximumSwap : ITestable {
        public void RunTest() {
            int[] tests = { 2736, 9973 };
            Solution solution = new();
            foreach (var test in tests) 
                Console.WriteLine(solution.MaximumSwap(test));
        }
        public class Solution {
            public int MaximumSwap(int num) {
                var div = num.ToString().ToCharArray();
                int maxIndex = div.Length - 1;
                int index1 = -1, index2 = -1;
                for (int i = div.Length - 1; i >=0; --i) {
                    if (div[i] > div[maxIndex]) maxIndex = i;
                    else if (div[i] < div[maxIndex]) {
                        index1 = i;
                        index2 = maxIndex;
                    }
                }
                if (index1 >= 0) {
                    (div[index2], div[index1]) = (div[index1], div[index2]);
                    return int.Parse(div);
                }
                else return num;
            }
        }
    }
}
