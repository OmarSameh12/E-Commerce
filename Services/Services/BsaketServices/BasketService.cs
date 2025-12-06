using AutoMapper;
using Infrastructure.BasketRepositories;
using Services.Services.BsaketServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.BsaketServices
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository repository;
        private readonly IMapper mapper;

        public BasketService(IBasketRepository Repository, IMapper Mapper)
        {
            repository = Repository;
            mapper = Mapper;
        }
        public Task<bool> DeleteBasketAsync(string id)
        =>repository.DeleteBasketAsync(id);


        public async Task<CustomerBasketDto> GetBasketAsync(string id)
        {
            var customerBasket= await repository.GetBasketAsync(id);
            if (customerBasket is null)
                return new CustomerBasketDto();

            var mappedCustBasket=  mapper.Map<CustomerBasketDto>(customerBasket);
            return mappedCustBasket;

        }

        public async Task<CustomerBasketDto> UpdateBasketAsync(CustomerBasketDto basket)
        {
            var customerBasket = mapper.Map<CustomerBasket>(basket);
            var mappedCustBasket=  await repository.UpdateBasketAsync(customerBasket);
            var mappedCustomerBasket = mapper.Map<CustomerBasketDto>(mappedCustBasket);
            return mappedCustomerBasket;
        }
    }
}
