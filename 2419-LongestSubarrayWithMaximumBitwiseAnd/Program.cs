Solution solution = new();
int[] nums = [1,2,3,3,2,2];
Console.WriteLine(solution.LongestSubarray(nums));

Console.ReadKey();

public class Solution {
    public int LongestSubarray(int[] nums) {
        int max = 0;
        // Find the maximum value in the array
        foreach (int num in nums) {
            max = Math.Max(max, num);
        }

        int longest = 0, currentLength = 0;

        // Iterate over the array to find the length of the longest subarray with AND equal to max
        foreach (int num in nums) {
            if (num == max) {
                currentLength++;
                longest = Math.Max(longest, currentLength);
            } else {
                currentLength = 0;
            }
        }

        return longest;
    }
}