using Library;
namespace Formation {

    public class GeneratePassword {
        public static void Run() {
            var chars = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            var min = 3;
            var max = 5;
            var result = new List<string>();
            var stack = new Stack<char>();
            var freqMap = new Dictionary<char, int>();
            
            Solution(chars, min, max, result, stack, freqMap);

            AssortedMethods.PrintStringArray(result.ToArray());
        }
        
        private static void Solution(char[] chars, int min, int max, List<string> result, Stack<char> stack, Dictionary<char, int> freqMap) {
            if (stack.Count >= min && stack.Count <= max) {
                var password = string.Join("", stack.Reverse());
                result.Add(password);
            }
            
            if (stack.Count == max) {
                return;
            }
            
            foreach (char c in chars) {
                var count = freqMap.GetValueOrDefault(c, 0);
                
                if ((stack.Count == 0 || stack.Peek() != c) && count < 2) {
                    stack.Push(c);
                    freqMap[c] = count + 1;

                    Solution(chars, min, max, result, stack, freqMap);

                    stack.Pop();
                    freqMap[c]--;
                }
            }
        }
    }
}
