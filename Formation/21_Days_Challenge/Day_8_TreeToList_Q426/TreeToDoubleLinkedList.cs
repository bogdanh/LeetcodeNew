#nullable disable warnings
using Library;

namespace Formation {

    public class TreeToDoubleLinkedList {
        public static void Run() {
            var root = new TreeNode(1, null, null);
            root.Left = new TreeNode(2, null, null);
            root.Right = new TreeNode(3, null, null);

            root.Left.Left = new TreeNode(4, null, null);
            root.Left.Right = new TreeNode(5, null, null);

            root.Right.Left = new TreeNode(6, null, null);
            root.Right.Right = new TreeNode(7, null, null);

            // root.Print();

            var result = Solution(root);

            // result.Print();
        }
        
        private static TreeNode Solution(TreeNode root) {
            if (root == null) {
                return root;
            }

            TreeNode first = null;
            TreeNode last = null;
            var stack = new Stack<TreeNode>();
            
            while (root != null || stack.Count > 0) {
                while (root != null) {
                    stack.Push(root);
                    root = root.Left;
                }

                root = stack.Pop();
                
                if (first == null) {
                    first = root;
                }
                
                if (last != null) {
                    last.Right = root;
                    root.Left = last;
                }

                last = root;
                root = root.Right;
            }

            last.Right = first;
            first.Left = last;

            return first;
        }
    }
}
