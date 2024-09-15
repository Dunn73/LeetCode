Solution solution = new();
string allowed = "ab";
string[] words = ["ad","bd","aaab","baa","badab"];

Console.WriteLine(solution.CountConsistentStrings(allowed, words));

Console.ReadKey();
public class Solution {
    public int CountConsistentStrings(string allowed, string[] words) {
        int count = words.Length;
        Dictionary<char, int> allowedIndex = new();
        foreach (var character in allowed) {
        allowedIndex.Add(character, 0);
        }

        foreach (var word in words) {
            foreach (var letter in word) {
                if (!allowedIndex.ContainsKey(letter)) {
                    count --;
                    break;
                }
            }
            
        }

       return count;
    }
}