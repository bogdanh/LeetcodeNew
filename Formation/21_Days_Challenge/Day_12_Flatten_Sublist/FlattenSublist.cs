#nullable disable warnings
using Library;

namespace Formation {

    public class FLattenSublist {
        public static void Run() {
            var result = new List<int>();
            var head = new SingleLinkedListNode(1,
                       new SingleLinkedListNode(2,
                       new SingleLinkedListNode(3, 
                       new SingleLinkedListNode(4, null))));

            head.Next.Sublist = new SingleLinkedListNode(1,
                                new SingleLinkedListNode(2,
                                new SingleLinkedListNode(3,
                                new SingleLinkedListNode(4, null))));
            head.Next.Next.Sublist = new SingleLinkedListNode(10,
                                    new SingleLinkedListNode(11,
                                    new SingleLinkedListNode(12,
                                    new SingleLinkedListNode(13, null))));
            Solution(head, result);
            AssortedMethods.PrintIntArray(result.ToArray());
        }
        
        private static void Solution(SingleLinkedListNode head, List<int> result) {
            if (head == null) {
                return;
            }

            result.Add(head.Val);

            Solution(head.Sublist, result);

            Solution(head.Next, result);
        }
    }
}
