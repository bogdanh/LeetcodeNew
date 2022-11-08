
#nullable disable warnings
namespace Formation {

    public class KClosestPoints {
        public static void Run() {
            var points = new Point[] {
                new Point {
                    X = 2,
                    Y = 0
                },
                new Point {
                    X = 0,
                    Y = 2
                },
                new Point {
                    X = 3,
                    Y = 3
                },
                new Point {
                    X = 4,
                    Y = 2
                },
                new Point {
                    X = 2,
                    Y = 5
                }
            };
            var K = 3;

            var result = Solution(points, K);
            
            if (result == null) {
                return;
            }
            
            foreach (var point in result) {
                Console.WriteLine($"({point.X}, {point.Y})");
            }
        }
        
        private static Point[] Solution(Point[] points, int K) {
            if (points.Length < K) {
                return null;
            }
            
            var pq = new PriorityQueue<Point, double>(Comparer<double>.Create((x, y) => y.CompareTo(x)));
            
            foreach (var point in points) {
                pq.Enqueue(point, point.Dist);
                
                while (pq.Count > K) {
                    pq.Dequeue();
                }
            }

            return pq.UnorderedItems.Select(item => item.Element).ToArray();
        }

        private class Point {
            public int X { get; set; }
            public int Y { get; set; }

            public double Dist {
                get {
                    return Math.Sqrt(this.X * this.X + this.Y * this.Y);
                }
            }
        }
    }
}
