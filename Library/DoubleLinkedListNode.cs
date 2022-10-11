using System.Diagnostics;
using System.Text;

namespace Library {

    [DebuggerDisplay("{Val}")]
    public class DoubleLinkedListNode {
        public int Val { get; set; }
        public DoubleLinkedListNode? Next { get; set; }
        public DoubleLinkedListNode? Prev { get; set; }
        
        public DoubleLinkedListNode() {
            Val = 0;
            Next = null;
            Prev = null;
        }
        
        public DoubleLinkedListNode(int val, DoubleLinkedListNode next, DoubleLinkedListNode prev) {
            Val = val;
            Next = next;
            Prev = prev;
        }
        
        public void Print() {
            var sb = new StringBuilder();

            var curr = this;
            
            if (curr != null) {
                sb.Append($"{curr.Val} ⇆ ");
                curr = curr.Next;
            }
            
            while (curr != this && curr != null) {
                sb.Append($"{curr.Val} ⇆ ");
                curr = curr.Next;
            }
            
            if (sb.Length > 0) {
                sb.Length = sb.Length - 3;
            }

            Console.WriteLine(sb.ToString());
        }
    }
}