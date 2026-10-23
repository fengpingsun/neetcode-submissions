public class Solution {
    public int CountComponents(int n, int[][] edges) {
        // Create adjacency list
        Dictionary<int, List<int>> adjList = new();
        for (int i = 0; i < n; i++) adjList[i] = new();
        foreach (int[] edge in edges)
        {
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }

        // Run DFS
        bool[] visited = new bool[n];
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                count++;
                DFS(i);
            }
        }
        return count;

        void DFS(int i)
        {
            if (visited[i]) return;

            visited[i] = true;
            foreach (var nei in adjList[i])
            {
                DFS(nei);
            }
        }
    }
}
