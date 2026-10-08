public class Solution {
    public int[] FindBuildings(int[] heights) {
        Stack<int> stack = new Stack<int>();
        int n = heights.Length;
        for (int i = 0; i < n; i++)
        {
            while (stack.Count > 0 && heights[i] >= heights[stack.Peek()])
                stack.Pop();
            stack.Push(i);
        }
        int[] res = new int[stack.Count];
        for (int i = res.Length - 1; i >= 0; i--)
            res[i] = stack.Pop();
        return res;
    }
}