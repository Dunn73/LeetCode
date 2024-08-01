Solution solution = new();

string[] details = ["7868190130M7522","5303914400F9211","9273338290F4010"];

Console.WriteLine(solution.CountSeniors(details));

Console.ReadKey();
public class Solution {
    public int CountSeniors(string[] details) {
        int totalSeniors = 0;

        foreach (var element in details) {
            if (char.GetNumericValue(element[11]) == 6 && char.GetNumericValue(element[12]) > 0){
                totalSeniors ++;
            }
            else if (char.GetNumericValue(element[11]) > 6){
                totalSeniors ++;
            }
        }

        return totalSeniors;
    }
}