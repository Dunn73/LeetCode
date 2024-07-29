Solution solution = new Solution();
        
int[] rating1 = {2, 5, 3, 4, 1};
Console.WriteLine(solution.NumTeams(rating1));

int[] rating2 = {2, 1, 3};
Console.WriteLine(solution.NumTeams(rating2));

int[] rating3 = {1, 2, 3, 4};
Console.WriteLine(solution.NumTeams(rating3)); 

int[] rating4 = {4, 3, 2, 1};
Console.WriteLine(solution.NumTeams(rating4)); 

Console.ReadKey();

public class Solution {
    public int NumTeams(int[] rating) {
        int n = rating.Length;
        int count = 0;
        
        for (int j = 0; j < n; j++) {
            int leftSmaller = 0, leftLarger = 0;
            int rightSmaller = 0, rightLarger = 0;
            
            // Count elements to the left of j
            for (int i = 0; i < j; i++) {
                if (rating[i] < rating[j]) leftSmaller++;
                if (rating[i] > rating[j]) leftLarger++;
            }
            
            // Count elements to the right of j
            for (int k = j + 1; k < n; k++) {
                if (rating[k] < rating[j]) rightSmaller++;
                if (rating[k] > rating[j]) rightLarger++;
            }
            
            // Calculate valid teams with j as the middle element
            count += leftSmaller * rightLarger + leftLarger * rightSmaller;
        }
        
        return count;
    }
}