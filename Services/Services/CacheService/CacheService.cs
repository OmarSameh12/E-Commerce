using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.Services.CacheService
{
    public class CacheService : ICacheService
    {
        private readonly IDatabase database;
        public CacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            database = connectionMultiplexer.GetDatabase();
        }

        public async Task<string> GetCacheResponseAsync(string cacheKey)
        {
            var serilzedResponse = await database.StringGetAsync(cacheKey);
            if (string.IsNullOrEmpty(serilzedResponse))
                return null;
            return serilzedResponse;

        }

        public async Task SetCacheResponseAsync(string cacheKey, object Response, TimeSpan TimeToLive)
        {
            if (Response != null)
                return ;

            var options = new JsonSerializerOptions{PropertyNamingPolicy=JsonNamingPolicy.CamelCase };
            var serilizedResponse=JsonSerializer.Serialize(Response,options);
            await database.StringSetAsync(cacheKey,serilizedResponse,TimeToLive);

        }
    }
}
