// https://leetcode.cn/problems/maximum-binary-tree/

namespace MaximumBinaryTree {
    public static class Test {
        public static void RunTest() {
            Solution solution = new();

            int[] test1 = { 3, 2, 1, 6, 0, 5 };
            TreeNode root1 = solution.ConstructMaximumBinaryTree(test1);
            Console.WriteLine(root1.ToString());

            int[] test2 = { 3, 2, 1 };
            TreeNode root2 = solution.ConstructMaximumBinaryTree(test2);
            Console.WriteLine(root2.ToString());
        }
    }
    public class TreeNode {
        public int val;
        public TreeNode? left;
        public TreeNode? right;
        public TreeNode(int val = 0,
            TreeNode? left = null, TreeNode? right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
        public override string ToString() {
            if (this == null) return "";
            Queue<TreeNode?> queue = new();
            queue.Enqueue(this);
            string ans = "";
            while (queue.Count > 0) {
                TreeNode? node = queue.Dequeue();
                if (node == null) {
                    ans += "null ";
                    continue;
                }
                ans += string.Format("{0} ", node.val);
                if (node.left != null || node.right != null) {
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }
            return ans;
        }
    }
    public class Solution {

        public TreeNode ConstructMaximumBinaryTree(int[] nums) {
            Stack<int> stack = new();
            TreeNode[] nodes = new TreeNode[nums.Length];
            for (int i = 0; i < nums.Length; ++i) {
                nodes[i] = new TreeNode(nums[i]);
                while (stack.Count > 0 && nums[i] > nums[stack.Peek()])
                    nodes[i].left = nodes[stack.Pop()];
                if (stack.Count > 0) nodes[stack.Peek()].right = nodes[i];
                stack.Push(i);
            }
            int top = 0;
            while (stack.Count > 0) top = stack.Pop();
            return nodes[top];
        }
    }
}