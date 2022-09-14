// https://leetcode.cn/problems/trim-a-binary-search-tree/

using CommonStructure;

namespace Sept2022 {
    public class TrimABinarySearchTree : ITestable {
        public void RunTest() {
            var tests = new (string root, int low, int high)[] {
                ("[1,0,2]", 1, 2), ("[3,0,4,null,2,null,null,1]", 1, 3) };
            Solution solution = new();
            foreach (var test in tests) {
                var res = solution.TrimBST(new TreeNode(test.root), test.low, test.high);
                if (res == null) {
                    Console.WriteLine("null");
                    continue;
                }
                else Console.WriteLine(res.ToString());
            }
        }
        public class Solution {
            public TreeNode? TrimBST(TreeNode? root, int low, int high) {
                if (root == null) return null;
                if (root.val < low)
                    return TrimBST(root.right, low, high);
                else if (root.val > high)
                    return TrimBST(root.left, low, high);
                else {
                    root.left = TrimBST(root.left, low, high);
                    root.right = TrimBST(root.right, low, high);
                    return root;
                }
            }
        }
    }
}
