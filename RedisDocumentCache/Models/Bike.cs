using Redis.OM.Modeling;

namespace RedisDocumentCache.Models;

[Document(StorageType = StorageType.Json, Prefixes = ["bikes"])]
public class Bike
{
    [RedisIdField]
    [Indexed]
    public string? id { get; set; }
    [Indexed]
    public string? model { get; set; }
    [Searchable]
    public string? brand { get; set; }
    [Searchable]
    public decimal price { get; set; }
    [Searchable]
    public string? type { get; set; }
    [Indexed(CascadeDepth = 1)]
    public List<Specification> specs { get; set; } = [];
    [Searchable]
    public string? description { get; set; }
}
