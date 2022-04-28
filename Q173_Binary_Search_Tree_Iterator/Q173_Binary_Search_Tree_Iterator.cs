using Library;

namespace Q173_Binary_Search_Tree_Iterator {

    public class Q173_Binary_Search_Tree_Iterator {

        public static void Run() {
            TreeNode root = new TreeNode(7);
            root.Left = new TreeNode(3);
            root.Right = new TreeNode(15);
            root.Right.Left = new TreeNode(9);
            root.Right.Right = new TreeNode(20);

            BSTIterator bstIterator = new BSTIterator(root);
            Console.WriteLine(bstIterator.Next());
            Console.WriteLine(bstIterator.Next());
            Console.WriteLine(bstIterator.HasNext());
            Console.WriteLine(bstIterator.Next());
            Console.WriteLine(bstIterator.HasNext());
            Console.WriteLine(bstIterator.Next());
            Console.WriteLine(bstIterator.HasNext());
            Console.WriteLine(bstIterator.Next());
            Console.WriteLine(bstIterator.HasNext());

            BSTIteratorWithStack bstIteratorWithStack = new BSTIteratorWithStack(root);
            Console.WriteLine(bstIteratorWithStack.Next());
            Console.WriteLine(bstIteratorWithStack.Next());
            Console.WriteLine(bstIteratorWithStack.HasNext());
            Console.WriteLine(bstIteratorWithStack.Next());
            Console.WriteLine(bstIteratorWithStack.HasNext());
            Console.WriteLine(bstIteratorWithStack.Next());
            Console.WriteLine(bstIteratorWithStack.HasNext());
            Console.WriteLine(bstIteratorWithStack.Next());
            Console.WriteLine(bstIteratorWithStack.HasNext());
        }

        public class BSTIterator {

            private List<int> List { get; set; }
            private int Index { get; set; }

            public BSTIterator(TreeNode root) {
                List = new List<int>();
                Index = 0;
                InOrder(root);
            }

            public int Next() {
                return List[Index++];
            }

            public bool HasNext() {
                return Index < List.Count;
            }

            private void InOrder(TreeNode? root) {
                if (root == null) {
                    return;
                }

                InOrder(root.Left);
                List.Add(root.Val);
                InOrder(root.Right);
            }
        }

        public class BSTIteratorWithStack {
            private Stack<TreeNode> stack { get; set; }

            public BSTIteratorWithStack(TreeNode root) {
                stack = new Stack<TreeNode>();
                InOrder(root);
            }

            public int Next() {
                TreeNode top = stack.Pop();

                if (top.Right != null) {
                    InOrder(top.Right);
                }

                return top.Val;
            }

            public bool HasNext() {
                return stack.Count > 0;
            }

            private void InOrder(TreeNode? root) {
                while (root != null) {
                    stack.Push(root);
                    root = root.Left;
                }
            }
        }
    }
}
