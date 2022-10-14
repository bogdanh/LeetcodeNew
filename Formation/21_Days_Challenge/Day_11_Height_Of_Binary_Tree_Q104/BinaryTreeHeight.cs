#nullable disable warnings

using Library;

namespace Formation {

    public class BinaryTreeHeight {
        public static void Run() {
            var root = new TreeNode(1, null, null);
            root.Left = new TreeNode(2, null, null);
            root.Right = new TreeNode(3, null, null);
            root.Left.Left = new TreeNode(4, null, null);
            root.Left.Right = new TreeNode(5, null, null);

            var result = Solution(root);
            Console.WriteLine(result);
            result = Solution1(root);
            Console.WriteLine(result);
            result = IterativeStack(root);
            Console.WriteLine(result);
            result = IterativeQueue(root);
            Console.WriteLine(result);
        }
        
        private static int IterativeQueue(TreeNode root) {
            if (root == null) {
                return 0;
            }
            var max = 0;

            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            
            while (q.Count > 0) {
                int size = q.Count();
                max++;
                
                while (size > 0) {
                    size--;
                    root = q.Dequeue();
                    
                    if (root.Left != null) {
                        q.Enqueue(root.Left);
                    }
                    
                    if (root.Right != null) {
                        q.Enqueue(root.Right);
                    }
                }
            }

            return max;
        }
        
        private static int IterativeStack(TreeNode root) {
            if (root == null) {
                return 0;
            }
            
            var max = 0;
            var nodesStack = new Stack<TreeNode>();
            var depthStack = new Stack<int>();

            nodesStack.Push(root);
            depthStack.Push(1);
            
            while (nodesStack.Count > 0) {
                root = nodesStack.Pop();
                var currDepth = depthStack.Pop();
                
                if (root != null) {
                    max = Math.Max(max, currDepth);
                    nodesStack.Push(root.Left);
                    nodesStack.Push(root.Right);
                    depthStack.Push(currDepth + 1);
                    depthStack.Push(currDepth + 1);
                }
            }

            return max;
        }
        
        private static int Solution1(TreeNode root) {
            if (root == null) {
                return 0;
            }

            var leftMax = Solution1(root.Left);
            var rightMax = Solution1(root.Right);

            return 1 + Math.Max(leftMax, rightMax);
        }
        
        private static int Solution(TreeNode root) {
            if (root == null) {
                return 0;
            }

            var max = 0;
            var depth = 1;
            Helper(root, ref max, depth);

            return max;
        }
        
        private static void Helper(TreeNode root, ref int max, int depth) {
            if (root == null) {
                return;
            }
            
            if (root.Left == null && root.Right == null) {
                max = Math.Max(max, depth);
            }

            Helper(root.Left, ref max, depth + 1);
            Helper(root.Left, ref max, depth + 1);
        }
    }
}
