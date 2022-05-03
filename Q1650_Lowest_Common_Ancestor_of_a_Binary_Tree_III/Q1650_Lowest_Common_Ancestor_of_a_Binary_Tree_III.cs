using Library;

namespace Q1650_Lowest_Common_Ancestor_of_a_Binary_Tree_III {
    public class Q1650_Lowest_Common_Ancestor_of_a_Binary_Tree_III {

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

            root.Left.Parent = root;
            root.Right.Parent = root;
            root.Left.Left.Parent = root.Left;
            root.Left.Right.Parent = root.Left;
            root.Left.Right.Left.Parent = root.Left.Right;
            root.Left.Right.Right.Parent = root.Left.Right;
            root.Right.Left.Parent = root.Right;
            root.Right.Right.Parent = root.Right;

            TreeNode p = root.Left;
            TreeNode q = root.Right.Right;

            TreeNode? result = Solution(p, q);
            Console.WriteLine($"LCA for {p.Val} & {q.Val} = {result?.Val}");
            result = SolutionSimplified(p, q);
            Console.WriteLine($"LCA for {p.Val} & {q.Val} = {result?.Val}");
        }

        private static TreeNode? Solution(TreeNode? p, TreeNode? q) {
            int pCount = CountDepthOf(p);
            int qCount = CountDepthOf(q);

            int diff = Math.Abs(pCount - qCount);
            
            if (pCount > qCount) {
                while (diff > 0) {
                    p = p?.Parent;
                    diff--;
                }
            } else {
                while (diff > 0) {
                    q = q?.Parent;
                    diff--;
                }
            }
            
            while (p != q) {
                p = p?.Parent;
                q = q?.Parent;
            }

            return p;
        }
        
        private static TreeNode? SolutionSimplified(TreeNode? p, TreeNode? q) {
            TreeNode? a = p;
            TreeNode? b = q;

            while (a != b) {
                a = a == null ? q : a?.Parent;
                b = b == null ? p : b?.Parent;
            }
            return a;
        }
        
        private static int CountDepthOf(TreeNode? node) {
            int count = 0;

            while (node != null) {
                count++;
                node = node.Parent;
            }

            return count;
        }
    }

}
