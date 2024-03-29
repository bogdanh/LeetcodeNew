using System.Diagnostics;
using System.Text;

namespace Library {

    [DebuggerDisplay("{Val}")]
    public class SingleLinkedListNode {
        public int Val { get; set; }
        public SingleLinkedListNode? Next { get; set; } = null;
        public SingleLinkedListNode? Sublist { get; set; } = null;

        public SingleLinkedListNode() {
            Val = 0;
            Next = null;
        }

        public SingleLinkedListNode(int val, SingleLinkedListNode next) {
            Val = val;
            Next = next;
        }
        
        public SingleLinkedListNode(int val, SingleLinkedListNode next, SingleLinkedListNode sublist) {
            Val = val;
            Next = next;
            Sublist = sublist;
        }

        public void Print() {
            StringBuilder sb = new StringBuilder();
            SingleLinkedListNode? tmp = this;

            while (tmp != null) {
                sb.Append($"{tmp.Val} -> ");
                tmp = tmp.Next;
            }

            if (sb.Length > 0) {
                sb.Length = sb.Length - 4;
            }

            Console.WriteLine(sb.ToString());
        }
    }
}