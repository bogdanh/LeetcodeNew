using System;
using System.Collections.Generic;
using System.Text;

namespace Q316_Remove_Duplicate_Letters {
    public class Q316_Remove_Duplocate_Letters {

        private static string Solution(string s) {
            Stack<char> stack = new Stack<char>();
            HashSet<char> seen = new HashSet<char>();
            Dictionary<char, int> lastOccurence = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++) {
                lastOccurence[s[i]] = i;
            }

            for (int i = 0; i < s.Length; i++) {
                char c = s[i];

                if (!seen.Contains(c)) {
                    while (stack.Count > 0 && c < stack.Peek() && lastOccurence[stack.Peek()] > i) {
                        seen.Remove(stack.Pop());
                    }
                }

                seen.Add(c);
                stack.Push(c);
            }

            char[] resultArray = new char[stack.Count];
            int idx = 0;

            while (stack.Count > 0) {
                resultArray[idx++] = stack.Pop();
            }

            Reverse(resultArray);

            return new string(resultArray);
        }

        private static void Reverse(char[] arr) {
            int i = 0;
            int j = arr.Length - 1;

            while (i < j) {
                char tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
                i++;
                j--;
            }
        }

        public static void Run() {
            string s = "bcabc";
            Console.WriteLine(s);
            string result = Solution(s);
            Console.WriteLine(result);
        }
    }
}
