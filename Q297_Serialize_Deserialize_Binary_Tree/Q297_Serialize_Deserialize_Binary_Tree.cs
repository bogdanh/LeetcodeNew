using System.Text;
using Library;

namespace Q297_Serialize_Deserialize_Binary_Tree {

    public class Q297_Serialize_Deserialize_Binary_Tree {
        private static string Serialize(TreeNode root) {
            StringBuilder sb = new StringBuilder();
            Queue<TreeNode?> q = new Queue<TreeNode?>();
            q.Enqueue(root);

            while (q.Count > 0) {
                TreeNode? node = q.Dequeue();

                if (node == null) {
                    sb.Append("null,");
                    continue;
                }

                sb.Append($"{node.Val},");
                q.Enqueue(node.Left);
                q.Enqueue(node.Right);
            }

            return sb.ToString();
        }

        private static TreeNode Deserialize(string serialized) {
            string[] nodes = serialized.Split(",");
            TreeNode root = new TreeNode(int.Parse(nodes[0]));
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            int i = 1;

            while (q.Count > 0 && i < nodes.Length) {
                root = q.Dequeue();
                if (nodes[i] != "null") {
                    root.Left = new TreeNode(int.Parse(nodes[i]));
                    q.Enqueue(root.Left);
                }
                i++;
                if (nodes[i] != "null") {
                    root.Right = new TreeNode(int.Parse(nodes[i]));
                    q.Enqueue(root.Right);
                }
                i++;
            }

            return root;
        }

        #region Recursive
        private static string SerializeRecursive(TreeNode root) {
            StringBuilder sb = new StringBuilder();

            SerializeHelper(root, sb);
            return sb.ToString();
        }

        private static void SerializeHelper(TreeNode? root, StringBuilder sb) {
            if (root == null) {
                sb.Append("null,");
                return;
            }

            sb.Append($"{root.Val},");
            SerializeHelper(root.Left, sb);
            SerializeHelper(root.Right, sb);
        }

        private static TreeNode? DeserializeRecursive(string data) {
            Queue<string> q = new Queue<string>(data.Split(","));
            return DeserializeHelper(q);
        }

        private static TreeNode? DeserializeHelper(Queue<string> q) {
            string node = q.Dequeue();

            if (node == "null") {
                return null;
            }

            TreeNode root = new TreeNode(int.Parse(node));
            root.Left = DeserializeHelper(q);
            root.Right = DeserializeHelper(q);

            return root;
        }

        #endregion Recursive

        public static void Run() {
            TreeNode root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Right.Left = new TreeNode(4);
            root.Right.Right = new TreeNode(5);

            string result = Serialize(root);
            Console.WriteLine(result);

            root = Deserialize(result);
        }
    }
}
