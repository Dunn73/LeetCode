Solution solution = new();

int?[] values = { 5, 1, 2, 3, null, 6, 4 };
int startValue = 3;;
int destValue = 6;
TreeNode root = TreeBuilder.BuildTree(values);

Console.WriteLine(solution.GetDirections(root, startValue, destValue));

Console.ReadKey();
 public class TreeNode {
     public int val;
     public TreeNode left;
     public TreeNode right;
     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
         this.val = val;
         this.left = left;
         this.right = right;
     }
 }


public class TreeBuilder {
    public static TreeNode BuildTree(int?[] values) {
        if (values == null || values.Length == 0) return null;

        TreeNode root = new TreeNode(values[0].Value);
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        int i = 1;
        while (queue.Count > 0 && i < values.Length) {
            TreeNode current = queue.Dequeue();

            if (values[i] != null) {
                current.left = new TreeNode(values[i].Value);
                queue.Enqueue(current.left);
            }
            i++;

            if (i < values.Length && values[i] != null) {
                current.right = new TreeNode(values[i].Value);
                queue.Enqueue(current.right);
            }
            i++;
        }

        return root;
    }
}

public class Solution {
    public string GetDirections(TreeNode root, int startValue, int destValue) {
        // Stores the path from the root to the start and destination values
        List<char> pathToStart = new List<char>();
        List<char> pathToDest = new List<char>();

        // Find both paths in a single DFS traversal
        FindPaths(root, startValue, destValue, new List<char>(), pathToStart, pathToDest);

        // Remove common prefix (common ancestor path)
        int i = 0;
        while (i < pathToStart.Count && i < pathToDest.Count && pathToStart[i] == pathToDest[i]) {
            i++;
        }

        // Steps up to the common ancestor
        int upSteps = pathToStart.Count - i;

        // Combine the steps up to the common ancestor and the steps down to the destination node
        string result = new string('U', upSteps) + new string(pathToDest.GetRange(i, pathToDest.Count - i).ToArray());
        
        return result;
    }

    private bool FindPaths(TreeNode node, int startValue, int destValue, List<char> path, List<char> pathToStart, List<char> pathToDest) {
        if (node == null) return false;

        // If the current node is the start or destination node, store the path
        if (node.val == startValue) {
            pathToStart.AddRange(path);
        }
        if (node.val == destValue) {
            pathToDest.AddRange(path);
        }

        // Recur for left and right subtrees
        path.Add('L');
        bool foundLeft = FindPaths(node.left, startValue, destValue, path, pathToStart, pathToDest);
        path.RemoveAt(path.Count - 1);

        path.Add('R');
        bool foundRight = FindPaths(node.right, startValue, destValue, path, pathToStart, pathToDest);
        path.RemoveAt(path.Count - 1);

        // Return true if either of the start or destination values is found in the subtree
        return foundLeft || foundRight || (node.val == startValue || node.val == destValue);
    }
}
