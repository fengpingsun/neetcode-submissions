public class Solution {
    string[] strs = ["abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"];
    public List<string> LetterCombinations(string digits) {
        List<string> res = new();
        if (string.IsNullOrEmpty(digits)) return res;
        
        StringBuilder sb = new();
        DFS(0);
        return res;

        void DFS(int index)
        {
            if (index == digits.Length)
            {
                res.Add(sb.ToString());
                return;
            }

            foreach (var c in strs[digits[index] - '2'])
            {
                // Add a letter
                sb.Append(c);
                DFS(index + 1);

                // Back track
                sb.Length -= 1;
            }
        }
    }
}
