public class Solution {  
    public List<string> GenerateParenthesis(int n) {
        List<string> res = new();
        StringBuilder sb = new();
        DFS(0, 0);
        return res;

        void DFS(int open, int close)
        {
            if (open == n && close == n)
            {
                res.Add(sb.ToString());
                return;
            }

            // Prune invalid branches
            if (open == n + 1 || open < close) return;

            // Open parenthesis
            sb.Append("(");
            DFS(open + 1, close);

            // Back track
            sb.Length -= 1;

            // Close parenthesis
            sb.Append(")");
            DFS(open, close + 1);

            // Back track
            sb.Length -= 1;
        }
    }
}
