#nullable disable warnings
// Complete the body of the function shown below
// The input of the function accepts one argument
//   a: Array of type integer of size between 2 and 2^31
//      the array contains a sequence starting from 0 and the following progression
//      [0,2,4,6,8,10 ... ]
// The array contains one missing number for example: [0,2,4,6,10,12] is missing 8
// Write a function that returns the missing number.
// 
// Examples:
// a = [0,2,4,8,10], result = 6
// a = [0,2,4,6,10], result = 8
// a = [2,4,6], result = 0

using System.Diagnostics;

namespace Q_Missing_Plus_Two {

    public class Q_Missing_Plus_Two {
        public static void Run() {
            var tests = new List<Test> {
                new Test {
                    Id = 1,
                    Array = new int[] { 0, 2, 4, 8, 10 },
                    Expected = 6
                },
                new Test {
                    Id = 2,
                    Array = new int[] { 0, 2, 4, 6, 10 },
                    Expected = 8
                },
                new Test {
                    Id = 3,
                    Array = new int[] { 2, 4, 6 },
                    Expected = 0
                }
            };
            
            foreach (var test in tests) {
                var num = Solution(test.Array);
                test.Verify(num);
            }
        }
        
        private static int Solution(int[] a) {
            int result = 0;
            
            foreach (var num in a) {
                if (num != result) {
                    break;
                }

                result += 2;
            }
            
            return result;
        }
    }
    
    internal class Test {
        public int[] Array { get; set; }
        public int Expected { get; set; }
        public int Id { get; set; }
        
        public void Verify(int num) {
            Debug.Assert(num == Expected, $"Test {Id} failed. {num} != {Expected}");
        }
    }
}
