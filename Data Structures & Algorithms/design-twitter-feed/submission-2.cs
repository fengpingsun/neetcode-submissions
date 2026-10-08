public class Twitter {
    Dictionary<int, HashSet<int>> follows = new();
    Dictionary<int, List<(int ts, int tweetId)>> posts = new();
    int timestamp = 0;

    public Twitter() {
        
    }
    
    public void PostTweet(int userId, int tweetId) {
        if (!posts.ContainsKey(userId)) posts[userId] = new List<(int, int)>();
        posts[userId].Add((timestamp++, tweetId));
    }
    
    public List<int> GetNewsFeed(int userId) {
        PriorityQueue<int, int> queue = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a))); // Bigger timestamp pops first ==> max heap
        List<int> users = new();
        users.Add(userId);
        if (follows.ContainsKey(userId)) users.AddRange(follows[userId]);
        
        foreach (var user in users)
        {
            if (posts.ContainsKey(user))
            {
                foreach (var post in posts[user])
                {
                    queue.Enqueue(post.tweetId, post.ts);
                }
            }
        }
        List<int> res = new();
        while (queue.Count > 0 && res.Count < 10)
        {
            res.Add(queue.Dequeue());
        }
        return res;
    }
    
    public void Follow(int followerId, int followeeId) {
        if (!follows.ContainsKey(followerId)) follows[followerId] = new HashSet<int>();
        follows[followerId].Add(followeeId);
    }
    
    public void Unfollow(int followerId, int followeeId) {
        follows[followerId].Remove(followeeId);
    }
}
