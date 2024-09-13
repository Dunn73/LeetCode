Solution solution = new();

int start = 10;
int goal = 7;

Console.WriteLine(solution.MinBitFlips(start, goal));

Console.ReadKey();
public class Solution {
    public int MinBitFlips(int start, int goal) {

        int numFlips = start ^ goal;

        return FlipHelper(numFlips);
    }

    public int FlipHelper(int n) {
        int count = 0;
        while (n > 0) {
            count += n & 1;
            n >>= 1;
        }
        return count;
    }
}