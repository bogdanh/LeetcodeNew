#nullable disable warnings

using System.Diagnostics;

namespace Formation {

    public class PalindromeAnagram {
        public static void Run() {
            var tests = new Test[] {
                new Test {
                    Id = 1,
                    Input = "aabbccc",
                    Expected = true
                },
                new Test {
                    Id = 2,
                    Input = "aabc",
                    Expected = false
                },
                new Test {
                    Id = 3,
                    Input = "aabbcc",
                    Expected = true
                }
            };

            Console.WriteLine();
            Console.WriteLine($"= {nameof(PalindromeAnagram)} =");

            foreach (var test in tests) {
                var result = Solution(test.Input);
                test.Verify(result);
            }
            
            Console.WriteLine();
        }
        
        private static bool Solution(string text) {
            var charMap = new Dictionary<char, int>();
            
            foreach (var c in text) {
                charMap[c] = charMap.GetValueOrDefault(c, 0) + 1;
            }

            var numOfOdd = 0;
            
            foreach (var kvp in charMap) {
                if ((kvp.Value & 1) != 0) {
                    numOfOdd++;
                    if (numOfOdd > 1) {
                        return false;
                    }
                }
            }

            return true;
        }
    }
    
    internal class Test {
        public int Id { get; set; }
        public string Input { get; set; }
        public bool Expected { get; set; }
        
        public void Verify(bool result) {
            var passed = result == Expected;
            Console.ForegroundColor = passed ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine($"Test {Id} {(result == Expected ? "passed" : "failed")}.");
        }
    }
}
