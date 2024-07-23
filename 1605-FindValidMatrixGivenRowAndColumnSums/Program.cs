Solution solution = new();

int[] rowSum = [3,8];
int[] colSum = [4,7];

var output = solution.RestoreMatrix(rowSum, colSum);

foreach (var row in output) {
    Console.WriteLine("[");
    foreach (var item in row ) {
        Console.WriteLine($"{item}, ");
    }
    Console.WriteLine("]");

}


Console.ReadKey();

public class Solution {
    public int[][] RestoreMatrix(int[] rowSum, int[] colSum) {
        int rows = rowSum.Length;
        int cols = colSum.Length;
        int[][] matrix = new int[rows][];
        for (int i = 0; i < rows; i++) {
            matrix[i] = new int[cols];
        }

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                int value = Math.Min(rowSum[i], colSum[j]);
                matrix[i][j] = value;
                rowSum[i] -= value;
                colSum[j] -= value;
            }
        }

        return matrix;
    }
}
