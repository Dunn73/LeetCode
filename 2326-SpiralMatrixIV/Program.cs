Solution solution = new();
int m = 3;
int n = 5;
ListNode head = new ListNode(3);
head.next = new ListNode(0);
head.next.next = new ListNode(2);
head.next.next.next = new ListNode(6);
head.next.next.next.next = new ListNode(8);
head.next.next.next.next.next = new ListNode(1);
head.next.next.next.next.next.next = new ListNode(7);
head.next.next.next.next.next.next.next = new ListNode(9);
head.next.next.next.next.next.next.next.next = new ListNode(4);
head.next.next.next.next.next.next.next.next.next = new ListNode(2);
head.next.next.next.next.next.next.next.next.next.next = new ListNode(5);
head.next.next.next.next.next.next.next.next.next.next.next = new ListNode(5);
head.next.next.next.next.next.next.next.next.next.next.next.next = new ListNode(0);
int[][] output = solution.SpiralMatrix(m,n,head);
foreach (var line in output) {
    Console.Write("[");
    foreach (var number in line) {
        Console.Write($"{number}, ");
    }
    Console.WriteLine("]");
}

Console.ReadKey();

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

public class Solution {
    public int[][] SpiralMatrix(int m, int n, ListNode head) {
        // Initialize the matrix with -1
        int[][] matrix = new int[m][];
        for (int i = 0; i < m; i++) {
            matrix[i] = new int[n];
            for (int j = 0; j < n; j++) {
                matrix[i][j] = -1;
            }
        }

        int top = 0, bottom = m - 1;
        int left = 0, right = n - 1;
        
        ListNode current = head;
        
        while (current != null && top <= bottom && left <= right) {
            // Fill top row
            for (int i = left; i <= right && current != null; i++) {
                matrix[top][i] = current.val;
                current = current.next;
            }
            top++;
            
            // Fill right column
            for (int i = top; i <= bottom && current != null; i++) {
                matrix[i][right] = current.val;
                current = current.next;
            }
            right--;
            
            // Fill bottom row
            for (int i = right; i >= left && current != null; i--) {
                matrix[bottom][i] = current.val;
                current = current.next;
            }
            bottom--;
            
            // Fill left column
            for (int i = bottom; i >= top && current != null; i--) {
                matrix[i][left] = current.val;
                current = current.next;
            }
            left++;
        }

        return matrix;
    }
}
