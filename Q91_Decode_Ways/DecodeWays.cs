namespace Q91_Decode_Ways {

    public class DecodeWays {
        public static void Run() {
            var str = "10"; //"2326";
            Console.WriteLine($"String: {str}");
            var result = Solution(str);
            Console.WriteLine($"Number of ways: {result}");
        }

        private static int Solution(string str) {
            if (string.IsNullOrWhiteSpace(str)) {
                return 0;
            }

            var dp = new int[str.Length];
            dp[0] = str[0] == '0' ? 0 : 1;

            for (var i = 1; i < str.Length; i++) {
                var curr = str[i];
                var prev = str[i - 1];
                
                if (curr >= '1' && curr <= '9') {
                    dp[i] = dp[i - 1];
                }
                
                if (prev == '1' ||
                   (prev == '2' && curr >= '0' && curr <= '6')) {
                    if (i >= 2) {
                        dp[i] += dp[i - 2];
                    } else {
                        dp[i] += 1;
                    }
                }
            }

            return dp[str.Length - 1];
        }
    }
}
