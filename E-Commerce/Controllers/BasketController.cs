using Microsoft.AspNetCore.Mvc;
using Services.Services.BsaketServices;
using Services.Services.BsaketServices.Dto;

namespace E_Commerce.Controllers
{
    public class BasketController : BaseController
    {
        private readonly IBasketService basketService;

        public BasketController(IBasketService baskt)
        {
            basketService = baskt;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasketDto>> GetBasketByIdAsync(string id)
            =>Ok(await basketService.GetBasketAsync(id));

        [HttpPost]
        public async Task<ActionResult<CustomerBasketDto>> UpdateBasket(CustomerBasketDto customerbasketDto) 
         =>Ok(await basketService.UpdateBasketAsync(customerbasketDto));
        [HttpDelete]
        public async Task<ActionResult<CustomerBasketDto>> DeleteBasketById(string id)
            =>Ok(await basketService.DeleteBasketAsync(id)); 
    
    
    }
}
