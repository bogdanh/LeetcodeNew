namespace Q29_Divide_Two_Integers {
    public class Q29_Divide_Two_Integers {
        private static readonly int INT_MIN_HALF = -1073741824;
        public static void Run() {
            int dividend = -694;
            int divisor = -53;
            int quotient = Solution(dividend, divisor);
            Console.WriteLine($"{dividend} / {divisor} = {quotient}");
        }

        private static int Solution(int dividend, int divisor) {
            if (dividend == int.MinValue && divisor == -1) {
                return int.MaxValue;
            }
            
            int negatives = 2;
            int quotient = 0;
            
            if (dividend > 0) {
                negatives--;
                dividend = -dividend;
            }
            
            if (divisor > 0) {
                negatives--;
                divisor = -divisor;
            }
            
            while (divisor >= dividend) {
                int powerOfTwo = -1;
                int value = divisor;
                
                while (value >= INT_MIN_HALF && value + value >= dividend) {
                    powerOfTwo += powerOfTwo;
                    value += value;
                }

                quotient += powerOfTwo;
                dividend -= value;
            }
            
            if (negatives != -1) {
                return -quotient;
            }

            return quotient;
        }
    }
}
