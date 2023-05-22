using AutoMapper;
using ProductCatalog.Cblx.Application.Request;
using ProductCatalog.Cblx.Application.Response;
using ProductCatalog.Cblx.Domain.Entities;
using ProductCatalog.Cblx.Domain.Interfaces;

namespace ProductCatalog.Cblx.Application.AppService;

public class ProductAppService : IProductAppService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductAppService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductResponse> Create(ProductRequest productRequest)
    {
        var product = _mapper.Map<Product>(productRequest);
        var productCreated = await _productRepository.Create(product);

        return _mapper.Map<ProductResponse>(productCreated);
    }

    public async Task<ProductResponse> Update(UpdateProductRequest updateProductRequest)
    {
        var product = _mapper.Map<Product>(updateProductRequest);
        var productUpdated = await _productRepository.Update(product);

        return _mapper.Map<ProductResponse>(productUpdated);
    }

    public async Task Delete(Guid id)
    {
        var product = await _productRepository.GetById(id);
        if (product is null)
            throw new Exception("Produto não encontrado!");
            // Se possível retornar BadRequest

        await _productRepository.Delete(product);
    }

    public async Task<ProductResponse> GetById(Guid id)
    {
        var product = await _productRepository.GetById(id);
        var productResponse = _mapper.Map<ProductResponse>(product);
        if (productResponse is null)
            throw new Exception("Produto não encontrado!");
            // Se possível retornar BadRequest

        return productResponse;
    }

    public async Task<IList<ProductResponse>> GetAll(int skip, int take)
    {
        var products = await _productRepository.GetAll(skip, take);

        if (products is null)
            throw new Exception("Nenhum produto cadastrado!");

        var productsResponse = _mapper.Map<List<ProductResponse>>(products);
        return productsResponse;
    }
}
