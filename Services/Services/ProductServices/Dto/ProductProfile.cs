using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.ProductServices.Dto
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResultDto>()
                .ForMember(pr => pr.ProductBrandName, options => options.MapFrom(p => p.ProductBrand.Name))
                .ForMember(pr => pr.ProductTypeName, options => options.MapFrom(p => p.ProductType.Name))
                .ForMember(dest=>dest.PictureUrl,options=>options.MapFrom<ProductUrlResolver>());

        }

    }
}
