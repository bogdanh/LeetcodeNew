using System.Text;

namespace Q282_Expression_Add_Operators {

    public class Q282_Expression_Add_Operators {

        private static IList<string> Solution(string num, int target) {
            IList<string> result = new List<string>();
            Helper(result, num, target, 0, 0, 0, new StringBuilder());
            return result;
        }

        private static void Helper(
            IList<string> result,
            string num,
            int target,
            int pos,
            long currVal,
            long prevValue,
            StringBuilder expr) {

            if (pos == num.Length) {
                if (currVal == target) {
                    result.Add(expr.ToString());
                }

                return;
            }

            for (int i = pos; i < num.Length; i++) {
                string currNum = num.Substring(pos, i + 1 - pos);

                if (currNum.Length > 1 && currNum[0] == '0') {
                    break;
                }

                long currOp = long.Parse(currNum);
                int len = expr.Length;

                if (pos == 0) {
                    Helper(result, num, target, i + 1, currOp, currOp, expr.Append(currOp));
                    expr.Length = len;
                } else {
                    Helper(result, num, target, i + 1, currVal + currOp, currOp, expr.Append($"+{currOp}"));
                    expr.Length = len;

                    Helper(result, num, target, i + 1, currVal - currOp, -currOp, expr.Append($"-{currOp}"));
                    expr.Length = len;

                    Helper(result, num, target, i + 1, currVal - prevValue + prevValue * currOp, prevValue * currOp, expr.Append($"*{currOp}"));
                }
            }
        }

        public static void Run() {
            string num = "123";
            int target = 6;

            Console.WriteLine($"num: {num}");
            Console.WriteLine($"target: {target}");
            IList<string> result = Solution(num, target);
            PrintStringList(result);
        }

        private static void PrintStringList(IList<string> stringList) {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            foreach (string str in stringList) {
                sb.Append($"{str}, ");
            }

            sb.Length = sb.Length - 2;
            sb.Append("]");
            Console.WriteLine(sb.ToString());
        }
    }
}