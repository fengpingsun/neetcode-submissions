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
        PriorityQueue<(int userId, int index), int> queue = new PriorityQueue<(int, int), int>(Comparer<int>.Create((a, b) => b.CompareTo(a))); // Bigger timestamp pops first ==> max heap
        
        // User's own tweets
        AddLatestTweet(userId, queue);

        // Followees' tweets
        if (follows.TryGetValue(userId, out var followees))
        {
            foreach (int followeeId in followees)
            {
                if (followeeId != userId)
                    AddLatestTweet(followeeId, queue);
            }
        }

        List<int> result = new();
        while (queue.Count > 0 && result.Count < 10)
        {
            var (authorId, index) = queue.Dequeue();
            var post = posts[authorId][index];
            result.Add(post.tweetId);

            // Add the next older tweet from this user.
            if (index > 0)
            {
                var nextPost = posts[authorId][index - 1];
                queue.Enqueue((authorId, index - 1), nextPost.ts);
            }
        }
        return result;
    }

    private void AddLatestTweet(int userId, PriorityQueue<(int userId, int index), int> queue)
    {
        if (posts.TryGetValue(userId, out var userPosts) && userPosts.Count > 0)
        {
            int index = userPosts.Count - 1;
            queue.Enqueue((userId, index), userPosts[index].ts);
        }
    }
    
    public void Follow(int followerId, int followeeId) {
        if (!follows.ContainsKey(followerId)) follows[followerId] = new HashSet<int>();
        follows[followerId].Add(followeeId);
    }
    
    public void Unfollow(int followerId, int followeeId) {
        follows[followerId].Remove(followeeId);
    }
}
