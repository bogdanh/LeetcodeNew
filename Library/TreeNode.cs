using System.Diagnostics;

namespace Library {

    [DebuggerDisplay("{Val}")]
    public class TreeNode {
        public int Val { get; set; }
        public TreeNode? Left { get; set; } = null;
        public TreeNode? Right { get; set; } = null;

        public TreeNode? Parent { get; set; } = null;

        public TreeNode(int val) {
            Val = val;
        }

        public TreeNode(int val, TreeNode left, TreeNode right) : this(val) {
            Left = left;
            Right = right;
        }
    }
}
