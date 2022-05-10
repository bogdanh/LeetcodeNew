namespace Q10_Regular_Expression_Matching {

    public class Q10_Regular_Expression_Matching {
        private static int count { get; set; }
        public static void Run() {

            string text = "aa";
            string pattern = "a*";
            Console.WriteLine($"text: {text}");
            Console.WriteLine($"pattern: {pattern}");
            count = 0;
            
            bool result = Solution(text, pattern);
            Console.WriteLine(result);
            Console.WriteLine(count);

            Console.WriteLine();
            count = 0;
            Dictionary<string, bool> memo = new Dictionary<string, bool>();
            result = SolutionMemoization(text, pattern, memo);
            Console.WriteLine(result);
            Console.WriteLine(count);
        }

        private static bool SolutionMemoization(string text, string pattern, Dictionary<string, bool> memo) {
            count++;
            if (pattern.Length == 0) {
                return text.Length == 0;
            }

            string key = $"{text}|{pattern}";
            if (memo.ContainsKey(key)) {
                return memo[key];
            }

            bool firstMatch = (!string.IsNullOrEmpty(text) && (text[0] == pattern[0] || pattern[0] == '.'));

            if (pattern.Length >= 2 && pattern[1] == '*') {
                bool value = Solution(text, pattern.Substring(2)) || (firstMatch && Solution(text.Substring(1), pattern));
                memo[key] = value;
                return value;
            } else {
                bool value = firstMatch && Solution(text.Substring(1), pattern.Substring(1));
                memo[key] = value;
                return value;
            }
        }

        private static bool Solution(string text, string pattern) {
            count++;
            if (pattern.Length == 0) {
                return text.Length == 0;
            }

            bool firstMatch = (!string.IsNullOrEmpty(text) && (text[0] == pattern[0] || pattern[0] == '.'));
            
            if (pattern.Length >= 2 && pattern[1] == '*') {
                return (Solution(text, pattern.Substring(2)) || 
                    (firstMatch && Solution(text.Substring(1), pattern))
                );
            } else {
                return firstMatch && Solution(text.Substring(1), pattern.Substring(1));
            }
        }
    }
}
