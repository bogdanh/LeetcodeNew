#nullable disable warnings
using System.Diagnostics;
using Library;

namespace Formation {

    public class ReverseKGroup {
        public static void Run() {
            var test = new Test {
                Id = 1,
                K = 2,
                List = new SingleLinkedListNode(1,
                    new SingleLinkedListNode(2,
                    new SingleLinkedListNode(3,
                    new SingleLinkedListNode(4,
                    new SingleLinkedListNode(5, null))))),
                Expected = new SingleLinkedListNode(2,
                        new SingleLinkedListNode(1,
                        new SingleLinkedListNode(4, 
                        new SingleLinkedListNode(3,
                        new SingleLinkedListNode(5, null)))))
            };

            test.List.Print();
            var result = Reverse(test.List, test.K);
            result.Print();
            test.Verify(result);
        }
        
        private static SingleLinkedListNode ReverseKGroups(SingleLinkedListNode head, int k) {
            var curr = head;
            var count = 0;
            
            while (curr != null && count < k) {
                count++;
                curr = curr.Next;
            }

            if (count == k) {
                var reversedHead = ReverseLinkedList(head, k);
                head.Next = ReverseKGroups(curr, k);
                return reversedHead;
            }

            return head;
        }
        
        private static SingleLinkedListNode Reverse(SingleLinkedListNode head, int k) {
            SingleLinkedListNode newHead = null;
            SingleLinkedListNode tail = null;
            var ptr = head;
            
            while (ptr != null) {
                var count = 0;
                ptr = head;
                
                while (count < k && ptr != null) {
                    ptr = ptr.Next;
                    count++;
                }
                
                if (count == k) {
                    var revHead = ReverseLinkedList(head, k);

                    if (newHead == null) {
                        newHead = revHead;
                    }
                    
                    if (tail != null) {
                        tail.Next = revHead;
                    }

                    tail = head;
                    head = ptr;
                }
            }
            
            if (tail != null) {
                tail.Next = head;
            }

            return newHead ?? head;
        }
        
        private static SingleLinkedListNode ReverseLinkedList(SingleLinkedListNode head, int k) {
            SingleLinkedListNode newHead = null;
            var curr = head;

            while (k > 0) {
                var nextNode = curr.Next;
                curr.Next = newHead;
                newHead = curr;
                curr = nextNode;
                k--;
            }
            
            return newHead;
        }
    }
    
    internal class Test {
        public int Id { get; set; }
        public int K { get; set; }
        public SingleLinkedListNode List { get; set; }
        public SingleLinkedListNode Expected { get; set; }
        
        public void Verify(SingleLinkedListNode result) {
            Debug.Assert(CheckList(result), $"Test {Id} failed.");
        }
        
        private bool CheckList(SingleLinkedListNode result) {
            while (Expected != null && result != null && Expected.Val == result.Val) {
                Expected = Expected.Next;
                result = result.Next;
            }

            return Expected == null && result == null;
        }
    }
}
