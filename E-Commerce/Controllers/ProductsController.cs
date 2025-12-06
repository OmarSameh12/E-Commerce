using Core.Entities;
using E_Commerce.HandleResponses;
using E_Commerce.Helper;
using Infrastructure.Interfaces;
using Infrastructure.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Helper;
using Services.Services.ProductServices;
using Services.Services.ProductServices.Dto;

namespace E_Commerce.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //Get all products 
        [HttpGet]
        [Cache(500)]
        public async Task<Pagination<ProductResultDto>> GetProducts([FromQuery]ProductSpecifications specs ) 
            => await _productService.GetAllProductsAsync(specs);
            
        
        [HttpGet("{id}")]
        public async Task<ProductResultDto> GetProductById(int? id) 
            => await _productService.GetProductByIdAsync(id);
            
        
        [HttpGet("Brands")]//get api/products/Brands
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands() 
            => await _productService.GetProductBrandsAsync();
            
        
        [HttpGet("Types")]
        public async Task<IReadOnlyList<ProductType>> GetProductTypes() 
            => await _productService.GetProductTypesAsync();
            
        

    }
}
