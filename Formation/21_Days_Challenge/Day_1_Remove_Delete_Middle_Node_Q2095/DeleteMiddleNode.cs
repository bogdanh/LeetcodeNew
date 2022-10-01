#nullable disable warnings
using System.Diagnostics;
using Library;

namespace Formation {

    public class DeleteMiddleNode {
        
        public static void Run() {
            var tests = new Test[] {
                new Test {
                    Id = 1,
                    Input = new SingleLinkedListNode(1,
                            new SingleLinkedListNode(2,
                            new SingleLinkedListNode(3,
                            null))),
                    Expected = new SingleLinkedListNode(1,
                            new SingleLinkedListNode(3, null))
                },
                new Test {
                    Id = 2,
                    Input = new SingleLinkedListNode(1,
                            new SingleLinkedListNode(2,
                            new SingleLinkedListNode(3,
                            new SingleLinkedListNode(4, null)))),
                    Expected = new SingleLinkedListNode(1,
                            new SingleLinkedListNode(2,
                            new SingleLinkedListNode(4, null)))
                }
            };
            
            foreach (var test in tests) {
                var result = Solution(test.Input);
                test.Verify(result);
            }
        }
        
        private static SingleLinkedListNode Solution(SingleLinkedListNode list) {
            if (list == null) {
                return list;
            }

            var result = new SingleLinkedListNode(int.MinValue, list);
            var slow = list;
            var fast = list?.Next;

            while (fast != null) {
                slow = slow.Next;
                fast = fast.Next?.Next;
            }

            slow.Next = slow.Next?.Next;

            return result.Next;
        }
    }

    internal class Test {
        public int Id { get; set; }
        public SingleLinkedListNode Input { get; set; }
        public SingleLinkedListNode Expected { get; set; }

        public void Verify(SingleLinkedListNode result) {
            Debug.Assert(CheckList(result), $"Test {Id} failed.");
        }

        private bool CheckList(SingleLinkedListNode result) {
            while (result != null && Expected != null && result.Val == Expected.Val) {
                result = result.Next;
                Expected = Expected.Next;
            }

            return result != null || Expected != null;
        }
    }
}
