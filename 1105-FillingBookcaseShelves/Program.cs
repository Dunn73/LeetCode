Solution solution = new();

int[][] books = [[1,1],[2,3],[2,3],[1,1],[1,1],[1,1],[1,2]];
int shelfWidth = 4;

Console.WriteLine(solution.MinHeightShelves(books, shelfWidth));


Console.ReadKey();

public class Solution {
    public int MinHeightShelves(int[][] books, int shelfWidth) {

        int n = books.Length;
        int[] dp = new int[n + 1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;

        for (int i = 1; i <= n; i++) {
            int width = 0, height = 0;
            for (int j = i; j > 0; j--) {
                width += books[j - 1][0];
                if (width > shelfWidth) break;
                height = Math.Max(height, books[j - 1][1]);
                dp[i] = Math.Min(dp[i], dp[j - 1] + height);
            }
        }

        return dp[n];
    }
}

