Solution solution = new();
int[] nums = [5,2,3,1];

var output = solution.SortArray(nums);

foreach (var number in output) {
    Console.WriteLine($"{number}, ");
}

Console.ReadKey();

public class Solution {
    private static Random random = new Random();
    
    public int[] SortArray(int[] array) {
        QuickSort(array, 0, array.Length - 1);
        return array;
    }
    
    private void QuickSort(int[] array, int left, int right) {
        if (left < right) {
            int pivotIdx = RandomizedPartition(array, left, right);
            QuickSort(array, left, pivotIdx);
            QuickSort(array, pivotIdx + 1, right);
        }
    }

    private int RandomizedPartition(int[] array, int left, int right) {
        int randomPivotIndex = random.Next(left, right + 1);
        Swap(array, randomPivotIndex, left);
        return Partition(array, left, right);
    }

    private int Partition(int[] array, int left, int right) {
        int pivotValue = array[left];
        int low = left - 1;
        int high = right + 1;

        while (true) {
            do {
                low++;
            } while (array[low] < pivotValue);

            do {
                high--;
            } while (array[high] > pivotValue);

            if (low >= high) {
                return high;
            }

            Swap(array, low, high);
        }
    }

    private void Swap(int[] array, int index1, int index2) {
        int temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }
}
