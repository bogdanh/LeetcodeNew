#nullable disable warnings
using System.Diagnostics;

namespace Q387_First_Unique_Character_In_a_String {

    public class Q387_First_Unique_Character_In_a_String {
        public static void Run() {
            var tests = new List<Test> {
                new Test {
                    Str = "leetcode",
                    Expected = 0,
                    Id = 1
                },
                new Test {
                    Str = "loveleetcode",
                    Expected = 2,
                    Id = 2
                },
                new Test {
                    Str = "aabb",
                    Expected = -1,
                    Id = 3
                }
            };
            
            foreach (var test in tests) {
                int pos = Solution(test.Str);
                test.Verify(pos);
            }
        }
        
        private static int Solution(string str) {
            var freq = new int[256];
            var map = new Dictionary<int, int>();

            for (int i = 0; i < str.Length; i++) {
                freq[str[i] - 'a']++;
                map[str[i] - 'a'] = i;
            }

            var result = int.MaxValue;

            for (int i = 0; i < freq.Length; i++) {
                if (freq[i] == 1) {
                    result = Math.Min(result, map[i]);
                }
            }

            return result == int.MaxValue ? -1 : result;
        }
    }
    
    internal class Test {
        public string Str { get; set; }
        public int Expected { get; set; }
        public int Id { get; set; }
        
        public void Verify(int idx) {
            Debug.Assert(idx == Expected, $"Test {Id} failed. {idx} != {Expected}");
        }
    }
}
