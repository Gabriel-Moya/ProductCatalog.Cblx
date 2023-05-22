using ProductCatalog.Cblx.Domain.Entities;

namespace ProductCatalog.Cblx.Domain.Interfaces;

public interface IProductRepository
{
    Task<Product> Create(Product product);
    Task<Product> Update(Product product);
    Task Delete(Product product);
    Task<Product?> GetById(Guid id);
    Task<IList<Product>> GetAll(int skip, int take);
}
