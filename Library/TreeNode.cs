using System.Diagnostics;

namespace Library {

    [DebuggerDisplay("{Val}")]
    public class TreeNode {
        public int Val { get; set; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }

        public TreeNode(int val) {
            Val = val;
        }

        public TreeNode(int val, TreeNode left, TreeNode right) : this(val) {
            Left = left;
            Right = right;
        }
    }
}
