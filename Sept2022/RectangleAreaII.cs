// https://leetcode.cn/problems/rectangle-area-ii/

using CommonStructure;

namespace Sept2022 {
    public class RectangleAreaII : ITestable {
        public void RunTest() {
            var tests = new int[][][] {
                new int[][] {
                    new int[] { 0, 0, 2, 2 },
                    new int[] { 1, 0, 2, 3 },
                    new int[] { 1, 0, 3, 1 }
                },
                new int[][] {
                    new int[] { 0, 0, 1000000000, 1000000000 }
                }
            };
            Solution solution = new();
            foreach (var test in tests)
                Console.WriteLine(solution.RectangleArea(test));
        }
        public class Solution {
            private static List<int> hBound = new();
            private class SegmentTree {
                private class Node {
                    public int Cover = 0;
                    public int Length = 0;
                    public int MaxLength = 0;
                }
                public int TotalLength => tree[1].Length;
                private readonly Node[] tree;
                public SegmentTree(int nodeCnt) {
                    tree = new Node[4 * (nodeCnt + 1) + 1];
                    Init(1, 1, nodeCnt);
                }
                private void Init(int idx, int l, int r) {
                    tree[idx] = new Node();
                    if (l == r) {
                        tree[idx].MaxLength = hBound[l] - hBound[l - 1];
                        return;
                    }
                    int mid = (l + r) / 2;
                    Init(idx * 2, l, mid);
                    Init(idx * 2 + 1, mid + 1, r);
                    tree[idx].MaxLength = tree[idx * 2].MaxLength + tree[idx * 2 + 1].MaxLength;
                }
                private void PushUp(int idx, int l, int r) {
                    if (tree[idx].Cover > 0)
                        tree[idx].Length = tree[idx].MaxLength;
                    else if (l == r) tree[idx].Length = 0;
                    else tree[idx].Length = tree[idx * 2].Length + tree[idx * 2 + 1].Length;
                }
                /// <summary>
                /// 区间修改（区间加上某个值）。
                /// </summary>
                /// <param name="idx">节点编号</param>
                /// <param name="l">当前节点区间左端点</param>
                /// <param name="r">当前节点区间右端点</param>
                /// <param name="ul">修改区间左端点</param>
                /// <param name="ur">修改区间右端点</param>
                /// <param name="diff">区间增量</param>
                public void Update(int idx, int l, int r, int ul, int ur, int diff) {
                    if (l > ur || r < ul) return;
                    if (ul <= l && r <= ur) {
                        tree[idx].Cover += diff;
                        PushUp(idx, l, r);
                        return;
                    }
                    int mid = (l + r) / 2;
                    Update(idx * 2, l, mid, ul, ur, diff);
                    Update(idx * 2 + 1, mid + 1, r, ul, ur, diff);
                    PushUp(idx, l, r);
                }
            }
            public static int BinarySearch(IList<int> array, int target) {
                int l = 0, r = array.Count - 1;
                while (l < r) {
                    int mid = l + (r - l) / 2;
                    if (array[mid] >= target) r = mid;
                    else l = mid + 1;
                }
                return l;
            }
            public int RectangleArea(int[][] rectangles) {
                const int Mod = (int)1e9 + 7;
                ISet<int> set = new HashSet<int>();
                foreach (int[] rectangle in rectangles) {
                    set.Add(rectangle[1]); // 下边界 
                    set.Add(rectangle[3]); // 上边界
                }
                hBound = new List<int>(set);
                hBound.Sort();
                var tree = new SegmentTree(hBound.Count - 1);
                var sweep = new List<(int bound, int idx, int diff)>();
                for (int i = 0; i < rectangles.Length; ++i) {
                    sweep.Add((rectangles[i][0], i, 1)); //左边界
                    sweep.Add((rectangles[i][2], i, -1)); // 右边界
                }
                sweep.Sort();
                long ans = 0;
                for (int i = 0; i < sweep.Count; ++i) {
                    int j = i;
                    while (j + 1 < sweep.Count
                        && sweep[i].bound == sweep[j + 1].bound)
                        ++j;
                    if (j + 1 == sweep.Count) break;
                    for (int k = i; k <= j; ++k) {
                        int idx = sweep[k].idx, diff = sweep[k].diff;
                        int left = BinarySearch(hBound, rectangles[idx][1]) + 1;
                        int right = BinarySearch(hBound, rectangles[idx][3]);
                        tree.Update(1, 1, hBound.Count - 1, left, right, diff);
                    }
                    ans += (long)tree.TotalLength * (sweep[j + 1].bound - sweep[j].bound);
                    i = j;
                }
                return (int)(ans % Mod);
            }
        }
    }
}
