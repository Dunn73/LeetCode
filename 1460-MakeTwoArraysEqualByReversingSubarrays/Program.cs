Solution solution = new();
int[] target = [1,2,3,4];
int[] arr = [2,4,1,3];

if (solution.CanBeEqual(target, arr) == true) {
    Console.WriteLine("True");
}
else {
    Console.WriteLine("False");
}
Console.ReadKey();

public class Solution {
    public bool CanBeEqual(int[] target, int[] arr) {
        Array.Sort(target);
        Array.Sort(arr);
        
        for (int i = 0; i < target.Length; i++){ 
            if (target[i] != arr[i]) {
                return false;
            }
        }


        return true;
    }
}