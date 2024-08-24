Solution solution = new();

int[] sample = [1,1,2,3,3,8,9,4,5,6,6];

IList<int> output = solution.FindDuplicates(sample);
foreach (int element in output) {
    Console.WriteLine(element);
}

Console.ReadKey();

public class Solution {
    IList<int> output = [];
    public IList<int> FindDuplicates(int[] nums) {

        foreach (int num in nums) {
            int index = Math.Abs(num) - 1;
            if (nums[index] < 0) {
                output.Add(index + 1);
            } else {
                nums[index] = -nums[index];
            }
        }


        return output;
    }
}

/* Linq Solution

public IList<int> FindDuplicates(int[] nums) {
        return nums.GroupBy(i => i)
                    .Where(g => g.Count() > 1)
                    .Select(g => g.Key)
                    .ToList();

*/