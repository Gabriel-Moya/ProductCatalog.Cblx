using ProductCatalog.Cblx.Domain.Entities;
using ProductCatalog.Cblx.Domain.Enums;
using ProductCatalog.Cblx.Infra.Data.Context;

namespace ProductCatalog.Cblx.Infra.Data.Seeders;

public static class Seeder
{
    public static void Seed(DataContext context)
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
            new Product("Chinelo", "Chinelo tradicional havaianas", 20.80M, 2, EProductType.NotOrganic)
        };

        context.AddRange(products);
        context.SaveChangesAsync();
    }
}