using AutoMapper;
using Core.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Specifications;
using Services.Helper;
using Services.Services.ProductServices.Dto;

namespace Services.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IMapper _mapper { get; }

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        //get all products
        public async Task<Pagination<ProductResultDto>> GetAllProductsAsync(ProductSpecifications specs)
        {
            var specifications = new ProductsWithTypesAndBrandsSpecifications(specs);
            var products = await _unitOfWork.Repository<Product>().GetAllWithSpecificationAsync(specifications);
            var totalCount = await _unitOfWork.Repository<Product>().CountAsync(specifications);
            var mapped_Product=_mapper.Map<IReadOnlyList<ProductResultDto>>(products);
            
            return new Pagination<ProductResultDto>(specs.PageIndex,specs.PageSize,totalCount,mapped_Product);
        }
        //Get One product by id
        public async Task<ProductResultDto> GetProductByIdAsync(int? id)
        {
            var specs = new ProductsWithTypesAndBrandsSpecifications(id);
            var product = await _unitOfWork.Repository<Product>().GetEntityWithSpecificationAsync(specs);
            var mapped_product = _mapper.Map<ProductResultDto>(product);
            
            return mapped_product;
        }

        //Get all product brands
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        => await _unitOfWork.Repository<ProductBrand>().GetAllAsync();

        
        //Get all product types
        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
          => await _unitOfWork.Repository<ProductType>().GetAllAsync();

    }
}
