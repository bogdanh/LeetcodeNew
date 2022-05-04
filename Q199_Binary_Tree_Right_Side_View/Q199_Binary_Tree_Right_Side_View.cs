using Library;

namespace Q199_Binary_Tree_Right_Side_View {

    public class Q199_Binary_Tree_Right_Side_View {

        public static void Run() {
            TreeNode root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Left.Right = new TreeNode(5);
            root.Right = new TreeNode(3);
            root.Right.Right = new TreeNode(4);

            List<int> result = Solution(root);
            AssortedMethods.PrintIntArray(result.ToArray());
        }

        private static List<int> Solution(TreeNode root) {
            List<int> rightSide = new List<int>();
            if (root == null) {
                return rightSide;
            }

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0) {
                int size = q.Count;

                for (int i = 0; i < size; i++) {
                    TreeNode node = q.Dequeue();
                    
                    if (i == size - 1) {
                        rightSide.Add(node.Val);
                    }
                    
                    if (node.Left != null) {
                        q.Enqueue(node.Left);
                    }
                    
                    if (node.Right != null) {
                        q.Enqueue(node.Right);
                    }
                }
            }
            
            return rightSide;
        }
    }
}
