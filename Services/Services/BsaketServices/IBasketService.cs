using Infrastructure.BasketRepositories;
using Services.Services.BsaketServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.BsaketServices
{
    public interface IBasketService
    {
        public Task<bool> DeleteBasketAsync(string id);

        public Task<CustomerBasketDto> GetBasketAsync(string id);

        public Task<CustomerBasketDto> UpdateBasketAsync(CustomerBasketDto basket);


    }
}
