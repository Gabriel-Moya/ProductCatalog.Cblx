using ProductCatalog.Cblx.Domain.Entities;
using ProductCatalog.Cblx.Domain.Enums;
using ProductCatalog.Cblx.Domain.Interfaces;

namespace ProductCatalog.Cblx.Test.FakeRepositories;

public class FakeProductRepository : IProductRepository
{
    public Task<Product> Create(Product product)
    {
        return Task.FromResult(product);
    }

    public Task Delete(Product product)
    {
        return Task.FromResult(0);
    }

    public Task<IList<Product>> GetAll(int skip, int take)
    {
        var products = new List<Product>()
        {
            new Product("Boné branco", "Boné branco aba reta", 39.90M, 2, EProductType.NotOrganic),
            new Product("Short cinza", "Short jeans feminino M", 99.90M, 3, EProductType.NotOrganic),
            new Product("Cenoura", "Cenoura desidratada granulada", 9.90M, 50, EProductType.Organic),
            new Product("Repolho roxo", "Repolho roxo picado", 7.60M, 60, EProductType.Organic),
            new Product("Bateria moura 12V", "Bateria de carro Moura 60Ah", 390M, 6, EProductType.NotOrganic),
            new Product("Calça jeans", "Calça jeans masculina", 89M, 3, EProductType.NotOrganic),
            new Product("Feijão carioca", "Feijão carioca pct - 1kg", 39.67M, 10, EProductType.Organic),
            new Product("Chinelo", "Chinelo tradicional havaianas", 20.80M, 2, EProductType.NotOrganic),
            new Product("Short cinza", "Short jeans feminino M", 99.90M, 3, EProductType.NotOrganic),
            new Product("Cenoura", "Cenoura desidratada granulada", 9.90M, 50, EProductType.Organic),
            new Product("Repolho roxo", "Repolho roxo picado", 7.60M, 60, EProductType.Organic),
            new Product("Bateria moura 12V", "Bateria de carro Moura 60Ah", 390M, 6, EProductType.NotOrganic),
            new Product("Calça jeans", "Calça jeans masculina", 89M, 3, EProductType.NotOrganic),
            new Product("Feijão carioca", "Feijão carioca pct - 1kg", 39.67M, 10, EProductType.Organic),
            new Product("Chinelo", "Chinelo tradicional havaianas", 20.80M, 2, EProductType.NotOrganic)
        };

        IList<Product> result = products.Skip((skip - 1) * take).Take(take).ToList();

        return Task.FromResult(result);
    }

    public Task<Product?> GetById(Guid id)
    {
        return Task.FromResult(new Product("Nome do produto", "Descrição aqui", 123.20M, 3, EProductType.NotOrganic));
    }

    public Task<Product> Update(Product product)
    {
        return Task.FromResult(product);
    }
}
