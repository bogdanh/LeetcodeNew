#nullable disable warnings
using Library;

namespace Q236_Lowest_Common_Ancestor_of_a_Binary_Tree {

    public class Q236_Lowest_Common_Ancestor_of_a_Binary_Tree {

        public static void Run() {
            TreeNode root = new TreeNode(3);
            root.Left = new TreeNode(5);
            root.Left.Left = new TreeNode(6);
            root.Left.Right = new TreeNode(2);
            root.Left.Right.Left = new TreeNode(7);
            root.Left.Right.Right = new TreeNode(4);
            root.Right = new TreeNode(1);
            root.Right.Left = new TreeNode(0);
            root.Right.Right = new TreeNode(8);

            TreeNode p = root.Left;
            TreeNode q = root.Right.Right;

            TreeNode result = Solution(root, p, q);
            Console.WriteLine(result?.Val);

            result = SolutionIterative(root, p, q);
            Console.WriteLine(result?.Val);
        }

        private static TreeNode Solution(TreeNode root, TreeNode p, TreeNode q) {
            if (root == null || root == p || root == q) {
                return root;
            }

            TreeNode left = Solution(root.Left, p, q);
            TreeNode right = Solution(root.Right, p, q);
            
            if (left != null && right != null) {
                return root;
            }

            return left ?? right;
        }
        
        private static TreeNode SolutionIterative(TreeNode root, TreeNode p, TreeNode q) {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            Dictionary<TreeNode, TreeNode> parent = new Dictionary<TreeNode, TreeNode>();
            stack.Push(root);
            parent[root] = null;
            
            while (!parent.ContainsKey(p) || !parent.ContainsKey(q)) {
                TreeNode node = stack.Pop();
                
                if (node.Left != null) {
                    stack.Push(node.Left);
                    parent[node.Left] = node;
                }
                
                if (node.Right != null) {
                    stack.Push(node.Right);
                    parent[node.Right] = node;
                }
            }

            HashSet<TreeNode> ancestors = new HashSet<TreeNode>();
            
            while (p != null) {
                ancestors.Add(p);
                p = parent[p];
            }
            
            while (!ancestors.Contains(q)) {
                q = parent[q];
            }

            return q;
        }
    }
}