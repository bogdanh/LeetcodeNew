using System;
using System.Collections.Generic;
using System.Text;

namespace Q1249_Minimum_Remove_To_Make_Valid_Parentheses {
    public class Q1249_Minimum_Remove_To_Make_Valid_Parentheses {

        private static string Solution(string s) {
            Stack<int> stack = new Stack<int>();
            HashSet<int> indexesToRemove = new HashSet<int>();

            for (int i = 0; i < s.Length; i++) {
                if (s[i] == '(') {
                    stack.Push(i);
                } else if (s[i] == ')') {
                    if (stack.Count == 0) {
                        indexesToRemove.Add(i);
                    } else {
                        stack.Pop();
                    }
                }
            }

            while (stack.Count > 0) {
                indexesToRemove.Add(stack.Pop());
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < s.Length; i++) {
                if (!indexesToRemove.Contains(i)) {
                    result.Append(s[i]);
                }
            }
            return result.ToString();
        }

        public static void Run() {
            string s = "))((";
            string result = Solution(s);
            Console.WriteLine($"Input: {s}");
            Console.WriteLine($"Output: {result}");
        }
    }
}
