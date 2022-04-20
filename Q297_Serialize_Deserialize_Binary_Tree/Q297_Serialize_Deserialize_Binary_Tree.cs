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
                    TreeNode left = new TreeNode(int.Parse(nodes[i]));
                    root.Left = left;
                    q.Enqueue(root.Left);
                }
                i++;
                if (nodes[i] != "null") {
                    TreeNode right = new TreeNode(int.Parse(nodes[i]));
                    root.Right = right;
                    q.Enqueue(root.Right);
                }
                i++;
            }

            return root;
        }

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
