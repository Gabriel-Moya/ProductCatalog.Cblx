using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductCatalog.Cblx.Application.AppService;
using ProductCatalog.Cblx.Application.AutoMapper;
using ProductCatalog.Cblx.Application.Request;
using ProductCatalog.Cblx.Application.Response;
using ProductCatalog.Cblx.Domain.Enums;
using ProductCatalog.Cblx.Test.FakeRepositories;

namespace ProductCatalog.Cblx.Test.Application.AppService;

[TestClass]
public class ProductAppServiceTests
{
    private readonly ProductAppService _productAppService = new ProductAppService(new FakeProductRepository(), new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperConfig()))));
    private readonly ProductRequest _validProductRequest = new ProductRequest("Nome do produto", "Descrição aqui", 123.20M, 3, EProductType.NotOrganic);
    private readonly UpdateProductRequest _validUpdateProductRequest = new UpdateProductRequest(Guid.NewGuid(), "Nome do produto", "Descrição aqui", 123.20M, 3, EProductType.NotOrganic);

    [TestMethod]
    public async Task CreateProduct_ShouldReturnProductResponse()
    {
        var productCreated = await _productAppService.Create(_validProductRequest);
        
        Assert.IsInstanceOfType(productCreated, typeof(ProductResponse));
    }

    [TestMethod]
    public async Task UpdateProduct_ShouldReturnProductResponse()
    {
        var productUpdated = await _productAppService.Update(_validUpdateProductRequest);

        Assert.IsInstanceOfType(productUpdated, typeof(ProductResponse));
    }

    [TestMethod]
    public async Task UpdateProduct_ShouldNotChangeTheId()
    {
        var productUpdated = await _productAppService.Update(_validUpdateProductRequest);

        Assert.AreEqual(_validUpdateProductRequest.Id, productUpdated.Id);
    }

    [TestMethod]
    public async Task GetById_ShouldReturnProduct()
    {
        var product = _productAppService.GetById(Guid.NewGuid());

        Assert.IsNotNull(product);
    }

    [TestMethod]
    [DataRow(1, 5)]
    [DataRow(1, 10)]
    [DataRow(1, 15)]
    public async Task GetAll_GivenSkipAndTakeShouldReturnTakeItems(int skip, int take)
    {
        var listProducts = await _productAppService.GetAll(skip, take);

        Assert.AreEqual(take, listProducts.Count);
    }
}
