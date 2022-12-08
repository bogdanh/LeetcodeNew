using System.Text;

namespace Formation {

    public class TextJustification {
        public static void Run() {
            var words = new[] {
                "this",
                "is",
                "an",
                "example",
                "of",
                "text",
                "justification"
            };
            var width = 16;
            
            var lines = Solution(words, width);
            
            foreach (var line in lines) {
                Console.WriteLine($"{line}|");
            }
        }

        private static List<string> Solution(string[] words, int width)
        {
            var lines = new List<string>();
            var index = 0;

            while (index < words.Length) {
                var count = words[index].Length;
                var last = index + 1;
                
                // count the length of all words at this line
                while (last < words.Length) {
                    // if current count + the next word's length + 1 is greater than the limit then don't
                    // in consideration the next 
                    if (words[last].Length + 1 + count > width) {
                        break;
                    }

                    count += words[last].Length + 1;
                    last++;
                }

                var sb = new StringBuilder();
                sb.Append(words[index]);

                var diff = last - index - 1; // number of spaces
                
                // if last line or one single word per line then left justification
                if (last == words.Length || diff == 0) {
                    for (int i = index + 1; i < last; i++) {
                        sb.Append(" ");
                        sb.Append(words[i]);
                    }

                    for (int i = sb.Length; i < width; i++) {
                        sb.Append(" ");
                    }
                } else {
                    var spaces = (width - count) / diff;
                    var remaining = (width - count) % diff;

                    for (int i = index + 1; i < last; i++) {
                        var spacesToAdd = spaces;
                        while (spacesToAdd > 0) {
                            sb.Append(" ");
                            spacesToAdd--;
                        }
                        
                        if (remaining > 0) {
                            sb.Append(" ");
                            remaining--;
                        }

                        sb.Append(" ");
                        sb.Append(words[i]);
                    }
                }
                lines.Add(sb.ToString());
                index = last;
            }

            return lines;
        }
    }
}
