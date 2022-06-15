using Library;

namespace Q253_Meeting_Room_II {

    public class Q253_Meeting_Room_II {

        // PriorityQueue (Min Heap)
        private static int Solution(int[][] meetings) {
            Array.Sort(meetings, (int[] a, int[] b) => {
                return a[0].CompareTo(b[0]);
            });

            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            pq.Enqueue(meetings[0][1], meetings[0][1]);

            for (int i = 1; i < meetings.Length; i++) {
                if (meetings[i][0] >= pq.Peek()) {
                    pq.Dequeue();
                }

                pq.Enqueue(meetings[i][1], meetings[i][1]);
            }

            return pq.Count;
        }
        
        // Two pointers (sort start and end)
        private static int Solution1(int[][] meetings) {
            int[] start = new int[meetings.Length];
            int[] end = new int[meetings.Length];
            int rooms = 0;
            int index = 0;
            
            foreach (int[] meeting in meetings) {
                start[index] = meeting[0];
                end[index] = meeting[1];
                index++;
            }

            Array.Sort(start);
            Array.Sort(end);

            int startIndex = 0;
            int endIndex = 0;
            
            while (startIndex < meetings.Length) {
                if (start[startIndex] < end[endIndex]) {
                    rooms++;
                } else {
                    endIndex++;
                }

                startIndex++;
            }

            return rooms;
        }

        public static void Run() {
            int[][] meetings = new int[6][];
            meetings[0] = new int[] { 11, 30 };
            meetings[1] = new int[] { 10, 20 };
            meetings[2] = new int[] { 8, 12 };
            meetings[3] = new int[] { 3, 19 };
            meetings[4] = new int[] { 2, 7 };
            meetings[5] = new int[] { 1, 10 };
            AssortedMethods.PrintInt2DArray(meetings);

            int result = Solution(meetings);
            Console.WriteLine(result);

            result = Solution1(meetings);
            Console.WriteLine(result);
        }
    }
}
