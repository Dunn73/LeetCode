Solution solution = new();

string s1 = "this apple is sweet";
string s2 = "this apple is sour";

string[] output = solution.UncommonFromSentences(s1, s2);

foreach (var item in output) {
    Console.WriteLine(item);
}


Console.ReadKey();
public class Solution {
    public string[] UncommonFromSentences(string s1, string s2) {
        Dictionary<string, int> words = new();

        string currentWord = "";

        for (int i = 0; i < s1.Length; i++) {
            if (char.IsWhiteSpace(s1[i])) {
                if (!words.ContainsKey(currentWord)) {
                    words.Add(currentWord, 1);
                    currentWord = "";
                }
                else {
                    words[currentWord] ++;
                    currentWord = "";
                }
                
            }
            else if (i == s1.Length-1){
                currentWord += s1[i];
                if (!words.ContainsKey(currentWord)) {
                    words.Add(currentWord, 1);
                    currentWord = "";
                }
                else {
                    words[currentWord] ++;
                    currentWord = "";
                }
            }
            else {
                currentWord += s1[i];
            }
        }

        for (int i = 0; i < s2.Length; i++) {
            if (char.IsWhiteSpace(s2[i])) {
                if (!words.ContainsKey(currentWord)) {
                    words.Add(currentWord, 1);
                    currentWord = "";
                }
                else {
                    words[currentWord] ++;
                    currentWord ="";
                }
                
            }
            else if (i == s2.Length-1){
                currentWord += s2[i];
                if (!words.ContainsKey(currentWord)) {
                    words.Add(currentWord, 1);
                    currentWord = "";
                }
                else {
                    words[currentWord] ++;
                    currentWord = "";
                }
            }
            else {
                currentWord += s2[i];
            }
        }

        string[] output = words
                            .Where(kvp => kvp.Value == 1)
                            .Select(kvp => kvp.Key)
                            .ToArray();


        return output;



    }
}