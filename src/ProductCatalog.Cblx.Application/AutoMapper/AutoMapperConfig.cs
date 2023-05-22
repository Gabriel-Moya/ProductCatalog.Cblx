using AutoMapper;

using ProductCatalog.Cblx.Application.Request;
using ProductCatalog.Cblx.Application.Response;
using ProductCatalog.Cblx.Domain.Entities;

namespace ProductCatalog.Cblx.Application.AutoMapper;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<ProductRequest, Product>();
        CreateMap<UpdateProductRequest, Product>();

        CreateMap<Product, ProductResponse>();

        CreateMap<ProductResponse, UpdateProductRequest>();
    }
}
