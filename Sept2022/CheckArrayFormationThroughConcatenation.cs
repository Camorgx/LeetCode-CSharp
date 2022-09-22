// https://leetcode.cn/problems/check-array-formation-through-concatenation/

using CommonStructure;

namespace Sept2022 {
    public class CheckArrayFormationThroughConcatenation
        : ITestable {
        public void RunTest() {
            var tests = new (int[] arr, int[][] pieces)[] {
                (
                    new int[] { 15, 88 }, 
                    new int[][] {
                        new int[] { 88 }, 
                        new int[] { 15 }
                    }
                ),
                (
                    new int[] { 49, 18, 16 }, 
                    new int[][] {
                        new int[] { 16, 18, 49 }
                    }
                ),
                (
                    new int[] { 91, 4, 64, 78 }, 
                    new int[][] {
                        new int[] { 78 },
                        new int[] { 4, 64 },
                        new int[] { 91 }
                    }
                )
            };
            var solution = new Solution();
            foreach (var test in tests)
                Console.WriteLine(
                    solution.CanFormArray(test.arr, test.pieces));
        }
        public class Solution {
            public bool CanFormArray(int[] arr, int[][] pieces) {
                IDictionary<int, int> map = new Dictionary<int, int>();
                for (int i = 0; i < pieces.Length; ++i)
                    map.Add(pieces[i][0], i);
                for (int i = 0; i < arr.Length; ++i) {
                    if (!map.ContainsKey(arr[i])) return false;
                    int index = map[arr[i]];
                    for (int k = 0; k < pieces[index].Length; ++k) {
                        if (i + k >= arr.Length) return false;
                        if (arr[i + k] != pieces[index][k]) return false;
                    }
                    i += pieces[index].Length - 1;
                }
                return true;
            }
        }
    }
}
