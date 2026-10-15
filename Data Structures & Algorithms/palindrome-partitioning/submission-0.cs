public class Solution {
    public List<List<string>> Partition(string s) {
        List<List<string>> res = new();
        List<string> part = new();
        DFS(0);
        return res;

        void DFS(int start)
        {
            if (start == s.Length)
            {
                res.Add(new List<string>(part));
                return;
            }

            for (int end = start; end < s.Length; end++)
            {
                if (!IsPalindrome(start, end)) continue;
                part.Add(s.Substring(start, end - start + 1));
                DFS(end + 1);
                part.RemoveAt(part.Count - 1);
            }
        }

        bool IsPalindrome(int start, int end)
        {
            bool res = true;
            while (start < end)
            {
                if (s[start] != s[end]) return false;
                start++;
                end--;
            }
            return res;
        }
    }
}
