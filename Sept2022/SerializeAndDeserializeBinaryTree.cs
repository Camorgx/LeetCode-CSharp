// https://leetcode.cn/problems/serialize-and-deserialize-binary-tree/
// https://leetcode.cn/problems/xu-lie-hua-er-cha-shu-lcof/

using CommonStructure;

namespace Sept2022 {
    public class SerializeAndDeserializeBinaryTree
        : ITestable {
        public void RunTest() {
            Codec codec = new();
            int?[][] tests = new int?[][] {
                new int?[] { 1, 2, 3, null, null, 4, 5 },
                Array.Empty<int?>(),
                new int?[] { 1 },
                new int?[] { 1, 2 }
            };
            Console.WriteLine(codec.deserialize(codec.serialize(null)));
            foreach (var test in tests) {
                TreeNode root = new TreeNode(test);
                var res = codec.deserialize(codec.serialize(root));
                if (res == null) Console.WriteLine();
                else Console.WriteLine(res.ToString());
            }
        }
        public class Codec {
            // Encodes a tree to a single string.
            public string serialize(TreeNode? root) {
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
            // Decodes your encoded data to tree.
            public TreeNode? deserialize(string data) {
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
        }
    }
}
