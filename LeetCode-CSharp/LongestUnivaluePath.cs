// https://leetcode.cn/problems/longest-univalue-path/

using CommonStructure;

namespace LongestUnivaluePath {
    public static class Test {
        public static void RunTest() {
            Solution solution = new();
            int[][] tests = new int[][] {
                new int[] { 5, 4, 5, 1, 1, -1, 5 },
                new int[] { 1, 4, 5, 4, 4, -1, 5 }
            };
            foreach (int[] test in tests)
                Console.WriteLine(
                    solution.LongestUnivaluePath(new TreeNode(test)));
        }
    }
    public class Solution {
        private int ans = 0;
        private int LongestSizePath(TreeNode? root) {
            if (root == null) return 0;
            int leftPath = LongestSizePath(root.left);
            int rightPath = LongestSizePath(root.right);
            leftPath = (root.left != null && root.left.val == root.val) ?
                leftPath + 1 : 0;
            rightPath = (root.right != null && root.right.val == root.val) ?
                rightPath + 1 : 0;
            ans = Math.Max(ans, leftPath + rightPath);
            return Math.Max(leftPath, rightPath);
        }
        public int LongestUnivaluePath(TreeNode root) {
            ans = 0;
            LongestSizePath(root);
            return ans;
        }
    }
}
