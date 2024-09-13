Solution solution = new();

int[] arr = [1,3,4,8];
int[][] queries = [[0,1],[1,2],[0,3],[3,3]];

foreach (var integer in solution.XorQueries(arr, queries)) {
    Console.WriteLine(integer);
}

Console.ReadKey();

public class Solution {
    public int[] XorQueries(int[] arr, int[][] queries) {
        int n = arr.Length;
        int[] prefixXor = new int[n];
        prefixXor[0] = arr[0];
        
        // Build the prefix XOR array
        for (int i = 1; i < n; i++) {
            prefixXor[i] = prefixXor[i - 1] ^ arr[i];
        }
        
        int[] result = new int[queries.Length];
        
        // Answer each query
        for (int i = 0; i < queries.Length; i++) {
            int left = queries[i][0];
            int right = queries[i][1];
            
            if (left == 0) {
                result[i] = prefixXor[right];
            } else {
                result[i] = prefixXor[right] ^ prefixXor[left - 1];
            }
        }
        
        return result;
    }
}
