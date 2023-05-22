using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Cblx.Domain.Enums;

public enum EProductType
{
    [Display(Name = "Orgânico")]
    Organic,

    [Display(Name = "Não orgânico")]
    NotOrganic
}
