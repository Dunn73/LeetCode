Solution solution = new();
int[] nums = [1,2,3,4];
int n = 4;
int left = 1;
int right = 5;

Console.WriteLine(solution.RangeSum(nums, n, left, right));


Console.ReadKey();
public class Solution {
    public int RangeSum(int[] nums, int n, int left, int right) {
        const int MOD = 1000000007;
        List<int> subarraySums = new List<int>();

        // Generate all subarray sums
        for (int i = 0; i < n; i++) {
            int currentSum = 0;
            for (int j = i; j < n; j++) {
                currentSum += nums[j];
                subarraySums.Add(currentSum);
            }
        }

        // Sort the list of subarray sums
        subarraySums.Sort();

        // Calculate the sum of the elements from index left to right
        long sum = 0;
        for (int k = left - 1; k < right; k++) {
            sum = (sum + subarraySums[k]) % MOD;
        }

        return (int)sum;
    }
}