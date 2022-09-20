#nullable disable warnings
using System.Diagnostics;

namespace Q20_Valid_Parentheses {

    public class Q20_Valid_Parentheses {
        public static void Run() {
            var tests = new List<Test> {
                new Test {
                    Id = 1,
                    Text = "[()()]",
                    Expected = true
                },
                new Test {
                    Id = 2,
                    Text = "[(]()]",
                    Expected = false,
                },
                new Test {
                    Id = 3,
                    Text = "[{()}]",
                    Expected = true
                },
                new Test {
                    Id = 4,
                    Text = "((()))",
                    Expected = true
                },
                new Test {
                    Id = 5,
                    Text = "[(])",
                    Expected = false
                },
                new Test {
                    Id = 6,
                    Text = "((()))",
                    Expected = true
                },
                new Test {
                    Id = 7,
                    Text = "()]]",
                    Expected = false
                },
                new Test {
                    Id = 8,
                    Text = "()[]{}()[]{}",
                    Expected = true
                }
            };
            
            foreach (var test in tests) {
                var result = Solution(test.Text);
                test.Verify(result);
            }
        }
        
        private static bool Solution(string text) {
            var parenthesesMap = new Dictionary<char, char> {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };
            var stack = new Stack<char>();
            var openParentheses = new HashSet<char> { '(', '[', '{' };
            
            foreach (var c in text) {
                if (openParentheses.Contains(c)) {
                    stack.Push(c);
                } else {
                    if (stack.Count == 0 || !stack.Pop().Equals(parenthesesMap[c])) {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
    }
    
    internal class Test {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Expected { get; set; }
        
        public void Verify(bool result) {
            Debug.Assert(result == Expected, $"Test {Id} failed.");
        }
    }
}
