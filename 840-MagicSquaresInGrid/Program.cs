Solution solution = new();

int[][] grid = [[5,5,5],[5,5,5],[5,5,5]];

Console.WriteLine(solution.NumMagicSquaresInside(grid));

Console.ReadKey();
public class Solution {
    public int NumMagicSquaresInside(int[][] grid) {
        int count = 0;

        // Loop through possible starting points of 3x3 subgrids
        for (int i = 0; i <= grid.Length - 3; i++) {
            for (int j = 0; j <= grid[0].Length - 3; j++) {
                if (IsMagicSquare(grid, i, j)) {
                    count++;
                }
            }
        }

        return count;
    }

    private bool IsMagicSquare(int[][] grid, int row, int col) {
        int[] digits = new int[10];

        // Check the digits and sum of rows, columns, and diagonals
        for (int i = 0; i < 3; i++) {
            int rowSum = 0, colSum = 0;
            for (int j = 0; j < 3; j++) {
                int val = grid[row + i][col + j];
                if (val < 1 || val > 9 || digits[val] == 1) return false;
                digits[val] = 1;
                rowSum += val;
                colSum += grid[row + j][col + i];
            }
            if (rowSum != 15 || colSum != 15) return false;
        }

        // Check diagonals
        int diag1Sum = grid[row][col] + grid[row + 1][col + 1] + grid[row + 2][col + 2];
        int diag2Sum = grid[row][col + 2] + grid[row + 1][col + 1] + grid[row + 2][col];

        return diag1Sum == 15 && diag2Sum == 15;
    }
}
