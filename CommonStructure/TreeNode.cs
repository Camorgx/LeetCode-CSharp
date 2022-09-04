namespace CommonStructure {
    /// <summary>
    /// 通用二叉树节点类，提供层次遍历的 ToString() 重写
    /// </summary>
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
        /// <summary>
        /// 以层次遍历构建一棵二叉树
        /// </summary>
        public TreeNode(in int[] data) {
            Queue<TreeNode> que = new();
            if (data[0] == -1) {
                val = 0;
                left = null;
                right = null;
                return;
            }
            val = data[0];
            que.Enqueue(this);
            int cnt = 1;
            while (que.Count > 0 && cnt < data.Length) {
                TreeNode node = que.Dequeue();
                if (data[cnt] != -1) {
                    node.left = new TreeNode(data[cnt]);
                    que.Enqueue(node.left);
                }
                ++cnt;
                if (cnt < data.Length && data[cnt] != -1) {
                    node.right = new TreeNode(data[cnt]);
                    que.Enqueue(node.right);
                }
                ++cnt;
            }
        }
        /// <summary>
        /// 输出给定二叉树的层次遍历
        /// </summary>
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
}
