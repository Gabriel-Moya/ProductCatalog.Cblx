using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductCatalog.Cblx.Domain.Entities;
using ProductCatalog.Cblx.Domain.Enums;

namespace ProductCatalog.Cblx.Test.Domain.Entities;

[TestClass]
public class ProductTests
{
    [TestMethod]
    public void Constructor_ShouldReturnProductObject()
    {
        var validProduct = new Product("Nome do produto", "Descrição aqui", 123.20M, 3, EProductType.NotOrganic);
        Assert.IsInstanceOfType(validProduct, typeof(Product));
    }
}
