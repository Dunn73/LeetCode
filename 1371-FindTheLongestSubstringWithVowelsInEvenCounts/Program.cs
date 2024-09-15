Solution solution = new();

string s = "eleetminicoworoep";

Console.WriteLine(solution.FindTheLongestSubstring(s));

Console.ReadKey();
public class Solution {
    public int FindTheLongestSubstring(string s) {
        
        // Dictionary to hold whether the vowels are even or odd
        Dictionary<char, bool> vowels = new() {
            {'a', true},
            {'e', true},
            {'i', true},
            {'o', true},
            {'u', true}
        };

        int count = 0;

        for (int j = 0; j < s.Length; j++) {

            if (count > s.Length-j) {
                return count;
            }

            for (int i = j; i < s.Length; i++) {
                if (vowels.ContainsKey(s[i])) {
                    vowels[s[i]] = !vowels[s[i]];
                }

                bool isValid = vowels.All(kvp => kvp.Value == true);

                if (isValid) {
                    if (i-j+1 > count) {
                        count = i-j+1;
                    }
                }
            }
            
            foreach (var key in vowels.Keys.ToList()) {
                vowels[key] = true;
            }
        }

        return count;
    }
}

