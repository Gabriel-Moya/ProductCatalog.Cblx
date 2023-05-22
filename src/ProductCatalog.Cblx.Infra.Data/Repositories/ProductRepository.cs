using Microsoft.EntityFrameworkCore;
using ProductCatalog.Cblx.Domain.Entities;
using ProductCatalog.Cblx.Domain.Interfaces;
using ProductCatalog.Cblx.Infra.Data.Context;

namespace ProductCatalog.Cblx.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Product> Create(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task Delete(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task<IList<Product>> GetAll(int skip, int take)
    {
        return await _context.Products
            .Skip((skip - 1) * take)
            .Take(take)
            .ToListAsync();
    }

    public async Task<Product?> GetById(Guid id)
    {
        return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Product> Update(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }
}
