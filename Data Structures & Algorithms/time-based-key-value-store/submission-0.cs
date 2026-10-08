public class TimeMap {
    Dictionary<string, List<(int ts, string val)>> dict = new();

    public TimeMap() {
        
    }
    
    public void Set(string key, string value, int timestamp) {
        if (!dict.ContainsKey(key)) dict[key] = new List<(int, string)>();
        dict[key].Add((timestamp, value));
    }
    
    public string Get(string key, int timestamp) {
        string res = "";
        if (!dict.ContainsKey(key)) return res;
        var list = dict[key];
        int left = 0, right = list.Count - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (list[mid].ts == timestamp) return list[mid].val;
            if (list[mid].ts > timestamp) right = mid - 1;
            else
            {
                res = list[mid].val;
                left = mid + 1;
            }
        }
        return res;
    }
}
