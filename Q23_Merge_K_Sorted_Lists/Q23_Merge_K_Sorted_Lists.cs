#nullable disable warnings
namespace Q23_Merge_K_Sorted_Lists {

    public class Q23_Merge_K_Sorted_Lists {

        private static SingleLinkedListNode Solution(SingleLinkedListNode[] lists) {
            SingleLinkedListNode result = new SingleLinkedListNode();
            
            if (lists.Length == 0) {
                return result;
            }

            SingleLinkedListNode tmp = result;

            PriorityQueue<SingleLinkedListNode, int> pq = new PriorityQueue<SingleLinkedListNode, int>();
            
            foreach (SingleLinkedListNode list in lists) {
                pq.Enqueue(list, list.Val);
            }
            
            while (pq.Count > 0) {
                SingleLinkedListNode node = pq.Dequeue();
                tmp.Next = node;
                node = node.Next;
                tmp = tmp.Next;

                if (node != null) {
                    pq.Enqueue(node, node.Val);
                }
            }

            return result.Next;
        }
        
        public static void Run() {
            SingleLinkedListNode list1 = new SingleLinkedListNode(1,
                new SingleLinkedListNode(3,
                new SingleLinkedListNode(5,
                new SingleLinkedListNode(7, null)))
            );

            SingleLinkedListNode list2 = new SingleLinkedListNode(2,
                new SingleLinkedListNode(4,
                new SingleLinkedListNode(6, 
                new SingleLinkedListNode(8, null)))
            );

            SingleLinkedListNode list3 = new SingleLinkedListNode(2,
                new SingleLinkedListNode(3, null)
            );

            SingleLinkedListNode[] lists = new SingleLinkedListNode[] { list1, list2, list3 };
            foreach (SingleLinkedListNode list in lists) {
                list.Print();
            }

            SingleLinkedListNode result = Solution(lists);
            result.Print();
        }
    }
}
