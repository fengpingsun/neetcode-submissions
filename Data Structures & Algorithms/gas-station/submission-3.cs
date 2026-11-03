public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int curBalance = 0, totalBalance = 0;
        int start = 0;
        for (int i = 0; i < gas.Length; i++)
        {
            int diff = gas[i] - cost[i];
            curBalance += diff;
            totalBalance += diff;
            if (curBalance < 0)
            {
                curBalance = 0; // Reset curBalance to 0
                start = i + 1; // Reset start index to next (i + 1)
            }
        }
        return totalBalance >= 0 ? start : -1;
    }
}
