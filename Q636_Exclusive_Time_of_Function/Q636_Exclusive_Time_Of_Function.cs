using Library;

namespace Q636_Exclusive_Time_of_Function {

    public class Q636_Exclusive_Time_of_Function {
        private static int[] Solution(int n, IList<string> logs) {
            int[] result = new int[n];

            Stack<Log> stack = new Stack<Log>();

            foreach (string logEntry in logs) {
                Log log = new Log(logEntry);
                
                if (log.IsStart) {
                    stack.Push(log);
                } else {
                    Log top = stack.Pop();

                    result[log.Id] += log.Time - top.Time + 1;
                    
                    if (stack.Count > 0) {
                        result[stack.Peek().Id] -= log.Time - top.Time + 1;
                    }
                }
            }

            return result;
        }
        
        public class Log {
            public int Id { get; set; }
            public bool IsStart { get; set; }
            public int Time { get; set; }
            
            public Log(string log) {
                string[] parts = log.Split(':');
                Id = int.Parse(parts[0]);
                IsStart = parts[1].Equals("start");
                Time = int.Parse(parts[2]);
            }
        }
        
        public static void Run() {
            IList<string> logs = new List<string> {
                "0:start:0",
                "1:start:2",
                "1:end:5",
                "0:end:6"
            };
            int n = 2;

            int[] result = Solution(n, logs);
            AssortedMethods.PrintIntArray(result);
        }
    }
}
