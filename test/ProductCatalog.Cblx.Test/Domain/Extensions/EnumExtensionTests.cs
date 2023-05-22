using System.ComponentModel.DataAnnotations;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ProductCatalog.Cblx.Domain.Extensions;

namespace ProductCatalog.Cblx.Test.Domain.Extensions;

public enum TesteEnum
{
    [Display(Name = "Nome do primeiro item")]
    Value1,

    [Display(Name = "Nome do segundo item")]
    Value2
}

[TestClass]
public class EnumExtensionTests
{
    [TestMethod]
    public void GetDisplayName_ShouldReturnCorrectFirstName()
    {
        var testValue = TesteEnum.Value1;
        var displayName = testValue.GetDisplayName();

        Assert.AreEqual("Nome do primeiro item", displayName);
    }

    [TestMethod]
    public void GetDisplayName_ShouldReturnCorrectSecondName()
    {
        var testValue = TesteEnum.Value2;
        var displayName = testValue.GetDisplayName();

        Assert.AreEqual("Nome do segundo item", displayName);
    }
}
