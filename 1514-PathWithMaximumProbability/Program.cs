Solution solution = new();


int n = 3;
int[][] edges = [[0,1],[1,2],[0,2]];
double[] succProb = [0.5,0.5,0.2];
int start_node = 0;
int end_node = 2;

Console.WriteLine(solution.MaxProbability(n, edges, succProb, start_node, end_node));


Console.ReadKey();

public class Solution {
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end) {
        // Create the graph as an adjacency list
        var graph = new Dictionary<int, List<(int, double)>>();

        // Build the adjacency list from edges and probabilities
        for (int i = 0; i < edges.Length; i++) {
            int u = edges[i][0];
            int v = edges[i][1];
            double prob = succProb[i];

            if (!graph.ContainsKey(u)) graph[u] = new List<(int, double)>();
            if (!graph.ContainsKey(v)) graph[v] = new List<(int, double)>();

            graph[u].Add((v, prob));
            graph[v].Add((u, prob));
        }

        // Max-heap (using a PriorityQueue)
        var pq = new PriorityQueue<(int node, double prob), double>(Comparer<double>.Create((a, b) => b.CompareTo(a)));

        // Probability array, initialized with 0
        double[] probabilities = new double[n];
        probabilities[start] = 1.0;

        // Start with the starting node with probability 1
        pq.Enqueue((start, 1.0), 1.0);

        while (pq.Count > 0) {
            // Dequeue the node with the highest probability
            var (node, currentProb) = pq.Dequeue();

            // If we reached the end node, return the probability
            if (node == end) {
                return currentProb;
            }

            // Explore neighbors
            if (graph.ContainsKey(node)) {
                foreach (var (neighbor, edgeProb) in graph[node]) {
                    double newProb = currentProb * edgeProb;

                    // If we found a higher probability to reach this neighbor, update and push to priority queue
                    if (newProb > probabilities[neighbor]) {
                        probabilities[neighbor] = newProb;
                        pq.Enqueue((neighbor, newProb), newProb);
                    }
                }
            }
        }

        // If no path was found, return 0
        return 0.0;
    }
}