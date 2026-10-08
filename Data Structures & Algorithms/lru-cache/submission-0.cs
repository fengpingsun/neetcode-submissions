public class LRUCache {
    Dictionary<int, LinkedListNode<(int Key, int Val)>> cache = new();
    LinkedList<(int Key, int Val)> list = new();
    int capacity = 0;

    public LRUCache(int capacity) {
        this.capacity = capacity;
    }
    
    public int Get(int key) {
        if (!cache.ContainsKey(key)) return -1;
        LinkedListNode<(int Key, int Val)> node = cache[key];
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
            if (cache.Count == capacity)
            {
                LinkedListNode<(int Key, int Val)> nodeToBeRemoved = list.Last;
                cache.Remove(nodeToBeRemoved.Value.Key);
                list.Remove(nodeToBeRemoved);
            }

            node = new LinkedListNode<(int Key, int Val)>((key, value));
            cache[key] = node;
        }
        list.AddFirst(node);
    }
}
