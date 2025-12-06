using Core.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Specifications;
using Services.Helper;
using Services.Services.ProductServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.ProductServices
{
    public interface IProductService
    {

        public Task<ProductResultDto> GetProductByIdAsync(int? id);

        public Task<Pagination<ProductResultDto>> GetAllProductsAsync(ProductSpecifications specs);
        public Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        public Task<IReadOnlyList<ProductType>> GetProductTypesAsync();

    }
}
