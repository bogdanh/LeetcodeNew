using System;

namespace Q383_Ransom_Note {
    public class Ransom_Note {
        private static bool Solution(string ransomNote, string magazine) {
            if (ransomNote.Length > magazine.Length) {
                return false;
            }

            char[] alphabet = new char[256];

            foreach (char c in magazine) {
                alphabet[c]++;
            }

            foreach (char c in ransomNote) {
                alphabet[c]--;

                if (alphabet[c] < 0) {
                    return false;
                }
            }

            return true;
        }

        public static void Run() {
            string ransomNote = "a";
            string magazine = "b";

            Console.WriteLine(ransomNote);
            Console.WriteLine(magazine);

            Console.WriteLine(Solution(ransomNote, magazine));
        }
    }
}
