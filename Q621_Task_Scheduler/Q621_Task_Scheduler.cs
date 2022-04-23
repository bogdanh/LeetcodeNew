using System;
using System.Collections.Generic;
using System.Text;
using Library;

namespace Q621_Task_Scheduler {
    public class Q621_Task_Scheduler {

        private static int Solution(char[] tasks, int n) {
            PriorityQueue<Task, int> pq = new PriorityQueue<Task, int>(new TaskComparer());
            Dictionary<char, int> freqMap = new Dictionary<char, int>();

            foreach (char c in tasks) {
                freqMap[c] = freqMap.GetValueOrDefault(c, 0) + 1;
            }

            foreach (KeyValuePair<char, int> pair in freqMap) {
                pq.Enqueue(new Task { C = pair.Key, Freq = pair.Value }, pair.Value);
            }

            int count = 0;

            while (pq.Count > 0) {
                int k = n + 1;
                IList<Task> tmpList = new List<Task>();

                while (k > 0 && pq.Count > 0) {
                    Task task = pq.Dequeue();
                    task.Freq--;
                    tmpList.Add(task);
                    k--;
                    count++;
                }

                foreach (Task t in tmpList) {
                    if (t.Freq > 0) {
                        pq.Enqueue(t, t.Freq);
                    }
                }

                if (pq.Count == 0) {
                    break;
                }

                count += k;
            }

            return count;
        }

        public static void Run() {
            char[] tasks = new char[] { 'A', 'A', 'A', 'A', 'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
            AssortedMethods.PrintCharArray(tasks);
            int n = 2;
            Console.WriteLine($"n = {n}");
            int result = Solution(tasks, n);
            Console.WriteLine(result);
        }
    }

    public class Task {
        public char C { get; set; }
        public int Freq { get; set; }
    }

    public class TaskComparer : IComparer<int> {
        public int Compare(int x, int y) {
            return y.CompareTo(x);
        }
    }
}
