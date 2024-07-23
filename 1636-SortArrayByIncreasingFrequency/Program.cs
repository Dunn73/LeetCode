Solution solution = new();
int[] nums = [1,1,2,2,2,3];
var output = solution.FrequencySort(nums);

Console.WriteLine("[");
foreach (var item in output) {
    Console.Write($"{item}, ");
}
Console.WriteLine("]");
Console.ReadKey();
public class Solution {
    public int[] FrequencySort(int[] nums) {
        // Step 1: Count the frequencies of each number
        Dictionary<int, int> data = new();
        
        foreach (var item in nums) {
            if (data.ContainsKey(item)) {
                data[item]++;
            } else {
                data.Add(item, 1);
            }
        }

        // Step 2: Sort the dictionary by value (frequency) ascending, and by key descending
        var sortedData = data.OrderBy(pair => pair.Value)
                             .ThenByDescending(pair => pair.Key);

        // Step 3: Construct the result array
        List<int> result = new List<int>();
        
        foreach (var pair in sortedData) {
            for (int i = 0; i < pair.Value; i++) {
                result.Add(pair.Key);
            }
        }

        return result.ToArray();
    }
}