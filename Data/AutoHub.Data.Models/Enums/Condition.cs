namespace AutoHub.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum CarCondition
    {
        [Display(Name = "Употребяван")]
        Used = 1,
        [Display(Name = "За части")]
        ForParts = 2,
        [Display(Name = "Нов")]
        BrandNew = 3,
    }
}
