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
        private static void BuildTree(TreeNode root, IList<int?> data) {
            if (data.Count == 0) return;
            Queue<TreeNode> que = new();
            if (!data[0].HasValue) {
                root.val = 0;
                root.left = null;
                root.right = null;
                return;
            }
            root.val = data[0].GetValueOrDefault();
            que.Enqueue(root);
            int cnt = 1;
            while (que.Count > 0 && cnt < data.Count) {
                TreeNode node = que.Dequeue();
                if (data[cnt].HasValue) {
                    node.left = new TreeNode(data[cnt].GetValueOrDefault());
                    que.Enqueue(node.left);
                }
                ++cnt;
                if (cnt < data.Count && data[cnt].HasValue) {
                    node.right = new TreeNode(data[cnt].GetValueOrDefault());
                    que.Enqueue(node.right);
                }
                ++cnt;
            }
        }
        /// <summary>
        /// 以层次遍历构建一棵二叉树
        /// </summary>
        public TreeNode(IList<int?> data) {
            BuildTree(this, data);
        }
        /// <summary>
        /// 实现二叉树的反序列化
        /// </summary>
        public TreeNode(string data) {
            var strs = data.Split();
            IList<int?> list = new List<int?>();
            foreach (var item in strs)
                if (item.Length != 0)
                    list.Add(item == "null" ? null : Convert.ToInt32(item));
            BuildTree(this, list);
        }
        /// <summary>
        /// 输出给定二叉树层次遍历的序列化形式
        /// </summary>
        public override string ToString() {
            if (this == null) return "";
            Queue<TreeNode?> queue = new();
            IList<int?> list = new List<int?>();
            queue.Enqueue(this);
            while (queue.Count > 0) {
                TreeNode? node = queue.Dequeue();
                if (node == null) {
                    list.Add(null);
                    continue;
                }
                list.Add(node.val);
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
            while (list.Count > 0 && list.Last() == null)
                list.RemoveAt(list.Count - 1);
            string ans = "";
            foreach (var item in list)
                ans += (item == null) ? "null " : $"{item} ";
            return ans;
        }
        /// <summary>
        /// 实现二叉树的反序列化
        /// </summary>
        public static TreeNode? Deserialize(string data) {
            if (data.Length == 0) return null;
            var strs = data.Split();
            IList<int?> list = new List<int?>();
            foreach (var item in strs)
                if (item.Length != 0)
                    list.Add(item == "null" ? null : Convert.ToInt32(item));
            TreeNode root = new();
            BuildTree(root, list);
            return root;
        }
        /// <summary>
        /// 实现二叉树的序列化
        /// </summary>
        public static string Serialize(TreeNode? root) {
            if (root == null) return "";
            Queue<TreeNode?> queue = new();
            IList<int?> list = new List<int?>();
            queue.Enqueue(root);
            while (queue.Count > 0) {
                TreeNode? node = queue.Dequeue();
                if (node == null) {
                    list.Add(null);
                    continue;
                }
                list.Add(node.val);
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
            while (list.Count > 0 && list.Last() == null)
                list.RemoveAt(list.Count - 1);
            string ans = "";
            foreach (var item in list)
                ans += (item == null) ? "null " : $"{item} ";
            return ans;
        }
    }
}
