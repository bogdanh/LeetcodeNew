#nullable disable warnings
using System.Diagnostics;

namespace Q189_Rotate_Array {
    public class Q189_Rotate_Array {
        public static void Run() {
            var tests = new List<Test> {
                new Test {
                    Array = new int[] { 1, 2, 3, 4, 5 },
                    Expected = new int[] { 5, 1, 2, 3, 4 },
                    K = 1,
                    Id = 1
                },
                new Test {
                    Array = new int[] { 1, 2, 3, 4, 5 },
                    Expected = new int[] { 1, 2, 3, 4, 5 },
                    K = 0,
                    Id = 2
                },
                new Test {
                    Array = new int[] { 1, 2, 3, 4, 5 },
                    Expected = new int[] { 3, 4, 5, 1, 2 },
                    K = 3,
                    Id = 3
                },
                new Test {
                    Array = new int[] { 1, 2, 3, 4, 5 },
                    Expected = new int[] { 1, 2, 3, 4, 5 },
                    K = 5,
                    Id = 4
                },
                new Test {
                    Array = new int[] { 1, 2, 3, 4, 5 },
                    Expected = new int[] { 5, 1, 2, 3, 4 },
                    K = 6,
                    Id = 5
                }
            };
            
            foreach (var test in tests) {
                Rotate(test.Array, test.K);
                test.Verify();
            }
        }
        
        private static void Rotate(int[] a, int k) {
            k %= a.Length;
            Rotate(a, 0, a.Length - 1);
            Rotate(a, 0, k - 1);
            Rotate(a, k, a.Length - 1);
        }
        
        private static void Rotate(int[] a, int l, int r) {
            while (l < r) {
                Swap(a, l, r);
                l++;
                r--;
            }
        }
        
        private static void Swap(int[] a, int l, int r) {
            var tmp = a[l];
            a[l] = a[r];
            a[r] = tmp;
        }
    }
    
    internal class Test {
        public int[] Array { get; set; }
        public int K { get; set; }
        public int[] Expected { get; set; }
        public int Id { get; set; }
        
        public void Verify() {
            Debug.Assert(Array.SequenceEqual(Expected), $"Test {Id} failed");
        }
    }
}
