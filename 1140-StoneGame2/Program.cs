Solution solution = new();

int[] piles = [2,7,9,4,4];
Console.WriteLine(solution.StoneGameII(piles));
Console.ReadKey();

public class Solution {
 
    public int StoneGameII(int[] piles) {
        int n = piles.Length;

        // Suffix sum array to quickly calculate the sum of the remaining piles
        int[] suffixSum = new int[n + 1];
        suffixSum[n] = 0;  // No stones left beyond the last pile
        for (int i = n - 1; i >= 0; i--) {
            suffixSum[i] = piles[i] + suffixSum[i + 1];
        }

        // Memoization dictionary
        var memo = new Dictionary<(int, int), int>();

        int Dfs(int i, int M) {
            if (i >= n) return 0; // No more piles left
            if (memo.ContainsKey((i, M))) return memo[(i, M)];

            int maxStones = 0;

            // Alice can take from 1 to 2 * M piles
            for (int x = 1; x <= 2 * M && i + x <= n; x++) {
                // Alice takes the current x piles and then we calculate Bob's best response
                int currentStones = suffixSum[i] - suffixSum[i + x];
                // Bob will try to minimize Alice's future score
                maxStones = Math.Max(maxStones, currentStones + (suffixSum[i + x] - Dfs(i + x, Math.Max(M, x))));
            }

            memo[(i, M)] = maxStones;
            return maxStones;
        }

        return Dfs(0, 1);
    }

}