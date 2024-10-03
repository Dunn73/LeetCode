Solution solution = new();

IList<string> timePoints = ["23:59","00:02"];

Console.WriteLine(solution.FindMinDifference(timePoints));

Console.ReadKey();
public class Solution {
    public int FindMinDifference(IList<string> timePoints) {

        // Convert the time points to minutes
        List<int> minutesList = new List<int>();
        
        foreach (var time in timePoints) {
            string[] parts = time.Split(':');
            int hours = int.Parse(parts[0]);
            int minutes = int.Parse(parts[1]);
            minutesList.Add(hours * 60 + minutes);
        }

        // Sort the list of minutes
        minutesList.Sort();

        // Initialize the minimum difference to a large value
        int minDiff = int.MaxValue;

        // Find the minimum difference between consecutive times
        for (int i = 1; i < minutesList.Count; i++) {
            int diff = minutesList[i] - minutesList[i - 1];
            minDiff = Math.Min(minDiff, diff);
        }

        // Also check the difference between the first and last time, considering the circular nature of the clock
        int circularDiff = (1440 - minutesList[minutesList.Count - 1]) + minutesList[0];
        minDiff = Math.Min(minDiff, circularDiff);

        return minDiff;
    }
}