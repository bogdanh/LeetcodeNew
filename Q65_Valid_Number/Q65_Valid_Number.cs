namespace Q65_Valid_Number {

    public class Q65_Valid_Number {
        public static void Run() {
            string number = "-123.456E+789";
            Console.WriteLine($"{number}: {Solution(number)}");
            Console.WriteLine($"{number}: {SolutionDFS(number)}");
        }

        private static bool Solution(string number) {
            bool seenDigit = false;
            bool seenExponent = false;
            bool seenDot = false;

            for (int i = 0; i < number.Length; i++) {
                char c = number[i];

                if (Char.IsDigit(c)) {
                    seenDigit = true;
                } else if (c == '+' || c == '-') {
                    if (i > 0 && number[i - 1] != 'e' && number[i - 1] != 'E') {
                        return false;
                    }
                } else if (c == '.') {
                    if (seenDot || seenExponent) {
                        return false;
                    }

                    seenDot = true;
                } else if (c == 'e' || c == 'E') {
                    if (!seenDigit || seenExponent) {
                        return false;
                    }
                    seenExponent = true;
                    seenDigit = false;
                } else {
                    return false;
                }
            }

            return seenDigit;
        }

        // Deterministic Finite Automaton
        private static bool SolutionDFS(string number) {
            HashSet<int> validFinalStates = new HashSet<int> { 1, 4, 7 };
            int currentState = 0;
            List<Dictionary<string, int>> states = new List<Dictionary<string, int>> {
                new Dictionary<string, int> { // 0
                    { "digit", 1 },
                    { "sign", 2 },
                    { "dot", 3 }
                },
                new Dictionary<string, int> { // 1
                    { "digit", 1 },
                    { "dot", 4 },
                    { "expo", 5 }
                },
                new Dictionary<string, int> { // 2
                    { "digit", 1 },
                    { "dot", 3 }
                },
                new Dictionary<string, int> { // 3
                    { "digit", 4 }
                },
                new Dictionary<string, int> { // 4
                    { "digit", 4 },
                    { "expo", 5 }
                },
                new Dictionary<string, int> { // 5
                    { "sign", 6 },
                    { "digit", 7 }
                },
                new Dictionary<string, int> { // 6
                    { "digit", 7 }
                },
                new Dictionary<string, int> { // 7
                    { "digit", 7 }
                }
            };

            string group = string.Empty;

            foreach (char c in number) {
                if (c == '-' || c == '+') {
                    group = "sign";
                } else if (c == 'e' || c == 'E') {
                    group = "expo";
                } else if (Char.IsDigit(c)) {
                    group = "digit";
                } else if (c == '.') {
                    group = "dot";
                }
                
                if (!states[currentState].ContainsKey(group)) {
                    return false;
                }

                currentState = states[currentState][group];
            }

            return validFinalStates.Contains(currentState);
        }
    }
}
