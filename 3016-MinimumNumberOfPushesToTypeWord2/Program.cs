Solution solution = new();
string word = "abcde";


Console.WriteLine(solution.MinimumPushes(word));

Console.ReadKey();

public class Solution {
    public int MinimumPushes(string word) {
        int output = 0;
        Dictionary<char, int> letters = new();
        foreach (var letter in word) {
            if (letters.ContainsKey(letter)) {
                letters[letter] ++;
            }
            else {
                letters.Add(letter, 1);
            }
        }

        var sortedLetters = letters.OrderByDescending(kv => kv.Value).ToList();

        //1-8 is 1 key press, 9-16 is 2 key press, 17-24 is 3 key press, 25-26 is 4 key press

        for (int i = 1; i < sortedLetters.Count+1; i++) {
            if (i < 9) {
                output += sortedLetters[i-1].Value;
            }
            else if (i < 17) {
                output += sortedLetters[i-1].Value * 2;
            }
            else if (i < 25) {
                output += sortedLetters[i-1].Value * 3;
            }
            else {
                output += sortedLetters[i-1].Value * 4;
            }
        }

        return output;
    }
}