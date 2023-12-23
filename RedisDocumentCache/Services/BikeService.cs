using System.Collections;
using Microsoft.AspNetCore.Http.HttpResults;
using NRedisStack.RedisStackCommands;
using NRedisStack.Search;
using Redis.OM;
using Redis.OM.Searching;
using RedisDocumentCache.Models;

namespace RedisDocumentCache.Services;

public class BikeService
{
    private readonly RedisCollection<Bike> _bikes;
    private readonly ILogger<BikeService> _log;
    private readonly RedisConnectionProvider _provider;

    public BikeService(ILogger<BikeService> log, RedisConnectionProvider provider)
    {
        _log = log;
        _provider = provider;
        _bikes = (RedisCollection<Bike>)_provider.RedisCollection<Bike>();
    }
    public async Task<Bike> GetBikeAsync(string id)
    {
        try
        {
            var bike = await _bikes.FindByIdAsync(id);

            if (bike == null)
            {
                return new Bike();
            }
            return bike;
        }
        catch (Exception ex)
        {
            _log.LogError(ex.Message);
            throw;
        }
    }


    public async Task<IEnumerable<Bike>> GetBikes()
    {
         return await _bikes.ToListAsync();
    }

    public async Task<Bike> SaveBike(Bike newBike)
    {
        var bike = await GetBikeAsync(newBike.id);

        if (bike == null)
        {
            await _bikes.InsertAsync(newBike);
            return newBike;
        }
        else
        {
            bike = newBike;
            await _bikes.SaveAsync();

            return bike;
        }
    }
}

