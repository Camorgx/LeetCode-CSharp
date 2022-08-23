using CommonStructure;

namespace PrintBinaryTree {
    public static class Test {
        public static void RunTest() {
            Solution solution = new();
            
            var test1 = solution.PrintTree(new TreeNode(new int[]{ 1, 2 }));
            foreach (var line in test1) {
                foreach (var item in line)
                    Console.Write("\"{0}\" ", item);
                Console.WriteLine();
            }

            Console.WriteLine();

            var test2 = solution.PrintTree(
                new TreeNode(new int[] { 1, 2, 3, -1, 4 }));
            foreach (var line in test2) {
                foreach (var item in line)
                    Console.Write("\"{0}\" ", item);
                Console.WriteLine();
            }
        }
    }
    public class Solution {
        private int depth = 0;
        private void UpdateDepth(TreeNode? root, int dep) {
            if (root == null) return;
            depth = Math.Max(dep, depth);
            UpdateDepth(root.left, dep + 1);
            UpdateDepth(root.right, dep + 1);
        }
        private int GetDepth(TreeNode? root) {
            depth = 0;
            UpdateDepth(root, 1);
            return depth;
        }
        private void DFS(ref IList<IList<string>> ans, TreeNode node,
            int x, int y, in int depth) {
            ans[x][y] = node.val.ToString();
            if (node.left != null)
                DFS(ref ans, node.left, x + 1, y - (1 << (depth - x - 2)), depth);
            if (node.right != null)
                DFS(ref ans, node.right, x + 1, y + (1 << (depth - x - 2)), depth);
        }
        public IList<IList<string>> PrintTree(TreeNode root) {
            int dep = GetDepth(root);
            int width = (1 << dep) - 1;
            IList<IList<string>> ans = new List<IList<string>>();
            for (int i = 0; i < dep; ++i) {
                IList<string> line = new List<string>();
                for (int j = 0; j < width; ++j) line.Add("");
                ans.Add(line);
            }
            DFS(ref ans, root, 0, (width - 1) / 2, dep);
            return ans;
        }
    }
}
