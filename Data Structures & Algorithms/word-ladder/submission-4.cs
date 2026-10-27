public class Solution
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        HashSet<string> set = new HashSet<string>(wordList);

        if (!set.Contains(endWord)) return 0;

        Queue<string> queue = new();
        queue.Enqueue(beginWord);
        set.Remove(beginWord);

        int steps = 0;

        while (queue.Count > 0)
        {
            steps++;
            int levelCount = queue.Count;

            for (int i = 0; i < levelCount; i++)
            {
                string word = queue.Dequeue();

                if (word == endWord) return steps;

                char[] arr = word.ToCharArray();

                for (int j = 0; j < arr.Length; j++)
                {
                    char original = arr[j];

                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        if (c == original) continue;

                        arr[j] = c;
                        string newWord = new string(arr);

                        if (set.Remove(newWord))
                        {
                            queue.Enqueue(newWord);
                        }
                    }

                    arr[j] = original;
                }
            }
        }

        return 0;
    }
}