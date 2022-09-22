#nullable disable warnings
using System.Diagnostics;

namespace Q242_Valid_Anagram {

    public class Q242_Valid_Anagram {
        public static void Run() {
            var tests = new List<Test> {
                new Test {
                    Id = 1,
                    S = "binary",
                    T = "brainy",
                    Expected = true
                },
                new Test {
                    Id = 2,
                    S = "rat",
                    T = "car",
                    Expected = false
                },
                new Test {
                    Id = 3,
                    S = "BAT",
                    T = "tab",
                    Expected = false
                },
                new Test {
                    Id = 4,
                    S = "rail safety",
                    T = "fairy tales",
                    Expected = true
                },
                new Test {
                    Id = 5,
                    S = "the eyes",
                    T = "they see",
                    Expected = true
                },
                new Test {
                    Id = 6,
                    S = "debit card",
                    T = "bad credit",
                    Expected = true
                },
                new Test {
                    Id = 7,
                    S = "action man",
                    T = "cannot aim",
                    Expected = true
                },
                new Test {
                    Id = 8,
                    S = "",
                    T = "",
                    Expected = true
                },
                new Test {
                    Id = 9,
                    S = "batt",
                    T = "tab",
                    Expected = false
                }
            };
            
            foreach (var test in tests) {
                var result = Solution(test.S, test.T);
                test.Verify(result);
            }
        }
        
        private static bool Solution(string s, string t) {
            if (s.Length != t.Length) {
                return false;
            }

            var freqMap = new Dictionary<int, int>();
            foreach (var c in s) {
                freqMap[c] = freqMap.GetValueOrDefault(c, 0) + 1;
            }
            
            foreach (var c in t) {
                freqMap[c] = freqMap.GetValueOrDefault(c, 0) - 1;
                
                if (freqMap[c] < 0) {
                    freqMap.Remove(c);
                }
            }

            return freqMap.Count == 0;
        }
    }
    
    internal class Test {
        public int Id { get; set; }
        public string S { get; set; }
        public string T { get; set; }
        public bool Expected { get; set; }
        
        public void Verify(bool result) {
            Debug.Assert(result == Expected, $"Test {1} failed.");
        }
    }
}
