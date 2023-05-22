using ProductCatalog.Cblx.Application.Request;
using ProductCatalog.Cblx.Application.Response;

namespace ProductCatalog.Cblx.Application.AppService;

public interface IProductAppService
{
    Task<ProductResponse> Create(ProductRequest productRequest);
    Task<ProductResponse> Update(UpdateProductRequest updateProductRequest);
    Task Delete(Guid id);
    Task<ProductResponse> GetById(Guid id);
    Task<IList<ProductResponse>> GetAll(int skip, int take);
}
