using Redis.OM.Modeling;

namespace RedisDocumentCache.Models;

public class Specification
{
    [Searchable]
    public string? material { get; set; }
    [Searchable]
    public decimal weight { get; set; }
}