public class FunctionCache<TKey, TResult>
{
    private readonly Dictionary<TKey, CacheItem> cache = new Dictionary<TKey, CacheItem>();
    private readonly TimeSpan expiration;

    public FunctionCache(TimeSpan expiration)
    {
        this.expiration = expiration;
    }

    public TResult Get(TKey key, Func<TKey, TResult> function)
    {
        if (cache.ContainsKey(key))
        {
            var result = cache[key];

            if (result.HasExpired())
            {
                cache.Remove(key);
                return Get(key, function);
            }

            return result.Value;
        }

        var resultValue = function(key);
        cache.Add(key, new CacheItem(resultValue, DateTimeOffset.Now + expiration));
        return resultValue;
    }

    private class CacheItem
    {
        public TResult Value { get; }
        public DateTimeOffset Expiration { get; }

        public CacheItem(TResult value, DateTimeOffset expiration)
        {
            Value = value;
            Expiration = expiration;
        }

        public bool HasExpired()
        {
            return DateTimeOffset.Now > Expiration;
        }
    }
}