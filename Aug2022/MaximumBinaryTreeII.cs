// https://leetcode.cn/problems/maximum-binary-tree-ii/

using CommonStructure;

namespace MaximumBinaryTreeII {
    public static class Test {
        public static void RunTest() {
            Solution solution = new();

            var tests = new (int[] root, int val)[] {
                (new int[] { 4, 1, 3, -1, -1, 2 }, 5),
                (new int[] { 5, 2, 4, -1, 1 }, 3),
                (new int[] { 5, 2, 3, -1, 1 }, 4)
            };

            foreach (var testCase in tests) {
                TreeNode root = new TreeNode(testCase.root);
                Console.WriteLine(
                    solution.InsertIntoMaxTree(root, testCase.val)
                            .ToString());
            }
        }
    }
    public class Solution {
        public TreeNode InsertIntoMaxTree(TreeNode? root, int val) {
            if (root == null || root.val < val) 
                return new TreeNode(val, root, null);
            root.right = InsertIntoMaxTree(root.right, val);
            return root;
        }
    }
}
