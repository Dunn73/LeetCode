Solution solution = new();

int distance = 3;
int?[] values = [1,2,3,null,4];

TreeNode root = TreeBuilder.BuildTree(values);

Console.WriteLine(solution.CountPairs(root, distance));

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

public class Solution {
    public int CountPairs(TreeNode root, int distance) {
        int result = 0;
        
        // Helper function that returns a list of distances from the node's leaves
        List<int> dfs(TreeNode node) {
            // List to store distances from this node to its leaf nodes
            List<int> distances = new List<int>();

            // Base case: If the node is null, return an empty list
            if (node == null) return distances;
            
            // Base case: If the node is a leaf, return a list with a single distance of 1
            if (node.left == null && node.right == null) {
                distances.Add(1);
                return distances;
            }
            
            // Recursively get distances from left and right children
            List<int> leftDistances = dfs(node.left);
            List<int> rightDistances = dfs(node.right);
            
            // Count good pairs from distances in left and right subtrees
            foreach (int l in leftDistances) {
                foreach (int r in rightDistances) {
                    if (l + r <= distance) {
                        result++;
                    }
                }
            }
            
            // Update the distances for the current node
            foreach (int l in leftDistances) {
                distances.Add(l + 1);
            }
            foreach (int r in rightDistances) {
                distances.Add(r + 1);
            }
            
            return distances;
        }
        
        dfs(root);
        return result;
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
