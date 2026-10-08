public class LRUCache {
    LinkedList<(int Key, int Val)> list = new();
    Dictionary<int, LinkedListNode<(int Key, int Val)>> cache = new();
    int capacity;

    public LRUCache(int capacity) {
        this.capacity = capacity;    
    }
    
    public int Get(int key) {
        if (!cache.ContainsKey(key)) return -1;
        var node = cache[key];
        list.Remove(node);
        list.AddFirst(node);
        return node.Value.Val;
    }
    
    public void Put(int key, int value) {
        LinkedListNode<(int Key, int Val)> node = null;
        if (cache.ContainsKey(key))
        {
            node = cache[key];
            list.Remove(node);
            node.Value = (key, value);
        }
        else
        {
            node = new LinkedListNode<(int Key, int Val)>((key, value));
            if (cache.Count == capacity)
            {
                var nodeToBeRemoved = list.Last;
                list.Remove(nodeToBeRemoved);
                cache.Remove(nodeToBeRemoved.Value.Key);
            }
            cache[key] = node;
        }
        list.AddFirst(node);
    }
}
