using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.BasketRepositories
{
    public class BasketRepository : IBasketRepository
    {
        IDatabase _database;    

         public BasketRepository(IConnectionMultiplexer redis) {
            _database = redis.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string id)
        => await _database.KeyDeleteAsync(id);

        public async Task<CustomerBasket> GetBasketAsync(string id)
        {
            var data = await _database.StringGetAsync(id);
            return data.IsNullOrEmpty ?null:JsonSerializer.Deserialize<CustomerBasket>(data);  
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var isCreated = await _database.StringSetAsync(basket.Id,JsonSerializer.Serialize(basket),TimeSpan.FromDays(30));
            if (!isCreated)
                return null;

            return await GetBasketAsync(basket.Id); 
        }
    }
}
