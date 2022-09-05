// https://leetcode.cn/problems/maximum-width-of-binary-tree/

using CommonStructure;

namespace MaximumWidthOfBinaryTree {
    public static class Test {
        public static void RunTest() {
            int?[][] test = new int?[][] {
                new int?[] { 1, 3, 2, 5, 3, null, 9 },
                new int?[] { 1, 3, 2, 5, null, null, 9, 6, null, 7 },
                new int?[] { 1, 3, 2, 5 }
            };
            Solution solution = new();
            foreach (var set in test) {
                TreeNode treeNode = new(set);
                Console.WriteLine(treeNode.ToString());
                Console.WriteLine(solution.WidthOfBinaryTree(treeNode));
            }
        }
    }
    public class Solution {
        public int WidthOfBinaryTree(TreeNode root) {
            Queue<(TreeNode node, int index)> line = new();
            line.Enqueue((root, 1));
            int ans = 0;
            while (line.Count > 0) {
                ans = Math.Max(ans,
                    line.Last().index - line.First().index + 1);
                Queue<(TreeNode node, int index)> tmp = new();
                foreach (var (node, index) in line) {
                    if (node.left != null)
                        tmp.Enqueue((node.left, index * 2));
                    if (node.right != null)
                        tmp.Enqueue((node.right, index * 2 + 1));
                }
                line = tmp;
            }
            return ans;
        }
    }
}
