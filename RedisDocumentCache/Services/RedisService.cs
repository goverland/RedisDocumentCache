using StackExchange.Redis;

namespace RedisDocumentCache.Services;

public class RedisService
{
    public IDatabase GetConnection()
    {
        var redis = ConnectionMultiplexer.Connect("127.0.0.1:6379");
        return redis.GetDatabase();
    }
}
