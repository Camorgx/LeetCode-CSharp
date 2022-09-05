// https://leetcode.cn/problems/find-duplicate-subtrees/

using CommonStructure;

namespace Sept2022 {
    public class FindDuplicateSubtrees : ITestable {
        public void RunTest() {
            string[] tests = new string[] {
                "[1,2,3,4,null,2,4,null,null,4]",
                "[2,1,1]",
                "[2,2,2,3,null,3,null]"
            };
            Solution solution = new();
            foreach (string test in tests) {
                var res = solution.FindDuplicateSubtrees(
                    new TreeNode(test));
                foreach (TreeNode node in res)
                    Console.WriteLine(node.ToString());
                Console.WriteLine();
            }
        }
        public class Solution {
            private Dictionary<string , (TreeNode node, int index)> seen = new();
            private ISet<TreeNode> repeat = new HashSet<TreeNode>();
            private int index = 0;
            private int DFS(TreeNode? root) {
                if (root == null) return 0;
                var subTree = (root.val, DFS(root.left), DFS(root.right));
                string hash = subTree.ToString();
                if (seen.ContainsKey(hash)) {
                    var pair = seen[hash];
                    repeat.Add(pair.node);
                    return pair.index;
                }
                else {
                    seen.Add(hash, (root, ++index));
                    return index;
                }
            }
            public IList<TreeNode> FindDuplicateSubtrees(TreeNode root) {
                index = 0;
                seen.Clear();
                repeat.Clear();
                DFS(root);
                return repeat.ToList();
            }
        }
    }
}
