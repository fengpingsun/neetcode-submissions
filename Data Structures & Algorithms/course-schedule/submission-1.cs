public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        Dictionary<int, List<int>> adjList = new();
        int[] visited = new int[numCourses]; // Use 3-value visited array: 0-unvisited, 1-visiting, 2-visited
        // Create adjacency list
        for (int i = 0; i < numCourses; i++) adjList[i] = new List<int>();
        for (int i = 0; i < prerequisites.Length; i++)
        {
            adjList[prerequisites[i][0]].Add(prerequisites[i][1]);
        }

        // Traverse each node and check if there is loop or not
        for (int i = 0; i < numCourses; i++)
        {
            if (DFS(i)) return false;
        }
        return true;

        bool DFS(int course) // Is a loop detected
        {
            if (visited[course] != 0) return visited[course] == 1; // 1-visiting ==> has loop; 2-visited ==> no loop
            
            visited[course] = 1;
            if (adjList.ContainsKey(course))
            {
                foreach (var c in adjList[course])
                {
                    if (DFS(c)) return true;
                }
            }
            visited[course] = 2;
            return false;
        }
    }
}
