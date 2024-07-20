
Solution solution = new Solution();
int[] to_delete = {3, 5};
int?[] values = {1, 2, 3, 4, 5, 6, 7};

TreeNode root = TreeBuilder.BuildTree(values);

var output = solution.DelNodes(root, to_delete);

List<List<int?>> forestList = solution.ConvertForestToList(output);

foreach (var tree in forestList) {
    Console.WriteLine($"[{string.Join(", ", tree.Select(x => x.HasValue ? x.ToString() : "null"))}]");
}

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
    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete) {
        HashSet<int> toDeleteSet = new HashSet<int>(to_delete);
        List<TreeNode> forest = new List<TreeNode>();

        TreeNode dfs(TreeNode node, bool isRoot) {
            if (node == null) return null;

            bool deleted = toDeleteSet.Contains(node.val);

            if (isRoot && !deleted) {
                forest.Add(node);
            }

            node.left = dfs(node.left, deleted);
            node.right = dfs(node.right, deleted);

            return deleted ? null : node;
        }

        dfs(root, true);
        return forest;
    }

    public List<List<int?>> ConvertForestToList(IList<TreeNode> forest) {
        List<List<int?>> result = new List<List<int?>>();

        foreach (TreeNode root in forest) {
            List<int?> levelOrder = new List<int?>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0) {
                TreeNode current = queue.Dequeue();
                if (current != null) {
                    levelOrder.Add(current.val);
                    queue.Enqueue(current.left);
                    queue.Enqueue(current.right);
                } else {
                    levelOrder.Add(null);
                }
            }

            // Remove trailing nulls
            while (levelOrder.Count > 0 && levelOrder[levelOrder.Count - 1] == null) {
                levelOrder.RemoveAt(levelOrder.Count - 1);
            }

            result.Add(levelOrder);
        }

        return result;
    }
}
