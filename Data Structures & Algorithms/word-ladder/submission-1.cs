public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        // If endWord is not in wordList, then directly return 0
        if (!wordList.Contains(endWord)) return 0;

        // Create undirected graph from beginWord and workList
        HashSet<string> set = new HashSet<string>(wordList);
        set.Add(beginWord);
        Dictionary<string, List<string>> adjList = new();
        foreach (var word in set) adjList[word] = new();

        string[] words = set.ToArray();
        foreach (string word in words)
        {
            char[] arr = word.ToCharArray();
            for (int i = 0; i < word.Length; i++)
            {
                char original = arr[i];
                for (int j = 0; j < 26; j++)
                {
                    char temp = (char)('a' + j);
                    if (temp == original) continue;

                    arr[i] = temp;
                    string newWord = new string(arr);
                    if (set.Contains(newWord))
                    {
                        adjList[word].Add(newWord);
                    }
                }
                arr[i] = original;
            }
        }

        // Run BFS to check if endWord is reachable
        Queue<string> queue = new();
        HashSet<string> visited = new();
        queue.Enqueue(beginWord);
        visited.Add(beginWord);
        int steps = 0;
        while (queue.Count > 0)
        {
            steps++;
            int levelCount = queue.Count;
            for (int i = 0; i < levelCount; i++)
            {
                string word = queue.Dequeue();
                if (word == endWord) return steps;
                foreach (var neighbor in adjList[word])
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }
        }
        return 0;
    }

    private bool IsAdjacent(string word1, string word2)
    {
        var diffs = 0;
        for (int i = 0; i < word1.Length; i++)
        {
            if (word1[i] != word2[i])
            {
                diffs++;
                if (diffs > 1) return false;
            }
        }
        return diffs != 0;
    }
}
